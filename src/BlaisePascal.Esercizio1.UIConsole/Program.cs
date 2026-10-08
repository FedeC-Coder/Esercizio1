using BlaisePascal.Esercizio1.Domain;

public class Program
{
    public static void Main()
    {
        try
        {
            Vehicle veichle = new Vehicle("AB123AB", 1, 1, 1);
            Console.WriteLine(veichle.FuelPercentage);
            veichle.refill(100);
            Console.WriteLine(veichle.FuelPercentage);
        }
        catch (Exception ex) { 
            Console.WriteLine(ex.ToString());
        }
    }
}