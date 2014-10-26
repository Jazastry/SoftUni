using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentAndWorker
{
    class Worker : Human
    {
        public double WeekSalary { get; private set; }
        public double WorkHoursPerDay { get; private set; }

        public Worker(string firstName, string lastName, double weekSalary = 0, double workHoursPerDay = 0)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double MoneyPreHour(double weekSelary, double workHoursPerDay)
        {
            double result = (weekSelary / 5) / workHoursPerDay;
            return result;
        }
    }
   // Define a class Worker derived from Human with fields WeekSalary and
   // WorkHoursPerDay and method MoneyPerHour() 
   // that returns the payment earned by hour by the worker. 
}
