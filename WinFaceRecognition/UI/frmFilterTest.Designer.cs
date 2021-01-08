namespace WinFaceRecognition.UI
{
    partial class frmFilterTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilterTest));
            this.txtRes = new System.Windows.Forms.TextBox();
            this.pnlAll = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnGray = new System.Windows.Forms.Button();
            this.btnDifferenceFilter = new System.Windows.Forms.Button();
            this.btnDetectLines = new System.Windows.Forms.Button();
            this.btnDetectFace = new System.Windows.Forms.Button();
            this.btnDetectShape = new System.Windows.Forms.Button();
            this.btnDetectCorner = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFTT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRes
            // 
            this.txtRes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRes.Location = new System.Drawing.Point(1237, 92);
            this.txtRes.Multiline = true;
            this.txtRes.Name = "txtRes";
            this.txtRes.ReadOnly = true;
            this.txtRes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRes.Size = new System.Drawing.Size(314, 559);
            this.txtRes.TabIndex = 6;
            // 
            // pnlAll
            // 
            this.pnlAll.AllowDrop = true;
            this.pnlAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAll.AutoScroll = true;
            this.pnlAll.Location = new System.Drawing.Point(12, 68);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(1220, 583);
            this.pnlAll.TabIndex = 5;
            this.pnlAll.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAll_Paint);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(12, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(142, 42);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Browse Image ...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnGray
            // 
            this.btnGray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGray.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGray.Location = new System.Drawing.Point(160, 12);
            this.btnGray.Name = "btnGray";
            this.btnGray.Size = new System.Drawing.Size(142, 42);
            this.btnGray.TabIndex = 8;
            this.btnGray.Text = "Gray Filter";
            this.btnGray.UseVisualStyleBackColor = true;
            this.btnGray.Click += new System.EventHandler(this.btnGray_Click);
            // 
            // btnDifferenceFilter
            // 
            this.btnDifferenceFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDifferenceFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDifferenceFilter.Location = new System.Drawing.Point(308, 12);
            this.btnDifferenceFilter.Name = "btnDifferenceFilter";
            this.btnDifferenceFilter.Size = new System.Drawing.Size(142, 42);
            this.btnDifferenceFilter.TabIndex = 9;
            this.btnDifferenceFilter.Text = "Difference Filter";
            this.btnDifferenceFilter.UseVisualStyleBackColor = true;
            this.btnDifferenceFilter.Click += new System.EventHandler(this.btnDifferenceFilter_Click);
            // 
            // btnDetectLines
            // 
            this.btnDetectLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetectLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetectLines.Location = new System.Drawing.Point(456, 12);
            this.btnDetectLines.Name = "btnDetectLines";
            this.btnDetectLines.Size = new System.Drawing.Size(142, 42);
            this.btnDetectLines.TabIndex = 10;
            this.btnDetectLines.Text = "Detect Lines";
            this.btnDetectLines.UseVisualStyleBackColor = true;
            this.btnDetectLines.Click += new System.EventHandler(this.btnDetectLines_Click);
            // 
            // btnDetectFace
            // 
            this.btnDetectFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetectFace.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetectFace.Location = new System.Drawing.Point(604, 12);
            this.btnDetectFace.Name = "btnDetectFace";
            this.btnDetectFace.Size = new System.Drawing.Size(142, 42);
            this.btnDetectFace.TabIndex = 11;
            this.btnDetectFace.Text = "Detect Face";
            this.btnDetectFace.UseVisualStyleBackColor = true;
            this.btnDetectFace.Click += new System.EventHandler(this.btnDetectFace_Click);
            // 
            // btnDetectShape
            // 
            this.btnDetectShape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetectShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetectShape.Location = new System.Drawing.Point(752, 12);
            this.btnDetectShape.Name = "btnDetectShape";
            this.btnDetectShape.Size = new System.Drawing.Size(142, 42);
            this.btnDetectShape.TabIndex = 12;
            this.btnDetectShape.Text = "Detect Shape";
            this.btnDetectShape.UseVisualStyleBackColor = true;
            this.btnDetectShape.Click += new System.EventHandler(this.btnDetectShape_Click);
            // 
            // btnDetectCorner
            // 
            this.btnDetectCorner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetectCorner.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetectCorner.Location = new System.Drawing.Point(900, 12);
            this.btnDetectCorner.Name = "btnDetectCorner";
            this.btnDetectCorner.Size = new System.Drawing.Size(142, 42);
            this.btnDetectCorner.TabIndex = 13;
            this.btnDetectCorner.Text = "Detect Corner";
            this.btnDetectCorner.UseVisualStyleBackColor = true;
            this.btnDetectCorner.Click += new System.EventHandler(this.btnDetectCorner_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(1409, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(142, 42);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear Control";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1238, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Process Output";
            // 
            // btnFTT
            // 
            this.btnFTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFTT.Location = new System.Drawing.Point(1090, 12);
            this.btnFTT.Name = "btnFTT";
            this.btnFTT.Size = new System.Drawing.Size(142, 42);
            this.btnFTT.TabIndex = 16;
            this.btnFTT.Text = "FFT Detect";
            this.btnFTT.UseVisualStyleBackColor = true;
            this.btnFTT.Click += new System.EventHandler(this.btnFTT_Click);
            // 
            // frmFilterTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1563, 660);
            this.Controls.Add(this.btnFTT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDetectCorner);
            this.Controls.Add(this.btnDetectShape);
            this.Controls.Add(this.btnDetectFace);
            this.Controls.Add(this.btnDetectLines);
            this.Controls.Add(this.btnDifferenceFilter);
            this.Controls.Add(this.btnGray);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtRes);
            this.Controls.Add(this.pnlAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmFilterTest";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtRes;
        internal System.Windows.Forms.FlowLayoutPanel pnlAll;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnGray;
        private System.Windows.Forms.Button btnDifferenceFilter;
        private System.Windows.Forms.Button btnDetectLines;
        private System.Windows.Forms.Button btnDetectFace;
        private System.Windows.Forms.Button btnDetectShape;
        private System.Windows.Forms.Button btnDetectCorner;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFTT;
    }
}