using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 11 | Creating and Calling Siple Overloaded Helpers

namespace HelperMethods
{
  class Program
  {
    // "Void" means that this method doesn't return anything.
    static void Main(string[] args)
    {
      // string myValue = superSecretFormula("world");
      string myValue = superSecretFormula("Blaine");
      Console.WriteLine(myValue);
      Console.ReadLine();
    }

    // private methods can only be called inside of class "Program"
    private static string superSecretFormula()
    {
      // some cool stuff here
      return "Hello World!";
    }

    private static string superSecretFormula(string name)
    {
      return String.Format("Hello, {0}!", name);
    }

  }
}