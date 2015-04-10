using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data.Utilities
{
    public static class Utilities
    {
        public static Gender GetGender(int genderValue)
        {
            switch (genderValue)
            {
                case 0:
                    return Gender.Other;
                case 1:
                    return Gender.Male;
                case 2:
                    return Gender.Female;
                default:
                    throw new ArgumentOutOfRangeException("Gender value", "Gemder value is out of posible values.");
                    break;
            }
        }
    }
}
