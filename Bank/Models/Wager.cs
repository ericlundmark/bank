namespace Bank.Models
{
    public class Wager : Model
    {
        public double Amount { get; set; }
        public double Odds { get; set; }
        public Competition Competition { get; set; }
    }
}