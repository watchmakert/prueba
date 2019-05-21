using Busisnes.AeronavesBusisness.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Busisnes.AeronavesBusisness.Class
{
    public class AeronavesServices : IAeronavesServices
    {
        public List<Aeronave> GetAeronave()
        {
            try
            {
                List<Aeronave> lstAeronave;
                using (aplication2Context ctx = new aplication2Context())
                {
                    lstAeronave = ctx.Aeronave.ToList();
                }

                return lstAeronave;
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }

        public void AgregarAeronave(decimal latitud, decimal longitud, bool estado, int idAerolinea)
        {
            try
            {
                if (SiExisteAerolinea(idAerolinea))
                {
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        Aeronave aeronave = new Aeronave();
                        aeronave.Latitud = latitud;
                        aeronave.Longitud = longitud;
                        aeronave.Estado = estado;
                        aeronave.IdAerolinea = idAerolinea;
                        ctx.Aeronave.Add(aeronave);
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
        public void BorrarAeronave(int identificacion)
        {
            try
            {

                if (SiExisteAeronave(identificacion))
                {
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        Aeronave aeronave = ctx.Aeronave.Where(x => x.Id == identificacion).FirstOrDefault();
                        ctx.Aeronave.Remove(aeronave);
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
        public Aeronave ConsultarAeronave(int identificacion)
        {
            try
            {
                if (SiExisteAeronave(identificacion))
                {
                    Aeronave aeronave = new Aeronave();
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        aeronave = ctx.Aeronave.Where(x => x.Id == identificacion).FirstOrDefault();
                        ctx.SaveChanges();
                    }
                    return aeronave;
                }
                else
                {
                    Aeronave aeronave = new Aeronave();
                    return aeronave;
                }

            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }

        public void ActualizarAeronave(int identificacion, decimal latitud, decimal longitud, bool estado)
        {
            Aeronave aeronave = ConsultarAeronave(identificacion);
            using (aplication2Context ctx = new aplication2Context())
            {
                aeronave.Latitud = latitud;
                aeronave.Longitud = longitud;
                aeronave.Estado = estado;
                ctx.Entry(aeronave).State = EntityState.Modified;
                ctx.SaveChanges();

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
        private bool SiExisteAeronave(int identificacion)
        {
            using (aplication2Context ctx = new aplication2Context())
            {
                if (ctx.Aeronave.Where(x => x.Id == identificacion).Any()) return true;
                else return false;
            }

        }
    }
}
