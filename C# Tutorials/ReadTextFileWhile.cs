using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 12 | While Iterations and Reading Data from a Text File
// Added "using System.IO" for the StreamReader

namespace ReadTextFileWhile
{
  class Program
  {
    static void Main(string[] args)
    {
      StreamReader myReader = new StreamReader("Values.txt");
      // Values.txt isnt found.
      string line = "";

      while (line != null)
      {
        line = myReader.ReadLine();
        if (line != null)
        {
          Console.WriteLine(line);
        }
      }

      myReader.Close();
      Console.ReadLine();

    }
  }
}