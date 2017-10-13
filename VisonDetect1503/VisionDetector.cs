using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace VisonDetect1503
{
    class VisionDetector
    {
        #region Properties
        private Emgu.CV.Image<Gray ,byte> img;
        private Emgu.CV.Image<Gray, byte> imgEdges;
        private Emgu.CV.Image<Gray, byte> imgEdgesROI;
        RotatedRect rRect;
        

        #endregion

        #region Constructor
        public VisionDetector(Bitmap bmp)
        {
            img = new Emgu.CV.Image<Gray, byte>(bmp).PyrDown().PyrUp();
        }
        #endregion

        #region Canny and edge detection
        public Bitmap FindEdges(double cannyThreshold)
        {
            Bitmap bmp;

            Emgu.CV.Image<Gray, byte> edgeImage = new Emgu.CV.Image<Gray, byte>(1280, 1024);
            CvInvoke.Canny(img, edgeImage, cannyThreshold, cannyThreshold / 2.0);

            imgEdges = edgeImage;

            bmp = imgEdges.Bitmap;

            return bmp;
        }
        #endregion

        #region Hough Circle detection
        public Bitmap Findcircles(double cannyThreshold, double circleAccumulatorThreshold)
        {
            Bitmap bmp;

            CircleF[] circles = CvInvoke.HoughCircles(imgEdgesROI, HoughType.Gradient, 1.0, 5, cannyThreshold, circleAccumulatorThreshold);

            Emgu.CV.Image<Bgr, byte> imgWithCircles = img.Convert<Bgr, byte>();

            foreach(CircleF circle in circles)
            {
                imgWithCircles.Draw(circle, new Bgr(0, 0, 255), 1, LineType.EightConnected);
            }

            bmp = imgWithCircles.Bitmap;

            return bmp;
        }

        #endregion

        #region Set circle ROI
        public Bitmap SetEdgesCirlceROI(int X, int Y, double radius)
        {
            Bitmap bmp = new Bitmap(1280, 1024);

            Emgu.CV.Image<Gray, byte> imgRoi = new Emgu.CV.Image<Gray, byte>(bmp);
            imgRoi.SetZero();

            Emgu.CV.Image<Gray, byte> imgCircleFilter = new Emgu.CV.Image<Gray, byte>(1280, 1024);
            imgCircleFilter.SetZero();

            PointF centerPoint = new PointF((float)X, (float)Y);
            SizeF size = new SizeF((float)(radius * 2.0), (float)(radius * 2.0));
            Ellipse circle = new Ellipse(centerPoint, size, 0.0f);
            imgCircleFilter.Draw(circle, new Gray(255), -1, LineType.EightConnected);

            imgEdgesROI = imgEdges.And(imgCircleFilter);

            imgRoi = imgEdgesROI;
            return imgRoi.Bitmap;
            
        }
        #endregion

        #region Fit ellipse
        public Bitmap FindEllipseArc()
        {
            Bitmap bmp;

            Emgu.CV.Util.VectorOfVectorOfPoint contour = new Emgu.CV.Util.VectorOfVectorOfPoint();
            Emgu.CV.Util.VectorOfPoint arcOfEllipse = new Emgu.CV.Util.VectorOfPoint();

            List<Point> ptsOfArc = new List<Point>(); 
            
            //List<Emgu.CV.Util.VectorOfPoint> listOfArcOfEllipse = new List<Emgu.CV.Util.VectorOfPoint>();

            // Find of contours of ellipse
            CvInvoke.FindContours(imgEdgesROI, contour, null, RetrType.List, ChainApproxMethod.ChainApproxNone);

            for(int i = 0; i < contour.Size; i++)
            {
                if (contour[i].Size > 50)
                {
                    int length;
                    arcOfEllipse.Push(contour[i]);
                    //listOfArcOfEllipse.Add(contour[i]);

                    length = contour[i].Size;
    
                    //System.Windows.Forms.MessageBox.Show("Size:" + contour[i].Size.ToString());

                    /*
                    for (int j = 0; j < contour[i].Size; j++)
                    {
                        Console.WriteLine(contour[i][j].X.ToString() + "\t" + contour[i][j].Y.ToString());
                    }

                    Console.WriteLine("--------------------------------");
                    */
                }
            }
            //System.Windows.Forms.MessageBox.Show(endPtsOfArc.Count.ToString());

            rRect = CvInvoke.FitEllipse(arcOfEllipse);

            // Transfer the point vector(EMGU) to List(System) and get sorted 
            for(int i = 0; i < arcOfEllipse.Size; i++)
            {
                ptsOfArc.Add(arcOfEllipse[i]);
            }
            
            ptsOfArc.Sort(SortRadianCompare);
            
            /*
            for (int i = 0; i < ptsOfArc.Count; i++)
            {
                Console.WriteLine(ptsOfArc[i].X.ToString() + "\t" + ptsOfArc[i].Y.ToString());
            }
            */

            Point beginPoint = new Point();
            Point endPoint= new Point();

            double maxRadian = 0.0;
            // Find the gap
            for (int i = 0; i < ptsOfArc.Count - 1; i++)
            {
                double deltaY1 = (double)(ptsOfArc[i+1].Y - rRect.Center.Y);
                double deltaX1 = (double)(ptsOfArc[i+1].X - rRect.Center.X);
                double deltaY2 = (double)(ptsOfArc[i].Y - rRect.Center.Y);
                double deltaX2 = (double)(ptsOfArc[i].X - rRect.Center.X);

                if(System.Math.Atan2(deltaY1, deltaX1) - System.Math.Atan2(deltaY2, deltaX2) > maxRadian)
                {
                    maxRadian = System.Math.Atan2(deltaY1, deltaX1) - System.Math.Atan2(deltaY2, deltaX2);
                    beginPoint = ptsOfArc[i];
                    endPoint = ptsOfArc[i + 1];
                }
            }

            Emgu.CV.Image<Bgr, byte> imgWithRect = img.Convert<Bgr, byte>();

            /*
            List<Point>[] pointslistOfElliSegment = new List<Point>[listOfArcOfEllipse.Count];

            // Transfer the point vector(EMGU) to List(System) and get sorted 
            for(int i = 0; i < listOfArcOfEllipse.Count; i ++)
            {
                for(int j = 0; j < listOfArcOfEllipse[i].Size; j++)
                {
                    pointslistOfElliSegment[i].Add(listOfArcOfEllipse[i][j]);
                }

                pointslistOfElliSegment[i].Sort(SortRadianCompare);
            }
            */

            Point gapCenter = new Point( (beginPoint.X + endPoint.X)/2, (beginPoint.Y + endPoint.Y)/2);
            Point rectCenter = new Point((int)rRect.Center.X, (int)rRect.Center.Y);

            imgWithRect.Draw(new Ellipse(rRect), new Bgr(0, 0, 255), 2, LineType.EightConnected);
            imgWithRect.Draw(new LineSegment2D(gapCenter, rectCenter), new Bgr(0, 0, 255), 2, LineType.EightConnected);
            bmp = imgWithRect.Bitmap;

            return bmp;
        }
        #endregion

        /*
        
        private bool FindTheEllipseArcEndPoints(List<Point> endPts, out Point beginPoint, out Point endPoint)
        {
            List<Point> resultPoints = new List<Point>();

            for(int i = 0, j ; i < endPts.Count; i ++)
            {

                j = 0;
                for (; j < endPts.Count; j++)
                {
                    if(i != j)
                    {
                        if(DistanceOf2Points(endPts[i], endPts[j]) < 64)
                        { break; }
                    }
                }

                if(j == endPts.Count)
                {
                    resultPoints.Add(endPts[i]);
                }
            }

            System.Windows.Forms.MessageBox.Show(resultPoints.Count.ToString());

            if(resultPoints.Count == 2)
            {
                beginPoint = resultPoints[0];
                endPoint = resultPoints[1];

                return true;
            }
            else
            {
                beginPoint = Point.Empty;
                endPoint = Point.Empty;
                return false;
            }
        }
        */

        private double DistanceOf2Points(Point p1, Point p2)
        {
            return System.Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        private int SortRadianCompare(Point P1, Point P2)
        {
            double deltaY1 = (double)(P1.Y - rRect.Center.Y);
            double deltaX1 = (double)(P1.X - rRect.Center.X);
            double deltaY2 = (double)(P2.Y - rRect.Center.Y);
            double deltaX2 = (double)(P2.X - rRect.Center.X);

            if (System.Math.Atan2(deltaY1, deltaX1) == System.Math.Atan2(deltaY2, deltaX2))
            {
                return 0;
            }
            else
            {
                return System.Math.Atan2(deltaY1, deltaX1) > System.Math.Atan2(deltaY2, deltaX2) ? 1 : -1;
            }
        }

    }
}
