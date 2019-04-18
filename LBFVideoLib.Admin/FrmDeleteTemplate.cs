using LBFVideoLib.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LBFVideoLib.Admin
{
    public partial class FrmDeleteTemplate : Form
    {
        #region Local Members

        List<Template> _templateList = new List<Template>();
        private string _sourceTemplateFolderPath = "";

        #endregion Local Members



        public FrmDeleteTemplate()
        {
            InitializeComponent();
        }

        private void FrmDeleteTemplate_Load(object sender, EventArgs e)
        {
            lblVersionNo.Text = CommonHelper.GetVersionNo();
            InitDeleteTemplateForm();
        }

        #region Events

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Visible = true;
                progressBar1.Value = 10;

                int deleteCount = 0;
                DialogResult result = MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    for (int i = 0; i < _templateList.Count; i++)
                    {
                        if (_templateList[i].Selected == true)
                        {
                            Directory.Delete(_templateList[i].TemplateId, true);
                            deleteCount += 1;
                        }
                    }
                }

                progressBar1.Value = 100;
                if (deleteCount > 0)
                {
                    MessageBox.Show(deleteCount + "  Template(s) deleted successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillTemplateList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex);
            }
            finally
            {
                progressBar1.Visible = false;
                progressBar1.Value = 0;
            }
        }

        private void chkListTemplate_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                Template selectedTemplate = (chkListTemplate.Items[e.Index] as Template);
                if (e.NewValue == CheckState.Checked)
                {
                    selectedTemplate.Selected = true;
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    selectedTemplate.Selected = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex);
            }
        }

        private void chkListTemplate_ItemCheck(object sender, EventArgs e)
        {
            try
            {
                bool b = true;
                if (chkSelectAllBooks.CheckState == CheckState.Checked)
                {
                    b = true;
                }
                else if (chkSelectAllBooks.CheckState == CheckState.Unchecked)
                {
                    b = false;
                }

                for (int i = 0; i < chkListTemplate.Items.Count; i++)
                {
                    chkListTemplate.SetItemChecked(i, b);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex);
            }

        }

        #endregion Events

        #region Private Methods

        private void InitDeleteTemplateForm()
        {
            try
            {
                progressBar1.Visible = false;
                _sourceTemplateFolderPath = ConfigHelper.GetTemplateFolderPath;
                FillTemplateList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex);
            }
        }

        private void FillTemplateList()
        {
            try
            {
                _templateList.Clear();

                // Read all folders to fill classes
                string[] templateNameList = Directory.GetDirectories(_sourceTemplateFolderPath);

                for (int i = 0; i < templateNameList.Length; i++)
                {
                    Template template = new Template();
                    template.TemplateId = templateNameList[i];
                    template.TemplateName = Path.GetFileName(templateNameList[i]);
                    _templateList.Add(template);
                }

                chkListTemplate.DataSource = null;

                // Fill list box with class list.
                ((ListBox)this.chkListTemplate).DataSource = _templateList;
                ((ListBox)this.chkListTemplate).DisplayMember = "TemplateName";
                ((ListBox)this.chkListTemplate).ValueMember = "Selected";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex);
            }
        }

        #endregion Private Methods

    }
}
