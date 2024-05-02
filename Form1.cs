using System.Drawing.Imaging;

namespace KURS1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = new ChildForm();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.png;*.gif;*.tiff";
            openFileDialog.Title = "�������� �����������";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ChildForm childForm = new ChildForm();
                childForm.MdiParent = this;
                childForm.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                childForm.Show();

                childForm.FileName = Path.GetFileName(openFileDialog.FileName);
                childForm.FilePath = openFileDialog.FileName;
                childForm.ImageFormat = Path.GetExtension(openFileDialog.FileName);
                childForm.ImageWidth = childForm.BackgroundImage.Width;
                childForm.ImageHeight = childForm.BackgroundImage.Height;
                childForm.HorizontalResolution = childForm.BackgroundImage.HorizontalResolution;
                childForm.VerticalResolution = childForm.BackgroundImage.VerticalResolution;
                childForm.PhysicalWidth = childForm.BackgroundImage.PhysicalDimension.Width;
                childForm.PhysicalHeight = childForm.BackgroundImage.PhysicalDimension.Height;
                childForm.PixelFormat = childForm.BackgroundImage.PixelFormat.ToString();
                // �������� ������� �� �� ������
                System.Drawing.Imaging.PixelFormat format = childForm.BackgroundImage.PixelFormat;
                childForm.BitsPerPixel = Image.GetPixelFormatSize(format);

                bool usesTransparency = format.HasFlag(System.Drawing.Imaging.PixelFormat.Alpha);
                childForm.Transparency = usesTransparency ? "���" : "ͳ";
            }
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null && ActiveMdiChild is ChildForm)
            {
                ChildForm childForm = (ChildForm)ActiveMdiChild;
                SaveImage(childForm.BackgroundImage);
            }
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null && ActiveMdiChild is ChildForm)
            {
                ChildForm childForm = (ChildForm)ActiveMdiChild;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "BMP|*.bmp|JPEG|*.jpg|PNG|*.png|GIF|*.gif|TIFF|*.tiff";
                saveFileDialog.Title = "��������� ����������� ���";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    ImageFormat format = ImageFormat.Bmp;

                    switch (Path.GetExtension(fileName).ToLower())
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        case ".gif":
                            format = ImageFormat.Gif;
                            break;
                        case ".tiff":
                            format = ImageFormat.Tiff;
                            break;
                    }

                    childForm.BackgroundImage.Save(fileName, format);
                }
            }
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ChildForm childForm = (ChildForm)ActiveMdiChild;
                childForm.Close();
            }
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in MdiChildren)
            {
                form.Close();
            }
            Application.Exit();

        }
        private void SaveImage(Image image)
        {
            if (image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "BMP|*.bmp|JPEG|*.jpg|PNG|*.png|GIF|*.gif|TIFF|*.tiff";
                saveFileDialog.Title = "��������� �����������";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    ImageFormat format = ImageFormat.Bmp;

                    switch (Path.GetExtension(fileName).ToLower())
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        case ".gif":
                            format = ImageFormat.Gif;
                            break;
                        case ".tiff":
                            format = ImageFormat.Tiff;
                            break;
                    }

                    image.Save(fileName, format);
                }
            }
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �������� �� � ������� ������ ����
            if (ActiveMdiChild != null && ActiveMdiChild is ChildForm)
            {
                ChildForm activeChildForm = (ChildForm)ActiveMdiChild;

                // ��������� ���������� ��� ���������� � ��������� ���������� ����
                string fileName = activeChildForm.FileName;
                string filePath = activeChildForm.FilePath;
                string format = activeChildForm.ImageFormat;
                int width = activeChildForm.ImageWidth;
                int height = activeChildForm.ImageHeight;
                float horizontalResolution = activeChildForm.HorizontalResolution;
                float verticalResolution = activeChildForm.VerticalResolution;
                float physicalWidth = activeChildForm.PhysicalWidth;
                float physicalHeight = activeChildForm.PhysicalHeight;
                string pixelFormat = activeChildForm.PixelFormat;
                string transparency = activeChildForm.Transparency;
                int bitsPerPixel = activeChildForm.BitsPerPixel;

                // ��������� ���������� ������������
                MessageBox.Show(
                    $"��'� �����: {fileName}\n" +
                    $"���� �� �����: {filePath}\n" +
                    $"������ �����: {format}\n" +
                    $"����� (������ x ������): {width} x {height} ������\n" +
                    $"����������� �������� ��������: {verticalResolution} ����� �� ���������\n" +
                    $"������������� �������� ��������: {horizontalResolution} ����� �� ���������\n" +
                    $"Գ���� ������ (������ x ������): {physicalWidth} �� x {physicalHeight} ��\n" +
                    $"������������ ������ ������: {pixelFormat}\n" +
                    $"������������ ��� ��� ����� ���������: {transparency}\n" +
                    $"����� �� �� ������: {bitsPerPixel}"
                    );
            }
            else
            {
                MessageBox.Show("���� ��������� ���������� ���� ��� ���� �� � ������ ChildForm.");
            }
        }
    }
}
