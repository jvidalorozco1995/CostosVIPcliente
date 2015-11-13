using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class ProyectosBll
    {

        COSTOSVIPEnti db = new COSTOSVIPEnti();

        //Mostrar Todas las Eps, Retorna una lista.
        public List<ProyectosDTO> ListaProyectos()
        {
            List<ProyectosDTO> Est = new List<ProyectosDTO>();
            List<Proyectos> lst = db.Proyectos.ToList();

            if (lst != null)
            {
                Est = lst.Select(t => new ProyectosDTO
                {
                    Codigo = t.Codigo,
                    Proyecto = t.Proyecto,
                    Filtro = t.Filtro,
                    FechaIniObra = t.FechaIniObra,
                    FechaFinObra = t.FechaFinObra
              
                }).ToList();
            }
            return Est;
        }

    }
}
