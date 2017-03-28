using System;
using System.Collections.Generic;
using System.IO;

namespace WenKu
{
    /// <summary>
    /// 文件信息类
    /// </summary>
    public class DocInfo
    {
        public string DocName="";     //文件名
        public string ClassID="";      //文档所属分类编号
        public string DownAddress="";      //文件下载来源链接
        public string StoreAddress="";  //文件存储位置
        public long DocSize=0;     //文件大小
        public string MD5="";      //文件MD5标识
        public string DocType="";     //文件格式
        public string DocIntro = "";//文档简介
        public string DocKeyWord = "";//文档关键字
        public int Money = 0;   //文档财富值
        public string param="";
    }
    public class ClassInfo
    {
        public string ClassID;       //文档分类ID
        public string ClassName;     //文档分类名
        public int DocCount;         //文档数
    }
    public class WK
    {
        public string ClassName = ""; //分类名
        public string ClassID = "";  //分类编号
        public string param = "";
    }
    /// <summary>
    ///定义序列化类
    /// </summary>
    [Serializable]
    public class WKInfo
    {
        //public int KLWord = 1;
        public int Tgther = 1;
        public int order = 2;
        public int WordID = 1;
        public int WordID_2 = 2;
        //public int WordID_3 = 3;
        public int waitime = 0;
    }
    public class WebInfo
    {
        public string webName = ""; //网站名
        public string webType = ""; //网站抓取类型
        public string webUrl = "";  //网站域名
        public string webImport = ""; //抓取入口

    }
}
