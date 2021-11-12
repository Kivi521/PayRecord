using System;
using System.IO;
using System.Collections.Generic;
namespace MyPayProject
{
    public class PayRecordWriter
    {
        /// <summary>
        /// Write information from list of PayRecord objects to a csv file
        /// </summary>
        /// <param name="listOfRecord"> the list of PayRecord objects</param>
        /// <param name="filePath"> csv file path</param>
        /// <param name="showRecord">Whether write to console or not</param>
        /// <returns>file path of the csv file</returns>
        public static string write(List<PayRecord> listOfRecord, string filePath, bool showRecord = false)
        {
            DateTime centuryBegin = new DateTime(2001, 1, 1);
            DateTime currentDate = DateTime.Now;
            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            string fileName = $"{filePath}/{elapsedTicks}-records.csv";
            Console.WriteLine(fileName);
            


            FileStream fw = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fw);
            foreach (PayRecord record in listOfRecord)
            {
                string line = $"{record.Id},{record.Gross},{record.Net},{record.Tax}";
                sw.WriteLine(line);
                if (showRecord)
                {
                    Console.WriteLine(record.GetDetails());
                }
            }

            sw.Close();

            return fileName;
        }
        public PayRecordWriter()
        {
        }


        
    }
}
