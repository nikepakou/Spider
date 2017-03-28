using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace WenKu
{
    class DownloadFile
    {

        public string StrUrl;//文件下载网址
        public string StrFileName;//下载文件保存地址 
        public long lStartPos = 0; //返回上次下载字节
        public long lCurrentPos = 0;//返回当前下载字节
//        public long lDownloadFile;//返回当前下载文件长度
//        public string strlog = "";
        DateTime dt;
        MSSQL ms = new MSSQL();
//        Queue QD = new Queue();

        public RichTextBox AgentLog;

        public DocInfo doc;

        public DownloadFile()
        {
            AgentLog = baidu.logText;
        }

        //public DownloadFile(RichTextBox AgentLog)
        //{
        //    this.AgentLog = AgentLog;
        //}

        public void DownloadDoc()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            System.IO.FileStream fs;
            
            StrUrl = doc.DownAddress;
            StrFileName = doc.StoreAddress + "\\" + doc.DocName + ".doc";
            bool IsFailed = true;
#region 

            try
            {
                if (System.IO.File.Exists(StrFileName))
                {

                    StrFileName = doc.StoreAddress + "\\" + doc.DocName + "(" + DateTime.Now.ToString("yyyyMMddhhmmss") + ").doc";
                    fs = System.IO.File.OpenWrite(StrFileName);
                    lStartPos = 0;//fs.Length;
                    fs.Seek(lStartPos, System.IO.SeekOrigin.Current);
                    //移动文件流中的当前指针 

                }
                else
                {
                    fs = new System.IO.FileStream(StrFileName, System.IO.FileMode.Create);
                    lStartPos = 0;
                }

            }
            catch (System.Exception ex)
            {
                lock (AgentLog)
                {
                    AgentLog.AppendText(StrFileName + "-------下载出错：" + ex.Message + "     " + string.Format("{0:G}", DateTime.Now) + "\n");

                }
                //MessageBox.Show(StrFileName + "-------下载出错：" + ex.Message);
                return;
            }
            #endregion
#region
            //打开网络连接 
            try
            {
 

                dt = DateTime.Now;
                lock (AgentLog)
                {
                    AgentLog.AppendText(StrFileName + "-------开始下载！   " + string.Format("{0:G}", dt) + "\n");
                }

                //测试
                //WriteLog log = new WriteLog();
                //log.WriteLogFile(Thread.CurrentThread.Name,0);

                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(StrUrl);
                request.Method = "GET";
                request.ContentType = "application/msword";
                long length = request.GetResponse().ContentLength;
                //lDownloadFile = length;
                if (lStartPos > 0)
                    request.AddRange((int)lStartPos); //设置Range值

                //向服务器请求，获得服务器回应数据流 
                System.IO.Stream ns = request.GetResponse().GetResponseStream();

                byte[] nbytes = new byte[512];
                int nReadSize = 0;
                nReadSize = ns.Read(nbytes, 0, 512);
                while (nReadSize > 0)
                {
                    fs.Write(nbytes, 0, nReadSize);
                    nReadSize = ns.Read(nbytes, 0, 512);
                    lCurrentPos = fs.Length;
                }
                ns.Close();
                request.GetResponse().Close();
                dt = DateTime.Now;
                lock (AgentLog)
                {
                    AgentLog.AppendText(StrFileName + "-------下载完成！    " + string.Format("{0:G}", dt) + "\n");
                }
                baidu.downloadercount++;


            }
            catch (Exception ex)
            {
                lock (AgentLog)
                {
                    AgentLog.AppendText(StrFileName + "-------下载出错：" + ex.Message + "     " + string.Format("{0:G}", DateTime.Now) + "\n");
                }
                IsFailed=false;
                baidu.downfailcount++;
                
                
            }
            finally
            {

                fs.Close();
                //写入数据库
                doc.StoreAddress = StrFileName;
                doc.MD5 = md5_hash(StrFileName);
                doc.DocSize = lCurrentPos;
                doc.DocType = "doc";
                doc.StoreAddress = StrFileName;
                //doc.DocType = doc.DownAddress.Substring(doc.DownAddress.Length - 3, 3);

                    if (AddData(IsFailed)==1)
                    {
                        lock (AgentLog)
                        {
                            AgentLog.AppendText(StrFileName + "-------下载信息导入完成！    " + string.Format("{0:G}", DateTime.Now) + "\n");
                        }
                    }
                    else
                    {
                        lock (AgentLog)
                        {
                            AgentLog.AppendText(StrFileName + "-------下载信息导入失败！    " + string.Format("{0:G}", DateTime.Now) + "\n");
                        }
                    }
              }
            #endregion
        }

        protected int AddData(bool IsFail)
        {
            int i=1;
           
            if (!IsFail)
                i=ms.AddDownFail(doc);
            else
                i=ms.AddFileInfo(doc);
            return i;
        }

        /// <summary>
        /// 实现对一个文件md5的读取，path为文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string md5_hash(string path)
        {
            try
            {
                FileStream get_file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                System.Security.Cryptography.MD5CryptoServiceProvider get_md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash_byte = get_md5.ComputeHash(get_file);
                string resule = System.BitConverter.ToString(hash_byte);
                resule = resule.Replace("-", "");
                return resule;
            }
            catch (Exception e)
            {

                return e.ToString();

            }
        }
    }
}

