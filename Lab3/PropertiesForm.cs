using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class PropertiesForm : Form
    {
        Form1 F;

        public PropertiesForm(Form1 F1)
        {

            F = F1;
            InitializeComponent();
            label1.Text = F.GetRadius().ToString();
            label2.Text = F.GetPointColor();
            label3.Text = F.GetPenWidth();
            label4.Text = F.GetPenColor();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            F.ChangeRadius();
            label1.Text = F.GetRadius().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F.ChangePointColor();
            label2.Text = F.GetPointColor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            F.ChangeLineWidth();
            label3.Text = F.GetPenWidth();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            F.ChangeLineColor();
            label4.Text = F.GetPenColor();
        }
    }
}
