using Busisnes.RutasBusisness.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Busisnes.RutasBusisness.Class
{
    public class RutasServices : IRutaServices
    {
        public List<Ruta> GetRutas()
        {
            try
            {
                List<Ruta> lstRuta;
                using (aplication2Context ctx = new aplication2Context())
                {
                    lstRuta = ctx.Ruta.ToList();
                }

                return lstRuta;
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }

        public List<Ruta> GetRutasActuales()
        {
            try
            {
                DateTime Hoy = DateTime.Today;
                List<Ruta> lstRutas;
                using (aplication2Context ctx = new aplication2Context())
                {
                    lstRutas = ctx.Ruta.Where(x => x.Fechainicio >= Hoy && x.Fechafin <= Hoy).ToList();
                }

                return lstRutas;
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }

        public void AgregarRutas(DateTime inicio, DateTime final, int idAeronave, int idOrigen, int idDestino)
        {
            try
            {
                if (SiExisteAeronave(idAeronave) && SiExistePais(idOrigen) && SiExistePais(idDestino))
                {
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        if(ctx.Ruta.Where(x => x.IdAeronave == idAeronave).Any())
                        {
                            List<Ruta> rutas1 = (from p in ctx.Ruta where p.IdAeronave == idAeronave && p.Fechainicio <= inicio && p.Fechafin >= inicio select p).ToList();
                            List<Ruta> rutas2 = (from p in ctx.Ruta where p.IdAeronave == idAeronave && p.Fechainicio <= final && p.Fechafin >= final select p).ToList();
                            if(rutas1.Count()>0 || rutas2.Count() > 0)
                            {
                                //error
                            }
                            else
                            {
                                if(inicio <= final)
                                {
                                    Ruta ruta = new Ruta();
                                    ruta.Fechainicio = inicio;
                                    ruta.Fechafin = final;
                                    ruta.IdAeronave = idAeronave;
                                    ruta.IdOrigen = idOrigen;
                                    ruta.IdDestino = idDestino;
                                    ctx.Ruta.Add(ruta);
                                    ctx.SaveChanges();
                                }
                            }
                        }
                        else
                        {

                            if (inicio <= final)
                            {
                                Ruta ruta = new Ruta();
                                ruta.Fechainicio = inicio;
                                ruta.Fechafin = final;
                                ruta.IdAeronave = idAeronave;
                                ruta.IdOrigen = idOrigen;
                                ruta.IdDestino = idDestino;
                                ctx.Ruta.Add(ruta);
                                ctx.SaveChanges();
                            }
                        }

                        
                    }
                }
                
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }
        public void BorrarRuta(int identificacion)
        {
            try
            {
                if (SiExisteRuta(identificacion))
                {
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        Ruta ruta = ctx.Ruta.Where(x => x.Id == identificacion).FirstOrDefault();
                        ctx.Ruta.Remove(ruta);
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
        public Ruta ConsultarRuta(int identificacion)
        {
            try
            {
                if (SiExisteRuta(identificacion))
                {
                    Ruta ruta = new Ruta();
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        ruta = ctx.Ruta.Where(x => x.Id == identificacion).FirstOrDefault();
                        ctx.SaveChanges();
                    }
                    return ruta;
                }
                else
                {
                    Ruta ruta = new Ruta();
                    return ruta;
                }

            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }

        private bool SiExisteRuta(int identificacion)
        {
            using (aplication2Context ctx = new aplication2Context())
            {
                if (ctx.Ruta.Where(x => x.Id == identificacion).Any()) return true;
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
        private bool SiExistePais(int identificacion)
        {
            using (aplication2Context ctx = new aplication2Context())
            {
                if (ctx.Pais.Where(x => x.Id == identificacion).Any()) return true;
                else return false;
            }

        }

    }
}
