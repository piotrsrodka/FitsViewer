using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FitsViewer
{
    class Header
    {
        // Number format - decimal point instead of polish coma
        readonly NumberStyles ns = NumberStyles.Float;
        readonly CultureInfo ci = new CultureInfo("en-US");

        // Few header constants
        private const char keyValueSeparator = '=';
        private const char commentChar = '/';
        private const  int lineWidth = 80;
        private const  int LinesPerSection = 36;   // lines per Section - FITS standard            
        private const  int Section = lineWidth * LinesPerSection;    // = 2880

        // Header
        public string Text { get; set; }
        public int dataBegin;
        public List<HeaderRecord> HeaderKeyList { get; set; }

        /* Obligatory header keywords */
        public bool Simple  { get; set; }     // Simple: True if conforms to standard described in FITS Standard v 3.0 (2010)
        public  int Bitpix  { get; set; }     // number of bits per pixel                
        public  int Naxis   { get; set; }     // NAXIS - number of axes                
        public  int Width   { get; set; }     // NAXIS1 - varies most rapidly                
        public  int Height  { get; set; }     // NAXIS2 - varies next most rapidly
        
        /* Optional header keywords */        
        public double Bzero { get; set; }// BZERO and BSCALE keywords        
        public double Bscale { get; set; }// RealValue = bscale * value + bzero

        public Header(string fileName)
        {
            Bzero = double.NaN;
            Bscale = double.NaN;
            const int MAX_NR_OF_SECTIONS = 20;    // Reasonable maximum number of sections in one FITS file
            char[] buffer = new char[lineWidth];
            StringBuilder sb = new StringBuilder();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            HeaderKeyList = new List<HeaderRecord>();

            try
            {
                for (int line = 0; line < MAX_NR_OF_SECTIONS * LinesPerSection; line++)
                {
                    Array.Clear(buffer, 0, lineWidth);
                    sr.Read(buffer, 0, lineWidth);

                    string OneLine = new string(buffer);
                    sb.Append(OneLine);
                    sb.Append(Environment.NewLine);
                                        
                    if (OneLine.Trim().ToUpper() == "END")
                    {
                        Text = sb.ToString();

                        // Add Record (keyword, value, comment) to HeaderKeyList
                        HeaderRecord EndHR = new HeaderRecord("END", "", "");
                        HeaderKeyList.Add(EndHR);

                        dataBegin = lineWidth * line;
                        if (dataBegin % Section != 0)
                        {
                            int NrOfSections = dataBegin / Section;
                            dataBegin = (NrOfSections + 1) * Section;
                        }

                        return;
                    }
                    
                    // Split line into KEYWORD, VALUE, COMMENT
                    string[] lineSplit = OneLine.Split(keyValueSeparator);

                    string key = lineSplit[0];
                    string value = string.Empty;
                    string comment = string.Empty;

                    if (lineSplit.Count() >= 2)
                    {
                        string[] valueSplit = lineSplit[1].Split(commentChar);

                        value = valueSplit[0].Trim();

                        if (valueSplit.Count() >= 2)
                        {
                            comment = valueSplit[1];
                        }
                    }

                    // Add Record (nr, keyword, value, comment) to HeaderKeyList
                    HeaderRecord HR = new HeaderRecord(key, value, comment);
                    HeaderKeyList.Add(HR);

                    int intTmp;
                    double doubleTmp;

                    // Handle obligatory keywords
                    switch (key.ToUpper().Trim())
                    {
                        case "SIMPLE":
                            Simple = (value.ToUpper().Trim() == "T") ? true : false;
                            break;
                        case "BITPIX":
                            int.TryParse(value, out intTmp);
                            Bitpix = intTmp;
                            break;
                        case "NAXIS":
                            int.TryParse(value, out intTmp);
                            Naxis = intTmp;
                            break;
                        case "NAXIS1":
                            int.TryParse(value, out intTmp);
                            Width = intTmp;
                            break;
                        case "NAXIS2":
                            int.TryParse(value, out intTmp);
                            Height = intTmp;
                            break;
                        case "BZERO":
                            double.TryParse(value, ns, ci, out doubleTmp);
                            Bzero = doubleTmp;
                            break;
                        case "BSCALE":
                            double.TryParse(value, ns, ci, out doubleTmp);
                            Bscale = doubleTmp;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Unable to properly read FITS header");
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
        }
    }

    struct HeaderRecord
    {
        public string key;
        public string value;
        public string comment;

        public HeaderRecord(string key, string value, string comment)
        {
            this.key = key;
            this.value = value;
            this.comment = comment;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(key);
            sb.Append(", ");
            sb.Append(value);
            sb.Append(", ");
            sb.Append(comment);
            return sb.ToString();
        }
    }
}
