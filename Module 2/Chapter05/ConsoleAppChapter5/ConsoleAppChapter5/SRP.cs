using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppChapter5
{
     public class PersonManager
    {
        
        public PersonManager() { }
        public Person GetPerson(int id)
        {
            //Use persistence manager to return Person object based on ID
            return new Person();
        }

        public void Save(Person person)
        {
            //Save Person record into database
        }

        public void LogInformation(string message)
        {
            //Log this message into a logging table in database
        }

        public void LogError(Exception ex)
        {
            //Log error into database
        }

    }


}
