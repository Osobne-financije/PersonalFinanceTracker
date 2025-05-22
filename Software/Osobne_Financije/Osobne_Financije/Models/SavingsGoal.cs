using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osobne_Financije.Models
{
    class SavingsGoal
    {
        public int GoalId { get; set; }
        public int StudentId { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
