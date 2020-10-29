using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostTradingDataManager.UI.Helpers
{
    public static class ExportHelper
    {
        public static string SaveAsExcel()
        {
            using (var saveFile = new SaveFileDialog())
            {
                saveFile.Title = "Exporting to excel.";
                saveFile.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFile.CreatePrompt = false;

                var result = saveFile.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return null;
                }

                return saveFile.FileName;
            }
        }

        public static string SaveAsCsv()
        {
            using (var saveFile = new SaveFileDialog())
            {
                saveFile.Title = "Exporting as .csv file.";
                saveFile.Filter = "Excel files (*.csv)|*.csv";
                saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFile.CreatePrompt = false;

                var result = saveFile.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return null;
                }

                return saveFile.FileName;
            }
        }
    }
}
