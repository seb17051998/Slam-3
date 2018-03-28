using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> liste = new List<int> { 4, 6, 1, 9, 5, 15, 8, 3, 20, 7 };
            

            
            IEnumerable<int> requeteTriee = from i in liste where i>5 orderby i select i;
            foreach(int i in requeteTriee)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
