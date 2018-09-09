using System;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace FitsViewer
{
    /*  
     *  This class handles data and operations required to read,
     *  write and modify FITS files as described in 
     *  FITS Standard version 3.0 (2010)
     * 
     *  Author: Piotr Śródka (c) 2013-2018
     */
    class FITS
    {
        public Header Header { get; set; }

        // Number format - decimal point instead of polish coma
        // NumberStyles ns = NumberStyles.Float;
        private readonly CultureInfo ci = new CultureInfo("en-US");

        public double[] PixelMap { get; set; }
        public Bitmap Bitmap { get; set; }
        public bool Scaled { get; set; }
                
        public double Mean { get; set; }
        public double Stddev { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Range { get; set; }

        public string FileName { get; set; }
        public string SafeFileName { get; set; }
        
        public FITS()
        {
            Header.Bitpix = -64;
            Header.Width = 1024;
            Header.Height = 1024;
            FileName = "empty.FITS";
            PixelMap = new double[Header.Width * Header.Height];
            Bitmap = new Bitmap(Header.Width, Header.Height);
            Scaled = false;
        }

        public FITS(FITS that)
        {
            Header.Bitpix = that.Header.Bitpix;
            Header.Width = that.Header.Width;
            Header.Height = that.Header.Height;
            FileName = that.FileName;
            PixelMap = new double[Header.Width * Header.Height];

            for (int i = 0; i < Header.Width * Header.Height; i++)
            {
                PixelMap[i] = that.PixelMap[i];
            }

            Bitmap = new Bitmap(that.Bitmap);
            Scaled = that.Scaled;
        }

        public FITS(int _bitpix, int _width, int _height, string _fileName)
        {
            Header.Bitpix = _bitpix;
            Header.Width = _width;
            Header.Height = _height;
            FileName = _fileName;
            PixelMap = new double[_width * _height];
            Bitmap = new Bitmap(_width, _height);
            Scaled = false;
        }

        public FITS(string fileName)
        {
            Header = new Header(fileName);

            if (Header.Text.Length == 0) return;

            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var binaryReader = new BinaryReader(fileStream);

            try
            {
                binaryReader.BaseStream.Position = Header.dataBegin;
                FillPixelMap(binaryReader);
            }
            finally
            {
                binaryReader.Close();
                fileStream.Close();
            }
        }

        private void FillPixelMap(BinaryReader br)
        {
            PixelMap = new double[Header.Width * Header.Height];
            Min = double.MaxValue;
            Max = double.MinValue;
            double actual;
            double sum = 0.0;

            for (int h = 0; h < Header.Height; h++)
            {
                for (int w = 0; w < Header.Width; w++)
                {
                    actual = GetNextChunk(br, Header.Bitpix);
                    actual += Header.Bzero;
                    PixelMap[h * Header.Width + w] = actual;
                    sum += actual;
                    if (actual > Max) Max = actual;
                    if (actual < Min) Min = actual;
                }
            }

            Range = Max - Min;
            Mean = sum / (Header.Width * Header.Height);
            Stddev = ImageStdDev(Mean);
        }

        private double GetNextChunk(BinaryReader binaryReader, int bitpix)
        {
            byte[] oneNumber = new byte[8];

            for (int i = Math.Abs(bitpix / 8) - 1; i >= 0; i--)
            {
                oneNumber[i] = binaryReader.ReadByte();
            }

            switch (bitpix)
            {
                case 8:
                    return oneNumber[0];
                case 16:
                    return BitConverter.ToInt16(oneNumber, 0);
                case 32:
                    return BitConverter.ToInt32(oneNumber, 0);
                case 64:
                    return BitConverter.ToInt64(oneNumber, 0);
                case -32:
                    return BitConverter.ToSingle(oneNumber, 0);
                case -64:
                    return BitConverter.ToDouble(oneNumber, 0);
            }

            return double.NaN;
        }

        public double ImageStdDev(double mean)
        {
            int size = Header.Width * Header.Height;

            if ((size == 0) || double.IsNaN(mean)) return double.NaN;

            double result = 0.0;
            double diff;

            for (int i = 0; i < size; i++)
            {
                diff = (PixelMap[i] - mean);
                result += (diff * diff);
            }

            result = result / size;

            return Math.Sqrt(result);
        }
    }
}
