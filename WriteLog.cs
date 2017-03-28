using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WenKu
{
    class WriteLog
    {
        public void WriteLogFile(string strlog, int flag, string strpath)
        {

            string input = strlog;
            System.DateTime currentTime = DateTime.Now;
            string filename = currentTime.ToString().Replace('/','-') + ".txt";
            if (flag == 1)
            {
                filename = "分类完成日志（" + currentTime.ToString() + "）.txt";
            }
            //指定日志文件的目录 
            strpath = strpath + "\\log";
            if (!Directory.Exists(strpath))
            {
                Directory.CreateDirectory(strpath);
            }

            filename = filename.Replace(':', '-');
            
            string fname = strpath + "\\" + filename;
            //定义文件信息对象 
            // input = strlog + "  启动了";
            input = input.Replace("\n", "\r\n");

            //创建写文件流 
            using (FileStream fs = new FileStream(fname,FileMode.Create,FileAccess.Write))
            {
                //根据上面创建的文件流创建写数据流 
                StreamWriter w = new StreamWriter(fs);
                try
                {

                    //设置写数据流的起始位置为文件流的末尾 
                    w.BaseStream.Seek(0, SeekOrigin.End);
                    //写入“Log   Entry   :   ” 
                    w.Write("------------------------------------\r\n ");
                    w.Write("Log   Entry   :   ");
                    //写入当前系统时间并换行 
                    w.Write("{0}   {1}   \r\n ", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                    //写入日志内容并换行 
                    w.Write(input + "\r\n ");
                    //写入------------------------------------“并换行 
                    w.Write("------------------------------------\r\n ");
                }
                catch (System.Exception)
                {

                }
                finally
                {
                    //清空缓冲区内容，并把缓冲区内容写入基础流 
                    w.Flush();
                    //关闭写数据流 
                    w.Close();
                }


            }
        }
    }
}
