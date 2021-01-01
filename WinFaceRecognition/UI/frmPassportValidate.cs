using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFaceRecognition.ClassLogic;

namespace WinFaceRecognition.UI
{
    public partial class frmPassportValidate : Form
    {
        public frmPassportValidate()
        {
            InitializeComponent();
        }
        OpenFileDialog fl = new OpenFileDialog() { Filter = ImageModifier.GetImageFilter() };

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (fl.ShowDialog() == DialogResult.OK)
                {
                    string filename = fl.FileName;

                    Bitmap bmp = new Bitmap(filename);

                    pxMain.Image = bmp;
                    pxMain.Height = bmp.Height;
                    pxMain.Width = bmp.Width;
                    pxMain.SizeMode = PictureBoxSizeMode.AutoSize;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
         

        private void btnValidatePassport_Click(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = string.Empty;
                if (FaceAPI.IsValidPassport((Bitmap)pxMain.Image, ref lblInfo))
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnValidate2_Click(object sender, EventArgs e)
        {
            try
            {
                if (FaceAPI.IsValidPassport2((Bitmap)pxMain.Image, ref lblInfo))
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
