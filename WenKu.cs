using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Threading;
using System.IO;
using System.Collections;
using System.Data.SqlClient;

namespace WenKu
{
    public partial class baidu : Form                                                 
    {
        //连接主数据库所用参数
        public static string DataServerAdd;
        public static string DataServerName;
        public static string DatasName;
        public static string DatasPass;

        //连接关键词数据库所用参数
        public static string KeyWordAdd;

        public bool connectBtned = false;   //数据库连接是否已测试
        public bool keyconnected = false;
        public bool IsFirst = true;         //是否是首次开始
        public bool IsStart = true;         //是否已开始

        //线程
        Thread Thread_Crawl; //抓取线程
        Thread Thread_Time;//时间监控线程

        public static int filecount = 0;        //已抓取总数
        public static int keywordcount = 0;     //检索词数
        public static string Word = "";     //当前检索词


       // public static int LWMaxID = 0;        //词库中当前长度词的最大ID
        public static int taxis = 0;

        public static WKInfo wk = new WKInfo();                                                          //(引用) FileInfo.cs-(40,18):public class WKInfo

        public static WebInfo wi = new WebInfo();                                                        //(引用) FileInfo.cs-(50,18):public class WKInfo
        public static RichTextBox logText;

        public static Hashtable HT = new Hashtable();

        public baidu()
        {
            InitializeComponent();
            logText = LogBox;
            //cmBLWord.SelectedIndex = 0;
            cmBOrder.SelectedIndex = 0;
            //cmBTgther.SelectedIndex = 0;
            cmBInterval.SelectedIndex = 0;
        }

        private void BeginBtn_Click(object sender, EventArgs e)
        {
            if (!connectBtned)
            {
                MessageBox.Show("请先测试数据库！");
                return;
            }
            if (!keyconnected)
            {
                MessageBox.Show("请导入参数！");
                return;
            }
            if (IsFirst)
            {
                IsFirst = false;
                beginBtn.Enabled = false;
                KeyConnect.Enabled = false;
                Thread_Time = new Thread(new ThreadStart(MonitorTime));
                Thread_Time.Name = "Thread_Time";
                Thread_Time.IsBackground = true;
                Thread_Time.Start();//启动时间监控线程
                Thread_Crawl = new Thread(new ThreadStart(Spider.Extract));
                Thread_Crawl.Name = "Thread_Crawl";
                Thread_Crawl.IsBackground = true;
                Thread_Crawl.Start();//启动抓取线程

            }
            else{
                Thread_Crawl.Resume();
                beginBtn.Enabled = false;
                suspendBtn.Enabled = true;                                               //suspendBtn为“暂停抓去”键
                IsStart = true;                                                         
            }
        }
        private void MonitorTime()
        {
            CheckForIllegalCrossThreadCalls = false;
            int hour = 0;//小时
            int min = 0;//分钟
            int sec = 0;//秒
            //MSSQL ms = new MSSQL();
            while (true)
            {
                LtimeGo.Text = "已运行时间：" + hour.ToString() + "小时 " + min.ToString() + "分钟 " + sec.ToString() + "秒";
                LfileADD.Text = "已解析出链接：" + filecount + "条";
                CurrKWord.Text = "当前检索词：" + Word;
                NKWord.Text = "已检索词数：" + keywordcount ;

                Thread.Sleep(999);
                sec += 1;
                if (sec >= 60)
                {
                    sec -= 60;
                    min += 1;
                }
                if (min >= 60)
                {
                    min -= 60;
                    hour += 1;
                }
                //if (sec == 30)//(min % 10 == 0) && (sec % 10 == 0)&&(min!=0))   //每10分钟写一次日志
                //{
                //    WriteLog wl = new WriteLog();
                //    lock (logText)
                //    {
                //     //   ms.Updateclass(sosoForm.classfo.ClassID, filecount, 0, 1);
                //        wl.WriteLogFile(logText.Text.ToString(), 0, MapPath.Text.ToString().Trim());
                //    }
                if ((min % 10 == 0) && (sec % 30 == 0)&&(min!=0)&&(sec!=0))   //每60分钟清理一次
                {
                    WriteLog wl=new WriteLog();
                    lock(logText){
                        wl.WriteLogFile(logText.Text,0,Directory.GetCurrentDirectory());
                        logText.Clear();
                    }
                }
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            DataServerAdd = serverAdd.Text.ToString().Trim();
            DataServerName = serverName.Text.ToString().Trim();
            DatasName = sName.Text.ToString().Trim();
            DatasPass = sPassword.Text.ToString().Trim();
            if (MSSQL.TestConn())
            {
                connectBtn.Enabled = false;
                connectBtned = true;
                logText.AppendText("元数据数据库连接成功！\n");
            }
            else 
            {
                MessageBox.Show("元数据数据库连接失败！");
                return;
            } 
            if (Access.Connect())
            {
                logText.AppendText("词表数据库连接成功！\n");
            }
            else
            {
                connectBtn.Enabled = true;
                connectBtned = false;
                MessageBox.Show("词表数据库连接失败！");
                return;
            }
            wi.webName = websiteName.Text.ToString().Trim();
            wi.webUrl = WebSiteAdd.Text.ToString().Trim();
            wi.webImport = wi.webUrl + WebOInfo.Text.Trim();
        }

        private void suspendBtn_Click(object sender, EventArgs e)
        {
            IsStart = false;
            suspendBtn.Enabled = false;
            beginBtn.Enabled = true;
            Thread_Crawl.Suspend();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            Thread_Crawl.Abort();
            Thread_Time.Abort();
            IsFirst = true;
            beginBtn.Enabled = true;
            connectBtn.Enabled = true;
        }

        private void KeyConnect_Click(object sender, EventArgs e)
        {                
            Access ac=new Access();
            if (File.Exists(Sequence.filename))
            {
                wk = Sequence.LoadFromXmlFormat();
                logText.AppendText("上次运行参数导入完毕!");

              //  LWMaxID = wk.WordID+ac.GetWCount(wk.KLWord)-1;
            }
            else{

                //wk.KLWord = Convert.ToInt32(cmBLWord.SelectedItem.ToString());
               // wk.Tgther = Convert.ToInt32(cmBTgther.SelectedItem.ToString());
                wk.order = cmBOrder.SelectedIndex;
                //wk.WordID = ac.GetFirstID(wk.KLWord);
               // LWMaxID =wk.WordID+ ac.GetWCount(wk.KLWord)-1;
                //wk.WordID_2 = wk.WordID + 1;
                wk.waitime = Convert.ToInt32(cmBInterval.Text.Trim());
            }
            MSSQL ms=new MSSQL();
            DataTable da = ms.ReadData("select Param,ClassID from SP_WenKu");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                HT.Add(da.Rows[i][0], da.Rows[i][1]);
            }
            KeyConnect.Enabled = false;
            logText.AppendText("参数构建完毕！"); 
            keyconnected = true;
        }
        private void btnStat_Click(object sender, EventArgs e)
        {
            if (!connectBtned)
            {
                MessageBox.Show("请先测试数据库！");
                return;
            }
            string strsql = "select distinct ClassID from SP_DocInfo";
            MSSQL ms = new MSSQL();
            DataTable ds = ms.ReadData(strsql);
            ds.Columns.Add("DocCount",typeof(int));
            int i = 0;
            while (i < ds.Rows.Count)
            {
                string id =ds.Rows[i][0].ToString();
                strsql = "select count(*) from SP_DocInfo where ClassID=" + id;
                DataTable da = ms.ReadData(strsql);
                int count = Convert.ToInt32(da.Rows[0][0]);
                ms.UpdataClass(count, id);
                i++;
            }
        }

    }
}
