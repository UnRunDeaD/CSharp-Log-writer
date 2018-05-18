using System;
using System.IO;
using System.Reflection;

namespace CSharpLogWriter
{
    public static class Log
    {
        public static string exePath = string.Empty;

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

        public static void Developer(string function, string LogMessage, int level)
        {
            try
            {
                string filename = "DevLog.txt";

                string path = GetPath(filename);

                switch (level)
                {
                    case 0:
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

        public static void Successful(string function, string LogMessage, string level)
        {
            try
            {
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

        public static void Error(string function, string LogMessage, string level)
        {
            try
            {
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

        private static void Write(string header, string function, string LogMessage, TextWriter Log)
        {
            try
            {
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
