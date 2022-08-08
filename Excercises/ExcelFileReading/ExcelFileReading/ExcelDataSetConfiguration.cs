using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelFileReading
{
    internal class ExcelDataSetConfiguratin
    {
        public int DocumentType { get; set; }
        public string CardNumber { get; set; }
        public int DV { get; set; }
        public string FirstHolderLastName { get; set; }
        public string SecondHolderLastName { get; set; }
        public string FirstHolderName { get; set; }
        public string OtherHolderName { get; set; }
        public string HolderBusinessName { get; set; }
        public string Address { get; set; }
        public int DepartmantCode { get; set; }
        public int McpCode { get; set; }
        public int Country { get; set; }
        public string AccountNumber { get; set; } //int
        public int AccountType { get; set; } //_____

        public int TaxExemptionCode { get; set; }
        public int FinalAccountBalance { get; set; }
        public int AverageDailyFinalBalance { get; set; }
        public int MedianDailyAccountBalance { get; set; }
        public int MaximumAccountBalanceValue { get; set; }
        public int MinimumAccountBalanceValue { get; set; }
        public int TotalValueOfCreditMovements { get; set; }
        public int NumberOfMovementsOfCreditNature { get; set; }
        public int AverageValueOfMovementsOfCreditNature { get; set; }
        public int MedianInTheMonthOfDailyCreditNatureMovements { get; set; }
        public int TotalValueOfMovementsOfDebitNature { get; set; }
        public int NumberOfMovementsOfDebitNature { get; set; }
        public int AveragevalueOfmovementsOfDebitNature { get; set; }

    }
}
