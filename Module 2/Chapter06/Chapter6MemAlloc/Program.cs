using System;
using System.Runtime;

namespace Chapter6MemAlloc
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //System.Diagnostics.Debugger.Break();




            DataManager manager = new DataManager();
            {
                manager.GetUsers();
            }


           // GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect();
            GC.Collect();
            GC.Collect();

            Console.WriteLine("done");
            Console.Read();
        }
    }


    public class FileLogger
    {

        //Finalizer implementation
        ~FileLogger()
        {

        }
        

    }
}
    