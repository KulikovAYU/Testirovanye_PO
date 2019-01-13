using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingGraph
{
    public partial class Form1 : Form
    {

        algorit algo = new algorit();
        DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }


        private void Diskr_Load(object sender, EventArgs e)
        {

        }


        private void Reset_Click(object sender, EventArgs e)
        {

            SmezButton.Show();
            label1.Show();
            IntButton.Show();
            LinksButton.Show();
            TextBox.Hide();
            button1.Hide();
            label2.Hide();
            button2.Hide();
            button3.Hide();
            numericUpDown1.Hide();
            numericUpDown2.Hide();
            label3.Hide();
            setka.Hide();
        }

        private void SmezButton_Click(object sender, EventArgs e)
        {
            SmezButton.Hide();
            Reset.Show();
            label1.Hide();
            IntButton.Hide();
            LinksButton.Hide();
            TextBox.Hide();
            button1.Show();
            numericUpDown1.Show();
            label2.Show();

        }

        private void IntButton_Click(object sender, EventArgs e)
        {
            SmezButton.Hide();
            label1.Hide();
            IntButton.Hide();
            LinksButton.Hide();
            TextBox.Hide();
            button2.Show();
            numericUpDown1.Show();
            label2.Show();
            numericUpDown2.Show();
            label3.Show();
            Reset.Show();
        }

        private void LinksButton_Click(object sender, EventArgs e)
        {
            SmezButton.Hide();
            label1.Hide();
            IntButton.Hide();
            LinksButton.Hide();
            TextBox.Hide();
            button3.Show();
            numericUpDown1.Show();
            label2.Show();
            numericUpDown2.Show();
            label3.Show();
            Reset.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button4.Show();
            button5.Show();
            numericUpDown1.Hide();
            label2.Hide();
            setkaOK.Show();
            int n = Convert.ToInt32(numericUpDown1.Value);
            algo.create_mas(n,n,1);

            ds.Tables.Clear();
            ds.Tables.Add("matriza");
            for (int i = 0; i < n; i++)
            {
                ds.Tables[0].Columns.Add((i + 1).ToString());
            }
            for (int i = 0; i < n; i++)
            {
                ds.Tables[0].Rows.Add(algo.RetRow(algo.mas, i));
            }
            setka.DataSource = ds.Tables[0];

            //Matrix1.Show();
            //Matrix2.Show();
            //Matrix3.Show();
            setka.Show();
            //setkaOK.Show();
            //WayAlgo.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Hide();
            button2.Hide();
            numericUpDown2.Hide();
            label3.Hide();
            label2.Hide();
            setkaOK.Show();
            button4.Show();
            button5.Show();
            int n = Convert.ToInt32(numericUpDown1.Value);
            int n1 = Convert.ToInt32(numericUpDown2.Value);
            algo.create_mas(n,n1,2);

            ds.Tables.Clear();
            ds.Tables.Add("matriza");
            for (int i = 0; i < n1; i++)
            {
                ds.Tables[0].Columns.Add((i + 1).ToString());
            }
            for (int i = 0; i < n; i++)
            {
                ds.Tables[0].Rows.Add(algo.RetRow(algo.mas, i));
            }
            setka.DataSource = ds.Tables[0];

            //Matrix1.Show();
            //Matrix2.Show();
            //Matrix3.Show();
            setka.Show();
            //setkaOK.Show();
            //WayAlgo.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Hide();
            button2.Hide();
            numericUpDown2.Hide();
            label3.Hide();
            label2.Hide();
            setkaOK.Show();
            button3.Hide();
            button4.Show();
            button5.Show();
            int n = Convert.ToInt32(numericUpDown1.Value);
            int n1 = Convert.ToInt32(numericUpDown2.Value);
            algo.create_mas(n, n1, 3);

            ds.Tables.Clear();
            ds.Tables.Add("matriza");
            for (int i = 0; i < 2; i++)
            {
                ds.Tables[0].Columns.Add((i + 1).ToString());
            }
            for (int i = 0; i < n1; i++)
            {
                ds.Tables[0].Rows.Add(algo.RetRow(algo.mas, i));
            }
            setka.DataSource = ds.Tables[0];

            //Matrix1.Show();
            //Matrix2.Show();
            //Matrix3.Show();
            setka.Show();
            //setkaOK.Show();
            //WayAlgo.Show();
        }

        private void setkaOK_Click(object sender, EventArgs e)
        {


            Boolean flaggy = false;


            TextBox.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    int nnn;
                    var isNumeric = int.TryParse(Convert.ToString(ds.Tables[0].Rows[i][j]), out nnn);
                    if (isNumeric)
                    {
                        algo.mas[i, j] = Convert.ToInt32(ds.Tables[0].Rows[i][j]);

                        if (((algo.type == 3) && (algo.mas[i, j] > algo.len)) || ((algo.type == 3) && (algo.mas[i, j] < 1)) ||((algo.type == 1) && (algo.mas[i, j] > 1)) || ((algo.type == 1) && (algo.mas[i, j] < 0)) || ((algo.type == 2) && (algo.mas[i, j] > 1)) || ((algo.type == 2) && (algo.mas[i, j] < 0)))
                        {
                            MessageBox.Show("Ошиба Ввода");
                            flaggy = true;
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошиба Ввода");
                        flaggy = true;
                        break;
                    }
               
                    
                }
            if (!flaggy)
            {
                algo.DoLinks(TextBox);
                TextBox.Show();
                setka.Hide();
                Reset.Show();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Boolean flaggy = false;
            TextBox.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    int nnn;
                    var isNumeric = int.TryParse(Convert.ToString(ds.Tables[0].Rows[i][j]), out nnn);
                    if (isNumeric)
                    {
                        algo.mas[i, j] = Convert.ToInt32(ds.Tables[0].Rows[i][j]);

                        if (((algo.type == 3) && (algo.mas[i, j] > algo.len)) || ((algo.type == 3) && (algo.mas[i, j] < 1)) || ((algo.type == 1) && (algo.mas[i, j] > 1)) || ((algo.type == 1) && (algo.mas[i, j] < 0)) || ((algo.type == 2) && (algo.mas[i, j] > 1)) || ((algo.type == 2) && (algo.mas[i, j] < 0)))
                        {
                            MessageBox.Show("Ошиба Ввода");
                            flaggy = true;
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошиба Ввода");
                        flaggy = true;
                        break;
                    }
                }
            if (!flaggy)
            {
                algo.DoSmez(TextBox);
                TextBox.Show();
                setka.Hide();
                Reset.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Boolean flaggy = false; 
            TextBox.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    int nnn;
                    var isNumeric = int.TryParse(Convert.ToString(ds.Tables[0].Rows[i][j]), out nnn);
                    if (isNumeric)
                    {
                        algo.mas[i, j] = Convert.ToInt32(ds.Tables[0].Rows[i][j]);

                        if (((algo.type == 3) && (algo.mas[i, j] > algo.len)) || ((algo.type == 3) && (algo.mas[i, j] < 1)) || ((algo.type == 1) && (algo.mas[i, j] > 1)) || ((algo.type == 1) && (algo.mas[i, j] < 0)) || ((algo.type == 2) && (algo.mas[i, j] > 1)) || ((algo.type == 2) && (algo.mas[i, j] < 0)))
                        {
                            MessageBox.Show("Ошиба Ввода");
                            flaggy = true;
                            break;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ошиба Ввода");
                        flaggy = true;
                        break;
                    }
                }
            if (!flaggy)
            {
                algo.DoInt(TextBox);
                TextBox.Show();
                setka.Hide();
                Reset.Show();
            }
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
