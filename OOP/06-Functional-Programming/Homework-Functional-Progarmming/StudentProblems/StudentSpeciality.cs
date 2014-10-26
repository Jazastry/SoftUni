using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProblems
{
    public class StudentSpeciality
    {
        private string specialityName;
        private int specialityNumber;

        public string SpecialityName
        {
            get { return this.specialityName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("SpecialityName");
                }
                this.specialityName = value;
            }
        }

        public int SpecialityNumber
        {
            get { return this.specialityNumber; }
            set { this.specialityNumber = value; }
        }

        public StudentSpeciality(int specialityNumb, string specialityName)
        {
            this.SpecialityName = specialityName;
            this.SpecialityNumber = specialityNumb;
        }
    }
}
