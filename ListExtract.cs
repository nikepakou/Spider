using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.IO.Compression;

namespace WenKu
{
    static class ListExtract
    {
        public static bool IsLast=false;
        static public void Extract(string url)
        {
            string html = GetWebHtml(url);
            if (!string.IsNullOrEmpty(html))
            {
                IsLastPage(html);
                ExtractPage(html);
            }
        }
        /// <summary>
        /// 获取指定地址页面
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        static private string GetWebHtml(string url)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            HttpWebRequest request = null;
            HttpWebResponse myResponse = null;
            StreamReader mySR = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
                //request.Method = "GET";
                request.Timeout = 50000;
                request.AllowAutoRedirect = false;
                request.ContentType = "application/x-www-form-urlencoded";
                request.CookieContainer = new CookieContainer();
                myResponse = (HttpWebResponse)request.GetResponse();
                Encoding enCoder = Encoding.GetEncoding("gb2312");
                if (myResponse.StatusCode == HttpStatusCode.OK && myResponse.ContentLength < 1024 * 1024)
                {
                    if (myResponse.ContentEncoding != null && myResponse.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
                        mySR = new StreamReader(new GZipStream(myResponse.GetResponseStream(), CompressionMode.Decompress), enCoder);
                    else
                        mySR = new StreamReader(myResponse.GetResponseStream(), enCoder);
                    string html = mySR.ReadToEnd();

                    return html;
                }

            }
            catch (Exception ex)
            {
                baidu.logText.AppendText("\n\n" + "访问" + url + "出错____" + ex.ToString() + "\n\n");
            }
            finally
            {
                if (myResponse != null)
                {
                    myResponse.Close();
                    myResponse = null;
                }
                if (mySR != null)
                    mySR.Close();

                if (request != null)
                    request = null;

            }
            return string.Empty;
        }
        /// <summary>
        /// 结果列表页面解析
        /// 解析出结果记录
        /// </summary>
        /// <param name="ExtractPage"></param>
        static private void ExtractPage(string html)
        {

            try
            {
                string strRef = "/view/.*?.html";
                MatchCollection matches = new Regex(strRef, RegexOptions.Compiled).Matches(html);
                foreach (Match match in matches)
                {
                    try
                    {
                        string href = match.Value.Replace("/view/","");
                        href = href.Replace(".html", "");
                        DocInfo fi = new DocInfo();
                        fi.DownAddress = href;
                        if (!string.IsNullOrEmpty(fi.DownAddress)&&!MSSQL.IsExistDoc(fi))
                        {
                            FInfoExtract.ExtractInfo(fi);
                        }
                    }
                    catch (Exception)
                    {
                    }

                }
            }
            catch (Exception)
            {
            }

        }
        /// <summary>
        /// 判断获取的页面是否有下一页
        /// </summary>
        /// <param name="html"></param>
        static private void IsLastPage(string html)
        {
            string regex = "<div.class=\"mt.f14.page\">.*?</div>";
            MatchCollection matches = new Regex(regex, RegexOptions.Singleline).Matches(html);
            if (matches.Count == 0)
            {
                IsLast = true;
            }
            else
            {
                foreach (Match match in matches)
                {
                    if (match.Value.IndexOf("下一页") == -1)
                        IsLast = true;
                }
            }
        }
    }
}
