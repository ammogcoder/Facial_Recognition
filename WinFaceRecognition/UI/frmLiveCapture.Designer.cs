namespace WinFaceRecognition.UI
{
    partial class frmLiveCapture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLiveCapture));
            this.ImageCaptured = new System.Windows.Forms.PictureBox();
            this.vspCapture = new AForge.Controls.VideoSourcePlayer();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.btnStopCamera = new System.Windows.Forms.Button();
            this.btnCaptureImage = new System.Windows.Forms.Button();
            this.btnStartCamera = new System.Windows.Forms.Button();
            this.chkDetectFace = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCaptured)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageCaptured
            // 
            this.ImageCaptured.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageCaptured.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImageCaptured.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageCaptured.Location = new System.Drawing.Point(31, 71);
            this.ImageCaptured.Name = "ImageCaptured";
            this.ImageCaptured.Size = new System.Drawing.Size(453, 291);
            this.ImageCaptured.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageCaptured.TabIndex = 14;
            this.ImageCaptured.TabStop = false;
            // 
            // vspCapture
            // 
            this.vspCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.vspCapture.Location = new System.Drawing.Point(31, 71);
            this.vspCapture.Name = "vspCapture";
            this.vspCapture.Size = new System.Drawing.Size(453, 291);
            this.vspCapture.TabIndex = 9;
            this.vspCapture.Text = "VideoSourcePlayer1";
            this.vspCapture.VideoSource = null;
            // 
            // cmbCamera
            // 
            this.cmbCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Location = new System.Drawing.Point(31, 368);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(451, 24);
            this.cmbCamera.TabIndex = 10;
            this.cmbCamera.SelectedIndexChanged += new System.EventHandler(this.cmbCamera_SelectedIndexChanged);
            // 
            // btnStopCamera
            // 
            this.btnStopCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopCamera.Enabled = false;
            this.btnStopCamera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopCamera.ImageKey = "005-stop-2.png";
            this.btnStopCamera.Location = new System.Drawing.Point(267, 414);
            this.btnStopCamera.Name = "btnStopCamera";
            this.btnStopCamera.Padding = new System.Windows.Forms.Padding(27, 0, 27, 0);
            this.btnStopCamera.Size = new System.Drawing.Size(215, 46);
            this.btnStopCamera.TabIndex = 12;
            this.btnStopCamera.Text = "Stop";
            this.btnStopCamera.UseVisualStyleBackColor = true;
            this.btnStopCamera.Click += new System.EventHandler(this.btnStopCamera_Click);
            // 
            // btnCaptureImage
            // 
            this.btnCaptureImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCaptureImage.Enabled = false;
            this.btnCaptureImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaptureImage.ImageKey = "004-capture.png";
            this.btnCaptureImage.Location = new System.Drawing.Point(31, 482);
            this.btnCaptureImage.Name = "btnCaptureImage";
            this.btnCaptureImage.Padding = new System.Windows.Forms.Padding(27, 0, 27, 0);
            this.btnCaptureImage.Size = new System.Drawing.Size(451, 45);
            this.btnCaptureImage.TabIndex = 13;
            this.btnCaptureImage.Text = "Capture Image";
            this.btnCaptureImage.UseVisualStyleBackColor = true;
            this.btnCaptureImage.Click += new System.EventHandler(this.btnCaptureImage_Click);
            // 
            // btnStartCamera
            // 
            this.btnStartCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartCamera.Enabled = false;
            this.btnStartCamera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartCamera.ImageKey = "010-play-button-sing.png";
            this.btnStartCamera.Location = new System.Drawing.Point(31, 414);
            this.btnStartCamera.Name = "btnStartCamera";
            this.btnStartCamera.Padding = new System.Windows.Forms.Padding(28, 0, 28, 0);
            this.btnStartCamera.Size = new System.Drawing.Size(230, 46);
            this.btnStartCamera.TabIndex = 11;
            this.btnStartCamera.Text = "Start";
            this.btnStartCamera.UseVisualStyleBackColor = true;
            this.btnStartCamera.Click += new System.EventHandler(this.btnStartCamera_Click);
            // 
            // chkDetectFace
            // 
            this.chkDetectFace.AutoSize = true;
            this.chkDetectFace.Location = new System.Drawing.Point(31, 44);
            this.chkDetectFace.Name = "chkDetectFace";
            this.chkDetectFace.Size = new System.Drawing.Size(106, 21);
            this.chkDetectFace.TabIndex = 15;
            this.chkDetectFace.Text = "Detect Face";
            this.chkDetectFace.UseVisualStyleBackColor = true;
            // 
            // frmLiveCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 637);
            this.Controls.Add(this.chkDetectFace);
            this.Controls.Add(this.ImageCaptured);
            this.Controls.Add(this.vspCapture);
            this.Controls.Add(this.cmbCamera);
            this.Controls.Add(this.btnStopCamera);
            this.Controls.Add(this.btnCaptureImage);
            this.Controls.Add(this.btnStartCamera);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLiveCapture";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Live Capture";
            this.Load += new System.EventHandler(this.frmLiveCapture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageCaptured)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox ImageCaptured;
        internal AForge.Controls.VideoSourcePlayer vspCapture;
        internal System.Windows.Forms.ComboBox cmbCamera;
        internal System.Windows.Forms.Button btnStopCamera;
        internal System.Windows.Forms.Button btnCaptureImage;
        internal System.Windows.Forms.Button btnStartCamera;
        private System.Windows.Forms.CheckBox chkDetectFace;
    }
}