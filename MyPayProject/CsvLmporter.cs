using System;
using System.IO;
using System.Collections.Generic;
namespace MyPayProject
{
    public class CsvLmporter
    {
        public CsvLmporter()
        {
        }
        /// <summary>
        /// Import pay information from a csv file and generate a list of PayRecord objects
        /// </summary>
        /// <param name="filePath">path of the input csv file </param>
        /// <returns>A list of PayRecord objects</returns>
        public static List<PayRecord> ImportPayRecords(string filePath)
        {
            List<PayRecord> payRecords = new List<PayRecord>();
            using (var reader = new StreamReader(filePath))
            {
                List<double> hours = new List<double>();
                List<double> rates = new List<double>();

                
                int visa = 0;
                int yearToDate = 0;

                //Dictionary<string, string>

                string preId = "";
                string visaStr = "";
                int previousVisa = 0;
                int counter = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (counter == 0)
                    {
                        counter++;
                        continue;
                    }

                    if (line.Length == 0)
                    {
                        break;
                    }

                    var values = line.Split(',');

                    
                    // current employee information
                    string id = values[0];
                    string hour = values[1];
                    string rate = values[2];
                    visaStr = values[3];
                    string yearToDateStr = values[4];

                    if (preId!= "" && preId != id)
                    { 

                        // create payrecord object for previous employee.
                        if(previousVisa == 0)
                        {
                            Console.WriteLine(preId+"resident");
                            PayRecord record = createPayRecord(int.Parse(preId), hours.ToArray(), rates.ToArray(), 0, 0);
                            payRecords.Add(record);
                        }
                        else
                        {
                            Console.WriteLine(preId + "working");
                            PayRecord record = createPayRecord(int.Parse(preId), hours.ToArray(), rates.ToArray(), visa, yearToDate);
                            payRecords.Add(record);
                        }

                        hours.Clear();
                        rates.Clear();
                    }

                    preId = id;
                    hours.Add(double.Parse(hour));
                    rates.Add(double.Parse(rate));

                    if(visaStr.Length > 0)
                    { 
                        visa = int.Parse(visaStr);
                        yearToDate = int.Parse(yearToDateStr);
                    }
                    else
                    {
                        visa = 0;
                        yearToDate = 0;
                    }

                    previousVisa = visa;

                    //Console.WriteLine(line);
                }


                if (visaStr.Length == 0)
                {
                    PayRecord record = createPayRecord(int.Parse(preId), hours.ToArray(), rates.ToArray(), 0, 0);
                    payRecords.Add(record);
                }
                else
                {
                    PayRecord record = createPayRecord(int.Parse(preId), hours.ToArray(), rates.ToArray(), visa, yearToDate);
                    payRecords.Add(record);
                }


            }

            return payRecords;
        }
        /// <summary>
        /// an static class of creatPayRecord to show different kind of employee's situation
        /// </summary>
        /// <param name="id">parameter of employee's id</param>
        /// <param name="hours">parameter of employee's working hour</param>
        /// <param name="rates">parameter of employee's corresponding rate</param>
        /// <param name="visa">parameter of employee's visa number</param>
        /// <param name="yearToDate">parameter of employee's year to date, which is how much they have been paid during the financial year</param>
        /// <returns>lists of show different kind of employee's situation</returns>
        public static PayRecord createPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) 
        {
            if (visa == 0)
            {
                PayRecord record = new ResidentPayRecord(id, hours, rates);
                return record;
            }
            else
            {
                PayRecord record = new WorkingHolidayPayRecord(id, hours, rates, visa, yearToDate);
                return record;
            }
        }
    }
}
