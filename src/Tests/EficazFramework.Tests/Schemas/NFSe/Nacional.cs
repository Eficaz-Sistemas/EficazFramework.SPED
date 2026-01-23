using EficazFramework.SPED.Schemas.NFSe.Nacional;
using EficazFramework.SPED.Tests;

namespace EficazFramework.SPED.Schemas.NFSe;

public class NFSeNacional : BaseXmlTest<Nacional.NFSe>
{
    [Test]
    public async Task Read()
    {
        Nacional.NFSe instance = await ReadAsync(Resources.Schemas.XML.NFSe_Nacional_1_0_1);
        instance.Should().NotBeNull();

        instance.Chave.Should().Be("NFS3510000004900099000019700000000000006010200049010");
        instance.InfNFSe.LocalEmissao.Should().Be("FRANCA");
        instance.InfNFSe.LocalPrestacao.Should().Be("Franca");
        instance.InfNFSe.Numero.Should().Be(113);
        instance.InfNFSe.LocalIncidenciaCodigo.Should().Be("3516200");
        instance.InfNFSe.LocalIncidenciaNome.Should().Be("Franca");
        instance.InfNFSe.TributacaoNacional.Should().Be("Contabilidade, inclusive serviços técnicos e auxiliares.");
        instance.InfNFSe.VersaoAplicativo.Should().Be("SilTecnologia_v1.00");
        instance.InfNFSe.AmbienteGerador.Should().Be(AmbienteGerador.Prefeitura);
        instance.InfNFSe.TipoEmissao.Should().Be(TipoEmissao.LeiauteMunicipal);
        instance.InfNFSe.CodigoSituacao.Should().Be("100");
        instance.InfNFSe.DataHoraProcessamento.Should().Be(new DateTimeOffset(2026, 01, 10, 0, 0, 0, TimeSpan.FromHours(-3)));
        instance.InfNFSe.NumeroSequencial.Should().Be("27644971");
        
        instance.InfNFSe.Emitente.Should().NotBeNull();
        instance.InfNFSe.Emitente.Cnpj.Should().Be("11222333000144");
        instance.InfNFSe.Emitente.InscricaoMunicipal.Should().Be("117915");
        instance.InfNFSe.Emitente.Nome.Should().Be("ORGANIZAÇÃO CONTÁBIL");
        instance.InfNFSe.Emitente.EnderecoNacional.Should().NotBeNull();
        instance.InfNFSe.Emitente.EnderecoNacional.Logradouro.Should().Be("14400-000 - Rua da Nota, 1215   SALA 80");
        instance.InfNFSe.Emitente.EnderecoNacional.Numero.Should().Be("0");
        instance.InfNFSe.Emitente.EnderecoNacional.Bairro.Should().Be("Centro");
        instance.InfNFSe.Emitente.EnderecoNacional.MunicipioCodigo.Should().Be("3516200");
        instance.InfNFSe.Emitente.EnderecoNacional.UF.Should().Be("SP");
        instance.InfNFSe.Emitente.EnderecoNacional.CEP.Should().Be("14400000");
        instance.InfNFSe.Emitente.Telefone.Should().Be("9912345678");
        instance.InfNFSe.Emitente.Email.Should().Be("admin@fakemail.com");

        instance.InfNFSe.Valores.Should().NotBeNull();
        instance.InfNFSe.Valores.IssqnBaseCalculo.Should().Be(5000m);
        instance.InfNFSe.Valores.IssqnAliquota.Should().Be(2m);
        instance.InfNFSe.Valores.IssqnValor.Should().Be(100m);
        instance.InfNFSe.Valores.ValorTotalRetencoes.Should().BeNull();
        instance.InfNFSe.Valores.ValorTotalLiquido.Should().Be(5000m);

        instance.InfNFSe.DPS.Should().NotBeNull();
        instance.InfNFSe.DPS.InfDPS.Should().NotBeNull();
        var dps = instance.InfNFSe.DPS.InfDPS;
        dps.Id.Should().Be("DPS351620024973699600019749999000000000000113");
        dps.Ambiente.Should().Be(Nacional.Ambiente.Producao);
        dps.DataHoraEmissao.Should().Be(new DateTimeOffset(2026, 01, 10, 0, 0, 0, TimeSpan.FromHours(-3)));
        dps.VersaoAplicativo.Should().Be("SilTecnologia_v1.00");
        dps.Serie.Should().Be("49999");
        dps.Numero.Should().Be(113);
        dps.Competencia.Should().Be("2026-01-01");
        dps.TipoEmitente.Should().Be(EmitenteDps.Prestador);
        dps.LocalEmissaoCodigo.Should().Be("3516200");

        dps.Prestador.Should().NotBeNull();
        dps.Prestador.Cnpj.Should().Be("49736996000197");
        dps.Prestador.InscricaoMunicipal.Should().Be("117915");
        dps.Prestador.Telefone.Should().Be("1681282669");
        dps.Prestador.Email.Should().Be("DANIEL8304@GMAIL.COM");

        dps.Prestador.RegimeTributario.Should().NotBeNull();
        dps.Prestador.RegimeTributario.OptanteSimplesNacional.Should().Be(3);
        dps.Prestador.RegimeTributario.regApTribSN.Should().Be(2);
        dps.Prestador.RegimeTributario.RegimeEspecial.Should().Be(0);

        dps.Tomador.Should().NotBeNull();
        dps.Tomador.CNPJ.Should().Be("07170885000116");
        dps.Tomador.xNome.Should().Be("Ataide Marcelino Advogados");
        dps.Tomador.Endereco.Should().NotBeNull();
        dps.Tomador.Endereco.Nacional.Should().NotBeNull();
        dps.Tomador.Endereco.Nacional.MunicipioCodigo.Should().Be("3516200");
        dps.Tomador.Endereco.Nacional.CEP.Should().Be("14406022");
        dps.Tomador.Endereco.Logradouro.Should().Be("Avenida das Seringueiras");
        dps.Tomador.Endereco.Numero.Should().Be("1000");
        dps.Tomador.Endereco.Bairro.Should().Be("Residencial Amazonas");

        dps.Servico.Should().NotBeNull();
        dps.Servico.LocalPrestacao.Should().NotBeNull();
        dps.Servico.LocalPrestacao.Codigo.Should().Be("3516200");
        dps.Servico.InfoServico.Should().NotBeNull();
        dps.Servico.InfoServico.CodigoTribNacional.Should().Be("171901");
        dps.Servico.InfoServico.Descricao.Should().Be("Honorários Contábeis - Serviços de Consultoria Tributária - Mês 12/2025");
        dps.Servico.InfoServico.NBS.Should().Be("113022100");

        dps.Valores.Should().NotBeNull();
        dps.Valores.ValoresPrestacao.Should().NotBeNull();
        dps.Valores.ValoresPrestacao.ValorServico.Should().Be(5000.00m);

        dps.Valores.Tributos.Should().NotBeNull();
        dps.Valores.Tributos.Municipais.Should().NotBeNull();
        dps.Valores.Tributos.Municipais.Issqn.Should().Be("1");
        dps.Valores.Tributos.Municipais.TipoRetencao.Should().Be("1");

        dps.Valores.Tributos.TotalTributos.Should().NotBeNull();
        dps.Valores.Tributos.TotalTributos.ValorTotalTributos.Should().NotBeNull();
        dps.Valores.Tributos.TotalTributos.ValorTotalTributos.Federais.Should().Be(0.00m);
        dps.Valores.Tributos.TotalTributos.ValorTotalTributos.Estaduais.Should().Be(0.00m);
        dps.Valores.Tributos.TotalTributos.ValorTotalTributos.Municipais.Should().Be(100.00m);

        //[Test]
        //public async Task ParseLote()
        //{
        //    var folder = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Samples", "NFseNacional");
        //    if (Directory.Exists(folder))
        //    {
        //        var files = Directory.GetFiles(folder, "*.xml");
        //        foreach (var file in files)
        //        {
        //            Console.WriteLine($"Processing file: {file}");
        //            var doc = await ReadAsync(await File.ReadAllTextAsync(file));
        //            doc.Should().NotBeNull();
        //            Console.WriteLine($"✅ Parsed document type: {doc.DocumentType}. Chave: {doc.Chave}");
        //
        //        }
        //    }
        //    else
        //    {
        //        Assert.Fail($"Test folder does not exist: {folder}");
        //    }
        //}
    }


    [Test]
    public async Task ParseLote()
    {
        var baseDir = AppDomain.CurrentDomain.BaseDirectory;
        var folder = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Samples", "NFseNacional");
        if (Directory.Exists(folder))
        {
            var files = Directory.GetFiles(folder, "*.xml");
            foreach (var file in files)
            {
                Console.WriteLine($"Processing file: {file}");
                var doc = await ReadAsync(File.ReadAllText(file));
                doc.Should().NotBeNull();
                doc.Should().BeOfType<Nacional.NFSe>();

                var nfse = doc as Nacional.NFSe;

                Console.WriteLine($"✅ Parsed document type: {nfse.DocumentType}. Chave: {nfse.Chave}");
                Console.WriteLine($"*** Dados da NFSe Nacional ***");
                Console.WriteLine($"🛍️ Chave = {nfse.Chave}");
                Console.WriteLine($"🛍️ Número = {nfse.InfNFSe.Numero}");
                Console.WriteLine($"🛍️ Emitente = {nfse.InfNFSe.Emitente.Nome}, {nfse.InfNFSe.Emitente.Cnpj ?? nfse.InfNFSe.Emitente.CPF}");
                Console.WriteLine($"🛍️ Tomador = {nfse.InfNFSe.DPS.InfDPS.Tomador.xNome}, {nfse.InfNFSe.DPS.InfDPS.Tomador.CNPJ ?? nfse.InfNFSe.DPS.InfDPS.Tomador.CPF}");
                Console.WriteLine($"🛍️ Valor Serviço = {nfse.InfNFSe.DPS.InfDPS.Valores.ValoresPrestacao.ValorServico}");
                if (nfse.InfNFSe.DPS.InfDPS.IBSCBS != null)
                {
                    Console.WriteLine($"🛍️ CST: {nfse.InfNFSe.DPS.InfDPS.IBSCBS?.valores?.trib?.gIBSCBS?.CST}");
                    Console.WriteLine($"🛍️ cClassTrib: {nfse.InfNFSe.DPS.InfDPS.IBSCBS?.valores?.trib?.gIBSCBS?.cClassTrib}");
                    Console.WriteLine($"🛍️ BC IBS/CBS: {nfse.InfNFSe.IBSCBS?.valores?.vBC}");
                    Console.WriteLine($"🛍️ IBS Mun %: {nfse.InfNFSe.IBSCBS?.valores?.mun?.pIBSMun}");
                    Console.WriteLine($"🛍️ IBS Mun: {nfse.InfNFSe.IBSCBS?.totCIBS?.gIBS?.gIBSMunTot?.vIBSMun}");
                    Console.WriteLine($"🛍️ IBS UF %: {nfse.InfNFSe.IBSCBS?.valores?.uf?.pIBSUF}");
                    Console.WriteLine($"🛍️ IBS UF % Red: {nfse.InfNFSe.IBSCBS?.valores?.uf?.pRedAliqUF}");
                    Console.WriteLine($"🛍️ IBS UF % Efetivo: {nfse.InfNFSe.IBSCBS?.valores?.uf?.pAliqEfetUF}");
                    Console.WriteLine($"🛍️ IBS UF: {nfse.InfNFSe.IBSCBS?.totCIBS?.gIBS?.gIBSUFTot?.vIBSUF}");
                    Console.WriteLine($"🛍️ CBS %: {nfse.InfNFSe.IBSCBS?.valores?.fed?.pCBS}");
                    Console.WriteLine($"🛍️ CBS UF % Red: {nfse.InfNFSe.IBSCBS?.valores?.fed?.pRedAliqCBS}");
                    Console.WriteLine($"🛍️ CBS UF % Efetivo: {nfse.InfNFSe.IBSCBS?.valores?.fed?.pAliqEfetCBS}");
                    Console.WriteLine($"🛍️ CBS: {nfse.InfNFSe.IBSCBS?.totCIBS?.gCBS?.vCBS}");
                }
                else
                {
                    Console.WriteLine("IBS/CBS tag group is null");
                }
                Console.WriteLine($"***");
                Console.WriteLine("=============================================");
            }
        }
        else
        {
            Assert.Fail($"Test folder does not exist: {folder}");
        }
    }



}