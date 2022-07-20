using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Correlação entre códigos de itens comercializados
/// </summary>
/// <remarks>
/// O registro deverá ser informado apenas se o campo TIPO_ITEM do registro 0200 Pai for informado com valor “00 –
/// Mercadoria para Revenda”. <br/><br/>
/// A obrigatoriedade, que só poderá ser estabelecida a partir de 2024, e a forma de escrituração deste registro serão
/// definidas pela UF de domicílio do declarante.Os contribuintes obrigados, caso não tenham informado o registro nas EFD de 
/// 2023, deverão informar, na EFD de janeiro de 2024, todos os códigos de item inativados ou alterados no exercício de 2023.
/// Este registro tem por objetivo informar a correlação entre os diversos códigos de item, relacionados a uma mesma
/// mercadoria, utilizados nos documentos fiscais de entrada e de saída e nos registros da EFD ICMS-IPI.A correlação será feita
/// sempre em relação ao item “atômico”, ou seja, aquele que representa a menor unidade de comercialização praticada pelo
/// estabelecimento.<br/><br/>
/// Nos casos em que os itens são formados pela agregação de mercadorias (kits, cestas básicas etc.), este registro deve
/// ser informado quando aquele item receber um código específico no estoque.A informação do relacionamento entre os
/// componentes de uma mercadoria não sobrepõe a legislação de cada UF na forma de emissão de notas de kits e cestas.
/// No campo 03 QTD_CONTIDA será informada a quantidade de itens “atômicos” contidos no item informado no
/// registro 0200 pai.<br/><br/>
/// Exemplo 1: se o item 0200 Pai é uma cesta básica que contém 10 diferentes produtos, então, esse 0200 terá 10 
/// Registros 0221 filhos.<br/><br/>
/// Exemplo 2: se o item 0200 Pai é uma lata de refrigerante X com 350ml, então, esse 0200 terá apenas um registro 
/// 0221 filho com COD_ITEM_ATOMICO igual ao COD_ITEM do 0200 Pai e QTD_CONTIDA igual a “1”.<br/><br/>
/// Exemplo 3: se o item 0200 Pai é uma caixa com 12 latas de refrigerante X com 350ml, então, esse 0200 terá apenas
/// um registro 0221 filho com COD_ITEM_ATOMICO igual ao COD_ITEM do 0200 do exemplo 2 e QTD_CONTIDA igual a 
/// “12”.
/// </remarks>
public class Registro0221 : Primitives.Registro
{
    public Registro0221() : base("0221")
    {
    }

    public Registro0221(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0221|"); // 1
        writer.Append(CodigoItemAtomico + "|"); // 2
        writer.Append(string.Format("{0:0.######}", QuantidadeContida) + "|"); // 3
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoItemAtomico = data[2].ToString();
        QuantidadeContida = data[3].ToNullableDouble();
    }

    public string CodigoItemAtomico { get; set; } // 2
    public double? QuantidadeContida { get; set; } // 3
}
