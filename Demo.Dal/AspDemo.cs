using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;

namespace Demo.Dal
{
    public class AspDemo
    {
        public bool InsertTest(Test test)
        {
            string sql = string.Format("insert into Test values ('{0}','{1}','{2}')",test.No,test.Name,test.Type);

            return Datahelper.ExecuteNonQuery(sql) > 0 ? true:false;
        }

        public IList<Test> SelectTest()
        {
            string sql = "select * from Test";

            IList<Test> list = new List<Test>();

            MySqlDataReader sdr = Datahelper.ExecuteReader(sql);

            if (sdr != null&&sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Test t = new Test();

                    t.No = Convert.ToInt32(sdr["No"]);
                    t.Name = sdr["Name"].ToString();
                    t.Type = Convert.ToInt32(sdr["Type"]);

                    list.Add(t);
                }
                sdr.Close();
            }
            return list;
        }

        public bool UpdateTest(Test test)
        {
            if (test.No != 0)
            {
                string sql = string.Format("update Test set Name = '{0}' ,Type = '{1}'  where No = '{2}'",test.Name,test.Type,test.No);
                return Datahelper.ExecuteNonQuery(sql)>0 ? true : false;
            }
            return false;
        }

        public bool DeleteTest(Test test)
        {
            if (test.No != 0)
            {
                string sql = string.Format("delete  from Test where No = '{0}'", test.No);
                return Datahelper.ExecuteNonQuery(sql) > 0 ? true : false;
            }
            return false;
        }
    }
}
