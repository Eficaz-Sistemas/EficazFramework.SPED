namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Abertura, Identificação e Referências
/// </summary>
/// <exclude />
[ExcludeFromCodeCoverage]
public class Bloco0 : Primitives.Bloco
{
    /// <summary>
    /// Retorna a primeira instância de Registro0000 encontrada em <see cref="Primitives.Bloco.Registros"/>
    /// </summary>
    public Registro0000 Registro0000
    {
        get
        {
            return (Registro0000)Registros.Where(r => r.Codigo == "0000").FirstOrDefault();
        }
    }
}
