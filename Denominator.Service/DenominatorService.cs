using System;
using System.Diagnostics;

namespace Denominator.Service
{
    public class DenominatorService : IDenominatorService
    {
        public string GetChange(ApplicationArguments applicationArguments)
        {
            if (applicationArguments.Cost == null || applicationArguments.Tendered == null)
            {
                return "No Arguments passed or were passed incorrectly!";
            }

            try
            {
                var cost = decimal.Parse(applicationArguments.Cost);
                var tendered = decimal.Parse(applicationArguments.Tendered);

                if (tendered < cost)
                {
                    return "NOT ENOUGH TENDERED!";
                }

                if (tendered == cost)
                {
                    return "NO CHANGE!";
                }

                var changeFrom = tendered - cost;
                var result = "Your Change is:\n";

                var monies = new[]
                {
                    new {name = "£50", value = 50M},
                    new {name = "£20", value = 20M},
                    new {name = "£10", value = 10M},
                    new {name = "£5", value = 5M},
                    new {name = "£2", value = 2M},
                    new {name = "£1", value = 1M},
                    new {name = "50p", value = 0.50M},
                    new {name = "20p", value = 0.20M},
                    new {name = "10p", value = 0.10M},
                    new {name = "5p", value = 0.05M},
                    new {name = "2p", value = 0.02M},
                    new {name = "1p", value = 0.01M}
                };

                foreach (var money in monies)
                {
                    var count = (int) (changeFrom / money.value);

                    changeFrom -= count * money.value;

                    if (count <= 0) continue;

                    result += $"{count} x {money.name}";
                    result += "\n";
                }

                return result;
            }
            catch (FormatException e)
            {
                Debug.WriteLine(e);
                return "Tendered/Cost was not the correct format, please enter a decimal value for both arguments";
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
