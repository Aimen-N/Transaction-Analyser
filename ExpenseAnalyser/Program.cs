using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAnalyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter expense description: ");
            string ExpenseDescr = Console.ReadLine();

            Console.Write("Enter amount: ");
            int Amount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter category: ");
            string Category = Console.ReadLine();
            
        }
    }
}
