using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           

        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 1)
            {
                e.Handled = true;
            }
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        int z = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 20;

            double pr = Convert.ToInt32(textBox1.Text);
            double sk = Convert.ToInt32(textBox2.Text);
            double proc = Convert.ToInt32(textBox3.Text);
            double dol = Convert.ToInt32(textBox4.Text);
            double krat = Convert.ToInt32(textBox5.Text);
            double god = Convert.ToInt32(textBox6.Text);


            double stSK = pr / sk;
            double zk = dol + krat;
            double stZK = proc / zk;
            double vesSK = sk / (sk + zk);
            double vesZK = zk / (zk + sk);
            double P = 0.8;
            double WACC = stSK * vesSK + P * vesZK * stZK;
            double EVA = pr - WACC * (sk + dol);
            EVA = Math.Round(EVA, 2);



            this.dataGridView1.Rows[0 + z].Cells[0].Value = god;
            this.dataGridView1.Rows[0 + z].Cells[1].Value = EVA;
            z = z + 1;


            chart1.Series[0].Points.AddXY(god, EVA);
            chart1.Series[1].Points.AddXY(god,-5);
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 3;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter myWritet = new StreamWriter(myStream);
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                myWritet.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + " ");
                            }
                            myWritet.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message); 
                    }
                    finally
                    {
                        myWritet.Close();
                    }
                }
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}



