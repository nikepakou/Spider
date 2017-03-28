using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WenKu
{
    class MSSQL
    {

        static string strConn = "";
        private RichTextBox AgentLog;
        private DateTime dt;
        public MSSQL()
        {
            this.AgentLog = baidu.logText;
            GetConnStr();
        }

        //获取连接字符串
        static public void GetConnStr()
        {
            strConn = "server=" + baidu.DataServerAdd + ";database=" + baidu.DataServerName+ ";user id=" + baidu.DatasName + ";password=" + baidu.DatasPass;
        }

        //测试服务器连接
        static public bool TestConn()
        {
            bool flag=true;
            /*
            GetConnStr();
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                flag = true;

                //  MessageBox.Show("连接数据库成功！", "提示");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("无法连接数据库：" + ex.Message, "提示");
                flag = false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }*/
            return flag;
        }
        public static bool IsExistDoc(DocInfo doc)
        {
            GetConnStr();
            Control.CheckForIllegalCrossThreadCalls = false;
            SqlConnection conn = new SqlConnection(strConn);
            bool isExist = true;
            try{
                conn.Open();
                SqlCommand cmd = new SqlCommand("procSelectInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DownAddress", SqlDbType.NVarChar).Value = doc.DownAddress;
                if (cmd.ExecuteScalar() == null)
                {
                    isExist = false;
                }
            }
            catch(Exception ex){
                isExist = false;
            }
            finally{
                conn.Close();
                conn.Dispose();
            }
            return isExist;
        }
        /// <summary>
        /// 写入文档记录
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>写入成功or失败</returns>
        public static bool AddExtractInfo(DocInfo doc)
        {
            GetConnStr();
            Control.CheckForIllegalCrossThreadCalls = false;
            SqlConnection conn = new SqlConnection(strConn);
            bool isok = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("procAddExtractInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClassID", SqlDbType.NVarChar).Value = doc.ClassID;
                cmd.Parameters.Add("@DocName", SqlDbType.NVarChar).Value = doc.DocName;
                cmd.Parameters.Add("@DocType", SqlDbType.NVarChar).Value = doc.DocType;
                cmd.Parameters.Add("@DownAddress", SqlDbType.NVarChar).Value = doc.DownAddress;
                cmd.Parameters.Add("@DocIntro", SqlDbType.Text).Value = doc.DocIntro;
                cmd.Parameters.Add("@DocKeyWord", SqlDbType.NVarChar).Value = doc.DocKeyWord;
                cmd.Parameters.Add("@DocSize", SqlDbType.BigInt).Value = doc.DocSize;
                cmd.Parameters.Add("@Money", SqlDbType.Int).Value = doc.Money;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    isok = true;
                }
               
            }
            catch (System.Exception)
            {
                //dt = DateTime.Now;
                //lock (AgentLog)
                //{
                //    AgentLog.AppendText(doc.DocName + "----导入数据库出错：" + ex.Message + "   " + string.Format("{0:G}", dt) + "\n");
                //}
                isok = false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return isok;
        }
        

        ///// <summary>
        ///// 向数据库添加分类信息
        ///// </summary>
        ///// <param name="classin">classin为分类对象</param>
        ///// <returns>1表示成功</returns>
        //public int AddClassInfo(ClassInfo classin)
        //{
        //    GetConnStr();
        //    Control.CheckForIllegalCrossThreadCalls = false;
        //    SqlConnection conn = new SqlConnection(strConn);
        //    int isok = 1;
        //    try
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("SP_AddClassInfo", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = classin.ClassName;
        //        cmd.Parameters.Add("@ClassID", SqlDbType.NVarChar).Value = classin.ClassID;
        //        cmd.Parameters.Add("@DocCount", SqlDbType.Int).Value = classin.DocCount;
        //        cmd.ExecuteNonQuery();
        //        isok = 1;
        //    }
        //    catch (System.Exception)
        //    {

        //        //lock (AgentLog)
        //        //{
        //        //    AgentLog.AppendText(classin.ClassName + "  分类----导入数据库出错：" + ex.Message + "   " + string.Format("{0:G}", DateTime.Now) + "\n");
        //        //}
        //        isok = 0;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //    return isok;

        //}



        public DataTable ReadData(string strsql)
        {
            GetConnStr();
            DataTable dtt = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
                conn.Open();
                da.Fill(dtt);
                dt = DateTime.Now;
                AgentLog.AppendText("分类信息读取完毕！   " + string.Format("{0:G}", dt) + "\n");
            }
            catch (System.Exception ex)
            {
                dt = DateTime.Now;
                AgentLog.AppendText("分类信息读取失败：" + ex.Message + "   " + string.Format("{0:G}", dt) + "\n");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return dtt;
        }



        public void UpdataClass(int count,string id)
        {
            GetConnStr();
            using(SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update SP_Classes Set DocCount=" + count + "where ClassID=" + id, conn);
                cmd.ExecuteNonQuery();
            }
        }
        ///// <summary>
        ///// 更新分类信息，每执行一次向数据库对应分类下添加addcount个已下载数量
        ///// </summary>
        ///// <param name="addcount">classID为分类ID，complete用于表示该分类下载是否完成（1表示完成）</param>
        ///// <param name="complete"></param>
        ///// <returns></returns>
        //public int Updateclass(string ClassID, int DocCount, int DownCount, int complete)
        //{
        //    GetConnStr();
        //    SqlConnection conn = new SqlConnection(strConn);
        //    try
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("SP_UpdateClass", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@ClassID", SqlDbType.NVarChar).Value = ClassID;
        //        cmd.Parameters.Add("@DocCount", SqlDbType.Int).Value = DocCount;
        //        cmd.Parameters.Add("@DownCount", SqlDbType.Int).Value = DownCount;
        //        cmd.Parameters.Add("@IsComplete", SqlDbType.Int).Value = complete;
        //        cmd.ExecuteNonQuery();
        //        //dt = DateTime.Now;
        //        //AgentLog.AppendText(classID + "分类----更新成功！   " + string.Format("{0:G}", dt) + "\n");
        //    }
        //    catch (System.Exception)
        //    {
        //        //dt = DateTime.Now;
        //        //AgentLog.AppendText(classID+"分类----更新出错：" + ex.Message + "   " + string.Format("{0:G}", dt) + "\n");
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //    return 1;
        //}
///// <summary>
        ///// 向数据库添加文档信息
        ///// </summary>
        ///// <param name="doc">doc为文档信息对象</param>
        ///// <returns>1表示成功</returns>
        //public int AddFileInfo(DocInfo doc)
        //{
        //    GetConnStr();
        //    Control.CheckForIllegalCrossThreadCalls = false;
        //    SqlConnection conn = new SqlConnection(strConn);
        //    int isok = 1;
        //    try
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("SP_AddDocInfo", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@ClassID", SqlDbType.NVarChar).Value = doc.ClassID;
        //        cmd.Parameters.Add("@DocName", SqlDbType.NVarChar).Value = doc.DocName;
        //        cmd.Parameters.Add("@DocType", SqlDbType.NVarChar).Value = doc.DocType;
        //        cmd.Parameters.Add("@DocSize", SqlDbType.BigInt).Value = doc.DocSize;
        //        cmd.Parameters.Add("@MD5", SqlDbType.NVarChar).Value = doc.MD5;
        //        cmd.Parameters.Add("@DownAddress", SqlDbType.NVarChar).Value = doc.DownAddress;
        //        cmd.Parameters.Add("@StoreAddress", SqlDbType.NVarChar).Value = doc.StoreAddress;
        //        cmd.ExecuteNonQuery();
        //        //dt = DateTime.Now;
        //        //lock (AgentLog)
        //        //{
        //        //    AgentLog.AppendText(doc.DocName + "----导入数据库成功！   " + string.Format("{0:G}", dt) + "\n");
        //        //}
        //        isok = 1;
        //    }
        //    catch (System.Exception)
        //    {
        //        //dt = DateTime.Now;
        //        //lock (AgentLog)
        //        //{
        //        //    AgentLog.AppendText(doc.DocName + "----导入数据库出错：" + ex.Message + "   " + string.Format("{0:G}", dt) + "\n");
        //        //}
        //        isok = 0;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //    return isok;
        //}
        ///// <summary>
        ///// 向数据库添加下载失败文件信息
        ///// </summary>
        ///// <returns></returns>
        //public int AddDownFail(DocInfo doc)
        //{

        //    GetConnStr();
        //    Control.CheckForIllegalCrossThreadCalls = false;
        //    SqlConnection conn = new SqlConnection(strConn);
        //    int isok = 1;
        //    try
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("SP_AddDownFail", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@ClassID", SqlDbType.NVarChar).Value = doc.ClassID;
        //        cmd.Parameters.Add("@DocName", SqlDbType.NVarChar).Value = doc.DocName;
        //        cmd.Parameters.Add("@DocType", SqlDbType.NVarChar).Value = doc.DocType;
        //        cmd.Parameters.Add("@DocSize", SqlDbType.BigInt).Value = doc.DocSize;
        //        cmd.Parameters.Add("@MD5", SqlDbType.NVarChar).Value = doc.MD5;
        //        cmd.Parameters.Add("@DownAddress", SqlDbType.NVarChar).Value = doc.DownAddress;
        //        cmd.Parameters.Add("@StoreAddress", SqlDbType.NVarChar).Value = doc.StoreAddress;
        //        cmd.ExecuteNonQuery();
        //        isok = 1;
        //    }
        //    catch (System.Exception)
        //    {
        //        isok = 0;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //    return isok;
        //}
    }
}
