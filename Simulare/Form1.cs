using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulare
{
    public partial class Form1 : Form
    {
        Button[] b = new Button[9];
        int[] v = new int[9];
        int i, j;
        Random r = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            for (i = 1; i <= 7; i++)
            {
                v[i] = r.Next(50) + 10;
                b[i] = new Button();
                b[i].Width = 35;
                b[i].Height = 4 * v[i];
                b[i].Left = i * 50;
                b[i].Top = 10;
                b[i].Text = v[i].ToString();
                b[i].ForeColor = Color.White;
                b[i].BackColor = Color.Gray;
                this.Controls.Add(b[i]);
            }
            b[8] = new Button();
            b[8].Width = 1;
            b[8].Height = 1;
            b[8].Visible = false;
            this.Controls.Add(b[8]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(v[i]>v[j])
            {
                int aux = v[i];
                v[i] = v[j];
                v[j] = aux;
                b[i].Text = v[i].ToString();
                b[j].Text = v[j].ToString();
                b[i].Height = 4 * v[i];
                b[j].Height = 4 * v[j];
            }
            j++;
            b[j].BackColor = Color.DarkRed;
            b[j-1].BackColor = Color.Gray;
            if (j > 7)
            {
                i++;
                b[i].BackColor = Color.DarkRed;
                b[i-1].BackColor = Color.Gray;
                j = i + 1;
                b[j].BackColor = Color.DarkRed;
                if (i >= 7) { b[i].BackColor = Color.Gray; timer1.Stop(); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 1;
            b[i].BackColor = Color.DarkRed;
            j = 2;
            b[j].BackColor = Color.DarkRed;
            timer1.Start();
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
