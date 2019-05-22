using Busisnes.Paises.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Busisnes.Paises.Class
{
    public class PaisesServices : IPaisesServices
    {
        public List<Pais> GetPaises()
        {
            try
            {
                List<Pais> lstPais;
                using (aplication2Context ctx = new aplication2Context())
                {
                    lstPais = ctx.Pais.ToList();
                    // expresiones lambda
                    //var test1 = ctx.People.Where(p => p.Birthdate < DateTime.Now);
                    // Linq
                    //var test2 = from p in ctx.People
                    //            where p.Birthdate < DateTime.Now
                    //            join t in ctx.TypeIdentification on p.IdTypeIdentification equals t.Id
                    //            select p;

                }

                return lstPais;
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }

        public void AgregarPais(string name, decimal latitud, decimal longitud)
        {
            try
            {
                using (aplication2Context ctx = new aplication2Context())
                {
                    Pais pais = new Pais();
                    pais.Nombre = name;
                    pais.Longitud = longitud;
                    pais.Latitud = latitud;
                    ctx.Pais.Add(pais);
                    ctx.SaveChanges();

                }
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw;
            }
        }
        public void BorrarPais(int identificacion)
        {
            try
            {
                if (SiExistePais(identificacion))
                {
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        Pais pais = ctx.Pais.Where(x => x.Id == identificacion).FirstOrDefault();
                        ctx.Pais.Remove(pais);
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
        public Pais ConsultarPais(int identificacion)
        {
            try
            {
                if (SiExistePais(identificacion))
                {
                    Pais pais = new Pais();
                    using (aplication2Context ctx = new aplication2Context())
                    {
                        pais = ctx.Pais.Where(x => x.Id == identificacion).FirstOrDefault();
                        ctx.SaveChanges();
                    }
                    return pais;
                }
                else
                {
                    Pais pais = new Pais();
                    return pais;
                }
                
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                throw new Exception();
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
