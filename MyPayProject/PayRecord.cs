using System;

namespace MyPayProject
{
    public abstract class PayRecord
    {
        protected double[] _hours;
        protected double[] _rates;
        public int Id { get; private set; }

        public double Gross {
            get
            {
                double gross = 0;

                for (int i = 0; i < _hours.Length; i++)
                {
                    double localGross = _hours[i] * _rates[i];
                    gross += localGross;
                }

                return gross;
            }
        }

        public abstract double Tax { get; }

        public double Net {
            get
            {
                return Gross - Tax;
            }
        }

        public PayRecord(int id, double[] hours, double[] rates)
        {
            Id = id;
             _hours = hours;
            _rates = rates;

        }
        public virtual string GetDetails()
        {
            return "----------Employee：" + Id + "----------" + "\n"　+ "Gross: " + "  $" + Gross + "\n" + "Net: " + "    $" + Net + "\n" + "Tax: " + "    $" + Tax + "\n";
        }

    }
}
