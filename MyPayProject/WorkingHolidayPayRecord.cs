using System;
namespace MyPayProject
{
    public class WorkingHolidayPayRecord : PayRecord
    {
        public int Visa { get; private set; }
        public int YearToDate { get; private set; }


        /// <summary>
        /// override abstract property Tax;
        /// </summary>
        public override double Tax
        {
            get
            {
                return TaxCalculator.CalculateWorkingHolidayTax(Gross, YearToDate);
            }
        }

       
        /// <summary>
        /// override vitual property GetDetail ;
        /// </summary>
        TaxCalculator calculateWorkingHolidayTax = new TaxCalculator();
        public override string GetDetails()
        {


            return "----------Employee：" + Id + "----------" + "\n" + "Gross: " + "  $" + Gross + "\n" + "Net: " + "    $" + Net + "\n" + "Tax: " + "    $" + Tax + "\n" + "Visa: " + "   " + Visa + "\n" + "YTD: " + "    $" + YearToDate + "\n";
        }

        /// <summary>
        /// working holiday pay record class's constructor, inherit Base class's id, hours and rates property, and add visa and yearToDate property
        /// </summary>
        /// <param name="id">parameter of employee's id which is based on base class PayRecord</param>
        /// <param name="hours">parameter of employee's working hour which is based on base class PayRecord</param>
        /// <param name="rates">parameter of employee's corresponding rate which is based on base class PayRecord</param>
        /// <param name="visa">parameter of working holiday employee's visa</param>
        /// <param name="yearToDate">parameter of working holiday employee's year to date which is how much they have been paid during the financial year</param>
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base(id, hours, rates)
        {
            Visa = visa;
            YearToDate = yearToDate;
        }
    }
}
