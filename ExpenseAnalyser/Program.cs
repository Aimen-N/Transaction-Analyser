using ExpenseAnalyser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ExpenseAnalyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Expense> expenses = new List<Expense>(); //created  a list that holds expense objects
            List<CategorisationRule> LearnedRules = new List<CategorisationRule>();//stores what the program has learned
            bool Active = true;

            while (Active) //menu interface which keeps running until boolean statement becomes false
            {
                Console.WriteLine();
                Console.WriteLine("SELECT AN OPTION BELOW:");
                Console.WriteLine("1. Add expense");
                Console.WriteLine("2. View expenses");
                Console.WriteLine("3. View spending summary");
                Console.WriteLine("4. View spending by category");
                Console.WriteLine("5. Export Expenses");
                Console.WriteLine("6. Exit");
                Console.WriteLine();
                Console.Write("Please choose your option: ");
                string Option = Console.ReadLine();

                switch (Option)
                {
                    case "1":
                        AddExpense(expenses, LearnedRules); //calls method for adding expenses
                        break;
                    case "2":
                        ViewExpenses(expenses); //calls method for viewing expenses
                        break;
                    case "3":
                        ViewSpendingSummary(expenses); //calls method which gives the total and average spending
                        break;
                    case "4":
                        ViewSpendingByCategory(expenses);
                        break;
                    case "5":
                        ExportExpense(expenses); //calls method which exports the list of expenses
                        break;
                    case "6":
                        Active = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose 1, 2 or 3.");
                        break;

                }
            }
            
        }
        static void AddExpense(List<Expense> expenses, List<CategorisationRule> LearnedRules)
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

            Category category = CategoriseExpense(expenseDescr, LearnedRules); //calls the method to automatically determine the category from the description

            Expense expense = new Expense(expenseDescr, amount, category);
            expenses.Add(expense); //creates an expense
        }
        static Category CategoriseExpense(string description, List<CategorisationRule> LearnedRules)
        {
            string text = description.ToLower(); //converts user input to lower case

            if (text.Contains("tesco") || text.Contains("asda") || text.Contains("aldi") || text.Contains("lidl"))
            {
                return Category.Groceries;
            }

            if (text.Contains("uber") || text.Contains("bus") || text.Contains("train") || text.Contains("taxi") || text.Contains("tram"))
            {
                return Category.Transport;
            }

            if (text.Contains("amazon") || text.Contains("ebay"))
            {
                return Category.Shopping;
            }

            if (text.Contains("netflix") || text.Contains("amazon prime") || text.Contains("disney plus") || text.Contains("hbo max"))
            {
                return Category.Entertainment;
            }

            foreach (CategorisationRule rule in LearnedRules) //goes through all the rules that are learned
            {
                if (text.Contains(rule.Keyword.ToLower()))
                {
                    return rule.Category; //if the expense description matches then save it in that category
                }
            }
            return AskForCategory(description, LearnedRules);
        }
        static Category AskForCategory(string description, List<CategorisationRule> LearnedRules)
        {
            Console.WriteLine("Unable to assign a category for this expense. Please select one of the following categories you think is appropriate");
            Console.WriteLine("1. Groceries");
            Console.WriteLine("2. Transport");
            Console.WriteLine("3. Shopping");
            Console.WriteLine("4. EatingOut");
            Console.WriteLine("5. Entertainment");
            Console.WriteLine("6. Bills");
            Console.Write("Select a Category number: ");
            string Input = Console.ReadLine();
            Category SelectedCategory;

            switch (Input) 
            {
                case "1":
                    SelectedCategory = Category.Groceries;
                    break;
                case "2":
                    SelectedCategory = Category.Transport;
                    break;
                case "3":
                    SelectedCategory = Category.Shopping;
                    break;
                case "4":
                    SelectedCategory = Category.EatingOut;
                    break;
                case "5":
                    SelectedCategory = Category.Entertainment;
                    break;
                case "6":
                    SelectedCategory = Category.Bills;
                    break;
                default:
                    Console.WriteLine("Invalid category.");
                    return Category.Other;
            }
            CategorisationRule NewRule = new CategorisationRule(description, SelectedCategory); //created a new rule object
            LearnedRules.Add(NewRule); //added it to the list of learned rules
            return SelectedCategory;
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
        static void ViewSpendingSummary(List<Expense> expenses)
        {
            decimal Total = 0;
            decimal Avg = 0;
            for(int i=0; i<expenses.Count; i++)
            {
                Total = Total + expenses[i].Amount; //All the amounts in the list are added
                Avg = Total / expenses.Count; //calculates average spending
            }
            Console.WriteLine($"Total spending: £{Total}");
            Console.WriteLine($"Average spending: £{Avg}");
        }

        static void ViewSpendingByCategory(List<Expense> expenses)
        {
            Console.WriteLine("* SELECT CATEGORY FROM BELOW *"); //category options
            Console.WriteLine("1. Groceries");
            Console.WriteLine("2. Transport");
            Console.WriteLine("3. Shopping");
            Console.WriteLine("4. EatingOut");
            Console.WriteLine("5. Entertainment");
            Console.WriteLine("6. Bills");
            Console.Write("Select a Category: ");
            string input = Console.ReadLine();
            Category SelectedCategory; //stores the category selected by the user

            switch (input)
            {
                case "1":
                    SelectedCategory = Category.Groceries;
                    break;
                case "2":
                    SelectedCategory = Category.Transport;
                    break;
                case "3":
                    SelectedCategory = Category.Shopping;
                    break;
                case "4":
                    SelectedCategory = Category.EatingOut;
                    break;
                case "5":
                    SelectedCategory = Category.Entertainment;
                    break;
                case "6":
                    SelectedCategory = Category.Bills;
                    break;
                default:
                    Console.WriteLine("Invalid category.");
                    return;
            }
            Console.WriteLine();
            decimal TotalAmount = 0;
            bool ExpenseFound = false;

            foreach(Expense item in expenses)
            {
                if(item.Category == SelectedCategory) //matches the user selected category to the category in each expense
                {
                    TotalAmount = TotalAmount + item.Amount; //calculates the total spending for a specific category
                    ExpenseFound = true;
                }
            }
            if (!ExpenseFound) //checks to see if no expenses were found in the selected category
            {
                Console.WriteLine("No expenses found in this category. ");
            } else
            {
                Console.WriteLine($"You spent £{TotalAmount} in {SelectedCategory}");
            }
        }
        static void ExportExpense(List<Expense> expenses)
        {
            using (StreamWriter write = new StreamWriter("expenses.csv")) //opens expenses.csv for writing
            {
                write.WriteLine("Description, Amount, Category"); //column headers 
                foreach(Expense item in expenses)
                {
                    write.WriteLine($"{item.Description}, {item.Amount}, {item.Category}"); //write each expense as a line in the CSV file
                }
            }
            Console.WriteLine("Expenses successfully Exported");
        }
    }
 }

