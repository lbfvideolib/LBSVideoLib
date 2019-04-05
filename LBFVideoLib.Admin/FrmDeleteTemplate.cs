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
        List<Template> _templateList = new List<Template>();
        private string _sourceTemplateFolderPath = "";

        public FrmDeleteTemplate()
        {
            InitializeComponent();
        }

        private void FrmDeleteTemplate_Load(object sender, EventArgs e)
        {

            InitDeleteTemplateForm();

        }

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
                ExceptionHandler.HandleException(ex, "", false);
            }
        }

        private void FillTemplateList()
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

            chkListClass.DataSource = null;

            // Fill list box with class list.
            ((ListBox)this.chkListClass).DataSource = _templateList;
            ((ListBox)this.chkListClass).DisplayMember = "TemplateName";
            ((ListBox)this.chkListClass).ValueMember = "Selected";
        }

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
                ExceptionHandler.HandleException(ex, "", false);
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
                Template selectedTemplate = (chkListClass.Items[e.Index] as Template);
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
    }
}
