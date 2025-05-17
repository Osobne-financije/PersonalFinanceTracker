using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osobne_Financije.Models
{
    class Income
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }

    }
}
