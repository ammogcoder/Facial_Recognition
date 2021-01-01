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
    public partial class frmFilterTest : Form
    {
        public frmFilterTest()
        {
            InitializeComponent();
        }

        private void pnlAll_Paint(object sender, PaintEventArgs e)
        {

        } 
        public PictureBox PixBox()
        {
            return new PictureBox() { Width = 200, Height = 180, SizeMode = PictureBoxSizeMode.StretchImage, BorderStyle = BorderStyle.FixedSingle };
        }
        Bitmap defaultBmp;

        OpenFileDialog fl = new OpenFileDialog() { Filter = ImageModifier.GetImageFilter() };

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (fl.ShowDialog() == DialogResult.OK)
                {
                    string filename = fl.FileName;

                    Bitmap bmp = new Bitmap(filename);
                    PictureBox px = PixBox();
                    px.Image = bmp;
                    defaultBmp = bmp;
                    pnlAll.Controls.Add(px); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            var px = PixBox();
            px.Image = FilterStats.ConvertToGrayScale(defaultBmp);
            pnlAll.Controls.Add(px);
        }

        private void btnDifferenceFilter_Click(object sender, EventArgs e)
        {
            var px = PixBox();
            px.Image = CornerDetector.GetDifferenceFilterImage(defaultBmp);
            pnlAll.Controls.Add(px);
        }

        private void btnDetectLines_Click(object sender, EventArgs e)
        {
            var px = PixBox();
            px.Image = CornerDetector.DetectLines(defaultBmp);
            pnlAll.Controls.Add(px);
        }

        private void btnDetectCorner_Click(object sender, EventArgs e)
        {
            var px = PixBox();
            px.Image = CornerDetector.DetectCorners(defaultBmp);
            pnlAll.Controls.Add(px);
        }

        private void btnDetectShape_Click(object sender, EventArgs e)
        {
            var BlobCount = new BlobDetect().GetBlobDetection(defaultBmp, true);

            if (BlobCount.Count > 0)
            {
                txtRes.AppendText($"{Environment.NewLine}-------{Environment.NewLine} Shapes detected (Original): {BlobCount.Count.ToString()}");

                for (var index = 0; index <= BlobCount.Count - 1; index++)
                    txtRes.AppendText($"{Environment.NewLine} Shapes detected ({(index + 1).ToString()}): {BlobCount[index].ShapeType.ToString()}");
            }
            else
                txtRes.AppendText($"{Environment.NewLine}-------{Environment.NewLine} Shapes detected (Original): None");
        }

        private void btnDetectFace_Click(object sender, EventArgs e)
        {
            Bitmap modifiedBMP = new Bitmap(defaultBmp);
            PictureBox px = PixBox();
            px.Image = modifiedBMP;
            var res = FaceAPI.DetectFaceWithDrawing(ref px,
                                              Accord.Vision.Detection.ObjectDetectorSearchMode.Default,
                                              1.5, Accord.Vision.Detection.ObjectDetectorScalingMode.GreaterToSmaller,
                                              true, 3);
            if (res.FaceCount == 0)
                res = FaceAPI.DetectFaceWithDrawing(ref px,
                                              Accord.Vision.Detection.ObjectDetectorSearchMode.Default,
                                              1.5, Accord.Vision.Detection.ObjectDetectorScalingMode.SmallerToGreater,
                                              true, 3);
            pnlAll.Controls.Add(px);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pnlAll.Controls.Clear();
            txtRes.Clear();
        }

        short colorDistanceVal = 20; 
        private void btnFTT_Click(object sender, EventArgs e)
        {
            {
                var px = PixBox();
                Bitmap FFTImage = FilterStats.GetFFTImage(defaultBmp);
                px.Image = FFTImage;
                pnlAll.Controls.Add(px); 

                // 'calculate middle horizontal and vertical white dots ------------------------------------------
                var LargeDivisor = 20;
                var SmallDivisor = 3;
                Size VerticalRectback = new Size((int)(FFTImage.Width / (double)LargeDivisor), (int)(FFTImage.Height / (double)SmallDivisor));
                Rectangle VerticalRect = new Rectangle(new System.Drawing.Point((int)((FFTImage.Width / (double)2) - (VerticalRectback.Width / (double)2)),
                                                                (int)((FFTImage.Height / (double)2) - (VerticalRectback.Height / (double)2))), VerticalRectback);

                Size HorizontalRectback = new Size((int)(FFTImage.Width / (double)SmallDivisor), (int)(FFTImage.Height / (double)LargeDivisor));
                Rectangle HorizontalRect = new Rectangle(new System.Drawing.Point((int)((FFTImage.Width / (double)2) - (HorizontalRectback.Width / (double)2)),
                                                                    (int)((FFTImage.Height / (double)2) - (HorizontalRectback.Height / (double)2))), HorizontalRectback);

                 
                var Res = $"{Environment.NewLine}----Blur Back Color check";
                // search the rectangle color categories
                var VerticalColorCat = FaceAPI.GetColorCategoryPixelCountCompare(FFTImage, VerticalRect, Color.White, colorDistanceVal);
                Res += $"{Environment.NewLine}Vertical Rect - Base Color Count: {VerticalColorCat.BaseColorCount.ToString()}, %: {VerticalColorCat.BaseColorPercent.ToString()}";

                var HorizontalColorCat = FaceAPI.GetColorCategoryPixelCountCompare(FFTImage, HorizontalRect, Color.White, colorDistanceVal);
                Res += $"{Environment.NewLine}Horizontal Rect - Base Color Count: {HorizontalColorCat.BaseColorCount.ToString()}, %: {HorizontalColorCat.BaseColorPercent.ToString()}";

                txtRes.AppendText(Res);

                // 'add rect on grayscale----------------------------------
                Bitmap newbmp = new Bitmap(FFTImage);
                Graphics _g = Graphics.FromImage(newbmp);  

                _g.DrawRectangle(new Pen(Color.Yellow, 1), VerticalRect);
                _g.DrawRectangle(new Pen(Color.Yellow, 1), HorizontalRect);
                _g.Save();

                PictureBox pxB = PixBox();
                pxB.Image = newbmp;
                pnlAll.Controls.Add(pxB);
                pnlAll.Refresh();
            }

        }
    }
}
