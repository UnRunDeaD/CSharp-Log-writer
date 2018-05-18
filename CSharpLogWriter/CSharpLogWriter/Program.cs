﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLogWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Developer(function: "YourFunction", "Your Log Message or Exception", level: "important");

            Log.Error(function: "YourFunction", "Your Log Message or Exception", level: "priority");

            Log.Successful(function: "YourFunction", "Your Log Message or Action ", level: "SuccessfulAction");
        }
    }
}
