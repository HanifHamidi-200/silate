using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fCompany2 _dlg = new fCompany2();
            _dlg.ShowDialog();

        }

        private void btnCompany1_Click(object sender, EventArgs e)
        {
            fCompany1 _dlg = new fCompany1();
            _dlg.ShowDialog();
        }

        private void btnCompany3_Click(object sender, EventArgs e)
        {
            fCompany3 _dlg = new fCompany3();
            _dlg.ShowDialog();

        }

        private void btnCompany4_Click(object sender, EventArgs e)
        {
            fCompany4 _dlg = new fCompany4();
            _dlg.ShowDialog();

        }
    }
}
