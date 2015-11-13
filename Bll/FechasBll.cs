using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
   public class FechasBll
    {

        COSTOSVIPEnti db = new COSTOSVIPEnti();
        //Crear Empleados, Recibe un objeto y retorna un entero.
        public int insert(FechasDTO Cat)
        {
            Fechas Obj = new Fechas();

            try
            {
                Obj.Id = Cat.Id;
                Obj.Fecha = DateTime.Now;
                Obj.Proyecto = Cat.Proyecto;
                Obj.Tipo = "False";
                db.Fechas.Add(Obj);
                db.SaveChanges();
                return Obj.Id;
            }
            catch
            {
                return 0;
            }
        }

        public string actualizarfecha(int? IdFecha,string Proyecto) {

            try
            {
                
                db.ActualizarCostosFecha(IdFecha, Proyecto);
            }
            catch (Exception ex) {

                return "0";
            }
            return "1";
        }
       
        //Mostrar Todas las Eps, Retorna una lista.
        public List<FechasDTO> ListaFechasLineaBase(string Proyecto)
        {

            try
            {
                List<FechasDTO> Est = new List<FechasDTO>();
                List<Fechas> lst = db.Fechas.Where(t => t.Tipo == "True" && t.Proyecto == Proyecto).ToList();

                if (lst != null)
                {
                    Est = lst.Select(t => new FechasDTO
                    {
                        Id = t.Id,
                        Fecha =t.Fecha,
                        Proyecto=t.Proyecto,
                        Tipo = t.Tipo

                    }).ToList();
                }
                return Est;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

    
        //Eliminar Eps, Recibe una cadena y retorna un booleano.
        public bool Delete(int Id)
        {
            Fechas Cat=null;
            if (db.Fechas.Where(t => t.Id == Id).Count() >= 1)
            {
                Cat = db.Fechas.Where(t => t.Id == Id).First();
            }

            if (Cat != null)
            {

                db.Fechas.Remove(Cat);
                db.SaveChanges();

                return true;
            }
            else
            { return false; }
        }

        //Mostrar Todas las Eps, Retorna una lista.
        public List<FechasDTO> ListaFechas(string Proyecto)
        {

            try
            {
                List<FechasDTO> Est = new List<FechasDTO>();
                List<Fechas> lst = db.Fechas.Where(t => t.Tipo == "False" && t.Proyecto==Proyecto).ToList();

                if (lst != null)
                {
                    Est = lst.Select(t => new FechasDTO
                    {
                        Id = t.Id,
                        Fecha = t.Fecha,
                        Proyecto = t.Proyecto,
                        Tipo = t.Tipo

                    }).ToList();
                }
                return Est;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }
}
