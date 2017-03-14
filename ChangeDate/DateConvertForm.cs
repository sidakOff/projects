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
            string text;
            text = "";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = theDialog.FileName; const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(fileName))
                using (var streamReader = new StreamReader(fileStream, Encoding.Default, true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        //line=string.Format(line).Contains                        
                        text = text + line;
                    }
                    //string s = "log-bb-2014-02-12-12-06-13-diag";
                    var list=new List<string>();
                    Regex r = new Regex(@"(\d+)[-.\/](\d+)[-.\/](\d+)");
                    var x= from m in r.Matches(text).Cast<Match>()
                           select m.Value;
                    foreach (var date in x.ToList())
                    {
                        DateTime dateMatched;
                        string dateStr;
                        if (DateTime.TryParseExact(date, "dd/mm/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateMatched))
                        {
                            dateStr = dateMatched.ToString("ddmmyyyy");
                            text=text.Replace(date, dateStr);
                            list.Add(dateStr);
                        }
                        else
                        {
                            if (DateTime.TryParseExact(date, "dd.mm.yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateMatched))
                            {
                                dateStr = dateMatched.ToString("ddmmyyyy");
                                text = text.Replace(date, dateStr);
                                list.Add(dateStr);
                            }
                        }
                    }
                    string path = @"C:\Users\Roman\Desktop";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    path = string.Format(@"C:\Work\UploadToTelelinkFiles\{0}.txt", 1); //todo 
                    if (!File.Exists(path))
                    {
                        File.Create(path).Dispose();
                        TextWriter tw = new StreamWriter(path);
                        tw.Write(text);
                        tw.Close();
                    }
                    else if (File.Exists(path))
                    {
                        TextWriter tw = new StreamWriter(path, false);
                        tw.Write(text);
                        tw.Close();
                    }
                    MessageBox.Show(@"Всё пучком и выгрузилось в папку C:\Work\UploadToTelelinkFiles");
                }
            }
            
        }
    }
    //Match m = r.Match(a.ToString());
    //if (m.Success)
    //{
    //    string date = "";
    //    DateTime dt = DateTime.ParseExact(m.Value, "dd/mm/yy", CultureInfo.CurrentCulture);
    //    //var x=m.Value.ToString;
    //    //date = date + x; 
    //    //DateTime dt = DateTime.ParseExact(m.Value, "yyyy-MM-dd-hh-mm-ss", CultureInfo.InvariantCulture);

    //}


    //MessageBox.Show(text);
}
