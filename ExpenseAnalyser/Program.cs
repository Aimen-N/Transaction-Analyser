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
            string expenseDescr = Console.ReadLine();

            Console.Write("Enter amount: ");
            Decimal amount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            Expense expense = new Expense(expenseDescr, amount, category);
        }
    }
}
