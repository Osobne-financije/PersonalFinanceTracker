using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osobne_Financije.Models
{
    class LimitReport
    {
        public string CategoryName { get; set; }
        public decimal LimitAmount { get; set; }
        public decimal Spent { get; set; }

        public decimal Remaining
        {
            get
            {
                return LimitAmount - Spent;
            }
        }
    }
}
