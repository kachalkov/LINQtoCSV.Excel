﻿using System;
using System.Globalization;
using System.Text;

namespace LINQtoCSV.Excel
{
    /// <summary>
    /// Summary description for CsvFileDescription
    /// </summary>
    public class ExcelFileDescription
    {
        // Culture used to process the CSV values, specifically numbers and dates.
        private CultureInfo m_cultureInfo = CultureInfo.CurrentCulture;

        private int m_maximumNbrExceptions = 100;
        

        // If true, then:
        // When writing a file, the column names are written in the
        // first line of the new file.
        // When reading a file, the column names are read from the first
        // line of the file.
        //
        public bool FirstLineHasColumnNames { get; set; }

        // If true, only public fields and properties with the
        // [CsvColumn] attribute are recognized.
        // If false, all public fields and properties are used.
        //
        public bool EnforceCsvColumnAttribute { get; set; }

        // FileCultureName and FileCultureInfo both get/set
        // the CultureInfo used for the file.
        // For example, if the file uses Dutch date and number formats
        // while the current culture is US English, set
        // FileCultureName to "nl-NL".
        //
        // To simply use the current culture, leave the culture as is.
        //
        public string FileCultureName
        {
            get { return m_cultureInfo.Name; }
            set { m_cultureInfo = new CultureInfo(value); }
        }

        public CultureInfo FileCultureInfo
        {
            get { return m_cultureInfo; }
            set { m_cultureInfo = value; }
        }

        // When reading a file, exceptions thrown while the file is being read
        // are captured in an aggregate exception. That aggregate exception is then
        // thrown at the end - to make it easier to solve multiple problems with the
        // input file in one. 
        //
        // However, after MaximumNbrExceptions, the aggregate exception is thrown
        // immediately.
        //
        // To not have a maximum at all, set this to -1.
        public int MaximumNbrExceptions
        {
            get { return m_maximumNbrExceptions; }
            set { m_maximumNbrExceptions = value; }
        }

        // Character encoding. Defaults should work in most cases.
        // However, when reading or writing non-English files, you may want to use
        // Unicode encoding.
        public Encoding TextEncoding { get; set; }
        public bool DetectEncodingFromByteOrderMarks { get; set; }

        public bool UseFieldIndexForReadingData { get; set; }
        public bool UseOutputFormatForParsingCsvValue { get; set; }

        /// <summary>
        /// If set to true, wil read only the fields specified as attributes, and will discard other fields in the CSV file
        /// </summary>
        public bool IgnoreUnknownColumns { get; set; }

        // ---------------

        public ExcelFileDescription()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            m_cultureInfo = CultureInfo.CurrentCulture;
            FirstLineHasColumnNames = true;
            EnforceCsvColumnAttribute = false;
            TextEncoding = Encoding.UTF8;
            DetectEncodingFromByteOrderMarks = true;
            UseFieldIndexForReadingData = false;
            IgnoreUnknownColumns = false;
            UseOutputFormatForParsingCsvValue = false;
        }
    }
}
