using System.Collections.Generic;

namespace Denominator.Service
{
    public interface IDenominatorService
    {
        string GetChange(ApplicationArguments applicationArguments);
    }
}