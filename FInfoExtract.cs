using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace WenKu
{
    class FInfoExtract
    {
        /// <summary>
        /// 局部页面解析
        /// 提取出页面信息
        /// </summary>
        /// <param name="ExtractLinks"></param>
        /// <returns></returns>
        static public bool ExtractInfo(DocInfo fi)
        {
            bool Flag = false;
            string urls = baidu.wi.webUrl + "view/" + fi.DownAddress + ".html";
            string html = GetWebHtml(urls);
            if (string.IsNullOrEmpty(html))
                return Flag;

            //fi.DocIntro = ExtractIntro(html);
            fi.DocKeyWord = ExtractKWord(html);
           
            /////////////////////////////////////////
            string DOC_INFO = Seprate(html);
            if (!string.IsNullOrEmpty(DOC_INFO))
            {
                fi.DocName = ExtractFileName(DOC_INFO);
                if (!string.IsNullOrEmpty(fi.DocName))
                {
                    fi.param = ExtractParam(DOC_INFO);
                    if (baidu.HT.ContainsKey(fi.param))
                    {
                        fi.ClassID = (string)baidu.HT[fi.param];
                        
                        fi.Money = ExtractMoney(DOC_INFO);
                        fi.DocType = ExtractType(DOC_INFO);
                       // fi.DocSize = ExtractLength(DOC_INFO);
                        if (MSSQL.AddExtractInfo(fi))
                        {
                            baidu.filecount++;
                            Flag = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("警告：标识为"+fi.DownAddress+"的文档类别参数" + fi.param + "无法查询到！请马上查看补充！   "+ string.Format("{0:G}",DateTime.Now));
                    }
                }
            }
            return Flag;
        }
        //////////////////////////////////////////////////////////////
        /// <summary>
        /// 获取指定地址页面
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        static private string GetWebHtml(string url)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            HttpWebRequest request=null;
            HttpWebResponse myResponse=null;
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
            finally{
                if (myResponse != null)
                {
                    myResponse.Close();
                    myResponse=null;
                }
                if (mySR != null)
                   mySR.Close();

                if (request != null)
                    request = null;
 
            }
            return string.Empty;
        }
        /// <summary>
        /// 提取文档简介
        /// </summary>
        /// <param name="html"></param>
        /// <returns>简介</returns>
        //static private string ExtractIntro(string html)
        //{
        //    string strref = "";
        //    Regex re = new Regex("<span.id=\"summary\">.*?</span>", RegexOptions.Compiled | RegexOptions.Singleline);
        //    Match ma = re.Match(html);
        //    if (ma.Value!=null)
        //    {
        //        strref = Regex.Replace(ma.Value, "<((?>[^>]+))>", "");
        //    }
        //    return strref.Trim();
        //}
        /// <summary>
        /// 文档关键词
        /// </summary>
        /// <param name="html"></param>
        /// <returns>关键词</returns>
        static private string ExtractKWord(string html)
        {
            string strref = "";
            string strKey = "";
            Regex re = new Regex("<p.class=\"tag[^>]*>.*?</p>", RegexOptions.Compiled | RegexOptions.Singleline);
            Match ma = re.Match(html);
            if (ma.Value != null)
            {
                MatchCollection mb = new Regex("<a.*?>.*?</a>").Matches(ma.Value);
                foreach (Match mm in mb)
                {
                    strref = mm.Value.Replace("</a>", ";");
                    strref = Regex.Replace(strref, "<((?>[^>]+))>", "");
                    strref.Trim();
                    strKey = strKey + strref;
                }
            }
            return strKey.TrimEnd(';');
        }
        /// <summary>
        /// 提取文件大小
        /// </summary>
        /// <param name="html"></param>
        /// <returns>文件大小</returns>
        //static private long ExtractLength(string html)
        //{
        //    string strRef = "doc_size:\".*?\""; Match match = new Regex(strRef, RegexOptions.Compiled|RegexOptions.Singleline).Match(html);
        //    strRef = match.Value.Replace("doc_size:\"", "");
        //    String sizeS =strRef.Replace("\"","").Trim();
        //    long size = -1;
        //    if (sizeS.EndsWith("KB"))
        //    {
        //        sizeS = sizeS.Replace("KB", "");
        //        size = (long)(Double.Parse(sizeS) * 1024);
        //    }
        //    else if (sizeS.EndsWith("MB"))
        //    {
        //        sizeS = sizeS.Replace("MB", "");
        //        size = (long)(Double.Parse(sizeS) * 1024 * 1024);
        //    }
        //    return size;
        //}

        /// <summary>
        /// 提取文件类型
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        static private string ExtractType(string html)
        {
            string strRef = "doc_type:\"[a-z]+?\"";
            Match match = new Regex(strRef, RegexOptions.Compiled|RegexOptions.Singleline).Match(html);
            strRef = match.Value.Replace("doc_type:\"", "");
            strRef = strRef.Replace("\"", "");
            return strRef;
        }
        /// <summary>
        /// 提取出三级页面中文档财富值
        /// </summary>
        /// <param name="html"></param>
        /// <returns>财富值</returns>
        static private int ExtractMoney(string html)
        {
            int money = 0;
            string strRef = "price:\".*?\"";
            Match match = new Regex(strRef, RegexOptions.Compiled).Match(html);
            strRef = match.Value.Replace("price:\"", "");
            strRef = strRef.Replace("\"", "");
            try
            {
                money = Convert.ToInt32(strRef);
            }
            catch
            {
                money=0;
            }
            return money;
        }
        /// <summary>
        /// 提取出文件名
        /// </summary>
        /// <param name="ExtractFileName"></param>
        /// <returns>文件名</returns>
        static private string ExtractFileName(string html)
        {
            string strRef = "doc_name:\'.*?\'";
            Match match = new Regex(strRef, RegexOptions.Compiled|RegexOptions.Singleline).Match(html);
            strRef = match.Value.Replace("doc_name:\'", "");
            strRef = Regex.Replace(strRef, "[.。！？#@#￥$%&*=<>，‘、’；|：`/\"\\?!:']", "");
            return strRef.Trim();
        }
        /// <summary>
        /// 提取文档所属类号
        /// </summary>
        /// <param name="html"></param>
        /// <returns>类号</returns>
        static private string ExtractParam(string html)
        {
            string strRef = "cid:\".*?\"";
            Match match = new Regex(strRef, RegexOptions.Compiled | RegexOptions.Singleline).Match(html);
            strRef = match.Value.Replace("cid:\"", "");
            strRef = strRef.Replace("\"", "");
            return strRef.Trim();
        }
        /// <summary>
        /// 分离包含文件信息的字符块
        /// </summary>
        /// <param name="html"></param>
        /// <returns>DOC_INFO</returns>
        static private string Seprate(string html)
        {
            Regex re = new Regex("DOC_INFO={.*?}", RegexOptions.Compiled|RegexOptions.Singleline);
            Match ma = re.Match(html);
            return ma.Value;
        }
    }
}
