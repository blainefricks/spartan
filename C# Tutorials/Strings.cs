using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 13 | Working with Strings

namespace Strings
{
  class Program
  {
    static void Main(string[] args)
    {
      // string myString = "Go to your c:\\ drive";
      // string myString = "My \"so called\" life";
      // string myString = "What if I need \n a new line?";

      // string myString = string.Format("{0}!", "Bonzai");
      // string myString = string.Format("Make: {0} (Model: {1})", "BMW", "760li");

      // string myString = string.Format("{0:C}", 123.45); // Outpus Currencey "$123.45"
      // string myString = string.Format("{0:N}", 123456789); // Outputs Number "123,456,789.00"
      // string myString = string.Format("{0:P}", .123); // Outputs Percentage "12.30%"
      // string myString = string.Format("Phone number: {0:(###) ###-####}", 1234567890); // Outputs "(123) 456-7890"

      /*
      string myString = "";

      for (int i = 0; i <100; i++)
      {
        // myString = myString + "--" + i.ToString();
        myString += "--" + i.ToString();
      }
      */

      /*
      StringBuilder myString = new StringBuilder();

      for (int i = 0; i < 100; i++)
      {
        myString.Append("--");
        myString.Append(i);
      }
      */

      string myString = " That summer we took threes across the board  ";

      // myString = myString.Substring(5, 14);
      // myString = myString.ToUpper(); // Converts string to all upper case
      // myString = myString.Replace(" ", "--"); // Replaces all " " with "--"
      myString = String.Format(
        "Length before: {0} -- After: {1}",
        myString.Length, myString.Trim().Length);


      Console.WriteLine(myString);
      Console.ReadLine();
    }
  }
}