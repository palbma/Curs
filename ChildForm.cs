using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KURS1
{
    public partial class ChildForm : Form
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ImageFormat { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public float HorizontalResolution { get; set; }
        public float VerticalResolution { get; set; }
        public float PhysicalWidth { get; set; }
        public float PhysicalHeight { get; set; }
        public string PixelFormat { get; set; }
        public string Transparency { get; set; }
        public int BitsPerPixel { get; set; }
        public ChildForm()
        {
            InitializeComponent();
        }
    }
}
