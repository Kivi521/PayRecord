using System;
namespace MyPayProject
{
    public class ResidentPayRecord : PayRecord
    {
        /// <summary>
        /// override abstract propertay Tax;
        /// </summary>
        public override double Tax
        {
            get
            {
                return TaxCalculator.CalculateResidentialTax(Gross);
            }
        }

        /// <summary>
        /// ResidentPayRecord class's constructor, inherit Base class's id, hours and rates property
        /// </summary>
        /// <param name="id">parameter of employee's id which is based on base class PayRecord</param>
        /// <param name="hours">parameter of employee's working hour which is based on base class PayRecord</param>
        /// <param name="rates">parameter of employee's corresponding rate which is based on base class PayRecord</param>
        public ResidentPayRecord(int id, double[] hours, double[] rates): base (id, hours, rates)
        {

        }


    }
}
