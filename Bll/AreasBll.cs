using Dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Bll
{
    public class AreasBll
    {
        COSTOSVIPEnti db = new COSTOSVIPEnti();
        //Eliminar Eps, Recibe una cadena y retorna un booleano.
        public bool Delete(string Proyecto)
        {

            List<Areas> Cat = db.Areas.Where(t => t.Proyecto == Proyecto).ToList();
            if (Cat != null)
            {

                db.Areas.RemoveRange(Cat);
                db.SaveChanges();

                return true;
            }
            else
            { return false; }
        }

    }
}
