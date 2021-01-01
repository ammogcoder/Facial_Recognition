
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Windows.Forms;
using AForge.Controls;
using System.Drawing;

namespace WinFaceRecognition.ClassLogic
{ 
    public class VideoHandle
    {
        private string imgSource;
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        string NoCameraInfo = "Please attach a Camera and Try Again ";

        public void LoadVideoDevice(ComboBox cmb, VideoSourcePlayer VidPlayer)  
        {
            try
            {
                VidPlayer.SignalToStop();
                VidPlayer.WaitForStop();
                VidPlayer.Stop();
                cam = new VideoCaptureDevice(webcam[cmb.SelectedIndex].MonikerString);
                VidPlayer.VideoSource = cam;
                VidPlayer.Start();
            }
            catch (Exception ex)
            {
            }
        }
        public static bool CheckCameraAvailability()
        {
            try
            { 
                if (new FilterInfoCollection(FilterCategory.VideoInputDevice).Count > 0)
                    return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public static int  GetNoofCameras()
        {
            try
            {
                return new FilterInfoCollection(FilterCategory.VideoInputDevice).Count;
            }
            catch (Exception ex)
            {
            }
            return 0;
        }
        public void loadFrm(ref VideoSourcePlayer vidPlayer, ComboBox cmb, ref int CamCount, ref int DefaultCameraIndex) // , webCam As FilterInfoCollection, cam As VideoCaptureDevice)
        {
            try
            {
                webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                CamCount = webcam.Count;
                cmb.Items.Clear();
                if (CamCount < 1)
                    throw new Exception(NoCameraInfo);

                var ind = 0;
                foreach (FilterInfo device in webcam)
                { 
                        cmb.Items.Add(device.Name);
                        DefaultCameraIndex = ind; 
                    ind += 1;
                }
                if (cmb.Items.Count < 1)
                    throw new Exception(NoCameraInfo);

                cmb.SelectedIndex = 0;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
        public void StartCamera(ref VideoSourcePlayer vidPlayer, ref ComboBox cmb)
        {
            try
            {
                cam = new VideoCaptureDevice(webcam[cmb.SelectedIndex].MonikerString);
                vidPlayer.VideoSource = cam;
                vidPlayer.Start();
            }
            catch (Exception ex)
            {
            }
        }
        public void StartCamera(ref VideoSourcePlayer vidPlayer, int CameraIndex)
        {
            try
            {
                cam = new VideoCaptureDevice(webcam[CameraIndex].MonikerString);
                vidPlayer.VideoSource = cam;
                vidPlayer.Start();
            }
            catch (Exception ex)
            {
            }
        }
        public void StopCamera(ref VideoSourcePlayer vidPlayer)
        {
            try
            {
                vidPlayer.SignalToStop();
                vidPlayer.WaitForStop();
                vidPlayer.Stop();
            }
            catch (Exception ex)
            {
            }
        }
        public void DisposeCamera(ref VideoSourcePlayer vidPlayer)
        {
            try
            {
                vidPlayer.SignalToStop();
                vidPlayer.WaitForStop();
                vidPlayer.Stop();
                webcam = null;
                cam = null;
            }
            catch (Exception ex)
            {
            }
        }

        public void Initialize(ref Label lb, ref VideoSourcePlayer vidPlayer, ref ComboBox cmb) 
        {
            try
            {
                lb.Hide();
                webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (webcam.Count < 1)
                {
                    MessageBox.Show( "Please attach a video input device, and try again", "No Camera");  
                    imgSource = "";
                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }

        public Bitmap captureImage(VideoSourcePlayer vspCapture)
        {
            try
            {
                Bitmap retVal = null ;
                if (vspCapture.IsRunning)
                    retVal = vspCapture.GetCurrentVideoFrame();
                return retVal;
            }
            catch (Exception ex)
            {
            }
            return null/* TODO Change to default(_) if this is not a reference type */;
        }

        public static void ShowCaptured(System.Windows.Forms.PictureBox ImageCaptured, Bitmap CapturedImage, AForge.Controls.VideoSourcePlayer vspCapture)
        {
            try
            {
                ImageCaptured.SizeMode = PictureBoxSizeMode.StretchImage;
                ImageCaptured.Image = CapturedImage;
                ImageCaptured.Visible = true;
                vspCapture.Visible = false;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
