namespace FinanceDotNet.Models
{
    public class SavingsGoal
    {
        public int id { get; set; }
        public string GoalName { get; set; }
        public decimal TargetAmount { get; set; }

        public decimal SavedAmount { get; set; }
        public DateTime Deadline { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
