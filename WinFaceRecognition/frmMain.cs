using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFaceRecognition.UI;

namespace WinFaceRecognition
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        frmDetection frmDetect = new frmDetection();
        frmFilterTest frmFilter = new frmFilterTest();
        frmLiveCapture frmCapture = new frmLiveCapture();
        frmPassportValidate frmPassport = new frmPassportValidate();
        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnLiveDetection_Click(object sender, EventArgs e)
        {
            if (frmCapture == null) frmCapture = new frmLiveCapture();
            frmCapture.ShowDialog();
        }

        private void btnPassport_Click(object sender, EventArgs e)
        {
            if (frmPassport == null) frmPassport = new frmPassportValidate();
            frmPassport.ShowDialog();
        }

        private void btnDetection_Click(object sender, EventArgs e)
        {
            if (frmDetect == null) frmDetect = new frmDetection();
            frmDetect.ShowDialog();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (frmFilter == null) frmFilter = new frmFilterTest();
            frmFilter.ShowDialog();
        }
    }
}
