using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WenKu
{
    /// <summary>
    /// 控制词的组合
    /// </summary>
    class FitTgther
    {
        public static string WTgther()
        {
            string Word = "";
            Word = Access.GetKWord();
            return Word;
        }
        /// <summary>
        /// 双词组合
        /// </summary>
        /// <returns></returns>
        /// 组合功能去了
       //  private static void WTwoTgther(ref string[] Word)
        //{

          //  string FWord = Access.GetKWord(baidu.wk.WordID);
            //string LWord = Access.GetKWord(baidu.wk.WordID_2); 
            //if (FWord != "" && LWord != "")
            //{
              //  Word[0] = FWord + LWord;
                //Word[1] = FWord+" " + FWord;
            //}
            //else{
              //  baidu.logText.AppendText("双词组合出错！请查看！");
                //MessageBox.Show("Error!双词组合出错");
                //return;
          //  }
            /*if (baidu.wk.WordID_2 == baidu.LWMaxID)
            {
                baidu.wk.WordID += 1;
                baidu.wk.WordID_2 = baidu.wk.WordID + 1;
            }
            else{
                baidu.wk.WordID_2 += 1;
            }*/
        //}
        ///// <summary>
        ///// 三词组合
        ///// </summary>
        ///// <returns></returns>
        //private static void WThreeTgther(ref string[] Word)
        //{

        //}
    }
}
