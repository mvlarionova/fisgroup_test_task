namespace TestCreadit.DTO
{
    public class ShedulerChecks
    {
        public int Month { get; set; }
        /// <summary>
        /// Ежемесячный платеж
        /// </summary>
        public double MonthlyPayment { get; set; }
        /// <summary>
        /// Основной долг
        /// </summary>
        public double PrincipalDebt { get; set; }
        /// <summary>
        /// Долг по процентам
        /// </summary>
        public double InterestDebt { get; set; }
        /// <summary>
        /// Основной остаток долга
        /// </summary>
        public double RemainingDebt { get; set; }
        
    }
}