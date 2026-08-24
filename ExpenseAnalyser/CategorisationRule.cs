using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseAnalyser
{
    internal class CategorisationRule
    {
        public string Keyword { get; set; }
        public Category Category { get; set; }

        public CategorisationRule(string keyword, Category category)
        {
            Keyword = keyword;
            Category = category;
        }
    }
}
