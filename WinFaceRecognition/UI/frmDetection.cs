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
    public partial class frmDetection : Form
    {
        public frmDetection()
        {
            InitializeComponent();
        }

        OpenFileDialog fl = new OpenFileDialog() {Filter =  ImageModifier.GetImageFilter() };
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (fl.ShowDialog()==DialogResult.OK)
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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (pxMain.Image == null) throw new Exception("Browse an Image");

               var result = FaceAPI.DetectFaceWithDrawing(ref pxMain, 
                                              Accord.Vision.Detection.ObjectDetectorSearchMode.Default,
                                              1.5, Accord.Vision.Detection.ObjectDetectorScalingMode.GreaterToSmaller, 
                                              true, 3);

                if (result == null || result.FaceCount == 0)
                {
                    result = FaceAPI.DetectFaceWithDrawing(ref pxMain,
                                              Accord.Vision.Detection.ObjectDetectorSearchMode.Default,
                                              1.5, Accord.Vision.Detection.ObjectDetectorScalingMode.SmallerToGreater,
                                              true, 3);
                }

                if (result != null && result.FaceCount>0)
                {
                    lblInfo.Text = $"Face Count: {result.FaceCount}, Process Duration in Milliseconds: {result.OperationMilliSeconds}";
                }
                else
                {
                    lblInfo.Text = "No Face Found";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
