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
            List<Expense> expenses = new List<Expense>(); //created  a list that holds expense objects

            Console.Write("Enter expense description: ");
            string expenseDescr = Console.ReadLine();

            Console.Write("Enter amount: ");
            Decimal amount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            Expense expense = new Expense(expenseDescr, amount, category);
            expenses.Add(expense);
            Console.WriteLine(); //adds gap
            Console.WriteLine("All expenses:");
            foreach (Expense item in expenses) 
            {
                Console.WriteLine($"{item.Description} - £{item.Amount} - {item.Category}"); //prints each expense's detail
            }
        }
    }
}
