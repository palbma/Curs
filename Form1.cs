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

        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = new ChildForm();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.png;*.gif;*.tiff";
            openFileDialog.Title = "Выберите изображение";

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
                // Отримуємо кількість біт на піксель
                System.Drawing.Imaging.PixelFormat format = childForm.BackgroundImage.PixelFormat;
                childForm.BitsPerPixel = Image.GetPixelFormatSize(format);

                bool usesTransparency = format.HasFlag(System.Drawing.Imaging.PixelFormat.Alpha);
                childForm.Transparency = usesTransparency ? "Так" : "Ні";
            }
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null && ActiveMdiChild is ChildForm)
            {
                ChildForm childForm = (ChildForm)ActiveMdiChild;
                SaveImage(childForm.BackgroundImage);
            }
        }

        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null && ActiveMdiChild is ChildForm)
            {
                ChildForm childForm = (ChildForm)ActiveMdiChild;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "BMP|*.bmp|JPEG|*.jpg|PNG|*.png|GIF|*.gif|TIFF|*.tiff";
                saveFileDialog.Title = "Сохранить изображение как";

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

        private void закритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ChildForm childForm = (ChildForm)ActiveMdiChild;
                childForm.Close();
            }
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
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
                saveFileDialog.Title = "Сохранить изображение";

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

        private void інформаціяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Перевірка чи є активне дочірнє вікно
            if (ActiveMdiChild != null && ActiveMdiChild is ChildForm)
            {
                ChildForm activeChildForm = (ChildForm)ActiveMdiChild;

                // Отримання інформації про зображення з активного дочірнього вікна
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

                // Виведення інформації користувачеві
                MessageBox.Show(
                    $"Ім'я файлу: {fileName}\n" +
                    $"Шлях до файлу: {filePath}\n" +
                    $"Формат файлу: {format}\n" +
                    $"Розмір (ширина x висота): {width} x {height} пікселів\n" +
                    $"Вертикальна роздільна здатність: {verticalResolution} точок на сантиметр\n" +
                    $"Горизонтальна роздільна здатність: {horizontalResolution} точок на сантиметр\n" +
                    $"Фізичні розміри (ширина x висота): {physicalWidth} см x {physicalHeight} см\n" +
                    $"Використаний формат пікселів: {pixelFormat}\n" +
                    $"Використання біта або байта прозорості: {transparency}\n" +
                    $"Число біт на піксель: {bitsPerPixel}"
                    );
            }
            else
            {
                MessageBox.Show("Немає активного дочірнього вікна або воно не є формою ChildForm.");
            }
        }
    }
}
