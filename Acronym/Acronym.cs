using System;
using System.Collections.Generic;

namespace Acronym
{
    public static class AcronymFactory
    {
        public static string GetAcronym(string msg, Dictionary<string, string> specials = null)
        {
            string result = "";
            string[] parts = msg.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts) 
            {
                string firstChar;
                if (specials != null && specials.ContainsKey(part.ToLower()))
                    firstChar = specials[part.ToLower()];
                else
                    firstChar = part[0].ToString().ToUpper();
                result = result + firstChar;
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine("Output: " + GetAcronym(input));
            Console.ReadLine();
        }
    }
}
