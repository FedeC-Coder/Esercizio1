using BlaisePascal.Esercizio1.Domain;

public class Program
{
    public static void Main()
    {
        Vehicle veichle = new Vehicle(1, "AB123AB", 1, 1, 1);
        Console.WriteLine(veichle.fuelPercentage);
        veichle.refill(100);
        Console.WriteLine(veichle.fuelPercentage);
    }
}