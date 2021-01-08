using Accord.Imaging;
using Accord.Imaging.Filters;
using Accord.Vision.Detection;
using Accord.Vision.Detection.Cascades;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinFaceRecognition.ClassLogic
{
    /// <summary>
    /// Class Library demonstrating some of the features in Accord/Aforge .NET 
    /// </summary>
    public static class FaceAPI
    {
        private static short colorDistanceVal = 70; 
        private static int MinAcceptedBaseBackPercent = 65;
        private static double MinAcceptedNonBlurPercent = 15.1;
        private static int LargeDivisor = 20;
        private static int SmallDivisor = 3;
        private static int ImageResolution = 96; 
        private static decimal SubstantialImpactRate = (decimal)3.5;

        public static bool IsValidPassport2(Bitmap originalImage, ref Label lblInfo, bool CheckResolution = false )
        {
            lblInfo.Text = "------New Validation Result v2-------";
            try
            {
                if (CheckResolution && (originalImage.HorizontalResolution < ImageResolution || originalImage.VerticalResolution < ImageResolution))
                {
                    string ErrorMsg = string.Format("The Resolution of the Image is too low. Use Resolution of {0}dpi", ImageResolution);
                    throw new Exception(ErrorMsg);
                }
                else 
                    lblInfo.Text += Environment.NewLine + "The Resolution of the picture is good";

                // Sets base color for background
                Color BaseColor = Color.White; 

                // '-----------version 1 validate-----------------------------------------------
                bool isFirstCheckValid=false;
                try
                {
                    isFirstCheckValid = IsValidPassport(originalImage,ref lblInfo );
                }
                catch (Exception ex)
                { 
                    throw new Exception(ex.Message);
                }
                if (!isFirstCheckValid)
                    throw new Exception("Invalid Passport");

                // ------------------scan through the edges (10% round) to see if there is non-white background ----------------------
                Bitmap newbmp = new Bitmap(originalImage);
                Size rectback = new Size((int)(newbmp.Width / (double)5), (int)(newbmp.Height / (double)3));

                var W = newbmp.Width;
                var H = newbmp.Height;
                Rectangle leftrect = new Rectangle(new System.Drawing.Point(0, 0), rectback);
                Rectangle rightrect = new Rectangle(new System.Drawing.Point(W - rectback.Width, 0), rectback);

                // search the rectangle color categories
                var leftColorCat = GetColorCategoryPixelCountCompare(FilterStats.ConvertToGrayScale(newbmp), leftrect, BaseColor, colorDistanceVal);
                if (leftColorCat.BaseColorPercent < MinAcceptedBaseBackPercent) 
                    throw new Exception("Ensure white background is maintained on the left side.");  
                else
                    lblInfo.Text += Environment.NewLine + "White background is maintained on the left side.";

                var rightColorCat = GetColorCategoryPixelCountCompare(FilterStats.ConvertToGrayScale(newbmp), rightrect, BaseColor, colorDistanceVal);
                if (rightColorCat.BaseColorPercent < MinAcceptedBaseBackPercent)  
                    throw new Exception("Ensure white background is maintained on the right side."); 
                else
                    lblInfo.Text += Environment.NewLine + "White background is maintained on the right side.";

                //Blur detection for quality----------------------------------------------------------------- 
                var FFTImage = FilterStats.GetFFTImage(originalImage);

                //Calculate middle horizontal and vertical white dots ------------------------------------------
                Size VerticalRectback = new Size((int)(FFTImage.Width / (double)LargeDivisor), (int)(FFTImage.Height / (double)SmallDivisor));
                Rectangle VerticalRect = new Rectangle(new System.Drawing.Point((int)((FFTImage.Width / (double)2) - (VerticalRectback.Width / (double)2)), 
                                                                (int)((FFTImage.Height / (double)2) - (VerticalRectback.Height / (double)2))), VerticalRectback);

                Size HorizontalRectback = new Size((int)(FFTImage.Width / (double)SmallDivisor), (int)(FFTImage.Height / (double)LargeDivisor));
                Rectangle HorizontalRect = new Rectangle(new System.Drawing.Point((int)((FFTImage.Width / (double)2) - (HorizontalRectback.Width / (double)2)), 
                                                                    (int)((FFTImage.Height / (double)2) - (HorizontalRectback.Height / (double)2))), HorizontalRectback);
                // search the rectangle color categories 
                var VerticalColorCat = GetColorCategoryPixelCountCompare(FFTImage, VerticalRect, BaseColor, colorDistanceVal);
                var HorizontalColorCat = GetColorCategoryPixelCountCompare(FFTImage, HorizontalRect, BaseColor, colorDistanceVal);

                if ((double)VerticalColorCat.BaseColorPercent < MinAcceptedNonBlurPercent || (double)HorizontalColorCat.BaseColorPercent < MinAcceptedNonBlurPercent) 
                    throw new Exception("Ensure Picture is not Flattened nor Blurred"); 
                else
                    lblInfo.Text += Environment.NewLine + "Picture is not Flattened nor Blurred";

                lblInfo.Text += Environment.NewLine + Environment.NewLine + "VALID PASSPORT v2";
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public static bool IsValidPassport(  Bitmap originalImage, ref Label lblInfo, bool CheckResolution = false )
        {
            try
            {
                lblInfo.Text += Environment.NewLine + "------New Validation Result v1-------"; ;
                var TopConst = 5; 

                Bitmap Duplicate = originalImage;

                // do bmp cropping
                var modifiedBMP = ImageModifier.AutoCrop(Duplicate);

                // 'do convert to grayscale
                modifiedBMP = ImageModifier.ConvertToGrayScale((Bitmap)modifiedBMP);
                
                // detect face in picture here
                var res = DetectAnyFace(  originalImage,ObjectDetectorSearchMode.Default,
                                        1.5 ,
                                        Accord.Vision.Detection.ObjectDetectorScalingMode.GreaterToSmaller,true,3);
                if (res.FaceCount == 0)
                    res = DetectAnyFace(  originalImage, ObjectDetectorSearchMode.Default, 
                                        1.5, 
                                        Accord.Vision.Detection.ObjectDetectorScalingMode.SmallerToGreater, true, 3);
                if (res.FaceCount > 0)
                {
                    if (res.FaceCount > 1)
                    {   
                        throw new Exception("Multiple Human Faces Detected. Only One Face is Allowed");
                    }
                    else
                    {
                        lblInfo.Text += Environment.NewLine + "One Face detected";

                        var rect = res.FaceRectangles[0];
                        int ResolvedHeight = rect.Height;
                        int ResolvedWidth = rect.Width;
                        if (ResolvedWidth < (originalImage.Width / (double)SubstantialImpactRate) || ResolvedHeight < (originalImage.Height / (double)SubstantialImpactRate)) 
                            throw new Exception("Face doesn't cover substantial part of the passport"); 
                        else
                            lblInfo.Text += Environment.NewLine + "Face covered substantial part of the passport"; 
                        
                        if (rect.X == 0 || rect.X > (originalImage.Width - rect.Right) * 2.89 || ((originalImage.Width - rect.Right) * 2.89) < rect.X) 
                            throw new Exception("Face is not centralized on the Passport");
                        else
                            lblInfo.Text += Environment.NewLine + "Face is centralized on the Passport";

                        if (rect.Y == 0 || rect.Y < originalImage.Height / (double)TopConst) 
                            throw new Exception("Candidate's Face is too close to the Top of the Passport"); 
                        else
                        {
                            lblInfo.Text += Environment.NewLine + "Face is not too close to the Top of the Passport";

                            // get the background and check if it plain
                            //create a rectangle round the originalImage to be used for comparison/reference
                            Rectangle rects = new Rectangle(new System.Drawing.Point((int)(rect.X / (double)3), (int)(rect.Y / (double)3)),
                                new Size((int)((rect.Right + (originalImage.Width - rect.Right) / (double)2) - (rect.X / (double)3)),
                                (int)(originalImage.Height - (rect.Y / (double)3))));

                            Color PreviousColor = Color.Empty; // keep the previous color for comparison

                            // apply difference filter 
                            var diffImage = CornerDetector.GetDifferenceFilterImage(originalImage);
                            List<Color> lst1 = new List<Color>();
                            List<Color> lst2 = new List<Color>();

                            var BaseColorCompare = Color.Empty;
                            bool nonPlain = false;
                            int DiffBackCounter = 0;
                            for (int x = 0; x <= diffImage.Width - 1; x++)
                            {
                                if (x < (rects.X) | (x > rects.Right))
                                {
                                    for (int y = 0; y <= diffImage.Height - 1; y++)
                                    {
                                        if (y < (rect.Bottom) / (double)2 & y > rects.Top)
                                        {
                                            Color pixelColor = originalImage.GetPixel(x, y); // original background check - simple background check 

                                            if (BaseColorCompare == null)
                                                BaseColorCompare = originalImage.GetPixel(x, y); // form bgcolor base compare

                                            if (pixelColor != null )
                                            {
                                                if (GetColorDistance(pixelColor, BaseColorCompare) > 50)
                                                {
                                                    DiffBackCounter += 1;
                                                    lst1.Add(pixelColor);
                                                }
                                                else
                                                    lst2.Add(pixelColor);
                                            }

                                            // compare based on pixel counts
                                            if (lst1.Count > 200 & lst2.Count > 200)
                                            {
                                                nonPlain = true; // not plain
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (nonPlain)
                                    break;
                            }
                            if (nonPlain) 
                                throw new Exception("The Passport's Background is not Plain or face doesn't cover Substantial part of the Passport");
                            else
                                lblInfo.Text += Environment.NewLine + "The Passport's Background is Plain and Face cover Substantial part of the Passport";

                            if (!nonPlain)
                            {
                                lblInfo.Text += Environment.NewLine + Environment.NewLine + "VALID PASSPORT v1";
                                return true;
                            }
                        }
                    }
                }
                else
                    throw new Exception("The Passport is NOT a Valid Human Face or Face Not Properly Exposed");
            }
            catch (Exception ex)
            {
               throw ex;
            }
            return  false;
        }

        public static ColorCounterCategory GetColorCategoryPixelCountCompare(Bitmap SourceBmp, Rectangle rectSearch, 
            Color BaseColor, Int16 MaxColorDistance = 20)
        {
            ColorCounterCategory retVal = new ColorCounterCategory() { BaseColor = BaseColor };

            for (var x = 0; x <= SourceBmp.Width - 1; x++)
            {
                if (x >= (rectSearch.X) & (x <= rectSearch.Right))
                {
                    for (var y = 0; y <= SourceBmp.Height - 1; y++)
                    {
                        if (y <= rectSearch.Bottom & y >= rectSearch.Top)
                        {
                            Color pixelColor = SourceBmp.GetPixel(x, y);

                            // count the current values
                            if (IsColorClose(BaseColor, pixelColor, MaxColorDistance))
                                retVal.BaseColorCount += 1;
                            else
                                retVal.OtherColorCount += 1;
                        }
                    }
                }
            }
            // get the percent dominance of base color
            retVal.BaseColorPercent = System.Convert.ToDecimal(retVal.BaseColorCount / (double)(retVal.BaseColorCount + retVal.OtherColorCount)) * 100;
            return retVal;
        }

        public static bool IsColorClose(Color color1, Color color2, int DistanceMax)
        {
            try
            {
                var R = (System.Convert.ToInt32(color1.R) - System.Convert.ToInt32(color2.R)) * (System.Convert.ToInt32(color1.R) - System.Convert.ToInt32(color2.R));
                var G = (System.Convert.ToInt32(color1.G) - System.Convert.ToInt32(color2.G)) * (System.Convert.ToInt32(color1.G) - System.Convert.ToInt32(color2.G));
                var B = (System.Convert.ToInt32(color1.B) - System.Convert.ToInt32(color2.B)) * (System.Convert.ToInt32(color1.B) - System.Convert.ToInt32(color2.B));
                var sumSQR = (R) + (G) + (B);

                double ret = Math.Sqrt(sumSQR);
                if (ret > DistanceMax)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
            }
                return false;
        }

        public static ProcessData DetectFaceWithDrawing(ref PictureBox Pic, 
            ObjectDetectorSearchMode SearchMode = ObjectDetectorSearchMode.NoOverlap, 
            double ScalingFactor = 1.5, ObjectDetectorScalingMode ScalingMode = ObjectDetectorScalingMode.SmallerToGreater, 
            bool UseParallelProcessing = true, int Suppression = 3)
        {
            Stopwatch sw = new Stopwatch();
            try
            {
                HaarObjectDetector detector;
                FaceHaarCascade cascade = new FaceHaarCascade();
                detector = new HaarObjectDetector(cascade, 30);

                detector.SearchMode = SearchMode;
                detector.ScalingFactor =(float) ScalingFactor;
                detector.ScalingMode = ScalingMode;
                detector.UseParallelProcessing = UseParallelProcessing;
                detector.Suppression = Suppression;

                sw = Stopwatch.StartNew();
                Rectangle[] faceObjects =detector.ProcessFrame((Bitmap) Pic.Image);
                sw.Stop();

                Graphics g = Graphics.FromImage(Pic.Image);
                foreach (var face in faceObjects)
                    g.DrawRectangle(Pens.DeepSkyBlue, face);
                g.Dispose();

                Pic.Invalidate();

                return new ProcessData() { FaceCount = (short)faceObjects.Count(), OperationMilliSeconds = sw.ElapsedMilliseconds, FaceRectangles = faceObjects };
            }
            catch (Exception ex)
            {
                return new ProcessData() { FaceCount = 0, OperationMilliSeconds = sw.ElapsedMilliseconds };
            }
        }

        public static ProcessData DetectAnyFace(  Bitmap Bmp, ObjectDetectorSearchMode SearchMode = ObjectDetectorSearchMode.NoOverlap, 
            double ScalingFactor = 1.5, ObjectDetectorScalingMode ScalingMode = ObjectDetectorScalingMode.SmallerToGreater, 
            bool UseParallelProcessing = true, int Suppression = 3)
        {
            Stopwatch sw = new Stopwatch();
            try
            {
                HaarObjectDetector detector;
                FaceHaarCascade cascade = new FaceHaarCascade();
                detector = new HaarObjectDetector(cascade, 30);

                detector.SearchMode = SearchMode;
                detector.ScalingFactor =(float) ScalingFactor;
                detector.ScalingMode = ScalingMode;
                detector.UseParallelProcessing = UseParallelProcessing;
                detector.Suppression = Suppression;

                sw = Stopwatch.StartNew();
                Rectangle[] faceObjects = detector.ProcessFrame(Bmp);
                sw.Stop();

                return new ProcessData() { FaceCount = (short)faceObjects.Count(), OperationMilliSeconds = sw.ElapsedMilliseconds, FaceRectangles = faceObjects };
            }
            catch (Exception ex)
            {
                return new ProcessData() { FaceCount = 0, OperationMilliSeconds = sw.ElapsedMilliseconds };
            }
        }

        public static double GetColorDistance(Color color1, Color color2)
        {
            try
            {
                var R = (System.Convert.ToInt32(color1.R) - System.Convert.ToInt32(color2.R)) * (System.Convert.ToInt32(color1.R) - System.Convert.ToInt32(color2.R));
                var G = (System.Convert.ToInt32(color1.G) - System.Convert.ToInt32(color2.G)) * (System.Convert.ToInt32(color1.G) - System.Convert.ToInt32(color2.G));
                var B = (System.Convert.ToInt32(color1.B) - System.Convert.ToInt32(color2.B)) * (System.Convert.ToInt32(color1.B) - System.Convert.ToInt32(color2.B));
                var sumSQR = (R) + (G) + (B);

                return Math.Sqrt(sumSQR);
            }
            catch (Exception ex)
            {
            }
            return -1;
        }
    }  

    public class BlobDetect
    {
        // Blob Detection
        public Bitmap BlobDetection(Bitmap _bitmapSourceImage)
        {
            try
            {
                Grayscale _grayscale = new Grayscale(0.2125, 0.7154, 0.0721);
                Bitmap _bitmapGreyImage = _grayscale.Apply(_bitmapSourceImage);

                // create a edge detector instance
                DifferenceEdgeDetector _differeceEdgeDetector = new DifferenceEdgeDetector();
                Bitmap _bitmapEdgeImage = _differeceEdgeDetector.Apply(_bitmapGreyImage);

                Threshold _threshold = new Threshold(40);
                Bitmap _bitmapBinaryImage = _threshold.Apply(_bitmapEdgeImage);

                // Create a instance of blob counter algorithm
                BlobCounter _blobCounter = new BlobCounter();
                // Configure Filter
                _blobCounter.MinWidth = 70;
                _blobCounter.MinHeight = 70;
                _blobCounter.FilterBlobs = true;

                _blobCounter.ProcessImage(_bitmapBinaryImage);
                Blob[] _blobPoints = _blobCounter.GetObjectsInformation();

                Graphics _g = Graphics.FromImage(_bitmapSourceImage);

                SimpleShapeChecker _shapeChecker = new SimpleShapeChecker();
                for (int i = 0; i <= _blobPoints.Length; i++)
                {
                    List<IntPoint> _edgePoint = _blobCounter.GetBlobsEdgePoints(_blobPoints[i]);
                    List<IntPoint> _corners = null;
                    AForge.Point _center;
                    float _radius;

                    if ((_shapeChecker.IsQuadrilateral(_edgePoint,out _corners)))
                    {
                        // MessageBox.Show(""+_shapeChecker.CheckShapeType(_edgePoint));
                        System.Drawing.Font _font = new System.Drawing.Font("Segoe UI", 16);
                        System.Drawing.SolidBrush _brush = new System.Drawing.SolidBrush(System.Drawing.Color.PaleGreen);
                        System.Drawing.Point[] _coordinates = ToPointsArray(_corners);
                        if ((_coordinates.Length == 4))
                        {
                            int _x = _coordinates[0].X;
                            int _y = _coordinates[0].Y;
                            Pen _pen = new Pen(Color.Brown);
                            string _shapeString = "" + _shapeChecker.CheckShapeType(_edgePoint);
                            _g.DrawString(_shapeString, _font, _brush, _x, _y);
                            _g.DrawPolygon(_pen, ToPointsArray(_corners));
                        }
                    }

                    if ((_shapeChecker.IsCircle(_edgePoint, out _center, out _radius)))
                    {
                        string _shapeString = "" + _shapeChecker.CheckShapeType(_edgePoint);
                        System.Drawing.Font _font = new System.Drawing.Font("Segoe UI", 16);
                        System.Drawing.SolidBrush _brush = new System.Drawing.SolidBrush(System.Drawing.Color.Chocolate);
                        Pen _pen = new Pen(Color.GreenYellow);
                        int x =(int) _center.X;
                        int y = (int)_center.Y;
                        _g.DrawString(_shapeString, _font, _brush, x, y);
                        _g.DrawEllipse(_pen, (_center.X - _radius), (_center.Y - _radius), (_radius * 2), (_radius * 2));
                    }

                    if ((_shapeChecker.IsTriangle(_edgePoint,out _corners)))
                    {
                        string _shapeString = "" + _shapeChecker.CheckShapeType(_edgePoint);
                        System.Drawing.Font _font = new System.Drawing.Font("Segoe UI", 16);
                        System.Drawing.SolidBrush _brush = new System.Drawing.SolidBrush(System.Drawing.Color.Brown);
                        Pen _pen = new Pen(Color.GreenYellow);
                        int x =(int) _center.X;
                        int y = (int)_center.Y;
                        _g.DrawString(_shapeString, _font, _brush, x, y);
                        _g.DrawPolygon(_pen, ToPointsArray(_corners));
                    }
                }
                return _bitmapSourceImage;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        private System.Drawing.Point[] ToPointsArray(List<IntPoint> points)
        {
            System.Drawing.Point[] array = new System.Drawing.Point[points.Count - 1 + 1];
            for (int i = 0; i <= points.Count - 1; i++)
                array[i] = new System.Drawing.Point(points[i].X, points[i].Y);
            return array;
        }

        public List<ProcessDataShape> GetBlobDetection(Bitmap _bitmapSourceImage, bool DrawShape = true)
        {
            try
            {
                List<ProcessDataShape> retVals = new List<ProcessDataShape>();

                Grayscale _grayscale = new Grayscale(0.2125, 0.7154, 0.0721);
                Bitmap _bitmapGreyImage = _grayscale.Apply(_bitmapSourceImage);

                // create a edge detector instance
                DifferenceEdgeDetector _differeceEdgeDetector = new DifferenceEdgeDetector();
                Bitmap _bitmapEdgeImage = _differeceEdgeDetector.Apply(_bitmapGreyImage);

                Threshold _threshold = new Threshold(40);
                Bitmap _bitmapBinaryImage = _threshold.Apply(_bitmapEdgeImage);

                // Create a instance of blob counter algorithm
                BlobCounter _blobCounter = new BlobCounter();
                // Configure Filter
                _blobCounter.MinWidth = 70;
                _blobCounter.MinHeight = 70;
                _blobCounter.FilterBlobs = true;

                _blobCounter.ProcessImage(_bitmapBinaryImage);
                Blob[] _blobPoints = _blobCounter.GetObjectsInformation();
                Stopwatch sw;

                Graphics _g = Graphics.FromImage(_bitmapSourceImage);

                SimpleShapeChecker _shapeChecker = new SimpleShapeChecker();
                for (int i = 0; i <= _blobPoints.Length - 1; i++)
                {
                    List<IntPoint> _edgePoint = _blobCounter.GetBlobsEdgePoints(_blobPoints[i]);
                    List<IntPoint> _corners = null;
                    AForge.Point _center;
                    float _radius;

                    sw = Stopwatch.StartNew();
                    if ((_shapeChecker.IsQuadrilateral(_edgePoint, out _corners)))
                    {
                        // MessageBox.Show(""+_shapeChecker.CheckShapeType(_edgePoint));
                        System.Drawing.Font _font = new System.Drawing.Font("Segoe UI", 16);
                        System.Drawing.SolidBrush _brush = new System.Drawing.SolidBrush(System.Drawing.Color.PaleGreen);
                        System.Drawing.Point[] _coordinates = ToPointsArray(_corners);
                        if ((_coordinates.Length == 4))
                        {
                            int _x = _coordinates[0].X;
                            int _y = _coordinates[0].Y;
                            Pen _pen = new Pen(Color.Brown);
                            string _shapeString = "" + _shapeChecker.CheckShapeType(_edgePoint).ToString();
                            sw.Stop();
                            if (DrawShape)
                            {
                                _g.DrawString(_shapeString, _font, _brush, _x, _y);
                                _g.DrawPolygon(_pen, ToPointsArray(_corners));
                            }
                            retVals.Add(new ProcessDataShape() { ShapeCount = 1, OperationMilliSeconds = sw.ElapsedMilliseconds, ShapeType = ShapeTypes.Quadrilateral });
                        }
                    }

                    sw = Stopwatch.StartNew();
                    if ((_shapeChecker.IsCircle(_edgePoint,out _center,out _radius)))
                    {
                        string _shapeString = "" + _shapeChecker.CheckShapeType(_edgePoint);
                        System.Drawing.Font _font = new System.Drawing.Font("Segoe UI", 16);
                        System.Drawing.SolidBrush _brush = new System.Drawing.SolidBrush(System.Drawing.Color.Chocolate);
                        Pen _pen = new Pen(Color.GreenYellow);
                        int x =(int) _center.X;
                        int y =(int) _center.Y;
                        sw.Stop();
                        if (DrawShape)
                        {
                            _g.DrawString(_shapeString, _font, _brush, x, y);
                            _g.DrawEllipse(_pen, (_center.X - _radius), (_center.Y - _radius), (_radius * 2), (_radius * 2));
                        }
                        retVals.Add(new ProcessDataShape() { ShapeCount = 1, OperationMilliSeconds = sw.ElapsedMilliseconds, ShapeType = ShapeTypes.Circle });
                    }

                    sw = Stopwatch.StartNew();
                    if ((_shapeChecker.IsTriangle(_edgePoint,out _corners)))
                    {
                        string _shapeString = "" + _shapeChecker.CheckShapeType(_edgePoint);
                        System.Drawing.Font _font = new System.Drawing.Font("Segoe UI", 16);
                        System.Drawing.SolidBrush _brush = new System.Drawing.SolidBrush(System.Drawing.Color.Brown);
                        Pen _pen = new Pen(Color.GreenYellow);
                        int x =(int) _center.X;
                        int y =(int) _center.Y;
                        sw.Stop();
                        if (DrawShape)
                        {
                            _g.DrawString(_shapeString, _font, _brush, x, y);
                            _g.DrawPolygon(_pen, ToPointsArray(_corners));
                        }
                        retVals.Add(new ProcessDataShape() { ShapeCount = 1, OperationMilliSeconds = sw.ElapsedMilliseconds, ShapeType = ShapeTypes.Triangle });
                    }
                }
                return retVals;
            }
            catch (Exception ex)
            {
            }
            return null;
        } 
    }

    public class ImageModifier
    {
        /// <summary>
        /// Get the Filter string for all supported image types.
        /// This can be used directly to the FileDialog class Filter Property.
        /// </summary>
        /// <returns></returns>
        public static string GetImageFilter()
        {
            StringBuilder allImageExtensions = new StringBuilder();
            string separator = "";
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            Dictionary<string, string> images = new Dictionary<string, string>();
            foreach (ImageCodecInfo codec in codecs)
            {
                allImageExtensions.Append(separator);
                allImageExtensions.Append(codec.FilenameExtension);
                separator = ";";
                images.Add(string.Format("{0} Files: ({1})", codec.FormatDescription, codec.FilenameExtension),
                           codec.FilenameExtension);
            }
            StringBuilder sb = new StringBuilder();
            if (allImageExtensions.Length > 0)
            {
                sb.AppendFormat("{0}|{1}", "All Images", allImageExtensions.ToString());
            }
            images.Add("All Files", "*.*");
            foreach (KeyValuePair<string, string> image in images)
            {
                sb.AppendFormat("|{0}|{1}", image.Key, image.Value);
            }
            return sb.ToString();
        }
        public static byte[][] GetRGB(Bitmap bmp)
        {
            BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            IntPtr ptr = bmp_data.Scan0;
            int num_pixels = bmp.Width * bmp.Height;
            int num_bytes = bmp_data.Stride * bmp.Height;
            int padding = bmp_data.Stride - bmp.Width * 3;
            int i = 0;
            int ct = 1;
            byte[] r = new byte[num_pixels - 1 + 1];
            byte[] g = new byte[num_pixels - 1 + 1];
            byte[] b = new byte[num_pixels - 1 + 1];
            byte[] rgb = new byte[num_bytes - 1 + 1];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgb, 0, num_bytes);

            for (int x = 0; x <= num_bytes - 4; x += 3)
            {
                if (x == (bmp_data.Stride * ct - padding))
                {
                    x += padding;
                    ct += 1;
                }


                r[i] = rgb[x];
                g[i] = rgb[x + 1];
                b[i] = rgb[x + 2];
                i += 1;
            }
            bmp.UnlockBits(bmp_data);
            return new byte[3][] { r, g, b };
        }
        public static System.Drawing.Image AutoCrop(Bitmap bmp)
        {
            // Get an array containing the R,G,B components of each pixel
            var pixels = GetRGB(bmp);
            int h = bmp.Height - 1;
            int w = bmp.Width;
            int top = 0;
            int bottom = h;
            int left = bmp.Width;
            int right = 0;
            int white = 0;
            int tolerance = 95;
            // 95%
            bool prev_color = false;
            for (int i = 0; i <= pixels[0].Length - 1; i++)
            {
                int x = (i % (w));
                int y = System.Convert.ToInt32(System.Math.Floor(System.Convert.ToDecimal(i / w)));
                int tol = (int)(255 * tolerance / (double)100);
                if (pixels[0][i] >= tol && pixels[1][i] >= tol && pixels[2][i] >= tol)
                {
                    white += 1;
                    right = (x > right && white == 1) ? x : right;
                }
                else
                {
                    left = (x < left && white >= 1) ? x : left;
                    right = (x == w - 1 && white == 0) ? w - 1 : right;
                    white = 0;
                }
                if (white == w)
                {
                    top = (y - top < 3) ? y : top;
                    bottom = (prev_color && x == w - 1 && y > top + 1) ? y : bottom;
                }
                left = (x == 0 && white == 0) ? 0 : left;
                bottom = (y == h && x == w - 1 && white != w && prev_color) ? h + 1 : bottom;
                if (x == w - 1)
                {
                    prev_color = (white < w) ? true : false;
                    white = 0;
                }
            }
            right = (right == 0) ? w : right;
            left = (left == w) ? 0 : left;

            // Crop the image
            if (bottom - top > 0)
            {
                Bitmap bmpCrop = bmp.Clone(new Rectangle(left, top, right - left + 1, bottom - top), bmp.PixelFormat);

                return (Bitmap)bmpCrop;
            }
            else
                return bmp;
        }

        public static Bitmap TrimBitmap(Bitmap source)
        {
            Rectangle srcRect;
            BitmapData data= null;
            try
            {
                data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                byte[] buffer = new byte[data.Height * data.Stride - 1 + 1];
                Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
                int xMin = int.MaxValue;
                int xMax = 0;
                int yMin = int.MaxValue;
                int yMax = 0;
                for (int y = 0; y <= data.Height - 1; y++)
                {
                    for (int x = 0; x <= data.Width - 1; x++)
                    {
                        byte alpha = buffer[y * data.Stride + 4 * x + 3];
                        if (alpha != 0)
                        {
                            if (x < xMin)
                                xMin = x;
                            if (x > xMax)
                                xMax = x;
                            if (y < yMin)
                                yMin = y;
                            if (y > yMax)
                                yMax = y;
                        }
                    }
                }
                if (xMax < xMin || yMax < yMin)
                    // Image is empty...
                    return null/* TODO Change to default(_) if this is not a reference type */;
                srcRect = Rectangle.FromLTRB(xMin, yMin, xMax, yMax);
            }
            finally
            {
                if (data != null)
                    source.UnlockBits(data);
            }

            Bitmap dest = new Bitmap(srcRect.Width, srcRect.Height);
            Rectangle destRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
            using (Graphics graphics__1 = Graphics.FromImage(dest))
            {
                graphics__1.DrawImage(source, destRect, srcRect, GraphicsUnit.Pixel);
            }
            return dest;
        }
        public static byte[] ConvertToByteArray(Bitmap value)
        {
            byte[] bitmapBytes;
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                value.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                bitmapBytes = stream.ToArray();
            }
            return bitmapBytes;
        }
        public static Bitmap ConvertToGrayScale(Bitmap sourceBmp)
        {
            try
            { 
                // create a blank bitmap the same size as sourceBmp
                Bitmap newBitmap = new Bitmap(sourceBmp.Width, sourceBmp.Height);

                // get a graphics object from the new image
                Graphics g = Graphics.FromImage(newBitmap);

                // create the grayscale ColorMatrix 
                ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
                new float[] { 0.3F, 0.3F, 0.3F, 0, 0 },
                new float[] { 0.59F, 0.59F, 0.59F, 0, 0 },
                new float[] { 0.11F, 0.11F, 0.11F, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            });

                // create some image attributes
                ImageAttributes attributes = new ImageAttributes();

                // set the color matrix attribute
                attributes.SetColorMatrix(colorMatrix);

                // draw the sourceBmp image on the new image
                // using the grayscale color matrix
                g.DrawImage(sourceBmp, new Rectangle(0, 0, sourceBmp.Width, sourceBmp.Height), 0, 0, sourceBmp.Width, sourceBmp.Height, GraphicsUnit.Pixel, attributes);

                // dispose the Graphics object
                g.Dispose();
                return newBitmap;
            }
            catch (Exception ex)
            {
            }
            return null;
        } 
        public static Bitmap CropBitmap(ref Bitmap bmp, Size ReqPassportSize_)
        {
            // 'get the percentage for cropping
            var deriveCroppSizePercent = ((ReqPassportSize_.Height - ReqPassportSize_.Width) / (double)ReqPassportSize_.Width + (((ReqPassportSize_.Height - ReqPassportSize_.Width) / (double)ReqPassportSize_.Width) * 0.1));

            int cropX = (int)(bmp.Width * deriveCroppSizePercent);
            int cropY = 0;
            int cropWidth =(int) (bmp.Width - (bmp.Width * (deriveCroppSizePercent * 2)));
            int cropHeight = bmp.Height;

            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap cropped = bmp.Clone(rect, bmp.PixelFormat);
            return cropped;
        }
    }

    public class CornerDetector
    {
        public static Bitmap DetectCorners(Bitmap SourceImage, int Threshold = 40)
        {
            try
            {
                // Create a new SURF Features Detector using the given parameters
                FastCornersDetector fast = new FastCornersDetector()
                {
                    Threshold = Threshold,
                    Suppress = true
                };

                // Create a new AForge's Corner Marker Filter
                CornersMarker corners = new CornersMarker(fast, Color.White);

                // Apply the filter and display it on a picturebox
                return corners.Apply(SourceImage);
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public static Bitmap DetectLines(Bitmap SourceImage)
        {
            try
            {
                // Create a new Gabor filter
                GaborFilter filter = new GaborFilter();

                // Apply the filter
                Bitmap output = filter.Apply(SourceImage);
                return output;
            }
            catch (Exception ex)
            {
            }
            return null;
        } 
        public static Bitmap GetDifferenceFilterImage(Bitmap SourceImage )
        {
            try
            {
                EuclideanColorFiltering eu = new EuclideanColorFiltering(); 
                return eu.Apply(SourceImage);
            }
             
            catch (Exception ex)
            {
            }
            return null;
        }
    } 

    public class FilterStats
    {
        public static Bitmap CannyApply(Bitmap Image)
        {
            try
            {
                CannyEdgeDetector filter = new CannyEdgeDetector();
                return filter.Apply(Image);
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public static Bitmap HomogenityApply(Bitmap Image)
        {
            try
            {
                HomogenityEdgeDetector filter = new HomogenityEdgeDetector();
                return filter.Apply(Image);
            }
            catch (Exception ex)
            {
            }

            return null;
        }

        public static Bitmap DifferenceApply(Bitmap Image)
        {
            try
            {
                DifferenceEdgeDetector filter = new DifferenceEdgeDetector();
                return filter.Apply(Image);
            }
            catch (Exception ex)
            {
            }

            return null;
        }

        public static Bitmap ConvertToGrayScale(Bitmap Image)
        {
            return Grayscale.CommonAlgorithms.BT709.Apply(Image);
        }

        public static Histogram GetRedImageStatistics(Bitmap Image)
        {
            ImageStatistics stat = new ImageStatistics(Image);
            return stat.Red;
        }
        public static Histogram GetGrayImageStatistics(Bitmap Image)
        {
            ImageStatistics stat = new ImageStatistics(Image);
            return stat.Gray;
        }
        public static Histogram GetGreenImageStatistics(Bitmap Image)
        {
            ImageStatistics stat = new ImageStatistics(Image);
            return stat.Green;
        }

        public static Blob[] GetBlobObjectCount(Bitmap Image)
        {
            AForge.Imaging.BlobCounter blobCounter = new BlobCounter(Image);
            Blob[] blobs = blobCounter.GetObjects(Image, true);
            return blobs;
        }
        public static Blob[] GetBlobObjectInfoCount(Bitmap Image)
        {
            AForge.Imaging.BlobCounter blobCounter = new BlobCounter();
            blobCounter.ProcessImage(Image);
            Blob[] blobs = blobCounter.GetObjectsInformation() ;
            return blobs;
        }
        public static Bitmap ApplyBlobCounter(Bitmap Image)
        {
            AForge.Imaging.Filters.ConnectedComponentsLabeling filter = new AForge.Imaging.Filters.ConnectedComponentsLabeling();
            return filter.Apply(Image);
        }

        public static Bitmap GetFFTImage(Bitmap Picture)
        {
            int Power = 8; //  
            var WH = System.Math.Pow(2, Power);

            Picture = new Bitmap(Picture, (int)WH, (int)WH);
            Picture = ConvertToGrayScale(Picture);

            //Load Image
            var output = ComplexImage.FromBitmap(Picture);

            // ' Perform FFT
            output.ForwardFourierTransform();

            //return image
            return output.ToBitmap();
        }
        public static Complex[,] GetFFTImageData(Bitmap Picture)
        {
            int Power = 8; // ' (Picture.Width / 2) / 4
            var WH = System.Math.Pow(2, Power);

            Picture = new Bitmap(Picture, (int)WH, (int)WH);
            Picture = ConvertToGrayScale(Picture);

            // 'Load Image
            var output = ComplexImage.FromBitmap(Picture);

            // ' Perform FFT
            output.ForwardFourierTransform();

            // ' return data
            return output.Data;
        }
        public static Bitmap GetFFTImageB(Bitmap Picture)
        {
            int Power = 8; // ' (Picture.Width / 2) / 4
            var WH = System.Math.Pow(2, Power);

            Picture = new Bitmap(Picture, (int)WH, (int)WH);
            Picture = ConvertToGrayScale(Picture);

            // 'Loade Image
            var output = ComplexImage.FromBitmap(Picture);

            // ' Perform FFT
            output.BackwardFourierTransform();

            // ' return image
            return output.ToBitmap();
        }
    } 

    /// <summary>
    /// Model Class for keeping properties of Identified faces
    /// </summary>
    public class ProcessData
    {
        public long OperationMilliSeconds;
        public Int16 FaceCount;
        public Rectangle[] FaceRectangles;
    }

    /// <summary>
    /// Enum list for shapes
    /// </summary>
    public enum ShapeTypes
        {
            Triangle,
            Polygon,
            Rectangle,
            Quadrilateral,
            Circle
        }

    /// <summary>
    /// Model Class for keeping properties of Identified Shapes
    /// </summary>
    public class ProcessDataShape
    {
        public long OperationMilliSeconds;
        public Int16 ShapeCount;
        public ShapeTypes ShapeType;

    }

    /// <summary>
    /// Model Class for color categorization to two
    /// </summary>
    public class ColorCounterCategory
    {
        public Color BaseColor;
        public long BaseColorCount = 0;
        public decimal BaseColorPercent = 0;
        public long OtherColorCount = 0;
    }
}
