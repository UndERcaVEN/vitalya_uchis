using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                if (name == "") 
                {
                    throw new ArgumentNullException();
                }
                double height = Convert.ToDouble(textBox2.Text);
                errLabel.Visible = false;

                listBox1.Items.Add($"{name},\t {height}");
            }
            catch
            {
                errLabel.Visible = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar >= '0' && e.KeyChar <= '9') return;
            if (e.KeyChar == '.') e.KeyChar = ',';
            if (e.KeyChar == ',')
            {
                if (textBox2.Text.IndexOf(',') != -1 || textBox2.Text.Length == 0)
                    e.Handled = true;
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter) button1.Focus();
                else return;
            }
            e.Handled = true;*/
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            double maxH=0,s = 0;
            string field;
            string[] fields;
            int hs=0;
            
            for (int i = 0; i < listBox1.Items.Count; ++i)
            {
                field = Convert.ToString(listBox1.Items[i]);

                fields=field.Split(',');
                s += Convert.ToDouble(fields[1]);
                hs += Convert.ToInt32(fields[1]) + Convert.ToInt32(fields[2]);

                if (Convert.ToDouble(fields[1]) > maxH)
                {
                    maxH = Convert.ToDouble(fields[1]);
                }
            }
            s /= listBox1.Items.Count;
            avHLabel.Text = Convert.ToString(hs);
            maxHLabel.Text = Convert.ToString(maxH);

            if(maxH>0)
            {
                maxHLabel.Visible = true;
            }
            if(s>0)
            {
                avHLabel.Visible = true;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void readButton_Click(object sender, EventArgs e)
        {

        }

        private void writeButton_Click(object sender, EventArgs e)
        {

            StreamWriter streamwriter = new StreamWriter("list.txt", false);

            for (int i = 0; i < listBox1.Items.Count; ++i)
            {
                streamwriter.WriteLine(listBox1.Items[i].ToString());
            }
            streamwriter.Flush();
            streamwriter.Close();

        }
    }
}
