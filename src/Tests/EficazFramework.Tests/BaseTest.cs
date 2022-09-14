using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Tests;

public class BaseTest
{
    [SetUp]
    public void Setup()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
    }
}
