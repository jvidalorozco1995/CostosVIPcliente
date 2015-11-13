using Entidades;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BllJsonCal
{
   public class CostosPptoProgJSON
    {
        #region AQUI SE CARGAN LAS LISTAS APARTIR DE LO QUE TRAIGA FOX

       public static List<OrdenesDTO> OrdenesLista;
       public static List<CostosPptoProgDTOCOMPLETO> CostosPptoProg;
       public static List<CostoEntradoDTO> CostoEntradoLista;
       public static List<PedidosDTO> PedidosLista;
       public static List<SalidasDTO> SalidasLista;
       public static List<DescuentosDTO> DescuentoLista;
       public static List<CostosPptoProgDTOCOMPLETO> ListaCopiaCostosPptoProgLista;


       /*Metodo para cargar los descuentos apartir de un string*/
       public static List<DescuentosDTO> CargarDescuentos(string SQL)
       {

           try
           {
               DescuentoLista = (List<DescuentosDTO>)Newtonsoft.Json.JsonConvert.DeserializeObject(SQL, typeof(List<DescuentosDTO>));
               return DescuentoLista;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }
       /*------------------------------------------------*/

       /*Metodo para cargar las ordenes apartir de un string*/
       public static List<OrdenesDTO> CargarOrdenes(string SQL) {

           try
           {
               OrdenesLista = (List<OrdenesDTO>)Newtonsoft.Json.JsonConvert.DeserializeObject(SQL, typeof(List<OrdenesDTO>));
               return OrdenesLista;
           }
           catch (Exception ex) {

               throw ex;
           }
       
       }
       /*------------------------------------------------*/

       /*Metodo para cargar los costosEntrados apartir de un string*/
       public static List<CostoEntradoDTO> CargarCostoEntrado(string SQL)
       {
           try
           {
                   CostoEntradoLista = new List<CostoEntradoDTO>();
                   CostoEntradoLista = (List<CostoEntradoDTO>)Newtonsoft.Json.JsonConvert.DeserializeObject(SQL, typeof(List<CostoEntradoDTO>));
   
           }
           catch (Exception ex)
           {
             // i.Mensaje = "" + ex.Message;
           //   CostoEntradoLista.Add(i);
           }
           return CostoEntradoLista;
       }
       /*------------------------------------------------*/
       
       /*Metodo para cargar los costospptoprog apartir de un string*/
       public static List<CostosPptoProgDTOCOMPLETO> CargarCostos(string SQL)
       {
           try
           {
               CostosPptoProg = (List<CostosPptoProgDTOCOMPLETO>)Newtonsoft.Json.JsonConvert.DeserializeObject(SQL, typeof(List<CostosPptoProgDTOCOMPLETO>));

               return ActualizarCosto();
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }
       /*------------------------------------------------*/

       /*Metodo para cargar los pedidos apartir de un string*/
       public static List<PedidosDTO> CargarPedidos(string SQL)
       {

           try
           {
               PedidosLista = (List<PedidosDTO>)Newtonsoft.Json.JsonConvert.DeserializeObject(SQL, typeof(List<PedidosDTO>));
               return PedidosLista;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }
       /*------------------------------------------------*/

       /*Metodo para cargar las salidas apartir de un string*/
       public static List<SalidasDTO> CargarSalidas(string SQL)
       {

           try
           {
               SalidasLista = (List<SalidasDTO>)Newtonsoft.Json.JsonConvert.DeserializeObject(SQL, typeof(List<SalidasDTO>));
               return SalidasLista;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }
       /*------------------------------------------------*/
       #endregion
    
       /*Metodo para llenar todo el archivo de costos completo*/
       public static List<CostosPptoProgDTOCOMPLETO> ActualizarCosto()
       {
           try
           {

               List<CostosPptoProgDTOCOMPLETO> CostosPptoProgLista = new List<CostosPptoProgDTOCOMPLETO>();
               ListaCopiaCostosPptoProgLista = new List<CostosPptoProgDTOCOMPLETO>();
               foreach (var i in CostosPptoProg)
               {
                   /*Este objeto es llenado una tabla con formulas calculadas, todos estos campos vienen de la tabla ordenes por eso se llama asi*/
                    var Ordenes = CalcularPrecioCompraYcomp(i.Referencia1);
                   /*-----------------------------------------------------------------------------------------------------------*/
                   /*Este objeto es llenado una tabla con formulas calculadas, todos estos campos vienen de la tabla costoentrado por eso se llama asi*/
                   var CostoEntrado = CalcularPrecioEntrado(i.Referencia1);
                   /*-----------------------------------------------------------------------------------------------------------*/
                   /*Este objeto es llenado una tabla con formulas calculadas, todos estos campos vienen de la tabla Pedidos por eso se llama asi*/
                   var Pedidos = CalcularPedYaprob(i.Referencia1);
                   /*-----------------------------------------------------------------------------------------------------------*/
                   /*Este objeto es llenado una tabla con formulas calculadas, todos estos campos vienen de la tabla salidas por eso se llama asi*/
                   var SalidasSali = calcularSali(i.Referencia1,"0");
                   /*-----------------------------------------------------------------------------------------------------------*/
                    /*Este objeto es llenado una tabla con formulas calculadas, todos estos campos vienen de la tabla salidas por eso se llama asi*/
                   var SalidasTraslado = calcularSali(i.Referencia1,"2");
                   /*-----------------------------------------------------------------------------------------------------------*/
                   /*Este objeto es llenado una tabla con formulas calculadas, todos estos campos vienen de la tabla salidas por eso se llama asi*/
                   var Vlrpromsali = CalcularVlrpromsali(i.Referencia1);
                   /*-----------------------------------------------------------------------------------------------------------*/
                  /*Campos calculados para crear el archivo de costos*/
                   i.Preciocompra = Ordenes.PromVlrUnit;
                   i.Precioentrado = CostoEntrado.precioentrado;
                   i.Ped = Pedidos.ped;
                   i.Aprob = Pedidos.aprob;
                   i.Comp = Ordenes.comp;
                   i.Ent = CostoEntrado.cantent;
                   i.Traslado = SalidasTraslado.cant;
                   i.Xcomp = i.Consumototal + (i.Adic - i.Comp);
                   i.Xent = i.Comp - i.Ent;
                   /*si el control de inventario es ""---falso----"" entonces seleccionamos el ENT, y el SALDOXUNIT lo ponemos en cero, sino seleccionamos la suma de la cant de la salida y restamos lo entrado menos lo salido, menos lo traslado */
                   if (i.Ctrlinv.Equals("False")) { i.Sali = CostoEntrado.cantent; i.Saldoxunit = 0; } else { i.Sali = SalidasSali.cant; i.Saldoxunit = ((i.Ent - i.Sali)-i.Traslado);}
                   /*---------------------------------------------------------------------------------------------------------------------------------*/
                   i.Vlrent = i.Ent * i.Precioentrado;
                   /*Aqui copio la lista para poder sacar el saldoppto*/
                   ListaCopiaCostosPptoProgLista.Add(i);
                   /*-------------------------------------------------*/
                   i.Saldoxppto = calcularSaldoPpto(i.Referencia3).saldoppto;
                   i.Vlrenttraslado = (i.Vlrent - Vlrpromsali.vlrpromsal) * (i.Traslado * i.Sali);
                   i.Vlrcompradoxent = i.Xent * i.Preciocompra;
                   if (((i.Consumototal + i.Adic) - i.Comp) <= 0){ i.Vlrxcomp = 0;} else if (i.Precioentrado == 0){if (i.Precioaut > i.Precioppto){ i.Vlrxcomp = i.Precioaut * ((i.Consumototal + i.Adic) - i.Comp);}else{ i.Vlrxcomp = i.Precioppto * ((i.Consumototal + i.Adic) - i.Comp);}}else {i.Vlrxcomp = i.Precioentrado * ((i.Consumototal + i.Adic) - i.Comp);}
                   i.Vlrtraslado = Vlrpromsali.vlrpromsal * i.Traslado;
                  // i.Vlrproy = ((i.Vlrent + i.Xent) * i.Preciocompra) + (i.Vlrxcomp - i.Vlrtraslado);
                   i.Vlrproy = (i.Vlrent + i.Vlrcompradoxent + i.Vlrxcomp) - i.Vlrtraslado;
                   i.Vlrini = i.Consumototal * i.Precioppto;
                   i.descuento = CalcularDescuento(i.Referencia1).Valor;
                   i.IdFecha = i.IdFecha;
                   i.Validacion = i.Validacion;
                   if (i.Ctrlinv.Equals("True")) { i.Vlrejec = Vlrpromsali.vlrpromsal * i.Sali; } else { i.Vlrejec = i.Precioentrado * i.Sali; }
                   if (i.Vlrejec > i.Vlrproy) { i.Vlrproyejec = i.Vlrejec; } else { i.Vlrproyejec = i.Vlrproy; }
                   
                   /*añado un objeto de tipo costospptoprog, a una lista*/
                   CostosPptoProgLista.Add(i);
                   /*--------------------------------------------------*/
               }
             


               return CostosPptoProgLista;
               
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       /*------------------------------------------------*/

       #region Formulas calculadas
       /*Formula para calcular el valor precio compra*/
        public static OrdenesPrecioCompraDTO CalcularPrecioCompraYcomp(string Referencia)
       {
           try
           {
               if (OrdenesLista != null && OrdenesLista.Count!=0)
               {

                   var deptRpt2 = (from d in OrdenesLista
                                   where d.Referencia1 == Referencia
                                   group d by d.Referencia1 into grp
                                   select new OrdenesPrecioCompraDTO
                                   {
                                       Referencia1 = grp.Key,
                                       PromVlrUnit = (grp.Average(ed => ed.VlrUnita) == null ? 0 : grp.Average(ed => ed.VlrUnita)),
                                       comp = grp.Sum(ed => ed.Comp) == null ? 0 : grp.Sum(ed => ed.Comp)
                                   });

                   if (deptRpt2 != null && deptRpt2.Count() != 0)
                   {
                       return deptRpt2.First();
                   }
                   else {

                       OrdenesPrecioCompraDTO ord = new OrdenesPrecioCompraDTO();
                       ord.Referencia1 = Referencia;
                       ord.PromVlrUnit = 0;
                       ord.comp = 0;

                       return ord;
                   }

               }

               return null;
           }
           catch (Exception ex)
           {

               throw ex;
           }



       }
       /*----------------------------------------*/

        /*Formula para calcular el valor precio entrado*/
        public static CostoEntradoPrecioEntradoDTO CalcularPrecioEntrado(string Referencia)
        {
            try
            {
                if (CostoEntradoLista != null && OrdenesLista.Count != 0)
                {

                    var deptRpt2 = (from d in CostoEntradoLista
                                    where d.Referencia1 == Referencia
                                    group d by d.Referencia1 into grp
                                    select new CostoEntradoPrecioEntradoDTO
                                    {
                                        Referencia1 = grp.Key,
                                        costoentrado = grp.Sum(ed => ed.costoentrado),
                                        cantent = grp.Sum(ed => ed.cantent) == null ? 0 : grp.Sum(ed => ed.cantent),
                                        precioentrado = (grp.Sum(ed => ed.costoentrado) == 0 || grp.Sum(ed => ed.costoentrado) == null) || (grp.Sum(ed => ed.cantent) == 0 || grp.Sum(ed => ed.cantent) == null) ? 0 : grp.Sum(ed => ed.costoentrado) / grp.Sum(ed => ed.cantent)
                                       
                                   });

                    if (deptRpt2 != null && deptRpt2.Count() != 0)
                    {
                        return deptRpt2.First();

                    }
                    else {

                        CostoEntradoPrecioEntradoDTO cos = new CostoEntradoPrecioEntradoDTO();
                        cos.Referencia1 = Referencia;
                        cos.costoentrado = 0;
                        cos.cantent = 0;
                        cos.precioentrado = 0;


                        return cos;
                    }

                }
                return null;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
       /*----------------------------------------*/

       /*Formula para calcular el valor ped y aprob*/
       public static PedDTO CalcularPedYaprob(string Referencia)
       {
           try
           {
               if (PedidosLista != null && OrdenesLista.Count != 0)
               {
                  

                   var deptRpt2 = (from d in PedidosLista
                                   where d.Referencia1 == Referencia
                                   group d by d.Referencia1 into grp
                                   select new PedDTO
                                   {
                                       Referencia1 = grp.Key,
                                       ped = grp.Sum(ed => ed.ped) == null ? 0 : grp.Sum(ed => ed.ped),
                                       aprob = grp.Sum(ed => ed.aprob) == null ? 0 : grp.Sum(ed => ed.aprob)

                                   });

                   if (deptRpt2 != null && deptRpt2.Count() != 0)
                   {
                       return deptRpt2.First();
                   }
                   else {

                       PedDTO pe = new PedDTO();
                       pe.Referencia1 = Referencia;
                       pe.ped = 0;
                       pe.aprob = 0;
                       return pe;
                   }


               }

               return null;
           }
           catch (Exception ex)
           {

               throw ex;
           }



       }
        /*----------------------------------------*/

        /*Formula para calcular el valor de las salidas*/
        public static SaliDTO calcularSali(string Referencia,string TipoSa)
       {
           try
           {
               if (SalidasLista != null && OrdenesLista.Count != 0)
               {


                   var deptRpt2 = (from d in SalidasLista
                                   where d.Referencia1 == Referencia && d.tiposa.Equals(TipoSa)
                                   group d by d.Referencia1 into grp
                                   select new SaliDTO
                                   {
                                       Referencia1 = grp.Key,
                                       cant = grp.Sum(ed => ed.cant) == null ? 0 : grp.Sum(ed => ed.cant),


                                   });

                   if (deptRpt2 != null && deptRpt2.Count() != 0)
                   {
                       return deptRpt2.First();
                   }
                   else
                   {

                       SaliDTO sal = new SaliDTO();
                       sal.Referencia1 = Referencia;
                       sal.cant = 0;
                       sal.tiposa = "0";
                       return sal;
                   }


               }

               return null;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }
        /*----------------------------------------*/

        /*Formula para calcular el valor de el saldoxppto*/
        public static SaldoPptoDTO calcularSaldoPpto(string Referencia3)
        {
            try
            {
                if (ListaCopiaCostosPptoProgLista != null && OrdenesLista.Count != 0)
                {


                    var deptRpt2 = (from d in ListaCopiaCostosPptoProgLista
                                    where d.Referencia3 == Referencia3
                                    group d by d.Referencia3 into grp
                                    select new SaldoPptoDTO
                                    {
                                        Referencia3 = grp.Key,
                                        saldoppto = grp.Sum(ed => ed.Saldoxunit) == null ? 0 : grp.Sum(ed => ed.Saldoxunit),


                                    });

                    if (deptRpt2 != null && deptRpt2.Count() != 0)
                    {
                        return deptRpt2.First();
                    }
                    else
                    {

                        SaldoPptoDTO sal = new SaldoPptoDTO();
                        sal.Referencia3 = Referencia3;
                        sal.saldoppto = 0;
                   
                        return sal;
                    }


                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /*----------------------------------------*/

        /*Formula para calcular el valor de las valor promedio salida*/
        public static SaliVlrPromDTO CalcularVlrpromsali(string Referencia)
        {
            try
            {
                if (SalidasLista != null && OrdenesLista.Count != 0)
                {


                    var deptRpt2 = (from d in SalidasLista
                                    where d.Referencia1 == Referencia
                                    group d by d.Referencia1 into grp
                                    select new SaliVlrPromDTO
                                    {
                                        Referencia1 = grp.Key,
                                        vlrpromsal = (grp.Sum(ed => ed.costsali) == 0 || grp.Sum(ed => ed.costsali) == null) || (grp.Sum(ed => ed.costsali) == 0 || grp.Sum(ed => ed.cant) == null) ? 0 : grp.Sum(ed => ed.costsali) / grp.Sum(ed => ed.cant)


                                    });

                    if (deptRpt2 != null && deptRpt2.Count() != 0)
                    {
                        return deptRpt2.First();
                    }
                    else
                    {

                        SaliVlrPromDTO sal = new SaliVlrPromDTO();
                        sal.Referencia1 = Referencia;
                        sal.vlrpromsal = 0;
                        return sal;
                    }


                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /*Formula para calcular el valor descuento*/
        public static DescuentosDTO CalcularDescuento(string Referencia)
        {
            try
            {
                if (CostoEntradoLista != null && OrdenesLista.Count != 0)
                {

                    var deptRpt2 = (from d in DescuentoLista
                                    where d.Referencia == Referencia
                                    group d by d.Referencia into grp
                                    select new DescuentosDTO
                                    {
                                        Referencia = grp.Key,
                                        Valor = grp.Sum(ed => ed.Valor),
                                    });

                    if (deptRpt2 != null && deptRpt2.Count() != 0)
                    {
                        return deptRpt2.First();

                    }
                    else
                    {

                          DescuentosDTO cos = new DescuentosDTO();
                       
                          cos.Referencia = Referencia;
                          cos.Valor = 0;


                        return cos;
                    }

                }
                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
        /*----------------------------------------*/

        #endregion
    }
}
