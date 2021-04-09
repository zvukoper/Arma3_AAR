using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace AndreyIM_Log
{
    class Logger
    {
        public static RichTextBox RichTextBoxLogger { set; get; }

        public static void WriteLog(string str)
        {
            WriteLog(str, Color.Green);
        }

        public static void WriteLog(string str, Color color)
        {
            WriteToLogForm(str, color);

            // Пишем в файл
            string fileName = DateTime.Today.ToString("yyyy.MM.dd") + ".log";

            try
            {
                if (!Directory.Exists(Application.StartupPath + "\\Logs\\")) Directory.CreateDirectory(Application.StartupPath + "\\Logs\\");

                StreamWriter fs;
                FileInfo fi = new FileInfo(Application.StartupPath + "\\Logs\\" + fileName);
                fs = fi.AppendText();
                fs.WriteLine(DateTime.Now + ": " + str);
                fs.Close();
            }
            catch (System.Exception)
            {
                //WriteLog(ex.Message, Color.Red);
            }
        }

        private delegate void WriteToLogFormDelegate(string str, Color color);
        public static void WriteToLogForm(string str, Color color)
        {
            if (RichTextBoxLogger == null) return;

            try
            {
                if (RichTextBoxLogger.InvokeRequired)
                {
                    var func = new WriteToLogFormDelegate(WriteToLogForm);
                    RichTextBoxLogger.Invoke(func, str, color);
                }
                else
                {
                    if (RichTextBoxLogger.Lines.Count() > 100)
                    {
                        RichTextBoxLogger.Clear();
                    }

                    int start = RichTextBoxLogger.TextLength;
                    RichTextBoxLogger.AppendText(DateTime.Now + ": " + str + "\r\n");
                    int end = RichTextBoxLogger.TextLength;

                    RichTextBoxLogger.Select(start, end - start);
                    {
                        RichTextBoxLogger.SelectionColor = color;
                    }

                    RichTextBoxLogger.SelectionLength = 0;
                    RichTextBoxLogger.SelectionStart = RichTextBoxLogger.TextLength;

                    try { RichTextBoxLogger.ScrollToCaret(); }
                    catch (Exception) { }

                    RichTextBoxLogger.SelectionLength = 0;
                }
            }
            catch (Exception) { }
        }
    }
}
