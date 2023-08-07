using System.Collections.Generic;

public interface IAmauntCaluculation
{
    List<int> PrincipalCalculation();
    (List<int>, List<float>) InterestCaluculation();
    List<int> TaxCalculation(float tax);
    List<int> ResultCalculation(List<int> principals, List<int> taxPrincipals);
    int TotalReverseAmount();
}
