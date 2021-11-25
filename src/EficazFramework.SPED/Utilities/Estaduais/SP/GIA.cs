
namespace EficazFramework.SPED.Utilities.SP.GIA
{
    public class Helpers
    {
        public static string UF_ToGiaString(Schemas.NFe.OrgaoIBGE uf)
        {
            switch (uf)
            {
                case Schemas.NFe.OrgaoIBGE.AC:
                    {
                        return "01";
                    }

                case Schemas.NFe.OrgaoIBGE.AL:
                    {
                        return "02";
                    }

                case Schemas.NFe.OrgaoIBGE.AP:
                    {
                        return "03";
                    }

                case Schemas.NFe.OrgaoIBGE.AM:
                    {
                        return "04";
                    }

                case Schemas.NFe.OrgaoIBGE.BA:
                    {
                        return "05";
                    }

                case Schemas.NFe.OrgaoIBGE.CE:
                    {
                        return "06";
                    }

                case Schemas.NFe.OrgaoIBGE.DF:
                    {
                        return "07";
                    }

                case Schemas.NFe.OrgaoIBGE.ES:
                    {
                        return "08";
                    }

                case Schemas.NFe.OrgaoIBGE.GO:
                    {
                        return "10";
                    }

                case Schemas.NFe.OrgaoIBGE.MA:
                    {
                        return "12";
                    }

                case Schemas.NFe.OrgaoIBGE.MT:
                    {
                        return "13";
                    }

                case Schemas.NFe.OrgaoIBGE.MS:
                    {
                        return "28";
                    }

                case Schemas.NFe.OrgaoIBGE.MG:
                    {
                        return "14";
                    }

                case Schemas.NFe.OrgaoIBGE.PA:
                    {
                        return "15";
                    }

                case Schemas.NFe.OrgaoIBGE.PB:
                    {
                        return "16";
                    }

                case Schemas.NFe.OrgaoIBGE.PR:
                    {
                        return "17";
                    }

                case Schemas.NFe.OrgaoIBGE.PE:
                    {
                        return "18";
                    }

                case Schemas.NFe.OrgaoIBGE.PI:
                    {
                        return "19";
                    }

                case Schemas.NFe.OrgaoIBGE.RJ:
                    {
                        return "22";
                    }

                case Schemas.NFe.OrgaoIBGE.RN:
                    {
                        return "20";
                    }

                case Schemas.NFe.OrgaoIBGE.RS:
                    {
                        return "21";
                    }

                case Schemas.NFe.OrgaoIBGE.RO:
                    {
                        return "23";
                    }

                case Schemas.NFe.OrgaoIBGE.RR:
                    {
                        return "24";
                    }

                case Schemas.NFe.OrgaoIBGE.SC:
                    {
                        return "25";
                    }

                case Schemas.NFe.OrgaoIBGE.SP:
                    {
                        return "26";
                    }

                case Schemas.NFe.OrgaoIBGE.SE:
                    {
                        return "27";
                    }

                case Schemas.NFe.OrgaoIBGE.TO:
                    {
                        return "29";
                    }

                default:
                    {
                        return "00";
                    }
            }
        }

        public static string UF_ToGiaString(Schemas.NFe.Estado uf)
        {
            switch (uf)
            {
                case Schemas.NFe.Estado.AC:
                    {
                        return "01";
                    }

                case Schemas.NFe.Estado.AL:
                    {
                        return "02";
                    }

                case Schemas.NFe.Estado.AP:
                    {
                        return "03";
                    }

                case Schemas.NFe.Estado.AM:
                    {
                        return "04";
                    }

                case Schemas.NFe.Estado.BA:
                    {
                        return "05";
                    }

                case Schemas.NFe.Estado.CE:
                    {
                        return "06";
                    }

                case Schemas.NFe.Estado.DF:
                    {
                        return "07";
                    }

                case Schemas.NFe.Estado.ES:
                    {
                        return "08";
                    }

                case Schemas.NFe.Estado.GO:
                    {
                        return "10";
                    }

                case Schemas.NFe.Estado.MA:
                    {
                        return "12";
                    }

                case Schemas.NFe.Estado.MT:
                    {
                        return "13";
                    }

                case Schemas.NFe.Estado.MS:
                    {
                        return "28";
                    }

                case Schemas.NFe.Estado.MG:
                    {
                        return "14";
                    }

                case Schemas.NFe.Estado.PA:
                    {
                        return "15";
                    }

                case Schemas.NFe.Estado.PB:
                    {
                        return "16";
                    }

                case Schemas.NFe.Estado.PR:
                    {
                        return "17";
                    }

                case Schemas.NFe.Estado.PE:
                    {
                        return "18";
                    }

                case Schemas.NFe.Estado.PI:
                    {
                        return "19";
                    }

                case Schemas.NFe.Estado.RJ:
                    {
                        return "22";
                    }

                case Schemas.NFe.Estado.RN:
                    {
                        return "20";
                    }

                case Schemas.NFe.Estado.RS:
                    {
                        return "21";
                    }

                case Schemas.NFe.Estado.RO:
                    {
                        return "23";
                    }

                case Schemas.NFe.Estado.RR:
                    {
                        return "24";
                    }

                case Schemas.NFe.Estado.SC:
                    {
                        return "25";
                    }

                case Schemas.NFe.Estado.SP:
                    {
                        return "26";
                    }

                case Schemas.NFe.Estado.SE:
                    {
                        return "27";
                    }

                case Schemas.NFe.Estado.TO:
                    {
                        return "29";
                    }

                default:
                    {
                        return "00";
                    }
            }
        }

        public static Schemas.NFe.OrgaoIBGE UF_FromGiaString(string uf)
        {
            switch (uf ?? "")
            {
                case "01":
                    {
                        return Schemas.NFe.OrgaoIBGE.AC;
                    }

                case "02":
                    {
                        return Schemas.NFe.OrgaoIBGE.AL;
                    }

                case "03":
                    {
                        return Schemas.NFe.OrgaoIBGE.AP;
                    }

                case "04":
                    {
                        return Schemas.NFe.OrgaoIBGE.AM;
                    }

                case "05":
                    {
                        return Schemas.NFe.OrgaoIBGE.BA;
                    }

                case "06":
                    {
                        return Schemas.NFe.OrgaoIBGE.CE;
                    }

                case "07":
                    {
                        return Schemas.NFe.OrgaoIBGE.DF;
                    }

                case "08":
                    {
                        return Schemas.NFe.OrgaoIBGE.ES;
                    }

                case "10":
                    {
                        return Schemas.NFe.OrgaoIBGE.GO;
                    }

                case "12":
                    {
                        return Schemas.NFe.OrgaoIBGE.MA;
                    }

                case "13":
                    {
                        return Schemas.NFe.OrgaoIBGE.MT;
                    }

                case "28":
                    {
                        return Schemas.NFe.OrgaoIBGE.MS;
                    }

                case "14":
                    {
                        return Schemas.NFe.OrgaoIBGE.MG;
                    }

                case "15":
                    {
                        return Schemas.NFe.OrgaoIBGE.PA;
                    }

                case "16":
                    {
                        return Schemas.NFe.OrgaoIBGE.PB;
                    }

                case "17":
                    {
                        return Schemas.NFe.OrgaoIBGE.PR;
                    }

                case "18":
                    {
                        return Schemas.NFe.OrgaoIBGE.PE;
                    }

                case "19":
                    {
                        return Schemas.NFe.OrgaoIBGE.PI;
                    }

                case "22":
                    {
                        return Schemas.NFe.OrgaoIBGE.RJ;
                    }

                case "20":
                    {
                        return Schemas.NFe.OrgaoIBGE.RN;
                    }

                case "21":
                    {
                        return Schemas.NFe.OrgaoIBGE.RS;
                    }

                case "23":
                    {
                        return Schemas.NFe.OrgaoIBGE.RO;
                    }

                case "24":
                    {
                        return Schemas.NFe.OrgaoIBGE.RR;
                    }

                case "25":
                    {
                        return Schemas.NFe.OrgaoIBGE.SC;
                    }

                case "26":
                    {
                        return Schemas.NFe.OrgaoIBGE.SP;
                    }

                case "27":
                    {
                        return Schemas.NFe.OrgaoIBGE.SE;
                    }

                case "29":
                    {
                        return Schemas.NFe.OrgaoIBGE.TO;
                    }

                default:
                    {
                        return Schemas.NFe.OrgaoIBGE.SP;
                    }
            }
        }
    }
}