using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace law
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = dataBaseUtil.getConnection();
            if ("".Equals(textBox1.Text.Trim())||"".Equals(textBox2.Text.Trim()))
            {
                MessageBox.Show("用户名或密码不能为空！");
                conn.Close();
            }
            else
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select user_id from user where user_num='" + textBox1.Text.Trim()+"' and user_password='" + textBox2.Text.Trim()+"'", conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader dr= cmd.ExecuteReader();
                if (dr.Read()&& !"".Equals(dr.GetValue(0).ToString()))       /*dr.GetValue()获取查出来的值*/
                {
                    this.Hide();
                    main m = new main();
                    m.Show();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("用户名不存在或密码错误！");
                    conn.Close();
                }
            }


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            register r = new register();
            r.Show();
        }
    }
}
