using Business.Strategy.ETO.Domain.PastStrategies;

namespace Business.Strategy.ETO.Domain.Financial
{
    public class FinancialEntity
    {
        public string AttachedIncomeStatement { get; private set; }
        public string CashFlow { get; private set; }
        public string Indebtedness { get; private set; }
        public PastStrategiesEntity PastStrategies { get; private set; }

       



        public FinancialEntity(string attachedIncomeStatement, string cashFlow, string indebtedness, PastStrategiesEntity pastStrategies)
        {
            AttachedIncomeStatement = attachedIncomeStatement;
            CashFlow = cashFlow;
            Indebtedness = indebtedness;
            PastStrategies = pastStrategies;
        }

    }
}
