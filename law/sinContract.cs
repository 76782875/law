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
    public partial class sinContract : Form
    {
        MySqlConnection conn = dataBaseUtil.getConnection();
        MySqlDataAdapter mda = null;
        DataSet ds = null;

        public sinContract()
        {
            InitializeComponent();
        }

  

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            main m = new main();
            m.Show();
        }

        private void sinContract_Load(object sender, EventArgs e)
        {
            conn.Open();
            dataGridView1.DataSource = null;
            mda = new MySqlDataAdapter("select * from contract", conn);
            ds=new DataSet();
            mda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //创建命令重建对象
            MySqlCommandBuilder scb = new MySqlCommandBuilder(mda);

            //更新数据
            try
            {
                mda.Update(ds);
                MessageBox.Show("修改成功!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
