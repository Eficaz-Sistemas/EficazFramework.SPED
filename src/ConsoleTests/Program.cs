using EficazFramework.SPED.Utilities.Registros;

namespace ConsoleTests;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Functions.ConvertStringArrayInDefaultSchema(new string[] {"Q100", "1", "Otávio", "R$ 5.000,00"}));
    }
}
