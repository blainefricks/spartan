using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 14 | Working with DateTime

namespace DatesAndTimes
{
  class Program
  {
    static void Main(string[] args)
    {
      DateTime myValue = DateTime.Now;
      // Console.WriteLine(myValue.ToString()); // Outputs "2/6/2015 11:35:31 AM"
      // Console.WriteLine(myValue.ToShortDateString()); // Outputs "2/6/2015"
      // Console.WriteLine(myValue.ToShortTimeString()); // Outputs "11:39 AM"
      // Console.WriteLine(myValue.ToLongDateString()); // Outputs "Friday, February 6, 2015"
      // Console.WriteLine(myValue.ToLongTimeString()); // Outputs "11:40:57 AM"

      // Console.WriteLine(myValue.AddDays(3).ToLongDateString()); // Outputs "Monday, February 9, 2015", 3 days from now
      // Console.WriteLine(myValue.AddHours(3).ToShortTimeString()); // Outputs "2:44 PM", 3 hours from now

      // Console.WriteLine(myValue.AddDays(-3).ToLongDateString()); // Outputs "Tuesday, February 3, 2015", 3 days ago

      // Console.WriteLine(myValue.Month.ToString()); // Outputs "2" for February

      // DateTime myBirthday = new DateTime(1269, 12, 7);
      // Console.WriteLine(myBirthday.ToShortDateString()); // Outputs "12/7/1269"

      DateTime myBirthday = DateTime.Parse("12/7/1969");
      TimeSpan myAge = DateTime.Now.Subtract(myBirthday);
      Console.WriteLine(myAge.TotalDays); // Outputs "16497.4950594559"

      Console.ReadLine();
    }
  }
}