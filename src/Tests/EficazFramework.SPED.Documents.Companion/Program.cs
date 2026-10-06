using EficazFramework.Documents.Companion;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using System.Diagnostics;


// DANFSe NACIONAL v2.0 (NT 008)
var nfse = await Helper.ObterNFSeNacionalAsync("001.xml");
await new EficazFramework.SPED.Documents.NFSe.DanfseDocument(nfse!, new()
{ 
    ExibirCanhoto = true,
    LogoNfse = EficazFramework.SPED.Resources.Logos.nfse
}).ShowInCompanionAsync();

// DANFE SIMPLIFICADO
// var nfe = await Helper.ObterNFeAsync("001.xml");

// DANFE SIMPLIFICADO
//var nfe = await Helper.ObterNFeAsync("002.xml");

//var document = new EficazFramework.SPED.Documents.NFe.DanfeDocument(nfe!, new()
//{
//    MensagemRodape = container =>
//    {
//        container.Row(row =>
//        {
//            row.RelativeItem().Padding(1).Text("Desenvolvido por Eficaz Sisteams de Gestão e Inteligência Tributária Ltda").FontSize(7);
//        });
//    }
//});
//await document.ShowInCompanionAsync();
Console.ReadKey();