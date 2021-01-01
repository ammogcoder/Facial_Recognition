namespace WinFaceRecognition
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tbMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnPassport = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnLiveDetection = new System.Windows.Forms.Button();
            this.btnDetection = new System.Windows.Forms.Button();
            this.tbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.ColumnCount = 2;
            this.tbMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbMain.Controls.Add(this.btnPassport, 1, 1);
            this.tbMain.Controls.Add(this.btnFilter, 0, 1);
            this.tbMain.Controls.Add(this.btnLiveDetection, 1, 0);
            this.tbMain.Controls.Add(this.btnDetection, 0, 0);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.Padding = new System.Windows.Forms.Padding(25);
            this.tbMain.RowCount = 2;
            this.tbMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbMain.Size = new System.Drawing.Size(803, 486);
            this.tbMain.TabIndex = 0;
            // 
            // btnPassport
            // 
            this.btnPassport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPassport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassport.Location = new System.Drawing.Point(404, 246);
            this.btnPassport.Name = "btnPassport";
            this.btnPassport.Size = new System.Drawing.Size(371, 212);
            this.btnPassport.TabIndex = 3;
            this.btnPassport.Text = "Passport Validator";
            this.btnPassport.UseVisualStyleBackColor = true;
            this.btnPassport.Click += new System.EventHandler(this.btnPassport_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(28, 246);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(370, 212);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filter Demo";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnLiveDetection
            // 
            this.btnLiveDetection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLiveDetection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiveDetection.Location = new System.Drawing.Point(404, 28);
            this.btnLiveDetection.Name = "btnLiveDetection";
            this.btnLiveDetection.Size = new System.Drawing.Size(371, 212);
            this.btnLiveDetection.TabIndex = 1;
            this.btnLiveDetection.Text = "Face Live Detection";
            this.btnLiveDetection.UseVisualStyleBackColor = true;
            this.btnLiveDetection.Click += new System.EventHandler(this.btnLiveDetection_Click);
            // 
            // btnDetection
            // 
            this.btnDetection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDetection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetection.Location = new System.Drawing.Point(28, 28);
            this.btnDetection.Name = "btnDetection";
            this.btnDetection.Size = new System.Drawing.Size(370, 212);
            this.btnDetection.TabIndex = 0;
            this.btnDetection.Text = "Object/Face Detection";
            this.btnDetection.UseVisualStyleBackColor = true;
            this.btnDetection.Click += new System.EventHandler(this.btnDetection_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 486);
            this.Controls.Add(this.tbMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tbMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbMain;
        private System.Windows.Forms.Button btnPassport;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnLiveDetection;
        private System.Windows.Forms.Button btnDetection;
    }
}

