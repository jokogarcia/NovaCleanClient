using System;
using System.Collections.Generic;
using System.Text;

namespace NovaCleanClient.Services
{
    public static class DebugLogger
    {
        public static void Log(string message, string label = "ConsumerAppDev")
        {
#if DEBUG
            Console.Write("\n\n*********************** " + label + " ***********************\n");
            Console.Write(message);
            Console.Write("\n*********************** " + label + " ***********************\n\n");

#endif
        }
    }
}
