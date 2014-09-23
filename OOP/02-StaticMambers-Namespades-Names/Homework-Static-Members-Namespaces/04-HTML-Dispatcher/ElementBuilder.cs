using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_HTML_Dispatcher
{
    public class ElementBuilder
    {
        private string element;
        private string atribute;
        private string valueOfAtribute;
        private string atributeAndValue;
        private string content = "";
        private string returnResult;
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
        public string Atribute 
        {
            get
            {
                return this.atribute;
            }
            set
            {
                if ((String.IsNullOrEmpty(value)) || (String.IsNullOrWhiteSpace(value)))
                {
                    throw new ArgumentNullException("Atribute");
                }
                else
                {
                    this.atribute = value;
                }
            }
        }
        public string ValueOfAtribute
        {
            get
            {
                return this.valueOfAtribute;
            }
            set
            {
                if ((String.IsNullOrEmpty(value)) || (String.IsNullOrWhiteSpace(value)))
                {
                    throw new ArgumentNullException("ValueAtribute");
                }
                else
                {
                    this.valueOfAtribute = value;
                }
            }
        }
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
        private string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                if ((String.IsNullOrEmpty(value)) || (String.IsNullOrWhiteSpace(value)))
                {
                    throw new ArgumentNullException("Content");
                }
                else
                {
                    this.content += value;
                }
            }
        }
        private string ReturnResult
        {
            get
            {
                return this.returnResult;
            }
            set
            {
                this.returnResult = value;                
            }
        }
        public ElementBuilder()
        {

        }
        public ElementBuilder(string element)
        {
            this.Element = element;
        }
        public void AddAtribute(string atribute, string value)
        {
            this.Atribute = atribute;
            this.ValueOfAtribute = value;
            this.AtributeAndValue = " " + this.Atribute + "=\"" + this.ValueOfAtribute + "\"";   
        }
        public void AddContent(string content)
        {
            this.Content = content;
        }
        public static string operator *(ElementBuilder el, int cuantity)
        {
            string res = "";
            for (int i = 0; i < cuantity; i++)
            {
                res += String.Format("<{0}{1}>{2}</{0}>", el.Element, el.AtributeAndValue, el.Content);
            }
                return res;
        }
        public override string ToString()
        {
            returnResult = String.Format("<{0}{1}>{2}</{0}>", this.Element, this.AtributeAndValue, this.Content);
            return returnResult;
        }
    }
}
