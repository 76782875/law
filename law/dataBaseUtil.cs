using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace law
{
    class dataBaseUtil
    {
        static MySqlConnection conn;
        static MySqlCommand cmd;
        public static MySqlConnection getConnection()
        {
            conn = new MySqlConnection("Database = law; Data Source = localhost; User Id = root; Password = cooler;charset=utf8");
            if (conn != null)
            {
                return conn;
            }
            else
            {
                MessageBox.Show("数据库连接失败,请重新连接");
                return null;
            }
                
        }

        public static MySqlCommand getCommand()
        {
            cmd = conn.CreateCommand();
            if (conn != null)
            {
                return cmd;
            }
            else
            {
                MessageBox.Show("获取命令失败,请重新尝试");
                return null;
            }
        }
    }
}
