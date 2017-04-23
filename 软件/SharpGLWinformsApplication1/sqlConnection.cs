using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
namespace SharpGLWinformsApplication1
{
    class history_series_from{
        public static int history_series_fo = 0;
    }

    class xmlConnection
    {
        public static string str = "../Debug/userInfo.xml";
    }
    class GuanLiYuan
    {
        public static bool ma = false;
    }
    class CanShuBianhuaZhi
    {
        public static Double[] Cal = new Double[20];
        public static Double[] x = new Double[20];
    }
    class XMLConnectionr
    {
        public static string str = "400";
    }
    class sqlConnection
    {
        //public string str =
        //@"Data Source = DESKTOP-4FA6J2C\SQLEXPRESS;Initial Catalog = PlatformFlawBase; Integrated Security = True";
        public string str = @"server=DESKTOP-4FA6J2C\SQLEXPRESS;database=PlatformFlawBase;Integrated Security=SSPI;";
        public string getconn()
        {
            string ConnectionString = str;
            return ConnectionString;
        }

        public string[] Read_SQL_Data(string tableName)
        {
            string[] readdata=null;
            try
            {
                DataSet ds = new DataSet();
                sqlConnection sc = new sqlConnection();

                SqlConnection conn = new SqlConnection(sc.str);
                conn.Open();
                string sql = "SELECT * FROM  "+tableName;
                // 创建数据适配器
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
                da.Fill(ds);
                int i = 0;
                readdata = new string[ds.Tables[0].Columns.Count];
                for (i = 0; i < ds.Tables[0].Columns.Count;i++)
                    readdata[i] = ds.Tables[0].Rows[0][i].ToString().Trim();
                
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("--:"+e);
            }
            return readdata;
        }
        public void Save_SQL_Data(string[] SaveData,string tableName)
        {
            try
            {

                string sql = "insert into  "+tableName+"  values('";
                for (int i = 0; i < SaveData.Length; i++)
                {
                    sql += SaveData[i].Trim() + "'";
                    if (i != SaveData.Length-1)
                    {
                        sql += ",'";
                    }
                    else
                    {
                        sql += ")";
                    }
                }

                sqlConnection sc = new sqlConnection();

                SqlConnection conn = new SqlConnection(sc.str);
                SqlCommand cmd = new SqlCommand("delete from " + tableName, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("--:" + e);
            }
        }
    }
    class JudgeInputText
    {
        
        public bool judge(string input)
        {
            if (input.Trim().Length == 0)
            {
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(input.Trim(), pattern);   //匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    return false;
                }
            }
            return true;
        }
      }
}
