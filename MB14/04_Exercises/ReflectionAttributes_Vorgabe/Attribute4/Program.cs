using System;
using System.Reflection;

namespace Attribute4 {

    public class AbbrevationAttribute : Attribute
    {
        private string _input;
        public AbbrevationAttribute(string input)
        {
            _input = input;
        }
        public string Input { get { return _input; } }
    }

    // A sample class for testing the new attribute
    class Stack
    {
        int[] data = new int[10];
        int top = 0;

        [Abbrevation("+ Push")]
        public void Push(int value)
        {
            data[top++] = value;
        }

        [Abbrevation("+ Pop")]
        public int Pop()
        {
            return data[--top];
        }
    }

    public class Test 
    {
        static void Main() 
        {
            Stack stack = new Stack();
            Type t = stack.GetType();

            foreach (var m in t.GetMethods())
            {
                object[] attr = m.GetCustomAttributes(typeof(AbbrevationAttribute), true);
                if (attr.Length > 0)
                {
                    AbbrevationAttribute abbr = (AbbrevationAttribute)(attr[0]);
                    Console.WriteLine(abbr.Input);
                }
            }
        }
    }
    
}