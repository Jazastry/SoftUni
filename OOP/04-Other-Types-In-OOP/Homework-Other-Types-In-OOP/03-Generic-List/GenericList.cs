using System;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
AttributeTargets.Method | AttributeTargets.Enum,
    AllowMultiple = true)]
public class VersionAttribute : System.Attribute
{
    public string Version { get; private set; }
    public VersionAttribute(int major, int minor)
    {
        string res = "e.g." + major.ToString() + "." + minor.ToString() + ".";
        this.Version = res;
    }

    public override string ToString()
    {
        return String.Format("{0}", this.Version);
    }
}

[Version(2,11)]
public class GenericList<T> where T : IComparable<T>
{    
    private int capacity = 16;
    private T[] elements;
    private int count = 0;
    public GenericList(int capacity = 16)
    {
        this.elements = new T[capacity];
    }
    public void Add(T element)
    {
        // Checks and if neccessary and grows the elements array
        ArrayAutoGrow();            
        elements[count] = element;
        count++;
    }
    private void ArrayAutoGrow()
    {
        if (count == capacity - 1)
        {
            capacity += capacity;
            T[] processList = new T[capacity];
            for (int i = 0; i < elements.Length; i++)
            {
                processList[i] = elements[i];
            }
            elements = processList;
        }
    }
    private void InsertByIndex(int index, T value)
    {
        if (index == count)
        {
            T valueOn = elements[index];
            elements[index] = value;
            elements[index + 1] = valueOn;
        }
        else
        {
            T[] valuesOver = new T[count - (index - 1)];
            int count2 = 0;
            for (int i = index; i <= count; i++)
            {
                valuesOver[count2] = elements[i];
                count2++;
            }

            elements[index] = value;
            count2 = index + 1;
            for (int j = 0; j < valuesOver.Length; j++)
            {
                elements[count2] = valuesOver[j];
                count2++;
            }
        }
        count++;
    }
    public void Remove(int index)
    {
        if ((index > count - 1) || (index < 0))
        {
            throw new IndexOutOfRangeException(String.Format("Index {0} is out of the array.", index));
        }
        else
        {
            T[] reorderArr = new T[count - 1];
            int count2 = 0;
            for (int j = 0; j < count; j++)
            {
                if (j < index)
                {
                    reorderArr[j] = elements[j];
                    count2 = j + 1;
                }
                else if (j > index)
                {
                    reorderArr[count2] = elements[j];
                    count2++;
                }
            }
            elements[count - 1] = elements[count];
            for (int k = 0; k < reorderArr.Length; k++)
            {
                elements[k] = reorderArr[k];
            }
            count--;
        }       
    }
    public T this[int index]
    {
        get
        {
            if ((index > count) || (index < 0))
            {
                throw new IndexOutOfRangeException(String.Format("No assigned value to Index :{0}." , index));
            }
            else
            {
                return this.elements[index];
            }                
        }
        set
        {
            if ((index > count) || (index < 0))
            {
                throw new IndexOutOfRangeException(String.Format("Index {0} is out of the array.", index));
            }
            else if ((index < count) && (index > 0))
            {
                // Checks and if neccessary grows the elements array
                ArrayAutoGrow();
                // Insert value on index and reorder the array
                InsertByIndex(index, value);
            }
        }
    }
    public void Clear()
    {
        capacity = 16;
        T[] newTarr = new T[capacity];
        elements = newTarr;
        count = 0;            
    }
    public int FindIndex(T value)
    {
        int index = -1;
        for (int i = 0; i < count; i++)
        {
            if (value.Equals(elements[i]))
            {
                index = i;
            }
        }
        return index;
    }
    public bool Contains(T value)
    {
        bool result = false;
        for (int i = 0; i < count; i++)
        {
            if (value.Equals(elements[i]))
            {
                result = true;
            }
        }
        return result;
    }
    public int Length()
    {
        return count;
    }
    public T Min(T a, T b)
    {
        if (a.CompareTo(b) <= 0)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
    public T FindMin()       
    {
        T min = elements[0];
        T transit = elements[0];
        for (int i = 0; i < count; i++)
        {          
            min = Min(elements[i], min);
        }
        return min;
    }
    public T Max(T a, T b)
    {
        if (a.CompareTo(b) >= 0)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
    public T FindMax()
    {
        T max = elements[0];
        T transit = elements[0];
        for (int i = 0; i < count; i++)
        {
            max = Max(elements[i], max);
        }
        return max;
    }
    public override string ToString()
    {
        string result = "[";
        for (int i = 0; i < elements.Length; i++)
        {
            if (typeof(T) == typeof(String))
            {
                result += elements[i] + ", ";
                if (i == elements.Length - 1)
                {
                    result += elements[i] + "]";
                }
            }
            else 
            {
                result += elements[i].ToString() + ", ";
                if (i == elements.Length - 1)
                {
                    result += elements[i].ToString() + "]";
                }
            }            
        }
        return result;
    }

    public int CompareTo(T other)
    {
        throw new NotImplementedException();
    }
}


