using System;
using System.Net;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;

namespace WenKu
{
    class Spider
    {
        /// <summary>
        /// 类外对象调用此函数
        /// </summary>
        /// <param name="解析"></param>
        static public void Extract()  //提取函数
        {
            while (true)  
            {                
                Sequence.SaveAsXmlFormat(baidu.wk);      //Sequence.cs-(12,11) class Sequence
                string wd = FitTgther.WTgther();
                if (wd == "")
                {
                    break;
                }
                baidu.Word = wd;
                int classcount =baidu.filecount;
                for (int i=1;i<=5;i++)
                {
                    int pn = 0;
                    string website = baidu.wi.webImport;
                    while (!ListExtract.IsLast&&pn<100)              //由pn<100可知没有深度挖掘网页中的文档信息
                    {
                        int listCount = baidu.filecount;
                        string www = HttpUtility.UrlEncode(wd, Encoding.GetEncoding("gb2312"));
                        string url = website + www + "&lm="+i+"&od="+baidu.wk.order+"&pn=" + pn * 10;            //lm为文档格式，有doc,txt,pdf等。od为相关下载，最多下载，最新上传。pn为页数，每页十个文档链接。
                        ListExtract.Extract(url);
                        lock (baidu.logText)
                        {
                            baidu.logText.AppendText(url + "解析完毕!\n"+"共解析"+(baidu.filecount-listCount).ToString()+"条有效文档\n");
                        }
                        pn++;
                    }
                    ListExtract.IsLast = false; //检索完一个词的所有结果后，把末页标志初始化回原值
                    Thread.Sleep(baidu.wk.waitime*60000);
                } 
                lock (baidu.logText)
                {
                    baidu.logText.AppendText("词（" + wd  + "）检索完成！共解析" +(baidu.filecount- classcount).ToString() + "条" + string.Format("{0:G}",DateTime.Now) + "\n");
                }    
                baidu.keywordcount++;           
              

            }
            MessageBox.Show("当前设置已解析完毕！");
        }
    }
}