using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_HTML_Dispatcher
{
    class ElementBuilder
    {
        private string element;
        private string Element
        {
            get
            {
                return this.element;
            }
            set
            {
                if ((String.IsNullOrEmpty(value)) || (String.IsNullOrWhiteSpace(value)))
                {
                    throw new ArgumentNullException("Element");
                }
                else
                {
                    this.element = value;
                }
            }
        }
        public ElementBuilder(string element)
        {
            this.Element = element;
        }
        private int count = 0;
        private string atributeAndValue;
        private string AtributeAndValue
        {
            get
            {
                return this.atributeAndValue;
            }
            set
            {
                if ((String.IsNullOrEmpty(value)) || (String.IsNullOrWhiteSpace(value)))
                {
                    throw new ArgumentNullException("AtributeAndValue");
                }
                else
                {
                    this.atributeAndValue += value;
                }
            }
        }
        public void AddAtribute(string attribute, string value)
        {
            if ((count == 0) && !String.IsNullOrWhiteSpace(attribute) && !String.IsNullOrWhiteSpace(value))
            {
                this.AtributeAndValue = attribute + "=\"" + value + "\"";
            }
            else if ((count == 0) && !String.IsNullOrWhiteSpace(value))
            {
                
            }
            else
            {
                this.AtributeAndValue += " " + attribute + "=\"" + value + "\"";
            }
            count++;
        }
        // AddAtribute(attribute, value)
    }
}
