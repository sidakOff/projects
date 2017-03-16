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
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            theDialog.Multiselect = true;
            var text = "";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                var fileNames = theDialog.FileNames;
                const Int32 BufferSize = 128;
                foreach (var fileName in fileNames)
                {
                    using (var fileStream = File.OpenRead(fileName))
                    using (var streamReader = new StreamReader(fileStream, Encoding.Default, true, BufferSize))
                    {
                        String line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            text = text + line;
                        }
                        var list = new List<string>();
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
                                list.Add(dateStr);
                            }
                            else
                            {
                                if (DateTime.TryParseExact(date, "dd.mm.yy", CultureInfo.InvariantCulture,
                                    DateTimeStyles.None, out dateMatched))
                                {
                                    dateStr = dateMatched.ToString("ddmmyyyy");
                                    text = text.Replace(date, dateStr);
                                    list.Add(dateStr);
                                }
                            }
                        }

                        string directoryName = Path.GetDirectoryName(fileName);
                        var txtName = Path.GetFileName(fileName);
                        directoryName = string.Format(@"{0}\(Formatted){1}", directoryName, txtName); //todo 
                        if (!File.Exists(directoryName))
                        {
                            File.Create(directoryName).Dispose();
                            TextWriter tw = new StreamWriter(directoryName);
                            tw.Write(text);
                            tw.Close();
                        }
                        else if (File.Exists(directoryName))
                        {
                            TextWriter tw = new StreamWriter(directoryName, false);
                            tw.Write(text);
                            tw.Close();
                        }
                    }
                }
                MessageBox.Show(
                    @"Документы на выгрузку изменены. Вы найдёте их в той же папке, где лежат оригиналы файлов.");
            }
        }
    }
}