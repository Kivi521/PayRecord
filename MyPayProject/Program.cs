using System;
using System.Collections.Generic;


namespace MyPayProject
{
    class MainClass
    {
        /// <summary>
        /// the entry point of the program
        /// </summary>
        /// <param name="args">the command line parameter is n array of strings</param>
        public static void Main(string[] args)
        {            
            List<PayRecord> records = CsvLmporter.ImportPayRecords(@"/Users/sunrenfei/Projects/MyPaySolution/MyPayProject/Import/employee-payroll-data.csv");

            PayRecordWriter.write(records, @"/Users/sunrenfei/Projects/MyPaySolution/MyPayProject/Export", true);

        }
    }
}
