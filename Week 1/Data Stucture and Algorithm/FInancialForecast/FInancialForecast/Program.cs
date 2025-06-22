class FinancialForecast
{
    public static int CalculateFuture(int currentAmount,float growthRate,int numberofyears)
    {
        if (numberofyears == 0)
        {
            return currentAmount;
        }
        else
        {
            currentAmount = (int)(currentAmount + (growthRate/100 * currentAmount));
            numberofyears--;
            return CalculateFuture(currentAmount, growthRate, numberofyears);
        }
        
    }

    public static void Main(string[] args)
    {
        int currentAmount = 1000;
        float growthRate = 13.3f;
        int numberofyears = 4;
        int finalamount = CalculateFuture(currentAmount,growthRate,numberofyears);
        Console.WriteLine(finalamount);
    }
}