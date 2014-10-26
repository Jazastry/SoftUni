using System;

class GenericList_Tests
{
    static void Main()
    {
        GenericList<string> myList = new GenericList<string>();

        Console.WriteLine("Assigning value of \"ajh\" to the elements");
        for (int i = 0; i < 15; i++)
        {
            myList.Add("ajh");    
        }

        Console.WriteLine(" Overriden ToString method :\n {0}\n", myList);

        myList[2] = "bef";
        Console.WriteLine(" Change value on index [2] to \"bef\"\n{0}\n", myList); 
  
        Console.WriteLine("Use FindIndex method for \"bef\" value :\n {0}\n", myList.FindIndex("bef"));

        string min = myList.FindMin();
        Console.WriteLine("Using FindMin : {0}", min);
        string max = myList.FindMax();
        Console.WriteLine("Using FindMax : {0}\n", max);

        Console.WriteLine("Using Contains(\"j\") : {0}", myList.Contains("j"));
        Console.WriteLine("Using Contains(\"bef\") : {0}\n", myList.Contains("bef"));

        myList.Remove(2);
        Console.WriteLine("Use Remove method for index [2] :\n {0}\n", myList);

        myList.Clear();
        Console.WriteLine("Using Clear method : \n {0}\n", myList);

        Type info = typeof(GenericList<>);
        object[] myVersion = info.GetCustomAttributes(false);

        for (int i = 0; i < myVersion.Length; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("Version : {0}", (Attribute)myVersion[i]);   
            }
        }
    }
}

