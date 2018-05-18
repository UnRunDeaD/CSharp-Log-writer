using System;
using System.IO;
using System.Reflection;

namespace CSharpLogWriter
{
    public static class Log
    {
        public static string exePath = string.Empty;

        //this Part will get the Path of your Application
        private static string GetPath(string filename)
        {
            exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string LogDir = exePath + "\\" + "Log";

            Directory.CreateDirectory(LogDir);

            string LogFile = LogDir + " \\" + filename;

            if(!File.Exists(LogFile))
            {
                FileStream fs = File.Create(LogFile);
                fs.Close();
            }

            return LogFile;
        }

        //here you can add specific Errors to your Developers or yourself
        public static void Developer(string function, string LogMessage, string level)
        {
            try
            {
                //the Name of the Logfile for Developers
                string filename = "DevLog.txt";

                string path = GetPath(filename);

                switch (level)
                {
                    case "important":
                        {
                            using (StreamWriter sw = File.AppendText(path))
                                Write("ENTRY", function, LogMessage, sw);
                            break;
                        }
                }
            }
            catch (Exception exc)
            {
                Log.Error(function: "Class Log - Developer", exc.ToString(), "FATAL ERROR");
            }
        }

        //in this Function you can log action who where taken with some controls or whatever
        public static void Successful(string function, string LogMessage, string level)
        {
            try
            {
                //the Name of the normal Logfile
                string filename = "Log.txt";

                string Path = GetPath(filename);

                switch (level)
                {
                    case "SuccessfullAction":
                        {
                            using (StreamWriter sw = File.AppendText(Path))
                                Write(level, function, LogMessage, sw);
                            break;
                        }
                }
            }
            catch (Exception exc)
            {
                Log.Error(function: "Class Log - Successfull", exc.ToString(), "FATAL ERROR");
            }
        }

        //here you can log all error while runtime
        public static void Error(string function, string LogMessage, string level)
        {
            try
            {
                //the Name of the Logfile for all your Errors
                string filename = "ErrorLog.txt";

                string Path = GetPath(filename);

                switch (level)
                {
                    case "ERROR UNKOWN":
                        {
                            using (StreamWriter sw = File.AppendText(Path))
                                Write(level, function, LogMessage, sw);
                            break;
                        }
                    case "FATAL ERRROR":
                        {
                            using (StreamWriter sw = File.AppendText(exePath))
                                Write(level, function, LogMessage, sw);
                            break;
                        }
                }
            }
            catch (Exception exc)
            {
                Log.Error(function: "Class Log - Error", exc.ToString(), "FATAL ERROR");
            }
        }

        //this will write all the code into a File
        private static void Write(string header, string function, string LogMessage, TextWriter Log)
        {
            try
            {
                //you can edit this code into whatever you want, it is for me a good format to log all stuff
                Log.WriteLine("-//-----");
                Log.WriteLine("{0}", header);
                Log.WriteLine("-//-----");
                Log.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                Log.WriteLine("    {0} : {1}", function, LogMessage);
                Log.WriteLine("");
                Log.WriteLine("");
                Log.Close();
            }
            catch (Exception exc)
            {
                
            }
        }
    }
}
