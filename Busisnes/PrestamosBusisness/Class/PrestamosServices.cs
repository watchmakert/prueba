using Busisnes.PrestamosBusisness.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Busisnes.PrestamosBusisness.Class
{
    public class PrestamosServices : IPrestamosServices
    {
        public List<Prestamo> GetPrestamos()
        {
            try
            {
                List<Prestamo> lstPrestamo;
                using (aplication2Context ctx = new aplication2Context())
                {
                    lstPrestamo = ctx.Prestamo.ToList();
                }

                return lstPrestamo;
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }

        public List<Prestamo> GetPrestamosActuales()
        {
            try
            {
                DateTime Hoy = DateTime.Today;
                List<Prestamo> lstPrestamo;
                using (aplication2Context ctx = new aplication2Context())
                {
                    lstPrestamo = ctx.Prestamo.Where(x => x.Fechainicio >= Hoy && x.Fechafin <= Hoy).ToList();
                }

                return lstPrestamo;
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }

        public Prestamo ConsultarPrestamo(int identificacion)
        {
            try
            {
                if (SiExistePrestamo(identificacion))
                {
                    Prestamo prestamo = new Prestamo();
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        prestamo = ctx.Prestamo.Where(x => x.Id == identificacion).FirstOrDefault();
                        ctx.SaveChanges();
                    }
                    return prestamo;
                }
                else
                {
                    Prestamo prestamo = new Prestamo();
                    return prestamo;
                }

            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;

            }
        }
        public void AgregarPrestamo(DateTime inicio, DateTime final, int idPopietario, int idPrestador, int idAeronave)
        {
            try
            {
                if (SiExisteAeronave(idPopietario) && SiExisteAerolinea(idPopietario) && SiExisteAerolinea(idPrestador))
                {
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        if (ctx.Prestamo.Where(x => x.Idaeronave == idAeronave).Any())
                        {
                            List<Prestamo> prestamo1 = (from p in ctx.Prestamo where p.Idaeronave == idAeronave && IsNotBetween(inicio, p.Fechainicio, p.Fechafin) select p).ToList();
                            List<Prestamo> prestamo2 = (from p in ctx.Prestamo where p.Idaeronave == idAeronave && IsNotBetween(final, p.Fechainicio, p.Fechafin)  select p).ToList();
                            if (prestamo1.Count() > 0 || prestamo2.Count() > 0)
                            {
                                //error
                            }
                            else
                            {
                                if (inicio <= final)
                                {
                                    Prestamo prestamo = new Prestamo();
                                    prestamo.Fechainicio = inicio;
                                    prestamo.Fechafin = final;
                                    prestamo.IdPropietario = idPopietario;
                                    prestamo.IdPrestador = idPrestador;
                                    prestamo.Idaeronave = idAeronave;
                                    ctx.Prestamo.Add(prestamo);
                                    ctx.SaveChanges();
                                }
                            }
                        }
                        else
                        {

                            if (inicio <= final)
                            {
                                Prestamo prestamo = new Prestamo();
                                prestamo.Fechainicio = inicio;
                                prestamo.Fechafin = final;
                                prestamo.IdPropietario = idPopietario;
                                prestamo.IdPrestador = idPrestador;
                                prestamo.Idaeronave = idAeronave;
                                ctx.Prestamo.Add(prestamo);
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

        public void BorrarPrestamo(int identificacion)
        {
            try
            {
                if (SiExistePrestamo(identificacion))
                {
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        Prestamo prestamo = ctx.Prestamo.Where(x => x.Id == identificacion).FirstOrDefault();
                        ctx.Prestamo.Remove(prestamo);
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

        private bool SiExisteAerolinea(int identificacion)
        {
            using (aplication2Context ctx = new aplication2Context())
            {
                if (ctx.Aerolinea.Where(x => x.Id == identificacion).Any()) return true;
                else return false;
            }

        }

        private bool SiExistePrestamo(int identificacion)
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

        private bool IsNotBetween(DateTime t1, DateTime t2, DateTime t3)
        {
            int result1 = DateTime.Compare(t1, t2);
            int result2 = DateTime.Compare(t1, t3);

            if ((result1 > 0 && result2 > 0) || (result1 < 0 && result2 < 0))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
