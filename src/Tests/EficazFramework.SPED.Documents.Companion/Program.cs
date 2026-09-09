using EficazFramework.Documents.Companion;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using System.Diagnostics;


// DANFE SIMPLIFICADO
// var nfe = await Helper.ObterNFeAsync("001.xml");

// DANFE SIMPLIFICADO
var nfe = await Helper.ObterNFeAsync("002.xml");

var document = new EficazFramework.SPED.Documents.NFe.DanfeDocument(nfe!, new());
await document.ShowInCompanionAsync();
Console.ReadKey();