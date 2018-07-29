using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Demo.Dal
{
  
    public class Datahelper
    {
        //连接字符串
        private static string connstr = "server = localhost; user id = root; password = root123; database = test";

        /*
           1.构建数据库连接
           2.构建数据库执行对象
           3.执行sql
           4.获得结果 关闭连接
         */

        public static int ExecuteNonQuery(string sql)
        {

            int result = 0;
            MySqlConnection conn = new MySqlConnection(connstr);

            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand(sql, conn);
                result = comm.ExecuteNonQuery();
            }
            catch(Exception ec)
            {
                conn.Close();
            }


            return result;

        }

        public static MySqlDataReader ExecuteReader(string sql)
        {
            MySqlConnection conn = new MySqlConnection(connstr);

            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand(sql, conn);

                return comm.ExecuteReader();
            }
            catch (Exception ec)
            {
                conn.Close();
                return null;
            }

        }
    }
}
