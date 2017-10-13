namespace VisonDetect1503
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_StartLive = new System.Windows.Forms.Button();
            this.pb_IdsLive = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_StopLive = new System.Windows.Forms.Button();
            this.btn_Freeze = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Detect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pb_CannyEdges = new System.Windows.Forms.PictureBox();
            this.num_CannyThreshold = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.pb_HoughCircles = new System.Windows.Forms.PictureBox();
            this.num_CircleAccumulator = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.num_Radius = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pb_IdsLive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CannyEdges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_CannyThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_HoughCircles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_CircleAccumulator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Radius)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_StartLive
            // 
            this.btn_StartLive.Location = new System.Drawing.Point(984, 12);
            this.btn_StartLive.Name = "btn_StartLive";
            this.btn_StartLive.Size = new System.Drawing.Size(120, 60);
            this.btn_StartLive.TabIndex = 0;
            this.btn_StartLive.Text = "Start Live";
            this.btn_StartLive.UseVisualStyleBackColor = true;
            this.btn_StartLive.Click += new System.EventHandler(this.btn_StartLive_Click);
            // 
            // pb_IdsLive
            // 
            this.pb_IdsLive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_IdsLive.Location = new System.Drawing.Point(658, 12);
            this.pb_IdsLive.Name = "pb_IdsLive";
            this.pb_IdsLive.Size = new System.Drawing.Size(320, 256);
            this.pb_IdsLive.TabIndex = 1;
            this.pb_IdsLive.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(982, 471);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Display Mode: ";
            // 
            // btn_StopLive
            // 
            this.btn_StopLive.Location = new System.Drawing.Point(984, 79);
            this.btn_StopLive.Name = "btn_StopLive";
            this.btn_StopLive.Size = new System.Drawing.Size(120, 60);
            this.btn_StopLive.TabIndex = 3;
            this.btn_StopLive.Text = "Stop Live";
            this.btn_StopLive.UseVisualStyleBackColor = true;
            this.btn_StopLive.Click += new System.EventHandler(this.btn_StopLive_Click);
            // 
            // btn_Freeze
            // 
            this.btn_Freeze.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Freeze.Location = new System.Drawing.Point(984, 146);
            this.btn_Freeze.Name = "btn_Freeze";
            this.btn_Freeze.Size = new System.Drawing.Size(120, 60);
            this.btn_Freeze.TabIndex = 4;
            this.btn_Freeze.Text = "Freeze";
            this.btn_Freeze.UseVisualStyleBackColor = true;
            this.btn_Freeze.Click += new System.EventHandler(this.btn_Freeze_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(982, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Color Depth: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(982, 495);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Color Mode: ";
            // 
            // btn_Detect
            // 
            this.btn_Detect.Location = new System.Drawing.Point(984, 213);
            this.btn_Detect.Name = "btn_Detect";
            this.btn_Detect.Size = new System.Drawing.Size(120, 60);
            this.btn_Detect.TabIndex = 7;
            this.btn_Detect.Text = "Detect";
            this.btn_Detect.UseVisualStyleBackColor = true;
            this.btn_Detect.Click += new System.EventHandler(this.btn_Detect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(982, 507);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Steal Mode: ";
            // 
            // pb_CannyEdges
            // 
            this.pb_CannyEdges.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_CannyEdges.Location = new System.Drawing.Point(658, 268);
            this.pb_CannyEdges.Name = "pb_CannyEdges";
            this.pb_CannyEdges.Size = new System.Drawing.Size(320, 256);
            this.pb_CannyEdges.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_CannyEdges.TabIndex = 9;
            this.pb_CannyEdges.TabStop = false;
            // 
            // num_CannyThreshold
            // 
            this.num_CannyThreshold.Location = new System.Drawing.Point(984, 308);
            this.num_CannyThreshold.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_CannyThreshold.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_CannyThreshold.Name = "num_CannyThreshold";
            this.num_CannyThreshold.Size = new System.Drawing.Size(120, 21);
            this.num_CannyThreshold.TabIndex = 10;
            this.num_CannyThreshold.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.num_CannyThreshold.ValueChanged += new System.EventHandler(this.num_CannyThreshold_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(984, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Canny Threshold:";
            // 
            // pb_HoughCircles
            // 
            this.pb_HoughCircles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_HoughCircles.Location = new System.Drawing.Point(12, 12);
            this.pb_HoughCircles.Name = "pb_HoughCircles";
            this.pb_HoughCircles.Size = new System.Drawing.Size(640, 512);
            this.pb_HoughCircles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_HoughCircles.TabIndex = 12;
            this.pb_HoughCircles.TabStop = false;
            // 
            // num_CircleAccumulator
            // 
            this.num_CircleAccumulator.Location = new System.Drawing.Point(984, 351);
            this.num_CircleAccumulator.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_CircleAccumulator.Name = "num_CircleAccumulator";
            this.num_CircleAccumulator.Size = new System.Drawing.Size(120, 21);
            this.num_CircleAccumulator.TabIndex = 13;
            this.num_CircleAccumulator.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.num_CircleAccumulator.ValueChanged += new System.EventHandler(this.num_CircleAccumulator_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(984, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "Circle Accumulator:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(986, 379);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "Radius Threshold:";
            // 
            // num_Radius
            // 
            this.num_Radius.Location = new System.Drawing.Point(984, 394);
            this.num_Radius.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.num_Radius.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_Radius.Name = "num_Radius";
            this.num_Radius.Size = new System.Drawing.Size(120, 21);
            this.num_Radius.TabIndex = 16;
            this.num_Radius.Value = new decimal(new int[] {
            93,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 536);
            this.Controls.Add(this.num_Radius);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.num_CircleAccumulator);
            this.Controls.Add(this.pb_HoughCircles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.num_CannyThreshold);
            this.Controls.Add(this.pb_CannyEdges);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Detect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Freeze);
            this.Controls.Add(this.btn_StopLive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_IdsLive);
            this.Controls.Add(this.btn_StartLive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Vison Detect 1503";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_IdsLive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CannyEdges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_CannyThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_HoughCircles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_CircleAccumulator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Radius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_StartLive;
        private System.Windows.Forms.PictureBox pb_IdsLive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_StopLive;
        private System.Windows.Forms.Button btn_Freeze;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Detect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pb_CannyEdges;
        private System.Windows.Forms.NumericUpDown num_CannyThreshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pb_HoughCircles;
        private System.Windows.Forms.NumericUpDown num_CircleAccumulator;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown num_Radius;
    }
}

