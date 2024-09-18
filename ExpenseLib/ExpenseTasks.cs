using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExpenseLib
{
    public class ExpenseTasks
    {
        private static List<Expense>? expenses = null;
        public static void Load(string filename)
        {
            try
            {
                string jsonData = File.ReadAllText(filename);
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                expenses = JsonSerializer.Deserialize<List<Expense>>(jsonData, options) ?? new();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Expense> Expenses => expenses?? new();
        public static double AmountTotal => expenses?.Sum(x => x.Amount) ?? 0;
        public static Expense? MaxAmountExpense
        {
            get
            {
                if(expenses == null){
                    return null;
                }
                double maxAmount = expenses.Max(x => x.Amount);
                return expenses.FirstOrDefault(x => x.Amount == maxAmount);
            }
        }
    }
}
