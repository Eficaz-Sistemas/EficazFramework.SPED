using System;
using System.Text;
using System.Xml;

namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

public abstract class BaseEfdReinfTest<T> : EficazFramework.SPED.Tests.BaseTest where T : IEfdReinfEvt
{
    internal void TestaEvento()
    {
        // criação da instância e alimentação dos campos
        T instancia = Activator.CreateInstance<T>();
        PreencheCampos(instancia);
        instancia.GeraEventoID();

        // serialização para xml (escrita)
        string xmlString = instancia.Serialize(); // ou .ToString();
        XmlDocument doc = new();
        doc.LoadXml(xmlString);

        // validação do XML pelo schema
        //doc.Validate();

        // deserialização para nova instância (leitura de xml)
        T novaInstancia = Activator.CreateInstance<T>();
        novaInstancia.Deserialize(xmlString);    }

    /// <summary>
    /// Utilize este método para preencher os campos do <paramref name="evento"/>
    /// </summary>
    /// <param name="evento"></param>
    public abstract void PreencheCampos(T evento);

    /// <summary>
    /// Utilize este método para comparar se o XML gerado a partir de <paramref name="instanciaPopulada"/>
    /// e escrito para <paramref name="instanciaXml"/> contém os mesmos valores nos campos
    /// </summary>
    /// <param name="instanciaPopulada">Instância criada no início do teste, que recebeu valores de
    /// <see cref="PreencheCampos(T)"/></param>
    /// <param name="instanciaXml">Instância resultante da leitura da string que contém o XML gerado
    /// a partir de <paramref name="instanciaPopulada"/></param>
    public abstract void ValidaLeituraXml(T instanciaPopulada, T instanciaXml);

}
