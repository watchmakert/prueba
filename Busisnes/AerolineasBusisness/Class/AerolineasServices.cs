using Busisnes.AerolineasBusisness.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Busisnes.AerolineasBusisness.Class
{
    public class AerolineasServices : IAerolineasServices
    {
        public List<Aerolinea> GetAerolineas()
        {
            try
            {
                List<Aerolinea> lstAerolinea;
                using (aplication2Context ctx = new aplication2Context())
                {
                    lstAerolinea = ctx.Aerolinea.ToList();
                }

                return lstAerolinea;
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }

        public void AgregarAerolinea(string name, int idpais)
        {
            try
            {
                if (SiExistePaisAerolinea(idpais))
                {
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        Aerolinea aerolinea = new Aerolinea();
                        aerolinea.Nombre = name;
                        aerolinea.IdPais = idpais;
                        ctx.Aerolinea.Add(aerolinea);
                        ctx.SaveChanges();
                    }
                }
                
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }
        public void BorrarAerolinea(int identificacion)
        {
            try
            {

                if (SiExisteAerolinea(identificacion))
                {
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        Aerolinea aerolinea = ctx.Aerolinea.Where(x => x.Id == identificacion).FirstOrDefault();
                        ctx.Aerolinea.Remove(aerolinea);
                        ctx.SaveChanges();
                    }

                }
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }
        public Aerolinea ConsultarAerolinea(int identificacion)
        {
            try
            {
                if (SiExisteAerolinea(identificacion))
                {
                    Aerolinea aerolinea = new Aerolinea();
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        aerolinea = ctx.Aerolinea.Where(x => x.Id == identificacion).FirstOrDefault();
                        ctx.SaveChanges();
                    }
                    return aerolinea;
                }
                else
                {
                    Aerolinea aerolinea = new Aerolinea();
                    return aerolinea;
                }

            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }

        private bool SiExistePaisAerolinea(int identificacion)
        {
            using (aplication2Context ctx = new aplication2Context())
            {
                if (ctx.Pais.Where(x => x.Id == identificacion).Any()) return true;
                else return false;
            }

        }
        private bool SiExisteAerolinea(int identificacion)
        {
            using (aplication2Context ctx = new aplication2Context())
            {
                if (ctx.Aerolinea.Where(x => x.Id == identificacion).Any()) return true;
                else return false;
            }

        }
    }
}
