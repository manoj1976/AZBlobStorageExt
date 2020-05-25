using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormProj_ForTesting
{
    public partial class Form1 : Form
    {
        BLOBStorageMgmt.BLOBStorageMgmt blobStorageMgmt = new BLOBStorageMgmt.BLOBStorageMgmt("DefaultEndpointsProtocol=https;AccountName=manojstorageac;AccountKey=oof6WRupsTtJZcYDv7+zsRHGKsP2aMAi2HhD6p5OozGuI/A0JAGB96307nQjRhClc9m0KYj54To3zMjIaEublA==;EndpointSuffix=core.windows.net");


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             blobStorageMgmt.UploadFile(@"c:\Temp\test.xml", @"test.xml", "input");
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            blobStorageMgmt.DownloadFile(@"test.xml", @"c:\Temp\test2.xml", "input");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            blobStorageMgmt.DownloadAndDeleteFile(@"test.xml", @"c:\Temp\test2.xml", "input");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            blobStorageMgmt.RenameFile(@"test.xml", @"Newtest.xml", "input");
        }
    }
}
