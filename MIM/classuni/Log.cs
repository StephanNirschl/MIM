using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MIM.classuni
    {
        class Log
{
    // Membervariable---------------------
    string logdirectory;
    string logfile;
    string logcontent;



    // Konstruktor------------------------
    public Log(string logdirectory, string logfile, string logcontent)
    {
        this.logdirectory = logdirectory;
        this.logfile = logfile;
        this.logcontent = logcontent;
    }


    // Methode----------------------------
    public void Logmethod()
    {

        try
        {
            // aktuell Uhrzeit auslesen
            string datetime = DateTime.Now.ToString();


            // stringbuilder logcontent
            StringBuilder sb = new();
            _ = sb.Append("\n" + datetime);
            _ = sb.Append("\n" + logcontent);



            // if log directory exists
            if (Directory.Exists(logdirectory))
            {
                // if logfile exist append content
                if (File.Exists(logdirectory + logfile))
                {
                    using StreamWriter myWriter = new(logdirectory + logfile, append: true);
                    myWriter.WriteLineAsync(sb.ToString());
                    myWriter.Close();

                }
                // if logfile not exists create new .log
                else
                {
                    StreamWriter myWriter = File.CreateText(logdirectory + logfile);
                    myWriter.WriteLine(sb.ToString());
                    myWriter.Close();
                }
            }
            // if log directory not exists - create directory and logfile
            else
            {
                Directory.CreateDirectory(logdirectory);
                StreamWriter myWriter = File.CreateText(logdirectory + logfile);
                myWriter.WriteLine(sb.ToString());
                myWriter.Close();
            }
        }
        catch (Exception e)
        {
            MessageBox.Show("error: " + e);
            //Console.WriteLine("error: " + e);
        }
    }

}
}




