using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WenKu
{
    class Access
    {
        public static string strConn= @"Provider=Microsoft.Jet.OLEDB.4.0 ;Data Source=Word.mdb";


        static public bool Connect()
        {
            bool flag = false;
            OleDbConnection conn = new OleDbConnection(strConn);
            try
            {
                conn.Open();
                flag = true;
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
            }
            return flag;
        }
        public static string GetKWord()
        {
            string KWord="";
            int ID = 0;
            string queryString = "select top 1 * from Word where ClassID_3 =''";
            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbCommand command = new OleDbCommand(queryString, conn);
            try
            { 
                conn.Open();
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    KWord = reader["KeyWord"].ToString();
                    ID = int.Parse(reader["ID"].ToString());
                    Access.Update(ID);
                }
                else
                    MessageBox.Show("当前词库解析完毕!");
                reader.Close();
                reader.Dispose();
            }
            catch (System.Exception ex)
            {
            }
            finally{
                conn.Close();
                conn.Dispose();
            }
            return KWord;
        }

        public static void Update(int id)
        {
            string strSQL = "update Word set ClassID_3='1'where ID="+id;
            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbCommand command = new OleDbCommand(strSQL, conn);
            try
            {
                conn.Open();
                command.CommandText = strSQL;
                command.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /*public int GetWCount(int klength)
        {
            int KeyCount = 0;
            string queryString = "select count(*) from Word where Length="+klength;
            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            try
            {
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    KeyCount = (int)reader[0];
                }
                reader.Close();
                reader.Dispose();
            }
            catch (System.Exception ex)
            {
            	
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return KeyCount;
        }*/
        /*public int GetFirstID(int klength)
        {
            int id = 0;
            string queryString = "select top 1 id from Word where Length=" + klength+" order by id asc";
            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            try
            {
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = (int)reader[0];
                }
                reader.Close();
                reader.Dispose();
            }
            catch (System.Exception ex)
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return id;
        }*/
    }
}
