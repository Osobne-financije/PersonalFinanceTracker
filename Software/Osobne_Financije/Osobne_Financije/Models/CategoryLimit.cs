using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osobne_Financije.Models
{
    class CategoryLimit
    {
        public int LimitId { get; set; }
        public int StudentId { get; set; }
        public int CategoryId { get; set; }
        public decimal LimitAmount { get; set; }
        public string CategoryName { get; set; }
    }
}
