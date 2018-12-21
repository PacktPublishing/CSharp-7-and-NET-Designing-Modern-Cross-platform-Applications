using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppChapter5
{
    //public interface ILogger
    //{
    //    void WriteLog(string message);
    //    List<string> GetLogs();
    //}

    ///// <summary>
    ///// Logger that prints the information on application console window
    ///// </summary>
    //public class ConsoleLogger : ILogger
    //{
    //    public List<string> GetLogs() => throw new NotImplementedException();
    //    public void WriteLog(string message)
    //    {
    //        Console.WriteLine(message);
    //    }
    //}

    ///// <summary>
    ///// Logger that writes the log into database and persist them
    ///// </summary>
    //public class DatabaseLogger : ILogger
    //{
    //    public List<string> GetLogs()
    //    {
    //        //do some work to get logs stored in database, as the actual code in not written so returning null
    //        return null; 
    //    }
    //    public void WriteLog(string message)
    //    {
    //        //do some work to write log into database
    //    }
    //}


    public interface ILogger
    {
        void WriteLog(string message);
     
    }

    public interface PersistenceLogger: ILogger
    {
        List<string> GetLogs();
    }

    /// <summary>
    /// Logger that prints the information on application console window
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(message);
        }
    }

    /// <summary>
    /// Logger that writes the log into database and persist them
    /// </summary>
    public class DatabaseLogger : PersistenceLogger
    {
        public List<string> GetLogs()
        {
            //do some work to get logs stored in database, as the actual code in not written so returning null
            return null;
        }
        public void WriteLog(string message)
        {
            //do some work to write log into database
        }
    }
}
