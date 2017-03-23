using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ChangeDate
{
    public partial class dateConvertForm : Form
    {
        public dateConvertForm()
        {
            InitializeComponent();
        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            string startPath = @"C:\Work\Current";
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Выберите файл";
            theDialog.Filter = "TXT files|*.txt";
            if (!Directory.Exists(startPath))
            {
                startPath = @"C:\";
            }
            theDialog.InitialDirectory = startPath;
            theDialog.Multiselect = true;
            string text = "";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                var fileNames = theDialog.FileNames;
                const Int32 BufferSize = 128;
                foreach (var fileName in fileNames)
                {
                    using (var fileStream = File.OpenRead(fileName))
                    using (var streamReader = new StreamReader(fileStream, Encoding.Default, true, BufferSize))
                    {
                        //String line;
                        //while ((line = streamReader.ReadLine()) != null)
                        //{
                        //    text = text + line;
                        //}
                        //var list = new List<string>();
                        text = streamReader.ReadToEnd();
                    }
                    Regex r = new Regex(@"(\d+)[-.\/](\d+)[-.\/](\d+)");
                    var x = from m in r.Matches(text).Cast<Match>()
                            select m.Value;
                    foreach (var date in x.ToList())
                    {
                        DateTime dateMatched;
                        string dateStr;
                        if (DateTime.TryParseExact(date, "dd/mm/yy", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dateMatched))
                        {
                            dateStr = dateMatched.ToString("ddmmyyyy");
                            text = text.Replace(date, dateStr);
                        }
                        else
                        {
                            if (DateTime.TryParseExact(date, "dd.mm.yy", CultureInfo.InvariantCulture,
                                DateTimeStyles.None, out dateMatched))
                            {
                                dateStr = dateMatched.ToString("ddmmyyyy");
                                text = text.Replace(date, dateStr);
                            }
                        }
                    }

                    string directoryName = Path.GetDirectoryName(fileName);
                    var txtName = Path.GetFileName(fileName);
                    directoryName = string.Format(@"{0}\{1}", directoryName, txtName); //todo 
                    if (!File.Exists(directoryName))
                    {
                        File.Create(directoryName).Dispose();
                        TextWriter writer = new StreamWriter(directoryName);
                        writer.Write(text);
                        writer.Close();
                        text = "";
                    }
                    else if (File.Exists(directoryName))
                    {
                        TextWriter tw = new StreamWriter(directoryName, false);
                        tw.Write(text);
                        tw.Close();
                        text = "";
                    }
                }
                MessageBox.Show(
                    @"Документы на выгрузку изменены. Вы найдёте их в той же папке, где лежат оригиналы файлов.");
            }
        }
    }
}