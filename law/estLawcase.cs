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
    public partial class estLawcase : Form
    {
        public estLawcase()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            main m = new main();
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = dataBaseUtil.getConnection();
            MySqlCommand cmd = dataBaseUtil.getCommand();
            cmd.CommandType = CommandType.Text;
            int r = 0;
            if (!"".Equals(textBox1.Text.Trim())|| !"".Equals(textBox2.Text.Trim()) || !"".Equals(textBox3.Text.Trim()) || !"".Equals(textBox4.Text.Trim()) || !"".Equals(textBox5.Text.Trim()) ||!"".Equals(textBox6.Text.Trim()) || !"".Equals(textBox7.Text.Trim()) || !"".Equals(textBox8.Text.Trim()) || !"".Equals(textBox9.Text.Trim()) || !"".Equals(textBox10.Text.Trim()))
            {
                cmd.CommandText = "insert into lawcase (case_id,case_clientName,case_clinetTel,case_lawer,case_lawerNum,case_note,case_num,case_occurProc,case_occurScene,case_occurTime,case_partyAddr,case_partyName,case_partyNum,case_partyTel,case_type) values ('" + new Random().Next(10000) + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + richTextBox2.Text.Trim() + "'," + textBox1.Text.Trim() + ",'" + richTextBox1.Text.Trim() + "','" + textBox10.Text.Trim() + "','" + dateTimePicker1.Value + "','" + textBox9.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + comboBox1.Text.Trim() + "')";
                conn.Open();
                r = cmd.ExecuteNonQuery();

                if (r <= 0)
                {
                    MessageBox.Show("新增失败!");
                    cmd.Dispose();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("恭喜您,新增成功!");
                    this.Hide();
                    main m = new main();
                    m.Show();
                    cmd.Dispose();
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("输入不能为空");
            }
        }
    }
}
