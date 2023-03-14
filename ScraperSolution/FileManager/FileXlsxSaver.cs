using IronXL;
using Scraper.Data;
using System;
using System.Collections.Generic;

namespace Scraper.FileManager
{
    public class FileXlsxSaver : FileSaver
    {
        private FileXlsxSaver() { }
        private static FileXlsxSaver _instance;
        public static FileXlsxSaver GetInstance()
        {
            if (_instance == null) { _instance = new FileXlsxSaver(); }
            return _instance;
        }
        public override void SaveFile(string fullPath, List<Link> links)
        {
            WorkBook wb = WorkBook.Load(fullPath);
            WorkSheet ws = wb.WorkSheets[0];
            var columnName = ReturnColumnName(ws.ColumnCount + 1);

            foreach (Link link in links)
            {
                ws[columnName + link.Id].Value = link.Url;
            }

            wb.Save();
            wb.Close();
        }
        public override void SaveNewFile(string path, string fileName, List<Link> links)
        {
            WorkBook wb = WorkBook.Create(ExcelFileFormat.XLSX);
            WorkSheet ws = wb.CreateWorkSheet("Links");

            foreach (Link link in links)
            {
                ws["A" + link.Id].Value = link.Url;
            }

            wb.SaveAs(path + @"\" + fileName + ".xlsx");
            wb.Close();
        }
        private string ReturnColumnName(int columnCount)
        {
            int modulo = 0;
            string columnName = "";

            while (columnCount > 0)
            {
                modulo = (columnCount - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnCount = (columnCount - modulo) / 26;
            }

            return columnName;
        }
    }
}
