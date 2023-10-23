using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccessLibrary
{
    public class CsvFileDataAccess
    {
        public List<PersonalModel> ReadAllRecords(string csvFile)
        {
            if(File.Exists(csvFile) == false)
            {
                return new List<PersonalModel>();
            }

            var lines = File.ReadAllLines(csvFile);
            List<PersonalModel> output = new List<PersonalModel>();
            
            foreach (var line in lines)
            {
                PersonalModel p = new PersonalModel();
                var vals = line.Split(',');

                if (vals.Length < 3)
                {
                    throw new Exception($"Invalid row of data: {line}");
                }

                p.FirstName = vals[0];
                p.LastName = vals[1];
                p.PhoneNumbers = vals[2].Split(';').ToList();

                output.Add(p);
            }
            return output;
        }
        public void WriteAllRecords(List<PersonalModel> records, string csvFile)
        {
            List<string> lines = new List<string>();
            foreach (var r in records)
            {
                lines.Add($"{r.FirstName},{r.LastName},{String.Join(';', r.PhoneNumbers)}");
            }
       File.WriteAllLines(csvFile, lines);
        }

    }
}
