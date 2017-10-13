using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisonDetect1503
{
    public partial class MainForm : Form
    {
        #region properties
        uEye.Camera ids_Camera;

        int memoryID;

        bool bDirect3d = false;
        bool bOpenGL = false;

        int colorDepth; //hehe	

        uEye.Defines.ColorMode displayColorMode;
        uEye.Defines.ColorMode stealColorMode;
        #endregion

        #region Constructor of Mainform
        public MainForm()
        {
            InitializeComponent();

            btn_StopLive.Enabled = false;
            btn_Freeze.Enabled = false;
        }
        #endregion

        #region Form event
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialize the camera
            CameraInitialize();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            uEye.Defines.Status statusRet;

            statusRet = ids_Camera.Acquisition.Stop(uEye.Defines.DeviceParameter.Wait);
            statusRet = ids_Camera.Exit();
        }
        #endregion

        #region Button event
        private void btn_StartLive_Click(object sender, EventArgs e)
        {
            // Start the camera acquisition
            uEye.Defines.Status statusRet = ids_Camera.Acquisition.Capture();

            // Refresh the status of buttons
            btn_StartLive.Enabled = false;
            btn_StopLive.Enabled = true;
            btn_Freeze.Enabled = true;
        }

        private void btn_StopLive_Click(object sender, EventArgs e)
        {
            // Stop the camera acquisition
            uEye.Defines.Status status = ids_Camera.Acquisition.Stop();

            // Refresh the status of buttons
            btn_StartLive.Enabled = true;
            btn_StopLive.Enabled = false;
            btn_Freeze.Enabled = false;
        }

        private void btn_Freeze_Click(object sender, EventArgs e)
        {
            if( false == btn_StartLive.Enabled)
            {
                // Freeze the live video
                ids_Camera.Acquisition.Freeze();

                // Refresh the status of buttons
                btn_StartLive.Enabled = true;
                btn_StopLive.Enabled = false;
                btn_Freeze.Enabled = false;
            }
        }

        private void btn_Detect_Click(object sender, EventArgs e)
        {
            uEye.Defines.Status statusRet;

            if (stealColorMode.ToString() == "Mono8")
            {
                Bitmap bmp;

                // Copies the next image to the active user memory (steal function).
                statusRet = ids_Camera.DirectRenderer.StealNextFrame(uEye.Defines.DeviceParameter.Wait);
                statusRet = ids_Camera.Memory.ToBitmap(this.memoryID, out bmp);

                VisionDetector detector = new VisionDetector(bmp);
                
                detector.FindEdges((double)num_CannyThreshold.Value);
                pb_CannyEdges.Image = detector.SetEdgesCirlceROI(640, 512, (double)num_Radius.Value);
               // pb_HoughCircles.Image = detector.Findcircles((double)num_CannyThreshold.Value, (double)num_CircleAccumulator.Value);
                pb_HoughCircles.Image = detector.FindEllipseArc();

            }
        }
        #endregion   

        #region NumUpDown event
        private void num_CannyThreshold_ValueChanged(object sender, EventArgs e)
        {
            this.btn_Detect_Click(null, EventArgs.Empty);
        }

        private void num_CircleAccumulator_ValueChanged(object sender, EventArgs e)
        {
            this.btn_Detect_Click(null, EventArgs.Empty);
        }
        #endregion

        #region Self defined functions
        private void CameraInitialize()
        {
            uEye.Defines.Status statusRet;

            // Create a instance of ids camera
            ids_Camera = new uEye.Camera();

            // Open the first available camera
            statusRet = ids_Camera.Init(0, this.pb_IdsLive.Handle.ToInt32());

            if (statusRet == uEye.Defines.Status.SUCCESS)
            {
                uEye.Defines.DisplayMode supportedMode;
                statusRet = ids_Camera.DirectRenderer.GetSupported(out supportedMode);

                if ((supportedMode & uEye.Defines.DisplayMode.Direct3D) == uEye.Defines.DisplayMode.Direct3D)
                {
                    bDirect3d = true;
                    label1.Text += "bDirect3d";
                }
                else if ((supportedMode & uEye.Defines.DisplayMode.OpenGL) == uEye.Defines.DisplayMode.OpenGL)
                {
                    bOpenGL = true;
                    //MessageBox.Show("OpenGL");
                    label1.Text += "OpenGL";
                }
                else
                {
                    label1.Text += "Null";
                }
            }
            else
            {
                MessageBox.Show("Fail to open the IDS camera, please check the USB connector and reslaunch the software.");
                Close();
            }

            // Set display mode 
            if (true == bDirect3d)
            {
                statusRet = ids_Camera.Display.Mode.Set(uEye.Defines.DisplayMode.Direct3D);
            }
            else if (true == bOpenGL)
            {
                statusRet = ids_Camera.Display.Mode.Set(uEye.Defines.DisplayMode.OpenGL);
            }

            // Enables real-time scaling of the image to the size of the display window. The overlay is scaled together with the camera image.
            statusRet = ids_Camera.DirectRenderer.EnableScaling();

            // Set the color mode
            statusRet = ids_Camera.PixelFormat.Set(uEye.Defines.ColorMode.Mono8);

            // Defines the color format for the steal function
            statusRet = ids_Camera.DirectRenderer.SetStealFormat(uEye.Defines.ColorMode.Mono8);

            // Get the color format for the steal function
            statusRet = ids_Camera.DirectRenderer.GetStealFormat(out stealColorMode);
            label4.Text += stealColorMode.ToString();

            // Allocates an image memory for an image and set it active
            ids_Camera.Memory.Allocate(1280, 1024, 8, true, out memoryID);

            ids_Camera.PixelFormat.Get(out displayColorMode);
            ids_Camera.PixelFormat.GetBitsPerPixel(out colorDepth);

            label2.Text += colorDepth.ToString();
            label3.Text += displayColorMode.ToString();

            // Set overlay graphics
            SetOverlayGraphic(640.0f, 512.0f,90.0f);
        }

        private void SetOverlayGraphic(float X, float Y, float radius)
        {
            uEye.Defines.Status statusRet;

            statusRet = ids_Camera.DirectRenderer.Overlay.SetSize(1280, 1024);
            statusRet = ids_Camera.DirectRenderer.Overlay.SetPosition(0, 0);
            //statusRet = ids_Camera.DirectRenderer.Overlay.EnableSemiTransparent();

            Graphics graph;
            statusRet = ids_Camera.DirectRenderer.Overlay.GetGraphics(out graph);
            Pen bluePen = new Pen(Color.Blue, 5);

            graph.DrawLine(bluePen, new Point(640, 0), new Point(640, 1024));
            graph.DrawLine(bluePen, new Point(0, 512), new Point(1280, 512));
            graph.DrawEllipse(bluePen, X - radius, Y - radius, (float)(radius * 2.0), (float)(radius * 2.0));

            statusRet = ids_Camera.DirectRenderer.Overlay.SetGraphics(ref graph);

            statusRet = ids_Camera.DirectRenderer.Overlay.Show();
        }

        #endregion

    }
}
