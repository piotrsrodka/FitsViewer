using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FitsViewer
{
    public partial class ViewForm : Form
    {
        private FITS _fits;
        private bool _headerMode = false;
        private string _dir;
        private string[] _files;
        private int _currentFile;

        public ViewForm(string[] args)
        {
            InitializeComponent();

            if (args.Length > 0)
            {
                _dir = Path.GetDirectoryName(args[0]);
                _files = Directory.GetFiles(_dir, "*.fits", SearchOption.TopDirectoryOnly);
                _currentFile = Array.IndexOf(_files, args[0]);
                DisplaySelectedImage(args[0]);
            }
        }

        private void DisplaySelectedImage(string fileName)
        {
            _fits = new FITS(fileName);

            if (!_headerMode)
            {
                Scale();
                pictureBox.Image = _fits.Bitmap;
            }

            textBoxHeader.Text = _fits.Header.Text;
            toolStripStatusLabel.Text = Path.GetFileName(fileName);
        }

        private void Scale()
        {
            if (!_fits.Scaled) ZScale(_fits);
        }

        // scale data to bitmap. Zscale, if that is possible.
        private void ZScale(FITS fits) 
        {
            int width = fits.Header.Width;
            int height = fits.Header.Height;
            int size = width * height;

            fits.Bitmap = new Bitmap(width, height);

            float contrast = 0.25f;

            int NSample = Math.Min(size / 10, 10000);

            int NRows = height / 15;

            int[] SubSampleX = new int[NSample];
            int[] SubSampleY = new int[NSample];

            double[] SubSample = new double[NSample];
            double[] SubSampleSorted = new double[NSample];

            Random random = new Random(DateTime.Now.Millisecond);

            for (int cell = 0; cell < NSample; cell++)
            {
                int X = SubSampleX[cell] = random.Next(1, width - 1);
                int Y = SubSampleY[cell] = random.Next(1, height - 1);
                SubSample[cell] = fits.PixelMap[X + Y * width];
            }

            float[] tmp = new float[NSample];

            SubSample.CopyTo(SubSampleSorted, 0);

            Array.Sort(SubSampleSorted);

            double zmin = SubSampleSorted[0];
            double zmed = SubSampleSorted[NSample / 2];
            double zmax = SubSampleSorted[NSample - 1];

            int midPoint = NSample / 2;

            double Sx = 0.5f * NSample * (NSample - 1);
            double Sy = SubSampleSorted.Sum();
            double Sxx = Count_Sxx(SubSampleSorted);
            double Sxy = Count_Sxy(SubSampleSorted);

            double a = (NSample * Sxy - Sx * Sy) / (NSample * Sxx - Sx * Sx);
            double b = (Sy - a * Sx) / NSample;

            a /= contrast;

            double scale;
            double value;

            // The minimum value to use for display scaling
            float z1 = Math.Max((float)fits.Min, (float)(zmed - midPoint * a));

            // The maximum value to use for display scaling
            float z2 = Math.Min((float)fits.Max, (float)(zmed + midPoint * a)); 

            fits.Range = Math.Abs(z2 - z1);

            if (fits.Range < float.Epsilon)
            {
                scale = 0.0;
            }
            else
            {
                scale = byte.MaxValue / fits.Range;
            }

            Color newColor;
            byte byteValue;

            double temp;

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    value = fits.PixelMap[w + h * width];

                    /* Min - max scaling --------------------------------*/
                    temp = (value - z1) * scale;

                    if (temp > 255.0)
                    {
                        byteValue = 255;
                    }
                    else
                    {
                        byteValue = (byte)temp;
                    }
                    /* _________________________________________________ */

                    newColor = Color.FromArgb(byteValue, byteValue, byteValue);

                    fits.Bitmap.SetPixel(width - w - 1, height - h - 1, newColor);
                }
            }

            fits.Scaled = true;
        }

        private double Count_Sxx(double[] array)
        {
            double result = 0.0;

            int n = array.Length;

            for (int i = 0; i < n; i++)
            {
                result += i * i;
            }

            return result;
        }

        private double Count_Sxy(double[] array)
        {
            double result = 0.0;

            int n = array.Length;

            for (int i = 0; i < n; i++)
            {
                result += array[i] * i;
            }

            return result;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string[] fileNames = openFileDialog.FileNames;
            string[] safeFileNames = openFileDialog.SafeFileNames;

            _dir = Path.GetDirectoryName(fileNames[0]);

            if (fileNames.Length < 2)
            {
                _files = Directory.GetFiles(_dir, "*.fits", SearchOption.TopDirectoryOnly);
            }
            else
            {
                _files = fileNames;
            }

            _currentFile = Array.IndexOf(_files, fileNames[0]);
            DisplaySelectedImage(fileNames[0]);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void Next()
        {
            if (_files == null) return;
            if (_currentFile < _files.Length - 1) _currentFile++;
            else _currentFile = 0;
            DisplaySelectedImage(_files[_currentFile]);
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            Prev();
        }

        private void Prev()
        {
            if (_files == null) return;
            if (_currentFile >= 1 && _currentFile < _files.Length) _currentFile--;
            else _currentFile = _files.Length - 1;
            DisplaySelectedImage(_files[_currentFile]);
        }

        private void buttonHeader_Click(object sender, EventArgs e)
        {
            if (_fits == null) return;

            flipDataHeader();
        }

        private void flipDataHeader()
        {
            if (!_headerMode)
            {
                textBoxHeader.Visible = true;
                textBoxHeader.ReadOnly = true;
                _headerMode = true;
            }
            else
            {
                if (!_fits.Scaled)
                {
                    Scale();
                    pictureBox.Image = _fits.Bitmap;
                }

                textBoxHeader.Visible = false;
                _headerMode = false;
            }
        }

        /* Magic new function - works like a charm */
        protected override bool ProcessDialogKey(Keys k)
        {
            switch (k)
            {
                case Keys.Right:
                    Next();
                    return true;
                case Keys.Left:
                    Prev();
                    return true;
                default:
                    return false;
            }
        }
    }
}
