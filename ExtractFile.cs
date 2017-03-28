using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;

namespace soso
{
    class ExtractFile
    {
        //RichTextBox rt;
        //private ContainUrl cu = null;
        //private ContainUrl EU = null;
//        string[] strTypes = { "doc" };
//        public int Filecounts = 0;
        string Surl = "";
        public ExtractFile()
        {
            //this.cu = cu;
            //this.EU = EU;
            //this.rt = sosoForm.logText;
        }
        public void BeginExtract(DocInfo fi)
        {
           // Control.CheckForIllegalCrossThreadCalls = false;
                while (sosoForm.UR.Count >= sosoForm.MaxQue)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                    //DocInfo fi = (DocInfo)cu.DeQueue();
                    string html = GetWebHtml(fi.DownAddress);
                    if (html != null)
                    {
                        if(fi.DocName.StartsWith("word文档下载"))
                        {
                            int i=fi.DownAddress.LastIndexOf('/');
                            Surl=fi.DownAddress.Remove(i+1);
                            }
                        else
                            Surl =sosoForm.wi.webUrl;
                        fi.DownAddress = ExtractUrl(html);
                        if (!string.IsNullOrEmpty(fi.DownAddress))
                        {
                            sosoForm.UR.Enqueue(fi);
                            sosoForm.filecount++;
                        }
                    }
                
           
        }
        /// <summary>
        /// 获取指定地址页面
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetWebHtml(string url)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            string html = null;
            Stream myStream;
            StreamReader mySR;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
                request.Method = "GET";
                request.Referer = "";
                request.ContentType = "application/x-www-form-urlencoded";
                request.CookieContainer = new CookieContainer();
                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                myStream = myResponse.GetResponseStream();
                Encoding enCoder = Encoding.GetEncoding("gb2312");
                mySR = new StreamReader(myStream, enCoder);
                html = mySR.ReadToEnd();
            }
            catch
            {
                
            }
            return html;
        }
        private string ExtractUrl(string html)
        {
            string url = "";
            try
            {
                string re = @"(?i:http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?\.doc";
                try
                {
                    Match mathes = new Regex(re).Match(html);
                    url = mathes.Value;
                }
                catch (Exception)
                {
                }
                if (string.IsNullOrEmpty(url))
                {
                    re = @"("+'"'+@"[\w- ./?%&=]*)\.doc";
                    try
                    {
                        Match mathes = new Regex(re).Match(html);
                        
                        
                        url = Surl + mathes.Value.TrimStart('/','"');
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            { }
            return url;
            
        }
    }
}
