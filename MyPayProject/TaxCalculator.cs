using System;
namespace MyPayProject
{
    public class TaxCalculator
    {
        public TaxCalculator()
        {
        }

        /// <summary>
        /// takes a double of residental gross as an input, and generates different levels of Tax of residents
        /// </summary>
        /// <param name="residentialGross">the double of residental gross to be used to generate the taxs </param>
        /// <returns>different levels of tax of residents</returns>
        public static double CalculateResidentialTax(double residentialGross)
        {
            if (residentialGross > -1 && residentialGross <= 72)
            {
                return residentialGross * 0.2342 - 3.213;
            }
            else if (residentialGross > 72 && residentialGross <= 361)
            {
                return residentialGross * 0.19 - 0.19;
            }
            else if (residentialGross > 361 && residentialGross <= 932)
            {
                return residentialGross * 0.3477 - 44.2476;
            }
            else if (residentialGross > 932 && residentialGross <= 1380)
            {
                return residentialGross * 0.39 - 103.8657;
            }
            else if (residentialGross > 1380 && residentialGross <= 3111)
            {
                return residentialGross * 0.345 - 41.7311;
            }
            else if (residentialGross > 3111 && residentialGross <= 999999)
            {
                return residentialGross * 0.47 - 352.7888;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// takes a double of working holiday gross and double of yearToDate as inputs, and generates different levels of Tax of working hodiday staffs
        /// </summary>
        /// <param name="residentialGross">the double of working holiday gross to be used to generate the taxs </param>
        /// <param name="yearToDate">takes the number of how much the working holiday staff been oaif during the financial year to be used to generate the taxs </param>
        /// <returns>different levels of tax of working holiday taxs</returns>

        public static double CalculateWorkingHolidayTax(double workingHolidayGross, double yearToDate)
        {
            double sumYearToDatePay = workingHolidayGross + yearToDate;
            if (sumYearToDatePay > -1 && sumYearToDatePay <= 37000)
            {
                return workingHolidayGross * 0.15;
            }
            else if (sumYearToDatePay > 37000 && sumYearToDatePay <= 90000)
            {
                return workingHolidayGross * 0.32;
            }
            else if (sumYearToDatePay > 90000 && sumYearToDatePay <= 180000)
            {
                return workingHolidayGross * 0.37;
            }
            else if (sumYearToDatePay > 180000 && sumYearToDatePay <= 9999999)
            {
                return workingHolidayGross * 0.45;
            }
            else
            {
                return -1;
            }
        }

    }
}
