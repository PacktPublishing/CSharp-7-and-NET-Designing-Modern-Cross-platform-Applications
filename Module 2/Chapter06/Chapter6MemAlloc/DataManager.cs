using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Chapter6MemAlloc
{
    public class DataManager : IDisposable
    {
        private SqlConnection _conn;
     
        //Returns the list of users from database
        public DataTable GetUsers()
        {
            //Invoke OpenConnection to instantiate the _conn object

            OpenConnection();

            //Executing command in a using block to dispose command object
            using(var command =new SqlCommand())
            {
                command.Connection = _conn;
                command.CommandText = "Select * from Users";

                //Executing reader in a using block to dispose reader object
                using (var reader = command.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }

            }
        }
        private void OpenConnection()
        {
            if (_conn == null)
            {
                _conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SampleDB;Data Source=.\sqlexpress");
                _conn.Open();
            }
        }

        //Disposing _connection object
        public void Dispose() {
            Console.WriteLine("Disposing object");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                if (_conn != null)
                {
                    _conn.Close();
                    _conn.Dispose();
                    //set _conn to null, so next time it won't hit this block
                    _conn = null;
                }
            }
        }

    }1

    //example with finalizer
    //public class DataManager : IDisposable
    //{
    //    private SqlConnection _conn;

    //    //Returns the list of users from database
    //    public DataTable GetUsers()
    //    {
    //        //Invoke OpenConnection to instantiate the _conn object

    //        OpenConnection();

    //        //Executing command in a using block to dispose command object
    //        using (var command = new SqlCommand())
    //        {
    //            command.Connection = _conn;
    //            command.CommandText = "Select * from Users";

    //            //Executing reader in a using block to dispose reader object
    //            using (var reader = command.ExecuteReader())
    //            {
    //                var dt = new DataTable();
    //                dt.Load(reader);
    //                return dt;
    //            }

    //        }
    //    }
    //    private void OpenConnection()
    //    {
    //        if (_conn == null)
    //        {
    //            _conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SampleDB;Data Source=.\sqlexpress");
    //            _conn.Open();
    //        }
    //    }

    //    //Disposing _connection object
    //    public void Dispose()
    //    {
    //        Console.WriteLine("Disposing object");
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }

    //    private void Dispose(Boolean disposing)
    //    {
    //        if (disposing)
    //        {
    //            //clean up any managed resources, if called from the //finalizer, all the managed resources will already be collected //by the GC
    //        }
    //        if (_conn != null)
    //        {
    //            _conn.Close();
    //            _conn.Dispose();
    //            //set _conn to null, so next time it won't hit this block
    //            _conn = null;
    //        }

    //    }

    //    //Implementing Finalizer
    //    ~DataManager()
    //    {
    //        Dispose(false);
    //    }
    //}

}
