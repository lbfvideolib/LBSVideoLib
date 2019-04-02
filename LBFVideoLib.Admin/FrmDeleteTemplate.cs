using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LBFVideoLib.Admin
{
    public partial class FrmDeleteTemplate : Form
    {
        public FrmDeleteTemplate()
        {
            InitializeComponent();
        }

        private void FrmDeleteTemplate_Load(object sender, EventArgs e)
        {
            progressBar1.Hide();
        }
    }
}
