using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;


namespace Barcode
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-S9B711P\\SQLEXPRESS;Initial Catalog=npb;User ID=sa;Password=sa@1234");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string batch = textBox1.Text;

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if((bool)item.Cells[0].Value == true)
                {
                    string prod = item.Cells[2].Value.ToString();
                    string mrp = item.Cells[1].Value.ToString();
                    string str = item.Cells[2].Value.ToString();

                    Bitmap bitmap = new Bitmap(str.Length * 50, 150);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        Font ofont = new System.Drawing.Font("3 of 9 Barcode", 40);
                        Font ifont = new System.Drawing.Font("Arial", 10);
                        Font iifont = new System.Drawing.Font("Arial", 10);
                        PointF oiopoint = new PointF(50f, 2f);
                        PointF oipoint = new PointF(50f, 23f);
                        PointF point = new PointF(25f, 48f);
                        PointF ipoint = new PointF(100f, 100f);


                        SolidBrush black = new SolidBrush(Color.Black);
                        SolidBrush white = new SolidBrush(Color.White);
                        graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                        graphics.DrawString(prod, iifont, black, oiopoint);
                        graphics.DrawString(str, ofont, black, point);
                        graphics.DrawString(batch, ifont, black, ipoint);
                        graphics.DrawString("mrp-" + mrp, ifont, black, oipoint);

                    }
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, ImageFormat.Png);
                        pictureBox1.Image = bitmap;
                        pictureBox1.Height = bitmap.Height;
                        pictureBox1.Width = bitmap.Width;
                    }
                }
            }
                      
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((bool)dataGridView1.SelectedRows[0].Cells[0].Value == false)
            {
                dataGridView1.SelectedRows[0].Cells[0].Value = true;
            }
            else
            {
                dataGridView1.SelectedRows[0].Cells[0].Value = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "JPEG(*.JPEG)|*.jpg" })
            {
                if (pictureBox1 == null)
                    return;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFileDialog.FileName);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Shop_ID")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select Shop_ID,Shop_Name, Route_ID,City_ID from tbl_ShopMaster WHERE Shop_ID LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[1].Value = item["Shop_ID"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["Shop_Name"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item["Route_ID"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item["City_ID"].ToString();
                }
            }

            if (comboBox1.Text == "Shop_Name")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select Shop_ID,Shop_Name, Route_ID,City_ID from tbl_ShopMaster WHERE Shop_Name LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[1].Value = item["Shop_ID"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["Shop_Name"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item["Route_ID"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item["City_ID"].ToString();
                }
            }

            if (comboBox1.Text == "Route_ID")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select Shop_ID,Shop_Name, Route_ID,City_ID from tbl_ShopMaster WHERE Route_ID LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[1].Value = item["Shop_ID"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["Shop_Name"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item["Route_ID"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item["City_ID"].ToString();
                }
            }

            if (comboBox1.Text == "City_ID")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select Shop_ID,Shop_Name, Route_ID,City_ID from tbl_ShopMaster WHERE City_ID LIKE '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[1].Value = item["Shop_ID"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["Shop_Name"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item["Route_ID"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item["City_ID"].ToString();
                }
            }


        }
    }
}
