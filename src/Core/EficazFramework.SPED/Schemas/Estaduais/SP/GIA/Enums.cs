
namespace EficazFramework.SPED.Schemas.SP.GIA;

public enum RegimeTributario
{
    RPA = 1,
    RES = 2,
    RPA_Dispensado = 3,
    Simples_ST = 4
}

public enum TipoGIA
{
    Normal = 1,
    Substitutiva = 2,
    Coligida = 3
}

public enum OrigemPreenchimento
{
    PreFormatadoERP = 0,
    Digitado = 1
}

public enum Operacao
{
    Propria = 0,
    ST = 1
}
