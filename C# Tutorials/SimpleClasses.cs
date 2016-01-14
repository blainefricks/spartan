using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 15 | Understanding and Creating Classes

namespace SimpleClasses
{
  class Program
  {
    static void Main(string[] args)
    {
      Car myNewCar = new Car();

    }
  }

  class Car
  {
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }

  }

}