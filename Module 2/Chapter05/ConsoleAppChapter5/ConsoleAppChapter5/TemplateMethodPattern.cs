using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppChapter5
{
    //public class Logger
    //{
    //    public virtual void logMessage(string message)
    //    {
    //        //This method logs information into file system
    //        LogtoFileSystem(message);
    //    }

    //    private void LogtoFileSystem(string message) {
    //        //Log to file system
    //    }

    //}

    public abstract class Logger
    {
        public abstract void LogMessage(string message);
        
        public void WriteLog(string message)
        {
            LogMessage(message);
        }
       

    }

    public class FileLogger : Logger
    {
        public override void LogMessage(string message)
        {
            //Log to file system
        }
    }

    //public class DatabaseLogger : Logger
    //{
    //    public override void LogMessage(string message)
    //    {
    //        //Log to database
    //    }
    //}
}
