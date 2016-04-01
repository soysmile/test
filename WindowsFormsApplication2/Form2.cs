using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form 
    {
        public Form2()
        {
            InitializeComponent();
        }

        //Connection string
        MySqlConnection mcon = new MySqlConnection("datasource=localhost;port=3306;username=root;password=0000");
        DataSet ds = new DataSet();

        //обновить
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                mcon.Close();
                MySqlDataAdapter mda = new MySqlDataAdapter("select * from borabora.drinks ", mcon);
                mcon.Open();
                DataTable dt = new DataTable();
                mda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["name"].ToString());
                    listitem.SubItems.Add(dr["name"].ToString());
                    listView1.Items.Add(listitem);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Добавить
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                mcon.Close();
                string reciept = "";
                reciept = listView1.SelectedItems.ToString();
                //reciept  содержит название коктейля
                reciept = listView1.SelectedItems[0].Text;
                MySqlDataAdapter mda = new MySqlDataAdapter("select * from borabora.drinks", mcon);
                mcon.Open();
                DataTable dt = new DataTable();
                mda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["ingridients"].ToString());
                    listitem.SubItems.Add(dr["ingridients"].ToString());
                    listView2.Items.Add(listitem);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


