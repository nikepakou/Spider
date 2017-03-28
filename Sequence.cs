using System;                                                           //类名 Sequence，函数名 SaveAsXmlFormat(WKInfo wk)
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace WenKu
{
    /// <summary>
    /// 序列化写入读取
    /// </summary>
    class Sequence
    {
        public static string filename = "WordParam.xml";
        static public void SaveAsXmlFormat(WKInfo wk)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(WKInfo));

            using (Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, wk);
            }
        }
        static public WKInfo LoadFromXmlFormat()
        {
            WKInfo wk;
            XmlSerializer xmlFormat = new XmlSerializer(typeof(WKInfo));
            using(Stream fStream =File.OpenRead(filename))
            {
                wk= (WKInfo)xmlFormat.Deserialize(fStream);
            }
            return wk;
        }
    }
}
