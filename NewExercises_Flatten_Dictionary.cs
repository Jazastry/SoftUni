using System;
using System.Collections.Generic;
using System.Linq;

namespace PepiProblem1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>();

            bool runung = true;
            string flatKey = "flatten";
            string endCommand = "end";
            while (runung)
            {
                string strIn = Console.In.ReadLine();
                string[] strArr = strIn.Split(' ');
                string commandKey = strArr[0];
                string innerKey = strArr.Length >= 2 ? strArr[1] : "";
                string innerVal = strArr.Length >= 3 ? strArr[2] : "";
                Console.Out.WriteLine(strArr[0]);

                if (commandKey.Replace(" ", "") == endCommand)
                {
                    runung = false;
                    break;
                }
                else if (commandKey == flatKey && dict.ContainsKey(innerKey))
                {  
                    // Create flatted dictionary from the existing 
                    var flatDict = GetInnerDictionary(dict, innerKey)
                        // result - dict Dictionary member with structure:
                        // Dictionary(<value+key>, <value+key>), the flattened dictionary has key=value
                        .ToDictionary(p => p.Key+p.Value, p => p.Key + p.Value);

                    if (dict.ContainsKey(flatKey))
                    {
                        // Add the existing flattened members to the new flatten dictionary
                        GetInnerDictionary(dict, flatKey).ToList()
                            .ForEach(p => flatDict.Add(p.Key + p.Value, p.Key + p.Value));
                    }

                    dict.Add(flatKey, flatDict);
                } 
                else if (dict.ContainsKey(commandKey))
                {
                    var existingInnerDict = GetInnerDictionary(dict, commandKey);
                    if(existingInnerDict.ContainsKey(innerVal))
                    {
                        existingInnerDict.Remove(innerVal);
                    }
                    existingInnerDict.Add(innerVal, innerKey);
                }
                else
                {
                    var newInnerDict = new Dictionary<string, string>();
                    newInnerDict.Add(innerVal, innerKey);
                    dict.Add(commandKey, newInnerDict);
                }
            }

            int i = 0;
            var nonFlatKeysLiust = dict.Where(p => p.Key != flatKey).Select(p => p.Key).ToList();

            foreach (var key in nonFlatKeysLiust)
            {
                i = 0;
                Console.Out.WriteLine(key);
                GetInnerDictionary(dict, key).ToList()
                    .ForEach(pr => Console.Out.WriteLine((i++) + ". " + pr.Value + " - " + pr.Key));                
            }

            if(dict.ContainsKey(flatKey))
            {
                var flatDictList = dict.Where(p => p.Key != flatKey).Select(p => p.Value).ToList();
                flatDictList.ForEach(p => p.ToList().ForEach(pr => Console.Out.WriteLine((i++) + ". " + pr.Value + pr.Key)));
            }
        }

        public static Dictionary<string, string> GetInnerDictionary(Dictionary<string, Dictionary<string, string>> dictToSearch, string niddle)
        {
            return dictToSearch.Where(p => p.Key == niddle).Select(p => p.Value).ToList().Single();
        }
    }
}
