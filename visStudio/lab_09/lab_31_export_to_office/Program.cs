using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed;
using Xceed.Words.NET;
using System.Diagnostics;

namespace lab_31_export_to_office
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\RabbitReport.docx";
            var doc = DocX.Create(fileName);

            doc.InsertParagraph("Rabbit Report");

            doc.InsertParagraph("Number of Rabbits Created: 1000");

            doc.InsertParagraph("Time taken: 17.6754 seconds");

            doc.Save();

            Process.Start("WINWORD.EXE", fileName);
        }
    }
}
