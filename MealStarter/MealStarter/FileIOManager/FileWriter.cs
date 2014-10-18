using System;
using System.IO;

namespace FileIOManager
{
    static public class FileWriter
    {

        static public void CreateText(string line)
        {
            StreamWriter sw = File.CreateText(FileLocation.OUTPUT_FILE);
            sw.WriteLine(line);
            sw.Close(); 

        }
        static public void AppendText( string line )
        {
            StreamWriter sw = File.AppendText(FileLocation.OUTPUT_FILE);
            sw.WriteLine(line);
            sw.Close(); 
        }
    }
}
