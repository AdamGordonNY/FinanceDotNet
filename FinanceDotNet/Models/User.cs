using System.Transactions;

namespace FinanceDotNet.Models
{
    public class User
    {

        public int id { get; set; }
        public string username { get; set; }
        public string passwordHash { get; set; }
        public string Email { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        
        public ICollection<SavingsGoal> SavingsGoals { get; set; }
    }
}
