using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
  public class SemanaActualBll
    {

        COSTOSVIPEnti db = new COSTOSVIPEnti();

        /*Listas estaticas para llenar el informe con sus respectivas descripciones*/
      //  public static List<CostosPptoProgDTO> ListaCostosClasificacion;
        public static List<DetallesCostosIndirectos> ListaDetalleCostosIndirectos;
        public static List<GruposCostosIndirectos> ListaGruposCostosIndirectos;
        public static List<DetallesCostosDirectos> ListaDetalleCostosDirectos;
        public static List<GruposCostosDirectos> ListaGruposCostosDirectos;
        public static List<ConsolidadoCostosDirectos> ListaConsolidadoDirectos;
        public static List<ConsolidadoCostosIndirectos> ListaConsolidadoIndirectos;
        public static List<ConsolidadoGlobal> listaConsolidadoGlobal;

        public static List<Costos> ListaCostosClasificacion2;
        public static List<CostosGastos> ListaCostosClasificacion3;
        /*-----------------------------------------------*/
        /*Metodo para llenar los costos del informe*/
      /*  public List<CostosPptoProgDTO> ListaCostosPresupuestos(int IdFecha)
        {

            ListaCostosClasificacion = new List<CostosPptoProgDTO>();
            ListaCostosClasificacion = (from p in db.CostosPptoProg
                                        join c in db.ClasificacionPresupuestos on p.referencia1.Substring(0, 6) equals c.CodPresu
                                        join t in db.Tipos on c.Tipo equals t.Id
                                        where p.IdFecha == IdFecha
                                        select new CostosPptoProgDTO
                                        {
                                            Id = p.Id,
                                            Referencia1 = p.referencia1.Substring(0, 6),
                                            Referencia2 = p.referencia2,
                                            Referencia3 = p.referencia3,
                                            Presupuesto = p.presupuesto,
                                            Codcapi = p.codcapi,
                                            Capitulo = p.capitulo,
                                            Codunit = p.codunit,
                                            Unitario = p.unitario,
                                            Undunita = p.undunita,
                                            Cantxppto = p.cantxppto,
                                            Codinsu = p.codinsu,
                                            Insutipo = p.insutipo,
                                            Insumo = p.insumo,
                                            Unidinsu = p.unidinsu,
                                            Ctrlinv = p.ctrlinven,
                                            Precioppto = p.precioppto,
                                            Consumounitario = p.consumounitario,
                                            Consumototal = p.consumototal,
                                            Adic = p.adic,
                                            Precioaut = p.precioaut,
                                            Preciocompra = p.preciocompra,
                                            Precioentrado = p.precioentrado,
                                            Ped = p.ped,
                                            Aprob = p.aprob,
                                            Comp = p.comp,
                                            Ent = p.ent,
                                            Sali = p.sali,
                                            Traslado = p.traslado,
                                            Xcomp = p.xcomp,
                                            Xent = p.xent,
                                            Saldoxunit = p.saldoxunit,
                                            Saldoxppto = p.saldoxppto,
                                            Vlrent = p.vlrent,
                                            Vlrenttraslado = p.vlrenttraslado,
                                            Vlrcompradoxent = p.vlrcompradoxent,
                                            Vlrxcomp = p.vlrxcomp,
                                            Vlrtraslado = p.vlrtraslado,
                                            Vlrproy = p.vlrproy,
                                            Vlrproyejec = p.vlrproyejec,
                                            Vlrini = p.vlrini,
                                            Vlrejec = p.vlrejec,
                                            IdFecha = p.IdFecha,
                                            Clasificacion = t.Id,
                                            nombreclasi = t.Tipo

                                        }).ToList();

            // ListaDetalleCostosIndirectosMetodo();
            // ListaDetallegruposCostosDirectosMetodo();
            return ListaCostosClasificacion;

        }*/
        /*-----------------------------------------------*/

        public string ListaCostosPresupuestos(int IdFecha) {

            listacosto(IdFecha);
            listacosto2(IdFecha);

            return "Ok CostosPptoProg";
        }

        public List<Costos> listacosto(int IdFecha) {

            ListaCostosClasificacion2 = new List<Costos>();
            List<VistaCostos> lst = db.VistaCostos.Where(t => t.IdFecha == IdFecha).ToList();

            if (lst != null)
            {
                ListaCostosClasificacion2 = lst.Select(t => new Costos
                {
                    Referencia1 = t.Referencia1,
                    Presupuesto = t.presupuesto,
                    Vlrproy =t.Vlrproy,
                    Clasificacion = t.Clasificacion,
                    Vlrcausado =t.VlrCausado,
                    Vlrejec =t.Vlrejecutado,
                    nombreclasi = t.nombreclasi,
                    IdFecha = t.IdFecha



                }).ToList();
            }
            return ListaCostosClasificacion2;
        
        }


        public List<CostosGastos> listacosto2(int IdFecha)
        {

            ListaCostosClasificacion3 = new List<CostosGastos>();
            var lst = db.VistaCostosGastos.Where(t => t.IdFecha == IdFecha).ToList();

            if (lst != null)
            {
                ListaCostosClasificacion3 = lst.Select(t => new CostosGastos
                {
                    Referencia1 = t.Referencia1,
                    Presupuesto = t.presupuesto,
                    Vlrproy = t.Vlrproy,
                    Clasificacion = t.Clasificacion,
                    Vlrcausado = t.VlrCausado,
                    Vlrejec = t.Vlrejecutado,
                    nombreclasi = t.nombreclasi,
                    IdFecha = t.IdFecha,
                    Capitulo = t.capitulo


                }).ToList();
            }
            return ListaCostosClasificacion3;

        }

        #region METODOS PARA SACAR EL GLOBAL
        /*Metodo para traer el global*/
        public List<ConsolidadoGlobal> ListaConsolidadoGlobal() {

            listaConsolidadoGlobal = new List<ConsolidadoGlobal>();
            ConsolidadoGlobal cons = new ConsolidadoGlobal();

            if(ListaConsolidadoIndirectos!=null && ListaConsolidadoDirectos!=null){

                cons.Vlrproy = ListaConsolidadoDirectos.First().Vlrproy + ListaConsolidadoIndirectos.First().Vlrproy;
                cons.VlrCausado = ListaConsolidadoDirectos.First().VlrCausado + ListaConsolidadoIndirectos.First().VlrCausado;
                cons.Vlrejecutado = ListaConsolidadoDirectos.First().Vlrejecutado + ListaConsolidadoIndirectos.First().Vlrejecutado;
                cons.Area = DescripcionProyecto("CMS").Area;
                cons.Vlrmt2vivienda =ListaConsolidadoDirectos.First().Vlrmt2vivienda + ListaConsolidadoIndirectos.First().Vlrmt2vivienda;
                cons.Vlrxvivienda = ListaConsolidadoDirectos.First().Vlrxvivienda + ListaConsolidadoIndirectos.First().Vlrxvivienda;
                cons.Nviviendas = DescripcionProyecto("CMS").Nviviendas;
                cons.Causado = cons.VlrCausado / cons.Vlrproy;
                cons.Ejecutado = cons.Vlrejecutado / cons.Vlrproy;
                cons.Presupuesto = "Total";
                listaConsolidadoGlobal.Add(cons);
            }
            return listaConsolidadoGlobal;
        }
        /*-----------------------------------------------*/
        #endregion



        #region METODOS PARA SACAR LOS COSTOS DIRECTOS
        /*Metodo para traer consolidado de costos Directos*/
        public List<ConsolidadoCostosDirectos> ListaConsolidadoCostosDirectos()
        {

            ListaConsolidadoDirectos = new List<ConsolidadoCostosDirectos>();

            if (ListaGruposCostosDirectos != null)
            {
                ConsolidadoCostosDirectos a =

                                 new ConsolidadoCostosDirectos
                                 {

                                     Vlrproy = ListaGruposCostosDirectos.Sum(ed => ed.Vlrproy) == null ? 0 : ListaGruposCostosDirectos.Sum(ed => ed.Vlrproy),
                                     VlrCausado = ListaGruposCostosDirectos.Sum(ed => ed.VlrCausado) == null ? 0 : ListaGruposCostosDirectos.Sum(ed => ed.VlrCausado),
                                     Vlrejecutado = ListaGruposCostosDirectos.Sum(ed => ed.Vlrejecutado) == null ? 0 : ListaGruposCostosDirectos.Sum(ed => ed.Vlrejecutado),
                                     Causado = (ListaGruposCostosDirectos.Sum(ed => ed.VlrCausado) == 0) || (ListaGruposCostosDirectos.Sum(ed => ed.Vlrproy) == 0) ? 0 : ListaGruposCostosDirectos.Sum(_ => _.VlrCausado) / ListaGruposCostosDirectos.Sum(_ => _.Vlrproy),
                                     Ejecutado = (ListaGruposCostosDirectos.Sum(ed => ed.Vlrejecutado) == 0) || (ListaGruposCostosDirectos.Sum(ed => ed.Vlrproy) == 0) ? 0 : ListaGruposCostosDirectos.Sum(_ => _.Vlrejecutado) / ListaGruposCostosDirectos.Sum(_ => _.Vlrproy),
                                     Vlrmt2vivienda = ListaGruposCostosDirectos.Sum(ed => ed.Vlrmt2vivienda),
                                     Vlrxvivienda = ListaGruposCostosDirectos.Sum(ed => ed.Vlrxvivienda),
                                     Area = DescripcionProyecto("CMS").Area,
                                     Nviviendas = DescripcionProyecto("CMS").Nviviendas,
                                 };

                ListaConsolidadoDirectos.Add(a);
            }


            return ListaConsolidadoDirectos;
        }
        /*-----------------------------------------------*/
        /*Metodo para traer los grupos de costos Directos*/
        public List<GruposCostosDirectos> ListaGruposCostosDirectosMetodo()
        {


            ListaGruposCostosDirectos = new List<GruposCostosDirectos>();


            if (ListaGruposCostosDirectos != null)
            {
                var deptRpt2 = (from d in ListaDetalleCostosDirectos
                                group d by d.Nombreclasi into g
                                select new GruposCostosDirectos
                                {
                                    Presupuesto = g.First().Nombreclasi,
                                    Vlrproy = g.Sum(ed => ed.Vlrproy) == null ? 0 : g.Sum(ed => ed.Vlrproy),
                                    VlrCausado = g.Sum(ed => ed.VlrCausado) == null ? 0 : g.Sum(ed => ed.VlrCausado),
                                    Vlrejecutado = g.Sum(ed => ed.Vlrejecutado) == null ? 0 : g.Sum(ed => ed.Vlrejecutado),
                                    Causado = (g.Sum(ed => ed.VlrCausado) == 0) || (g.Sum(ed => ed.Vlrproy) == 0) ? 0 : g.Sum(_ => _.VlrCausado) / g.Sum(_ => _.Vlrproy),
                                    Ejecutado = (g.Sum(ed => ed.Vlrejecutado) == 0) || (g.Sum(ed => ed.Vlrproy) == 0) ? 0 : g.Sum(_ => _.Vlrejecutado) / g.Sum(_ => _.Vlrproy),
                                    Vlrmt2vivienda = g.Sum(ed => ed.Vlrmt2vivienda),
                                    Vlrxvivienda = g.Sum(ed => ed.Vlrxvivienda),
                                    Area = g.First().Area,
                                    Nviviendas = g.First().Nviviendas

                                });

                foreach (var item in deptRpt2)
                {
                    GruposCostosDirectos Entidad = new GruposCostosDirectos();

                    Entidad.Presupuesto = item.Presupuesto;
                    Entidad.Vlrproy = item.Vlrproy;
                    Entidad.VlrCausado = item.VlrCausado;
                    Entidad.Clasificacion = item.Clasificacion;
                    Entidad.Vlrejecutado = item.Vlrejecutado;
                    Entidad.Causado = item.Causado;
                    Entidad.Ejecutado = item.Ejecutado;
                    Entidad.Vlrmt2vivienda = item.Vlrmt2vivienda;
                    Entidad.Area = item.Area;
                    Entidad.Vlrxvivienda = item.Vlrxvivienda;
                    Entidad.Nviviendas = item.Nviviendas;
                    Entidad.Nombreclasi = item.Nombreclasi;
                    ListaGruposCostosDirectos.Add(Entidad);
                }

            }


            return ListaGruposCostosDirectos;


        }
        /*-----------------------------------------------*/
        /*Metodo para traer el detalle de costos Directos*/
        public List<DetallesCostosDirectos> ListaDetalleCostosDirectosMetodo()
        {

            ListaDetalleCostosDirectos = new List<DetallesCostosDirectos>();

            if (ListaCostosClasificacion2 != null)
            {
                var results = (from line in ListaCostosClasificacion2
                               where line.Clasificacion != 5
                               select new DetallesCostosDirectos
                               {
                                   Referencia1 = line.Referencia1,
                                   Presupuesto =  line.Presupuesto,
                                   Vlrproy =  line.Vlrproy,
                                   Clasificacion =  line.Clasificacion,
                                   VlrCausado =  line.Vlrcausado,
                                   Vlrejecutado = line.Vlrejec,
                                   Causado = (line.Vlrcausado) == 0 || (line.Vlrproy)==0 ? 0 : line.Vlrcausado / line.Vlrproy,
                                   Ejecutado = (line.Vlrejec)==0 || (line.Vlrproy)== 0 ? 0 : line.Vlrejec / line.Vlrproy,
                                   Vlrmt2vivienda = (line.Vlrproy == 0) ? 0 : line.Vlrproy / DescripcionProyecto("CMS").Area,
                                   Vlrxvivienda = (line.Vlrproy == 0) ? 0 : line.Vlrproy / DescripcionProyecto("CMS").Nviviendas,
                                   Area = DescripcionProyecto("CMS").Area,
                                   Nviviendas = DescripcionProyecto("CMS").Nviviendas,
                                   Nombreclasi = line.nombreclasi

                               }).ToList();
                //return results;
                foreach (var item in results)
                {
                    DetallesCostosDirectos Entidad = new DetallesCostosDirectos();

                    Entidad.Presupuesto = item.Presupuesto;
                    Entidad.Referencia1 = item.Referencia1;
                    Entidad.Vlrproy = item.Vlrproy;
                    Entidad.VlrCausado = item.VlrCausado;
                    Entidad.Clasificacion = item.Clasificacion;
                    Entidad.Vlrejecutado = item.Vlrejecutado;
                    Entidad.Causado = item.VlrCausado / item.Vlrproy;
                    Entidad.Ejecutado = item.Ejecutado;
                    Entidad.Area = item.Area;
                    Entidad.Nviviendas = item.Nviviendas;
                    Entidad.Vlrxvivienda = item.Vlrxvivienda;
                    Entidad.Vlrmt2vivienda = item.Vlrmt2vivienda;

                   /* if (item.Nombreclasi == "Urbanismos")
                    {
                        Entidad.Area = item.Area;
                        Entidad.Nviviendas = item.Nviviendas;
                        Entidad.Vlrxvivienda = item.Vlrxvivienda;
                        Entidad.Vlrmt2vivienda = item.Vlrmt2vivienda;
                    }
                    else
                    {
                        Entidad.Area = 0;
                        Entidad.Nviviendas = 0;
                        Entidad.Vlrxvivienda = 0;
                        Entidad.Vlrmt2vivienda = 0;
                    }*/

                    Entidad.Nombreclasi = item.Nombreclasi;
                    ListaDetalleCostosDirectos.Add(Entidad);
                }

            }

            return ListaDetalleCostosDirectos;


        }
        /*-----------------------------------------------*/
        #endregion


        #region METODOS PARA SACAR LOS COSTOS INDIRECTOS

        /*Consolidado costos indirectos*/
        public List<ConsolidadoCostosIndirectos> ListaConsolidadoCostosIndirectosMetodo()
        {


            ListaConsolidadoIndirectos = new List<ConsolidadoCostosIndirectos>();


            if (ListaGruposCostosIndirectos != null)
            {
                var deptRpt2 = (from d in ListaGruposCostosIndirectos
                                group d by d.Presupuesto into g
                                select new ConsolidadoCostosIndirectos
                                {
                                    Presupuesto = "Gastos Generales",
                                    Vlrproy = g.Sum(ed => ed.Vlrproy) == null ? 0 : g.Sum(ed => ed.Vlrproy),
                                    VlrCausado = g.Sum(ed => ed.VlrCausado) == null ? 0 : g.Sum(ed => ed.VlrCausado),
                                    Vlrejecutado = g.Sum(ed => ed.Vlrejecutado) == null ? 0 : g.Sum(ed => ed.Vlrejecutado),
                                    Causado = (g.Sum(ed => ed.VlrCausado) == 0) || (g.Sum(ed => ed.Vlrproy) == 0) ? 0 : g.Sum(_ => _.VlrCausado) / g.Sum(_ => _.Vlrproy),
                                    Ejecutado = (g.Sum(ed => ed.Vlrejecutado) == 0) || (g.Sum(ed => ed.Vlrproy) == 0) ? 0 : g.Sum(_ => _.Vlrejecutado) / g.Sum(_ => _.Vlrproy),
                                    Vlrmt2vivienda = g.Sum(ed => ed.Vlrmt2vivienda),
                                    Vlrxvivienda = g.Sum(ed => ed.Vlrxvivienda),
                                    Area = DescripcionProyecto("CMS").Area,
                                    Nviviendas = DescripcionProyecto("CMS").Nviviendas

                                });

                foreach (var item in deptRpt2)
                {
                    ConsolidadoCostosIndirectos Entidad = new ConsolidadoCostosIndirectos();

                    Entidad.Presupuesto = item.Presupuesto;
                    Entidad.Capitulo = item.Capitulo;
                    Entidad.Vlrproy = item.Vlrproy;
                    Entidad.VlrCausado = item.VlrCausado;
                    Entidad.Clasificacion = item.Clasificacion;
                    Entidad.Vlrejecutado = item.Vlrejecutado;
                    Entidad.Causado = item.Causado;
                    Entidad.Ejecutado = item.Ejecutado;
                    Entidad.Vlrmt2vivienda = item.Vlrmt2vivienda;
                    Entidad.Area = item.Area;
                    Entidad.Vlrxvivienda = item.Vlrxvivienda;
                    Entidad.Nviviendas = item.Nviviendas;
                    ListaConsolidadoIndirectos.Add(Entidad);
                }

            }


            //ListaDetallegruposCostosDirectosMetodo();
            return ListaConsolidadoIndirectos;


        }
        /*-----------------------------------------*/
        /*Grupos costos indirectos*/
        public List<GruposCostosIndirectos> ListaGruposCostosIndirectosMetodo()
        {


            ListaGruposCostosIndirectos = new List<GruposCostosIndirectos>();


            if (ListaGruposCostosIndirectos != null)
            {
                var deptRpt2 = (from d in ListaDetalleCostosIndirectos
                                group d by d.Presupuesto into g
                                select new GruposCostosIndirectos
                                {
                                    Presupuesto = "Gastos Generales",
                                    Vlrproy = g.Sum(ed => ed.Vlrproy) == null ? 0 : g.Sum(ed => ed.Vlrproy),
                                    VlrCausado = g.Sum(ed => ed.VlrCausado) == null ? 0 : g.Sum(ed => ed.VlrCausado),
                                    Vlrejecutado = g.Sum(ed => ed.Vlrejecutado) == null ? 0 : g.Sum(ed => ed.Vlrejecutado),
                                    Causado = (g.Sum(ed => ed.VlrCausado) == 0) || (g.Sum(ed => ed.Vlrproy) == 0) ? 0 : g.Sum(_ => _.VlrCausado) / g.Sum(_ => _.Vlrproy),
                                    Ejecutado = (g.Sum(ed => ed.Vlrejecutado) == 0) || (g.Sum(ed => ed.Vlrproy) == 0) ? 0 : g.Sum(_ => _.Vlrejecutado) / g.Sum(_ => _.Vlrproy),
                                    Vlrmt2vivienda = g.Sum(ed => ed.Vlrmt2vivienda),
                                    Vlrxvivienda = g.Sum(ed => ed.Vlrxvivienda),
                                    Area = DescripcionProyecto("CMS").Area,
                                    Nviviendas = DescripcionProyecto("CMS").Nviviendas

                                });

                foreach (var item in deptRpt2)
                {
                    GruposCostosIndirectos Entidad = new GruposCostosIndirectos();

                    Entidad.Presupuesto = item.Presupuesto;
                    Entidad.Capitulo = item.Capitulo;
                    Entidad.Vlrproy = item.Vlrproy;
                    Entidad.VlrCausado = item.VlrCausado;
                    Entidad.Clasificacion = item.Clasificacion;
                    Entidad.Vlrejecutado = item.Vlrejecutado;
                    Entidad.Causado = item.Causado;
                    Entidad.Ejecutado = item.Ejecutado;
                    Entidad.Vlrmt2vivienda = item.Vlrmt2vivienda;
                    Entidad.Area = item.Area;
                    Entidad.Vlrxvivienda = item.Vlrxvivienda;
                    Entidad.Nviviendas = item.Nviviendas;
                    ListaGruposCostosIndirectos.Add(Entidad);
                }

            }


            //ListaDetallegruposCostosDirectosMetodo();
            return ListaGruposCostosIndirectos;


        }
        /*-----------------------------------------*/
        /*Detalles costos indirectos*/
        public List<DetallesCostosIndirectos> ListaDetalleCostosIndirectosMetodo()
        {

            ListaDetalleCostosIndirectos = new List<DetallesCostosIndirectos>();

            if (ListaCostosClasificacion3 != null)
            {
                ListaDetalleCostosIndirectos = (from line in ListaCostosClasificacion3
                               
                               
                               select new DetallesCostosIndirectos
                               {
                                 //  Referencia1 = line.Referencia1,
                                   Presupuesto = line.Presupuesto,
                                   Vlrproy = line.Vlrproy,
                                   Clasificacion = line.Clasificacion,
                                   VlrCausado = line.Vlrcausado,
                                   Vlrejecutado = line.Vlrejec,
                                   Causado = (line.Vlrcausado) == 0 || (line.Vlrproy) == 0 ? 0 : line.Vlrcausado / line.Vlrproy,
                                   Ejecutado = (line.Vlrejec) == 0 || (line.Vlrproy) == 0 ? 0 : line.Vlrejec / line.Vlrproy,
                                   Vlrmt2vivienda = (line.Vlrproy == 0) ? 0 : line.Vlrproy / DescripcionProyecto("CMS").Area,
                                   Vlrxvivienda = (line.Vlrproy == 0) ? 0 : line.Vlrproy / DescripcionProyecto("CMS").Nviviendas,
                                   Area = DescripcionProyecto("CMS").Area,
                                   Nviviendas = DescripcionProyecto("CMS").Nviviendas,
                                   Capitulo =line.Capitulo
                                 //  Nombreclasi = line.nombreclasi


                               }).ToList();
                //return results;
                /*foreach (var item in results)
                {
                    DetallesCostosIndirectos Entidad = new DetallesCostosIndirectos();

                 //   Entidad.Presupuesto = item.Presupuesto;
                    Entidad.Capitulo = item.Capitulo;
                    Entidad.Vlrproy = item.Vlrproy;
                    Entidad.VlrCausado = item.VlrCausado;
                    Entidad.Clasificacion = item.Clasificacion;
                    Entidad.Vlrejecutado = item.Vlrejecutado;
                    Entidad.Causado = item.VlrCausado / item.Vlrproy;
                    Entidad.Ejecutado = item.Ejecutado;
                    Entidad.Vlrmt2vivienda = item.Vlrmt2vivienda;
                    Entidad.Area = item.Area;
                    Entidad.Vlrxvivienda = item.Vlrxvivienda;
                    Entidad.Nviviendas = item.Nviviendas;
                    ListaDetalleCostosIndirectos.Add(Entidad);
                }*/

            }
            ListaGruposCostosIndirectosMetodo();
            return ListaDetalleCostosIndirectos;


        }
        /*-------------------------------------------*/
        #endregion


        /*Metodo para traer la información del proyecto*/
        public DescripcionProyect DescripcionProyecto(string Proyecto)
        {
            DescripcionProyect Est = new DescripcionProyect();
            DescripcionProyecto lst = db.DescripcionProyecto.Where(g => g.Proyecto == Proyecto).First();

            if (lst != null)
            {
                Est.Id = lst.Id;
                Est.Nviviendas = lst.Nviviendas;
                Est.Area = lst.Area;
                Est.Proyecto = lst.Proyecto;
            }

            return Est;
        }
        /*-----------------------------------------------*/

    }
}
