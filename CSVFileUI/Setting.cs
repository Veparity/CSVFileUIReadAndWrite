using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileUI
{
    public class Setting
    {
        private static IConfiguration _config;
        private static string csvFile;
        private static CsvFileDataAccess db = new CsvFileDataAccess();
        internal static void InitializeConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            _config = builder.Build();
           
        }
        internal static void GetFile()
        {
            csvFile = _config.GetValue<string>("CSVFile");
        }
        internal static void GetAllContacts()
        {
            var people = Setting.db.ReadAllRecords(csvFile);

            foreach (var person in people)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
        }

        internal static void CreateContact(PersonalModel person)
        {
            var people = db.ReadAllRecords(csvFile);
            people.Add(person);

            db.WriteAllRecords(people, csvFile);
        }

        internal static void UpdateContactFirstName(string firstName)
        {
            var people = db.ReadAllRecords(csvFile);
            people[0].FirstName = firstName;
        }

        public static void RemovePhoneNumberFromUser(string phoneNumber)
        {
            var people = db.ReadAllRecords(csvFile);
            people[0].PhoneNumbers.Remove(phoneNumber);

            db.WriteAllRecords(people, csvFile);
        }

        public static void RemoveUser()
        {
            var people = db.ReadAllRecords(csvFile);
            people.RemoveAt(0);
            db.WriteAllRecords(people, csvFile);
        }

    }
}
