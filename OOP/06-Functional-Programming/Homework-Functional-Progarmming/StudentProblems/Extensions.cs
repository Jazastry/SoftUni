using System.Collections.Generic;

namespace Tests
{
    public static class Extensions
    {
        public static bool ContainsCuantity(this List<int> marks, int markToSearch, int cuantity)
        {
            int counter = 0;
            foreach (int mark in marks)
            {
                if (mark == markToSearch)
                {
                    counter++;
                }
            }
            if (counter == cuantity)
            {
                return true;
            }
            return false;
        }
    }
}
