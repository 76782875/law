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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            login l = new login();
            l.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = dataBaseUtil.getConnection();
            MySqlCommand cmd = dataBaseUtil.getCommand();
            cmd.CommandType = CommandType.Text;
            int r = 0;
            if (!"".Equals(textBox1.Text.Trim()) || !"".Equals(textBox2.Text.Trim()) || !"".Equals(textBox3.Text.Trim()) || !"".Equals(textBox4.Text.Trim()))
            {
                if (textBox1.Text.Trim().Length == 6 && textBox2.Text.Trim().Length>7 && textBox2.Text.Trim().Length<13)
                {
                    if (textBox2.Text.Trim().Equals(textBox3.Text.Trim()))
                    {
                        if (textBox4.Text.Trim().Length == 11 && (textBox4.Text.Trim().Substring(0, 2).Equals("13") || textBox4.Text.Trim().Substring(0, 2).Equals("15") || textBox4.Text.Trim().Substring(0, 2).Equals("18")))
                        {
                            if (radioButton1.Checked)
                                cmd.CommandText = "insert into user (user_id,user_num,user_password,user_sex,user_tel) values ('" + new Random().Next(10000) + "','" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + radioButton1.Text.Trim() + "','" + textBox4.Text.Trim() + "')";
                            else
                                cmd.CommandText = "insert into user (user_id,user_num,user_password,user_sex,user_tel) values ('" + new Random().Next(10000) + "','" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + radioButton2.Text.Trim() + "','" + textBox4.Text.Trim() + "')";

                            conn.Open();
                            r = cmd.ExecuteNonQuery();

                            if (r <= 0)
                            {
                                MessageBox.Show("注册失败!");
                                cmd.Dispose();
                                conn.Close();
                            }
                            else
                            {
                                MessageBox.Show("恭喜您,注册成功!");
                                this.Hide();
                                login m = new login();
                                m.Show();
                                cmd.Dispose();
                                conn.Close();
                            }
                        }
                        else MessageBox.Show("手机号不合法!");
                    }
                    else MessageBox.Show("密码输入不一致！");
                }
                else MessageBox.Show("账号必须为6位,密码为8到12位!");
            }
            else MessageBox.Show("输入不能为空,请重新输入!");
        }
    }
}
