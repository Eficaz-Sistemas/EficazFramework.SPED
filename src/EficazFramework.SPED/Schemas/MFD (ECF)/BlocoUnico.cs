using System.Collections.Generic;
using System.Linq;

namespace EficazFrameworkCore.SPED.Schemas.MFD_ECF
{

    /// <summary>
    /// Abertura, Identificação e Referências
    /// </summary>
    /// <remarks></remarks>
    public class BlocoUnico : Primitives.Bloco
    {
        public RegistroE01 RegistroE01
        {
            get
            {
                return (RegistroE01)(from reg in Registros
                                     where reg.Codigo == "E01"
                                     select reg).FirstOrDefault();
            }
        }

        public RegistroE02 RegistroE02
        {
            get
            {
                return (RegistroE02)(from reg in Registros
                                     where reg.Codigo == "E02"
                                     select reg).FirstOrDefault();
            }
        }

        public IEnumerable<RegistroE12> RegistrosE12
        {
            get
            {
                return (from reg in Registros
                        where reg.Codigo == "E12"
                        select reg)?.Cast<RegistroE12>()?.ToList();
            }
        }

        public IEnumerable<RegistroE13> RegistrosE13
        {
            get
            {
                return (from reg in Registros
                        where reg.Codigo == "E13"
                        select reg).Cast<RegistroE13>().ToList();
            }
        }

        public IEnumerable<RegistroE14> RegistrosE14
        {
            get
            {
                return (from reg in Registros
                        where reg.Codigo == "E14"
                        select reg).Cast<RegistroE14>().ToList();
            }
        }

        public IEnumerable<RegistroE15> RegistrosE15
        {
            get
            {
                return (from reg in Registros
                        where reg.Codigo == "E15"
                        select reg).Cast<RegistroE15>().ToList();
            }
        }
    }
}