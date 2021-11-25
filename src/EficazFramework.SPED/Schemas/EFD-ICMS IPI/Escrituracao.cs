using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EficazFramework.SPED.Schemas.Primitives;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{
    public class Escrituracao : Primitives.Escrituracao
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Escrituracao() : base("Escrituração Fiscal Digital do ICMS e IPI")
        {
            Blocos.Add("0", new Bloco0());
            Blocos.Add("B", new BlocoB());
            Blocos.Add("C", new BlocoC());
            Blocos.Add("D", new BlocoD());
            Blocos.Add("E", new BlocoE());
            Blocos.Add("G", new BlocoG());
            Blocos.Add("H", new BlocoH());
            Blocos.Add("K", new BlocoK());
            Blocos.Add("1", new Bloco1());
            Blocos.Add("9", new Bloco9());
            BlocoTotalizador = "9";
            RegistroTotalizadorCodigo = "9900";
            RegistroTotalizadorStringFormat = "|" + RegistroTotalizadorCodigo + "|{0}|{1}|";
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public override void ProcessaLinha(string linha)
        {
            Registro reg = null;
            switch (linha.Substring(1, 4) ?? "")
            {
                case "0000":
                    {
                        Versao = linha.Substring(6, 3);
                        reg = new Registro0000(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        break;
                    }

                case "0001":
                    {
                        reg = new Registro0001(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0000.Registro0001 = (Registro0001)reg;
                        break;
                    }

                case "0005":
                    {
                        reg = new Registro0005(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0001.Registro0005 = (Registro0005)reg;
                        break;
                    }

                case "0015":
                    {
                        reg = new Registro0015(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0001.Registros0015.Add((Registro0015)reg);
                        break;
                    }

                case "0100":
                    {
                        reg = new Registro0100(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0001.Registro0100 = (Registro0100)reg;
                        break;
                    }

                case "0150":
                    {
                        reg = new Registro0150(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0001.Registros0150.Add((Registro0150)reg);
                        break;
                    }

                case "0175":
                    {
                        reg = new Registro0175(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        var reg0150 = ((Bloco0)Blocos["0"]).Registro0001.Registros0150.LastOrDefault();
                        if (reg0150 != null)
                        {
                            reg0150.Registros0175.Add((Registro0175)reg);
                        }

                        break;
                    }

                case "0190":
                    {
                        reg = new Registro0190(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0001.Registros0190.Add((Registro0190)reg);
                        break;
                    }

                case "0200":
                    {
                        reg = new Registro0200(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0001.Registros0200.Add((Registro0200)reg);
                        break;
                    }

                case "0205":
                    {
                        reg = new Registro0205(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        var reg0200 = ((Bloco0)Blocos["0"]).Registro0001.Registros0200.LastOrDefault();
                        if (reg0200 != null)
                        {
                            reg0200.Registros0205.Add((Registro0205)reg);
                        }

                        break;
                    }

                case "0206":
                    {
                        reg = new Registro0206(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        var reg0200 = ((Bloco0)Blocos["0"]).Registro0001.Registros0200.LastOrDefault();
                        if (reg0200 != null)
                        {
                            reg0200.Registros0206 = (Registro0206)reg;
                        }

                        break;
                    }

                case "0220":
                    {
                        reg = new Registro0220(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        var reg0200 = ((Bloco0)Blocos["0"]).Registro0001.Registros0200.LastOrDefault();
                        if (reg0200 != null)
                        {
                            reg0200.Registros0220.Add((Registro0220)reg);
                        }

                        break;
                    }

                case "0300":
                    {
                        reg = new Registro0300(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0001.Registros0300.Add((Registro0300)reg);
                        break;
                    }

                case "0305":
                    {
                        reg = new Registro0305(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        var reg0300 = ((Bloco0)Blocos["0"]).Registro0001.Registros0300.LastOrDefault();
                        if (reg0300 != null)
                        {
                            reg0300.Registro0305 = (Registro0305)reg;
                        }

                        break;
                    }

                case "0400":
                    {
                        reg = new Registro0400(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0001.Registros0400.Add((Registro0400)reg);
                        break;
                    }

                case "0450":
                    {
                        reg = new Registro0450(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0001.Registros0450.Add((Registro0450)reg);
                        break;
                    }

                case "0460":
                    {
                        reg = new Registro0460(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0001.Registros0460.Add((Registro0460)reg);
                        break;
                    }

                case "0500":
                    {
                        reg = new Registro0500(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0001.Registros0500.Add((Registro0500)reg);
                        break;
                    }

                case "0600":
                    {
                        reg = new Registro0600(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0001.Registros0600.Add((Registro0600)reg);
                        break;
                    }

                case "0990":
                    {
                        reg = new Registro0990(linha, Versao);
                        Blocos["0"].Registros.Add(reg);
                        ((Bloco0)Blocos["0"]).Registro0000.Registro0990 = (Registro0990)reg;
                        break;
                    }

                case "C100":
                    {
                        reg = new RegistroC100(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        break;
                    }

                case "C101":
                    {
                        reg = new RegistroC101(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC100 = ((BlocoC)Blocos["C"]).RegistrosC100.LastOrDefault();
                        if (regC100 != null)
                        {
                            regC100.RegistroC101 = (RegistroC101)reg;
                        }

                        break;
                    }

                case "C113":
                    {
                        reg = new RegistroC113(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC100 = ((BlocoC)Blocos["C"]).RegistrosC100.LastOrDefault();
                        if (regC100 != null)
                        {
                            regC100.RegistrosC113.Add((RegistroC113)reg);
                        }

                        break;
                    }

                case "C114":
                    {
                        reg = new RegistroC114(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC100 = ((BlocoC)Blocos["C"]).RegistrosC100.LastOrDefault();
                        if (regC100 != null)
                        {
                            regC100.RegistrosC114.Add((RegistroC114)reg);
                        }

                        break;
                    }

                case "C120":
                    {
                        reg = new RegistroC120(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC100 = ((BlocoC)Blocos["C"]).RegistrosC100.LastOrDefault();
                        if (regC100 != null)
                        {
                            regC100.RegistrosC120.Add((RegistroC120)reg);
                        }

                        break;
                    }

                case "C130":
                    {
                        reg = new RegistroC130(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC100 = ((BlocoC)Blocos["C"]).RegistrosC100.LastOrDefault();
                        if (regC100 != null)
                        {
                            regC100.RegistroC130 = (RegistroC130)reg;
                        }

                        break;
                    }

                case "C140":
                    {
                        reg = new RegistroC140(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC100 = ((BlocoC)Blocos["C"]).RegistrosC100.LastOrDefault();
                        if (regC100 != null)
                        {
                            regC100.RegistroC140 = (RegistroC140)reg;
                        }

                        break;
                    }

                case "C141":
                    {
                        reg = new RegistroC141(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC140 = ((BlocoC)Blocos["C"]).RegistrosC140.LastOrDefault();
                        if (regC140 != null)
                        {
                            regC140.RegistrosC141.Add((RegistroC141)reg);
                        }

                        break;
                    }

                case "C170":
                    {
                        reg = new RegistroC170(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC100 = ((BlocoC)Blocos["C"]).RegistrosC100.LastOrDefault();
                        if (regC100 != null)
                        {
                            regC100.RegistrosC170.Add((RegistroC170)reg);
                        }

                        break;
                    }

                case "C172":
                    {
                        reg = new RegistroC172(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC170 = ((BlocoC)Blocos["C"]).RegistrosC170.LastOrDefault();
                        if (regC170 != null)
                        {
                            regC170.RegistroC172 = (RegistroC172)reg;
                        }

                        break;
                    }

                case "C176":
                    {
                        reg = new RegistroC176(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC170 = ((BlocoC)Blocos["C"]).RegistrosC170.LastOrDefault();
                        if (regC170 != null)
                        {
                            regC170.RegistrosC176.Add((RegistroC176)reg);
                        }

                        break;
                    }

                case "C190":
                    {
                        reg = new RegistroC190(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC100 = ((BlocoC)Blocos["C"]).RegistrosC100.LastOrDefault();
                        if (regC100 != null)
                        {
                            regC100.RegistrosC190.Add((RegistroC190)reg);
                        }

                        break;
                    }

                case "C195":
                    {
                        reg = new RegistroC195(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC100 = ((BlocoC)Blocos["C"]).RegistrosC100.LastOrDefault();
                        if (regC100 != null)
                        {
                            regC100.RegistrosC195.Add((RegistroC195)reg);
                        }

                        break;
                    }

                case "C197":
                    {
                        reg = new RegistroC197(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC195 = ((BlocoC)Blocos["C"]).RegistrosC195.LastOrDefault();
                        if (regC195 != null)
                        {
                            regC195.RegistrosC197.Add((RegistroC197)reg);
                        }

                        break;
                    }

                case "C400":
                    {
                        reg = new RegistroC400(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        break;
                    }

                case "C405":
                    {
                        reg = new RegistroC405(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC400 = ((BlocoC)Blocos["C"]).RegistrosC400.LastOrDefault();
                        if (regC400 != null)
                        {
                            regC400.RegistrosC405.Add((RegistroC405)reg);
                        }

                        break;
                    }

                case "C410":
                    {
                        reg = new RegistroC410(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC405 = ((BlocoC)Blocos["C"]).RegistrosC405.LastOrDefault();
                        if (regC405 != null)
                        {
                            regC405.RegistroC410 = (RegistroC410)reg;
                        }

                        break;
                    }

                case "C420":
                    {
                        reg = new RegistroC420(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC405 = ((BlocoC)Blocos["C"]).RegistrosC405.LastOrDefault();
                        if (regC405 != null)
                        {
                            regC405.RegistrosC420.Add((RegistroC420)reg);
                        }

                        break;
                    }

                case "C425":
                    {
                        reg = new RegistroC425(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC420 = ((BlocoC)Blocos["C"]).RegistrosC420.LastOrDefault();
                        if (regC420 != null)
                        {
                            regC420.RegistrosC425.Add((RegistroC425)reg);
                        }

                        break;
                    }

                case "C460":
                    {
                        reg = new RegistroC460(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC405 = ((BlocoC)Blocos["C"]).RegistrosC405.LastOrDefault();
                        if (regC405 != null)
                            regC405.RegistrosC460.Add((RegistroC460)reg);
                        break;
                    }

                case "C470":
                    {
                        reg = new RegistroC470(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC405 = ((BlocoC)Blocos["C"]).RegistrosC405.LastOrDefault();
                        if (regC405 != null)
                            regC405.RegistrosC470.Add((RegistroC470)reg);
                        var regC460 = ((BlocoC)Blocos["C"]).RegistrosC460.LastOrDefault();
                        if (regC460 != null)
                            regC460.RegistrosC470.Add((RegistroC470)reg);
                        break;
                    }

                case "C490":
                    {
                        reg = new RegistroC490(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC405 = ((BlocoC)Blocos["C"]).RegistrosC405.LastOrDefault();
                        if (regC405 != null)
                        {
                            regC405.RegistrosC490.Add((RegistroC490)reg);
                        }

                        break;
                    }

                case "C500":
                    {
                        reg = new RegistroC500(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        break;
                    }

                case "C800":
                    {
                        reg = new RegistroC800(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        break;
                    }

                case "C850":
                    {
                        reg = new RegistroC850(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC800 = ((BlocoC)Blocos["C"]).RegistrosC800.LastOrDefault();
                        if (regC800 != null)
                        {
                            regC800.RegistrosC850.Add((RegistroC850)reg);
                        }

                        break;
                    }

                case "C860":
                    {
                        reg = new RegistroC860(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        break;
                    }

                case "C890":
                    {
                        reg = new RegistroC890(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC860 = ((BlocoC)Blocos["C"]).RegistrosC860.LastOrDefault();
                        if (regC860 != null)
                        {
                            regC860.RegistrosC890.Add((RegistroC890)reg);
                        }

                        break;
                    }

                case "C590":
                    {
                        reg = new RegistroC590(linha, Versao);
                        Blocos["C"].Registros.Add(reg);
                        var regC500 = ((BlocoC)Blocos["C"]).RegistrosC500.LastOrDefault();
                        if (regC500 != null)
                        {
                            regC500.RegistrosC590.Add((RegistroC590)reg);
                        }

                        break;
                    }

                case "D100":
                    {
                        reg = new RegistroD100(linha, Versao);
                        Blocos["D"].Registros.Add(reg);
                        break;
                    }

                case "D110":
                    {
                        reg = new RegistroD110(linha, Versao);
                        Blocos["D"].Registros.Add(reg);
                        var regD100 = ((BlocoD)Blocos["D"]).RegistrosD100.LastOrDefault();
                        if (regD100 != null)
                        {
                            regD100.RegistrosD110.Add((RegistroD110)reg);
                        }

                        break;
                    }

                case "D190":
                    {
                        reg = new RegistroD190(linha, Versao);
                        Blocos["D"].Registros.Add(reg);
                        var regD100 = ((BlocoD)Blocos["D"]).RegistrosD100.LastOrDefault();
                        if (regD100 != null)
                        {
                            regD100.RegistrosD190.Add((RegistroD190)reg);
                        }

                        break;
                    }

                case "D500":
                    {
                        reg = new RegistroD500(linha, Versao);
                        Blocos["D"].Registros.Add(reg);
                        break;
                    }
                // DirectCast(Me.Blocos("D"), BlocoD).RegistrosD500.Add(reg)

                case "D590":
                    {
                        reg = new RegistroD590(linha, Versao);
                        Blocos["D"].Registros.Add(reg);
                        var regD500 = ((BlocoD)Blocos["D"]).RegistrosD500.LastOrDefault();
                        if (regD500 != null)
                            regD500.RegistrosD590.Add((RegistroD590)reg);
                        break;
                    }

                case "E001":
                    {
                        reg = new RegistroE001(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        break;
                    }

                case "E100":
                    {
                        reg = new RegistroE100(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        break;
                    }

                case "E110":
                    {
                        reg = new RegistroE110(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE100 = ((BlocoE)Blocos["E"]).RegistroE100;
                        if (regE100 != null)
                            regE100.RegistroE110 = (RegistroE110)reg;
                        break;
                    }

                case "E111":
                    {
                        reg = new RegistroE111(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE110 = ((BlocoE)Blocos["E"]).RegistroE110;
                        if (regE110 != null)
                            regE110.RegistrosE111.Add((RegistroE111)reg);
                        break;
                    }

                case "E112":
                    {
                        reg = new RegistroE112(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE111 = ((BlocoE)Blocos["E"]).RegistrosE111.LastOrDefault();
                        if (regE111 != null)
                            regE111.RegistrosE112.Add((RegistroE112)reg);
                        break;
                    }

                case "E113":
                    {
                        reg = new RegistroE113(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE111 = ((BlocoE)Blocos["E"]).RegistrosE111.LastOrDefault();
                        if (regE111 != null)
                            regE111.RegistrosE113.Add((RegistroE113)reg);
                        break;
                    }

                case "E115":
                    {
                        reg = new RegistroE115(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE110 = ((BlocoE)Blocos["E"]).RegistroE110;
                        if (regE110 != null)
                            regE110.RegistrosE115.Add((RegistroE115)reg);
                        break;
                    }

                case "E116":
                    {
                        reg = new RegistroE116(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE110 = ((BlocoE)Blocos["E"]).RegistroE110;
                        if (regE110 != null)
                            regE110.RegistrosE116.Add((RegistroE116)reg);
                        break;
                    }

                case "E200":
                    {
                        reg = new RegistroE200(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        break;
                    }

                case "E210":
                    {
                        reg = new RegistroE210(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE200 = ((BlocoE)Blocos["E"]).RegistrosE200.LastOrDefault();
                        if (regE200 != null)
                            regE200.RegistroE210 = (RegistroE210)reg;
                        break;
                    }

                case "E220":
                    {
                        reg = new RegistroE220(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE210 = ((BlocoE)Blocos["E"]).RegistrosE210.LastOrDefault();
                        if (regE210 != null)
                            regE210.RegistrosE220.Add((RegistroE220)reg);
                        break;
                    }

                case "E230":
                    {
                        reg = new RegistroE230(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE220 = ((BlocoE)Blocos["E"]).RegistrosE220.LastOrDefault();
                        if (regE220 != null)
                            regE220.RegistrosE230.Add((RegistroE230)reg);
                        break;
                    }

                case "E240":
                    {
                        reg = new RegistroE240(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE220 = ((BlocoE)Blocos["E"]).RegistrosE220.LastOrDefault();
                        if (regE220 != null)
                            regE220.RegistrosE240.Add((RegistroE240)reg);
                        break;
                    }

                case "E250":
                    {
                        reg = new RegistroE250(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE210 = ((BlocoE)Blocos["E"]).RegistrosE210.LastOrDefault();
                        if (regE210 != null)
                            regE210.RegistrosE250.Add((RegistroE250)reg);
                        break;
                    }

                case "E300":
                    {
                        reg = new RegistroE300(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        break;
                    }

                case "E310":
                    {
                        reg = new RegistroE310(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE300 = ((BlocoE)Blocos["E"]).RegistrosE300.LastOrDefault();
                        if (regE300 != null)
                            regE300.RegistroE310 = (RegistroE310)reg;
                        break;
                    }

                case "E311":
                    {
                        reg = new RegistroE311(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE310 = ((BlocoE)Blocos["E"]).RegistrosE310.LastOrDefault();
                        if (regE310 != null)
                            regE310.RegistrosE311.Add((RegistroE311)reg);
                        break;
                    }

                case "E312":
                    {
                        reg = new RegistroE312(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE311 = ((BlocoE)Blocos["E"]).RegistrosE311.LastOrDefault();
                        if (regE311 != null)
                            regE311.RegistrosE312.Add((RegistroE312)reg);
                        break;
                    }

                case "E313":
                    {
                        reg = new RegistroE313(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE311 = ((BlocoE)Blocos["E"]).RegistrosE311.LastOrDefault();
                        if (regE311 != null)
                            regE311.RegistrosE313.Add((RegistroE313)reg);
                        break;
                    }

                case "E316":
                    {
                        reg = new RegistroE316(linha, Versao);
                        Blocos["E"].Registros.Add(reg);
                        var regE310 = ((BlocoE)Blocos["E"]).RegistrosE310.LastOrDefault();
                        if (regE310 != null)
                            regE310.RegistrosE316.Add((RegistroE316)reg);
                        break;
                    }

                case "G001":
                    {
                        reg = new RegistroG001(linha, Versao);
                        Blocos["G"].Registros.Add(reg);
                        break;
                    }

                case "G110":
                    {
                        reg = new RegistroG110(linha, Versao);
                        Blocos["G"].Registros.Add(reg);
                        break;
                    }

                case "G125":
                    {
                        reg = new RegistroG125(linha, Versao);
                        Blocos["G"].Registros.Add(reg);
                        var regg110 = ((BlocoG)Blocos["G"]).RegistroG110;
                        if (regg110 != null)
                            regg110.RegistrosG125.Add((RegistroG125)reg);
                        break;
                    }

                case "G126":
                    {
                        reg = new RegistroG126(linha, Versao);
                        Blocos["G"].Registros.Add(reg);
                        var regg125 = ((BlocoG)Blocos["G"]).RegistrosG125.FirstOrDefault();
                        if (regg125 != null)
                            regg125.RegistrosG126.Add((RegistroG126)reg);
                        break;
                    }

                case "G130":
                    {
                        reg = new RegistroG130(linha, Versao);
                        Blocos["G"].Registros.Add(reg);
                        var regg125 = ((BlocoG)Blocos["G"]).RegistrosG125.FirstOrDefault();
                        if (regg125 != null)
                            regg125.RegistrosG130.Add((RegistroG130)reg);
                        break;
                    }

                case "G140":
                    {
                        reg = new RegistroG140(linha, Versao);
                        Blocos["G"].Registros.Add(reg);
                        var regg130 = ((BlocoG)Blocos["G"]).RegistrosG130.FirstOrDefault();
                        if (regg130 != null)
                            regg130.RegistrosG140.Add((RegistroG140)reg);
                        break;
                    }

                case "H001":
                    {
                        reg = new RegistroH001(linha, Versao);
                        Blocos["H"].Registros.Add(reg);
                        break;
                    }

                case "H005":
                    {
                        reg = new RegistroH005(linha, Versao);
                        Blocos["H"].Registros.Add(reg);
                        break;
                    }

                case "H010":
                    {
                        reg = new RegistroH010(linha, Versao);
                        Blocos["H"].Registros.Add(reg);
                        break;
                    }

                case "H020":
                    {
                        reg = new RegistroH020(linha, Versao);
                        Blocos["H"].Registros.Add(reg);
                        var regH010 = ((BlocoH)Blocos["H"]).RegistrosH010.LastOrDefault();
                        if (regH010 != null)
                        {
                            regH010.RegistroH020 = (RegistroH020)reg;
                        }

                        break;
                    }

                case "H990":
                    {
                        reg = new RegistroH990(linha, Versao);
                        Blocos["H"].Registros.Add(reg);
                        break;
                    }

                case "K001":
                    {
                        reg = new RegistroK001(linha, Versao);
                        Blocos["K"].Registros.Add(reg);
                        break;
                    }

                case "K230":
                    {
                        reg = new Registrok230(linha, Versao);
                        Blocos["K"].Registros.Add(reg);
                        break;
                    }

                case "K235":
                    {
                        reg = new RegistroK235(linha, Versao);
                        Blocos["K"].Registros.Add(reg);
                        var reg230 = ((BlocoK)Blocos["K"]).RegistrosK230.LastOrDefault();
                        if (reg230 != null)
                        {
                            reg230.RegistrosK235.Add((RegistroK235)reg);
                        }

                        break;
                    }

                case "K990":
                    {
                        reg = new RegistroK990(linha, Versao);
                        Blocos["K"].Registros.Add(reg);
                        break;
                    }

                case "9999":
                    {
                        _mustStop = true;
                        break;
                    }
            }

            if (string.IsNullOrEmpty(linha) == false & string.IsNullOrWhiteSpace(linha) == false)
            {
                if (reg != null)
                {
                    reg.LeParametros(linha.Split("|"));
                }
            }
        }

        public override async Task<string> LeEmpresaArquivo(System.IO.Stream stream)
        {
            string cnpj = null;
            using (var reader = new System.IO.StreamReader(stream, Encoding))
            {
                while (!reader.EndOfStream)
                {
                    string linha = await reader.ReadLineAsync();
                    Versao = linha.Substring(6, 3);
                    string reg = linha.Substring(HeaderPosition.Index, HeaderPosition.Lenght);
                    var reg0000 = new Registro0000(linha, Versao);
                    reg0000.LeParametros(linha.Split("|"));
                    cnpj = reg0000.CNPJ;
                    break;
                }

                reader.Dispose();
            }

            return cnpj;
        }

        public override Registro[] PrefixoBlocoEncerramento()
        {
            var regs = new List<Registro>();
            var reg = new Registro9001();
            if (Blocos["C"].Registros.Count <= 0 & Blocos["D"].Registros.Count <= 0 & Blocos["E"].Registros.Count <= 0 & Blocos["H"].Registros.Count <= 0)
            {
                reg.IndicadorMovimento = IndicadorMovimento.SemDados;
            }
            else
            {
                reg.IndicadorMovimento = IndicadorMovimento.ComDados;
            }

            regs.Add(reg);
            return regs.ToArray();
        }

        public override Registro[] SufixoBlocoEncerramento()
        {
            var regs = new List<Registro>();
            var reg9900_9001 = new Registro9900
            {
                Registro = "9001",
                TotalLinhas = 1
            };
            regs.Add(reg9900_9001);
            var reg9900_9900 = new Registro9900
            {
                Registro = "9900",
                TotalLinhas = (from reg in Blocos[BlocoTotalizador].Registros
                               where reg is RegistroTotalizador
                               select reg).Count() + 4
            };
            regs.Add(reg9900_9900);
            var reg9900_9990 = new Registro9900
            {
                Registro = "9990",
                TotalLinhas = 1
            };
            regs.Add(reg9900_9990);
            var reg9900_9999 = new Registro9900
            {
                Registro = "9999",
                TotalLinhas = 1
            };
            regs.Add(reg9900_9999);
            var reg9990 = new Registro9990
            {
                TotalLinhas = Blocos["9"].Registros.Count + 6
            };
            regs.Add(reg9990);
            var reg9999 = new Registro9999
            {
                TotalLinhas = (from bl in Blocos.Values
                               select bl.Registros.Count).Sum() + 6
            };
            regs.Add(reg9999);
            return regs.ToArray();
        }


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}