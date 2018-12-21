using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppChapter5
{
    public interface IPayroll
    {
        void RunPayroll();
        decimal CalculateOvertime(int empID);
    }

    public interface IPrinter
    {
        void Print();
    }

    public interface IScanner
    {
        void Scanner();
    }

    public interface MultiFunctionPrinter : IPrinter, IScanner
    {

    }


    public interface IMultiFunctionPrinter
    {
        void Print();
        void Scan();
        
    }

    public class DeskjetPrinter : IPrinter
    {
        //Deskjet printer print the page
        public void Print() { }
    }


    public class OfficePrinter: IMultiFunctionPrinter
    {
        //Office printer can print the page
        public void Print() { }
        //Office printer can scan the page
        public void Scan() { }
    }
}
