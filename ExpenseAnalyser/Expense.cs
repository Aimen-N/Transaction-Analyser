using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAnalyser
{
    internal class Expense
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Category Category { get; set; }

        public Expense(string description, decimal amount, Category category)
        {
            Description = description;
            Amount = amount;
            Category = category;
        }
    }
}
