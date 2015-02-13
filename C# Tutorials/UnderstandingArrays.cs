using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingArrays
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] numbers = new int[5];

      numbers[0] = 4;
      numbers[1] = 8;
      numbers[2] = 15;
      numbers[3] = 16;
      numbers[4] = 23;
      // numbers[5] = 42;

      Console.WriteLine(numbers.Length);

      /*
      int[] numbers = new int[] { 4, 8, 15, 16, 23, 42 };

      Console.WriteLine(numbers[1].ToString());
      Console.ReadLine();
      */

      // string[] names = new string[] { "Eddie", "Alex", "Micheal", "David Lee"};

      // foreach (string name in names)
      // {
      //   Console.WriteLine(name);
      // }
      // Console.ReadLine();

      string zig = "You can get what you want out of life " +
                   "if you help enough other people get what they want.";

      char[] charArray = zig.ToCharArray();
      Array.Reverse(charArray); // Reverses all elements inside of Array.

      foreach (char zigChar in charArray)
      {
        // Console.WriteLine(zigChar); // Writes each character in string on one line per char
        Console.Write(zigChar); // Writes all Char's on the same line
      }

      Console.ReadLine();

    }
  }
}