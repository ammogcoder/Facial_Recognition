namespace WinFaceRecognition.UI
{
    partial class frmPassportValidate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPassportValidate));
            this.pnlHost = new System.Windows.Forms.Panel();
            this.pxMain = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnValidate2 = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnValidatePassport = new System.Windows.Forms.Button();
            this.pnlHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHost
            // 
            this.pnlHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHost.AutoScroll = true;
            this.pnlHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHost.Controls.Add(this.pxMain);
            this.pnlHost.Location = new System.Drawing.Point(3, 27);
            this.pnlHost.Name = "pnlHost";
            this.pnlHost.Size = new System.Drawing.Size(459, 607);
            this.pnlHost.TabIndex = 3;
            // 
            // pxMain
            // 
            this.pxMain.Location = new System.Drawing.Point(3, 3);
            this.pxMain.Name = "pxMain";
            this.pxMain.Size = new System.Drawing.Size(424, 399);
            this.pxMain.TabIndex = 0;
            this.pxMain.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfo.Location = new System.Drawing.Point(468, 27);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(414, 607);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = ".....";
            // 
            // btnValidate2
            // 
            this.btnValidate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidate2.Location = new System.Drawing.Point(637, 640);
            this.btnValidate2.Name = "btnValidate2";
            this.btnValidate2.Size = new System.Drawing.Size(245, 42);
            this.btnValidate2.TabIndex = 4;
            this.btnValidate2.Text = "Validate as Passport Image v2";
            this.btnValidate2.UseVisualStyleBackColor = true;
            this.btnValidate2.Click += new System.EventHandler(this.btnValidate2_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(6, 640);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(148, 42);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse Image ...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Process Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Source Image";
            // 
            // btnValidatePassport
            // 
            this.btnValidatePassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidatePassport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidatePassport.Location = new System.Drawing.Point(388, 640);
            this.btnValidatePassport.Name = "btnValidatePassport";
            this.btnValidatePassport.Size = new System.Drawing.Size(243, 42);
            this.btnValidatePassport.TabIndex = 9;
            this.btnValidatePassport.Text = "Validate as Passport Image v1";
            this.btnValidatePassport.UseVisualStyleBackColor = true;
            this.btnValidatePassport.Click += new System.EventHandler(this.btnValidatePassport_Click);
            // 
            // frmPassportValidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 689);
            this.Controls.Add(this.btnValidatePassport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlHost);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnValidate2);
            this.Controls.Add(this.btnBrowse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPassportValidate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Passport Validate";
            this.pnlHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHost;
        private System.Windows.Forms.PictureBox pxMain;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnValidate2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnValidatePassport;
    }
}