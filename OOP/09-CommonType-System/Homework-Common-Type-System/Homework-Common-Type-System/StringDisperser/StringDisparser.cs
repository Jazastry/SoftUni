using System;
using System.Collections;
using System.Collections.Generic;

namespace StringDisperser
{
    internal class StringDisparser : ICloneable, IComparable<StringDisparser>, IEnumerable<char>
    {
        public string[] stringsInput { get; set; }
        public string totalStringValue { get; set; }

        public StringDisparser(params string[] strings)
        {
            this.stringsInput = strings;
            this.totalStringValue = "";
            for (int i = 0; i < strings.Length; i++)
            {
                totalStringValue += strings[i];
            }
        }

        public override bool Equals(object obj)
        {
            StringDisparser otherStringDisparser = obj as StringDisparser;
            bool equals = true;
            if (otherStringDisparser == null)
            {
                equals = false;
            }
            if (! this.stringsInput.Length.Equals(otherStringDisparser.stringsInput.Length))
            {
                equals = false;
            }
            for (int i = 0; i < this.stringsInput.Length; i++)
            {
                if (!this.stringsInput[i].Equals(otherStringDisparser.stringsInput[i]))
                {
                    equals = false;
                    break;
                }
            }
            return equals;
        }

        public static bool operator ==(StringDisparser disparser1, StringDisparser disparser2)
        {
            return disparser1.Equals(disparser2);
        }

        public static bool operator !=(StringDisparser disparser1, StringDisparser disparser2)
        {
            return !(disparser1.Equals(disparser2));
        }
        public override int GetHashCode()
        {
            if (this.stringsInput.Length < 1)
            {
                throw new ArgumentNullException("StringDisparser don't have mambers to get hash code from.");
            }

            int hashedMembers = this.stringsInput[0].GetHashCode();
            for (int i = 1; i < this.stringsInput.Length; i++)
            {
                hashedMembers ^= this.stringsInput[i].GetHashCode();
            }

            return hashedMembers;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < this.totalStringValue.Length; i++)
            {
                yield return this.totalStringValue[i];
            }
        }

        public int CompareTo(StringDisparser other)
        {
            return this.totalStringValue.CompareTo(other.totalStringValue);
        }

        public object Clone()
        {
            string[] cloneStringsInput = new string[this.stringsInput.Length];
            for (int i = 0; i < this.stringsInput.Length; i++)
            {
                cloneStringsInput[i] = this.stringsInput[i];
            }

            StringDisparser cloneDisparser = new StringDisparser(cloneStringsInput);

            return cloneDisparser;
        }

        public override string ToString()
        {
            string result = String.Empty;
            for (int i = 0; i < this.stringsInput.Length; i++)
            {
                result += "\"" + this.stringsInput[i] + "\", ";
            }
            return result;
        }
    }
}
