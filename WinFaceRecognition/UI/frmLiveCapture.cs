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
    public partial class frmLiveCapture : Form
    {
        Bitmap CapturedImage;
        VideoHandle CameraAction = new VideoHandle();
        int DefaultCameraIndex; 
        public frmLiveCapture()
        {
            InitializeComponent();
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            try
            {
                CameraAction.StopCamera(ref vspCapture);
                vspCapture.Visible = false;
                btnStartCamera.Enabled = true;
                btnStopCamera.Enabled = false;
                btnCaptureImage.Enabled = false;

                if (CapturedImage == null)
                {
                    ImageCaptured.SizeMode = PictureBoxSizeMode.CenterImage; 
                }
                ImageCaptured.Visible = true;
            }
            catch (Exception ex)
            { 
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            try
            {
                CapturedImage = null;
                ImageCaptured.Visible = false; 
                CameraAction.StartCamera( ref vspCapture,   DefaultCameraIndex);
                vspCapture.Visible = true;
                btnStartCamera.Enabled = false;
                btnStopCamera.Enabled = true;
                btnCaptureImage.Enabled = true;
            }
            catch (Exception ex)
            { 
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCaptureImage_Click(object sender, EventArgs e)
        { 
                try
                {  
                    CapturedImage = CameraAction.captureImage(vspCapture);
                    VideoHandle.ShowCaptured(ImageCaptured, CapturedImage, vspCapture); 
                 
                    btnStopCamera.PerformClick();

                    btnStartCamera.Enabled = true;
                    btnStopCamera.Enabled = false;
                    btnCaptureImage.Enabled = false;

                    if (chkDetectFace.Checked)
                    {
                        var result = FaceAPI.DetectFaceWithDrawing(ref ImageCaptured,
                                              Accord.Vision.Detection.ObjectDetectorSearchMode.Default,
                                              1.5, Accord.Vision.Detection.ObjectDetectorScalingMode.GreaterToSmaller,
                                              true, 3);

                        if (result == null || result.FaceCount == 0)
                        {
                            result = FaceAPI.DetectFaceWithDrawing(ref ImageCaptured,
                                                      Accord.Vision.Detection.ObjectDetectorSearchMode.Default,
                                                      1.5, Accord.Vision.Detection.ObjectDetectorScalingMode.SmallerToGreater,
                                                      true, 3);
                        }
                    }

                }
                catch (Exception ex)
                { 
                    CapturedImage = null;
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnStopCamera.PerformClick();
                    btnStartCamera.PerformClick();
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            } 

        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnStopCamera.PerformClick();
                btnStartCamera.PerformClick();
            }
            catch (Exception ex)
            { 
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        int CamCount;
        public void InitializeCamera()
        {
            try
            { 
                Cursor = Cursors.WaitCursor;
                // get all cameras--------------------
                try
                {
                    CameraAction.loadFrm(ref vspCapture, cmbCamera, ref CamCount, ref DefaultCameraIndex);
                }
                catch (Exception ex)
                { 
                    if (CamCount == 0 )
                    {
                        MessageBox.Show("Please attach at least one camera. Form will now close", "No Camera Detected...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (CamCount == 0)
                            Close();
                    }
                }
                if (cmbCamera.Items.Count > 0)
                {
                    btnStartCamera.Enabled = true;
                    btnStartCamera.PerformClick();
                } 
                 
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void frmLiveCapture_Load(object sender, EventArgs e)
        {
            //detect camera connected
            InitializeCamera();
        }
    }
}
