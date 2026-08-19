using ExpenseAnalyser;
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
            bool Active = true;

            while (Active) //menu interface which keeps running until boolean statement becomes false
            {
                Console.WriteLine();
                Console.WriteLine("SELECT AN OPTION BELOW:");
                Console.WriteLine("1. Add expense");
                Console.WriteLine("2. View expenses");
                Console.WriteLine("3. View spending summary");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                Console.Write("Please choose your option: ");
                string Option = Console.ReadLine();

                switch (Option)
                {
                    case "1":
                        AddExpense(expenses); //calls method for adding expenses
                        break;
                    case "2":
                        ViewExpenses(expenses); //calls method for viewing expenses
                        break;
                    case "3":
                        ViewSpendingSummary(expenses); //calls method which gives the total and average spending
                        break;
                    case "4":
                        Active = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose 1, 2 or 3.");
                        break;

                }
            }
            
        }
        static void AddExpense(List<Expense> expenses)
        {
            Console.Write("Enter expense description: ");
            string expenseDescr = Console.ReadLine();

            bool validAmount = false;
            decimal amount=0;

            while (!validAmount) // Keep asking for an amount until the user enters a valid number
            {
                Console.Write("Enter amount: ");
                string useramount = Console.ReadLine();
                validAmount = decimal.TryParse(useramount, out amount); //TryParse converts the user's input into a decimal, returns true if successful and false if input is invalid
                if (!validAmount)
                {
                    Console.WriteLine("Invalid amount. Please enter a valid number.");
                }
            }

            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            Expense expense = new Expense(expenseDescr, amount, category);
            expenses.Add(expense); //creates an expense
        }
        static void ViewExpenses(List<Expense> expenses)
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses have been added.");
            }
            else
            {
                Console.WriteLine("All expenses:");

                foreach (Expense item in expenses)
                {
                    Console.WriteLine($"{item.Description} - £{item.Amount} - {item.Category}");
                }
            }
        }
        static void ViewSpendingSummary(List<Expense> expense)
        {

            decimal Total = 0;
            decimal Avg = 0;
            for(int i=0; i<expense.Count; i++)
            {
                Total = Total + expense[i].Amount; //All the amounts in the list are added
                Avg = Total / expense.Count; //calculates average spending
            }
            Console.WriteLine($"Total spending: £{Total}");
            Console.WriteLine($"Average spending: £{Avg}");


        }
    }
 }

