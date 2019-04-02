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
    public partial class FrmSchoolRegistrationUsingTemplate : Form
    {
        public FrmSchoolRegistrationUsingTemplate()
        {
            InitializeComponent();
        }

        private void cmdCreateTemplate_Click(object sender, EventArgs e)
        {
            FrmNewTemplate frmTemplate = new FrmNewTemplate();
            frmTemplate.Show();
        }

        private void cmdCustomRegistration_Click(object sender, EventArgs e)
        {
            frmSchoolRegistration frmReg = new frmSchoolRegistration();
            frmReg.Show();
        }

        private void FrmSchoolRegistrationUsingTemplate_Load(object sender, EventArgs e)
        {
            progressBar1.Hide();
        }

        private void cmdDeleteTemplate_Click(object sender, EventArgs e)
        {
            FrmDeleteTemplate frmDeleteTemplate = new FrmDeleteTemplate();
            frmDeleteTemplate.Show();
        }
    }
}
