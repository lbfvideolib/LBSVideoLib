using LBSVideoLib.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LBSVideoLib.Admin
{
    public partial class frmAdminLogin : Form
    {
       
        public frmAdminLogin()
        {
            InitializeComponent();
        }

     
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
         // Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          
            bool authenticated = LBSVideoLib.Common.Authentication.AuthenticateAdmin(txtEmailId.Text.Trim(), txtPwd.Text.Trim());

            if (authenticated)
            {
                frmRegistration frm = new frmRegistration();
                // frm.MdiParent = this.MdiParent;
                frm.ParentFormControl = this;
                frm.Show();
                this.Hide();
            }
            else
            {
                lblStatus.Text = "Invalid Email Id or Password!!";
            }
        }

        private void frmAdminLogin_Load(object sender, EventArgs e)
        {
            lblSessionYears.Text = string.Format(lblSessionYears.Text, ConfigHelper.SessionYears);
        }
    }
}
