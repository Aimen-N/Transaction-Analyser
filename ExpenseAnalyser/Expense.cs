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
        public string Category { get; set; }

        public Expense(string description, decimal amount, string category)
        {
            Description = description;
            Amount = amount;
            Category = category;
        }
    }
}
