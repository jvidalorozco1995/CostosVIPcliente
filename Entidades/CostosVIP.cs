using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{


    public class ProyectosDTO
    {
        public string Codigo { get; set; }
        public string Proyecto { get; set; }
        public string Filtro { get; set; }
        public DateTime? FechaIniObra { get; set; }
        public DateTime? FechaFinObra { get; set; }


    }
   
    public class FechasDTO
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string Proyecto { get; set; }
        public string Tipo { get; set; }

    }

    public class Areas
    {
        public int Id { get; set; }
        public string Proyecto { get; set; }
        public string NombreObra { get; set; }
        public string CodigoObraInmueble { get; set; }
        public string CodigoBloque { get; set; }
        public string NombreManzana { get; set; }
        public string CodigoInmueble { get; set; }
        public decimal ValorVenta { get; set; }
        public decimal Area { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class PedidosDTO
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "referencia1")]
        public string Referencia1 { get; set; }
        public string codcapi { get; set; }
        public string codunit { get; set; }
        public string codinsu { get; set; }
        public DateTime fecha { get; set; }
        public string pedido { get; set; }
        [JsonProperty(PropertyName = "ped")]
        public decimal? ped { get; set; }
        [JsonProperty(PropertyName = "aprob")]
        public decimal? aprob { get; set; }
        [JsonProperty(PropertyName = "comp")]
        public decimal? comp { get; set; }
        public decimal? xgenorden { get; set; }
        public string orden { get; set; }
        public string usuario { get; set; }
        public int? IdFecha { get; set; }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DescuentosDTO
    {

      

   //   [JsonProperty(PropertyName = "exp_1")]
       public int? Id {get; set;}
      [JsonProperty(PropertyName = "exp_2")]
       public string Referencia {get; set;}
   //   [JsonProperty(PropertyName = "descterc")]
       public string Tercero {get;set;}
    //  [JsonProperty(PropertyName = "descliqu")]
       public string Liquidacion {get;set;}
    //  [JsonProperty(PropertyName = "descobra")]
       public string Obra {get;set;}
      /*[DefaultValue("Ninguno")]*/
   //   [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate,PropertyName = "descconc")]
      public string Concepto {get;set;}
      [JsonProperty(PropertyName = "descvalo")]
      public decimal? Valor {get;set;}
  //    [JsonProperty(PropertyName = "descpres")]
      public string Presupuesto {get;set;}
     // [JsonProperty(PropertyName = "exp_9")]
       public int? IdFecha { get; set; }

    }



    [JsonObject(MemberSerialization.OptIn)]
    public class CostoEntradoDTO
    {
        //[JsonProperty(PropertyName = "exp_1")]
        public int? Id { get; set; }
        [JsonProperty(PropertyName = "referencia1")]
        public string Referencia1 { get; set; }
        [JsonProperty(PropertyName = "nombreppto")]
        public string nombppto { get; set; }
        [JsonProperty(PropertyName = "fecha")]
        public string fecha { get; set; }
        [JsonProperty(PropertyName = "orden")]
        public string orden { get; set; }
        [JsonProperty(PropertyName = "#liqu")]
        public string Nliqu { get; set; }
        [JsonProperty(PropertyName = "codterc")]
        public string codterc { get; set; }
        [JsonProperty(PropertyName = "nombre")]
        public string nombre { get; set; }
        [JsonProperty(PropertyName = "cap")]
        public string cap { get; set; }
        [JsonProperty(PropertyName = "nombrecap")]
        public string nombrecap { get; set; }
        [JsonProperty(PropertyName = "apu")]
        public string apu { get; set; }
        [JsonProperty(PropertyName = "nombreapu")]
        public string nombapu { get; set; }
        [JsonProperty(PropertyName = "codigo")]
        public string codigo { get; set; }
        [JsonProperty(PropertyName = "descripcion")]
        public string descripcion { get; set; }
        [JsonProperty(PropertyName = "unidad")]
        public string unidad { get; set; }
        [JsonProperty(PropertyName = "cantent")]
        public decimal? cantent { get; set; }
        [JsonProperty(PropertyName = "vrunitentrado")]
        public decimal? vlrunitentrado { get; set; }
        [JsonProperty(PropertyName = "costoentrado")]
        public decimal? costoentrado { get; set; }
        [JsonProperty(PropertyName = "usuario")]
        public string Usuario { get; set; }
        public decimal? descuento { get; set; }
        public int? IdFecha { get; set; }
     

    }
   
    [JsonObject(MemberSerialization.OptIn)]
    public class SalidasDTO
    {

        public int Id { get; set; }
        [JsonProperty(PropertyName = "referencia1")]
        public string Referencia1 { get; set; }
        public DateTime? Fecha { get; set; }
        public string liquidacion { get; set; }
        public string valeconsumo { get; set; }
        public string salida { get; set; }
        [JsonProperty(PropertyName = "tiposa")]
        public string tiposa { get; set; }
        public string codcapi { get; set; }
        public string codunita { get; set; }
        public string codinsum { get; set; }
        public string insumo { get; set; }
        [JsonProperty(PropertyName = "cant")]
        public decimal? cant { get; set; }
        public decimal? costsali { get; set; }
        public string saliobse { get; set; }
        public string saliusua { get; set; }
        public int IdFecha { get; set; }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class OrdenesDTO
    {

        public int Id { get; set; }
        [JsonProperty(PropertyName = "referencia1")]
        public string Referencia1 { get; set; }
        public string Presupuesto { get; set; }
        public string Cod_Unit { get; set; }
        public string Unitario { get; set; }
        public string Cod_Insumo { get; set; }
        public string Insumo { get; set; }
        public string Und { get; set; }
        [JsonProperty(PropertyName = "comp")]
        public decimal? Comp { get; set; }
        public decimal? Ent { get; set; }
        public decimal? PorEnt { get; set; }
        public DateTime? Fecha { get; set; }
        public string Orden { get; set; }
        public string Tipo { get; set; }
        public string Cod_Prov { get; set; }
        public string Proveedor { get; set; }
        [JsonProperty(PropertyName = "vlunitario")]
        public decimal? VlrUnita { get; set; }
        public decimal? CostEnt { get; set; }
        public string Usuario { get; set; }
        public int? IdFecha { get; set; }

    }
  
    public class OrdenesTempDTO
    {
        public int Id { get; set; }
        public string Referencia1 { get; set; }
        public string Presupuesto { get; set; }
        public string Cod_Unit { get; set; }
        public string Unitario { get; set; }
        public string Cod_Insumo { get; set; }
        public string Insumo { get; set; }
        public string Und { get; set; }
        public decimal? Comp { get; set; }
        public decimal? Ent { get; set; }
        public decimal? PorEnt { get; set; }
        public DateTime? Fecha { get; set; }
        public string Orden { get; set; }
        public string Tipo { get; set; }
        public string Cod_Prov { get; set; }
        public string Proveedor { get; set; }
        public decimal? VlrUnita { get; set; }
        public decimal? CostEnt { get; set; }
        public string Usuario { get; set; }
        public int? IdFecha { get; set; }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CostosPptoProgDTO
    {

        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "referencia1")]
        public string Referencia1 { get; set; }
        [JsonProperty(PropertyName = "referencia2")]
        public string Referencia2 { get; set; }
        [JsonProperty(PropertyName = "referencia3")]
        public string Referencia3 { get; set; }
        [JsonProperty(PropertyName = "presupuesto")]
        public string Presupuesto { get; set; }
        [JsonProperty(PropertyName = "codcapi")]
        public string Codcapi { get; set; }
        [JsonProperty(PropertyName = "capitulo")]
        public string Capitulo { get; set; }
        [JsonProperty(PropertyName = "codunit")]
        public string Codunit { get; set; }
        [JsonProperty(PropertyName = "unitario")]
        public string Unitario { get; set; }
        [JsonProperty(PropertyName = "undunita")]
        public string Undunita { get; set; }
        [JsonProperty(PropertyName = "cantxppto")]
        public decimal? Cantxppto { get; set; }
        [JsonProperty(PropertyName = "codinsu")]
        public string Codinsu { get; set; }
        [JsonProperty(PropertyName = "insutipo")]
        public string Insutipo { get; set; }
        [JsonProperty(PropertyName = "insumo")]
        public string Insumo { get; set; }
        [JsonProperty(PropertyName = "unidinsu")]
        public string Unidinsu { get; set; }
        [JsonProperty(PropertyName = "ctrlinven")]
        public string Ctrlinv { get; set; }
        [JsonProperty(PropertyName = "validacion")]
        public string Validacion { get; set; }
        [JsonProperty(PropertyName = "precioppto")]
        public decimal? Precioppto { get; set; }
        [JsonProperty(PropertyName = "consumounitario")]
        public decimal? Consumounitario { get; set; }
        [JsonProperty(PropertyName = "consumototal")]
        public decimal? Consumototal { get; set; }
        [JsonProperty(PropertyName = "adic")]
        public decimal? Adic { get; set; }
        [JsonProperty(PropertyName = "precioaut")]
        public decimal? Precioaut { get; set; }
        [JsonProperty(PropertyName = "preciocompra")]
        public decimal? Preciocompra { get; set; }
        [JsonProperty(PropertyName = "precioentrado")]
        public decimal? Precioentrado { get; set; }
        [JsonProperty(PropertyName = "Ped")]
        public decimal? Ped { get; set; }
        [JsonProperty(PropertyName = "Aprob")]
        public decimal? Aprob { get; set; }
        [JsonProperty(PropertyName = "Comp")]
        public decimal? Comp { get; set; }
        [JsonProperty(PropertyName = "Ent")]
        public decimal? Ent { get; set; }
        [JsonProperty(PropertyName = "Sali")]
        public decimal? Sali { get; set; }
        [JsonProperty(PropertyName = "Traslado")]
        public decimal? Traslado { get; set; }
        [JsonProperty(PropertyName = "Xcomp")]
        public decimal? Xcomp { get; set; }
        [JsonProperty(PropertyName = "Xent")]
        public decimal? Xent { get; set; }
        [JsonProperty(PropertyName = "Saldoxunit")]
        public decimal? Saldoxunit { get; set; }
        [JsonProperty(PropertyName = "Saldoxppto")]
        public decimal? Saldoxppto { get; set; }
        [JsonProperty(PropertyName = "Vlrent")]
        public decimal? Vlrent { get; set; }
        [JsonProperty(PropertyName = "Vlrenttraslado")]
        public decimal? Vlrenttraslado { get; set; }
        [JsonProperty(PropertyName = "Vlrcompradoxent")]
        public decimal? Vlrcompradoxent { get; set; }
        [JsonProperty(PropertyName = "Vlrxcomp")]
        public decimal? Vlrxcomp { get; set; }
        [JsonProperty(PropertyName = "Vlrtraslado")]
        public decimal? Vlrtraslado { get; set; }
        [JsonProperty(PropertyName = "Vlrproy")]
        public decimal? Vlrproy { get; set; }
        [JsonProperty(PropertyName = "Vlrproyejec")]
        public decimal? Vlrproyejec { get; set; }
        [JsonProperty(PropertyName = "Vlrini")]
        public decimal? Vlrini { get; set; }
        [JsonProperty(PropertyName = "Vlrejec")]
        public decimal? Vlrejec { get; set; }
        [JsonProperty(PropertyName = "exp_23")]
        public decimal? IdFecha { get; set; }
        [JsonProperty(PropertyName = "clasificacion")]
        public int? Clasificacion { get; set; }
        [JsonProperty(PropertyName = "nombreclasi")]
        public string nombreclasi { get; set; }
    
    
    }


    public class Costos {

        public string Referencia1 { get; set; }
        public string Presupuesto { get; set; }
        public decimal? Vlrproy { get; set; }
        public int? Clasificacion { get; set; }
        public decimal? Vlrcausado { get; set; }
        public decimal? Vlrejec { get; set; }
        public int? IdFecha { get; set; }
        public string nombreclasi { get; set; }

    
    }

    public class CostosGastos
    {

        public string Referencia1 { get; set; }
        public string Presupuesto { get; set; }
        public decimal? Vlrproy { get; set; }
        public int? Clasificacion { get; set; }
        public decimal? Vlrcausado { get; set; }
        public decimal? Vlrejec { get; set; }
        public int? IdFecha { get; set; }
        public string nombreclasi { get; set; }
        public string Capitulo { get; set; }

    }


    [JsonObject(MemberSerialization.OptIn)]
    public class CostosPptoProgDTOCOMPLETO
    {

        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "referencia1")]
        public string Referencia1 { get; set; }
        [JsonProperty(PropertyName = "referencia2")]
        public string Referencia2 { get; set; }
        [JsonProperty(PropertyName = "referencia3")]
        public string Referencia3 { get; set; }
        [JsonProperty(PropertyName = "presupuesto")]
        public string Presupuesto { get; set; }
        [JsonProperty(PropertyName = "codcapi")]
        public string Codcapi { get; set; }
        [JsonProperty(PropertyName = "capitulo")]
        public string Capitulo { get; set; }
        [JsonProperty(PropertyName = "codunit")]
        public string Codunit { get; set; }
        [JsonProperty(PropertyName = "unitario")]
        public string Unitario { get; set; }
        [JsonProperty(PropertyName = "undunita")]
        public string Undunita { get; set; }
        [JsonProperty(PropertyName = "cantxppto")]
        public decimal? Cantxppto { get; set; }
        [JsonProperty(PropertyName = "codinsu")]
        public string Codinsu { get; set; }
        [JsonProperty(PropertyName = "insutipo")]
        public string Insutipo { get; set; }
        [JsonProperty(PropertyName = "insumo")]
        public string Insumo { get; set; }
        [JsonProperty(PropertyName = "unidinsu")]
        public string Unidinsu { get; set; }
        [JsonProperty(PropertyName = "ctrlinven")]
        public string Ctrlinv { get; set; }
        [JsonProperty(PropertyName = "validacion")]
        public string Validacion { get; set; }
        [JsonProperty(PropertyName = "precioppto")]
        public decimal? Precioppto { get; set; }
        [JsonProperty(PropertyName = "consumounitario")]
        public decimal? Consumounitario { get; set; }
        [JsonProperty(PropertyName = "consumototal")]
        public decimal? Consumototal { get; set; }
        [JsonProperty(PropertyName = "adic")]
        public decimal? Adic { get; set; }
        [JsonProperty(PropertyName = "precioaut")]
        public decimal? Precioaut { get; set; }
        [JsonProperty(PropertyName = "preciocompra")]
        public decimal? Preciocompra { get; set; }
        [JsonProperty(PropertyName = "precioentrado")]
        public decimal? Precioentrado { get; set; }
        [JsonProperty(PropertyName = "Ped")]
        public decimal? Ped { get; set; }
        [JsonProperty(PropertyName = "Aprob")]
        public decimal? Aprob { get; set; }
        [JsonProperty(PropertyName = "Comp")]
        public decimal? Comp { get; set; }
        [JsonProperty(PropertyName = "Ent")]
        public decimal? Ent { get; set; }
        [JsonProperty(PropertyName = "Sali")]
        public decimal? Sali { get; set; }
        [JsonProperty(PropertyName = "Traslado")]
        public decimal? Traslado { get; set; }
        [JsonProperty(PropertyName = "Xcomp")]
        public decimal? Xcomp { get; set; }
        [JsonProperty(PropertyName = "Xent")]
        public decimal? Xent { get; set; }
        [JsonProperty(PropertyName = "Saldoxunit")]
        public decimal? Saldoxunit { get; set; }
        [JsonProperty(PropertyName = "Saldoxppto")]
        public decimal? Saldoxppto { get; set; }
        [JsonProperty(PropertyName = "Vlrent")]
        public decimal? Vlrent { get; set; }
        [JsonProperty(PropertyName = "Vlrenttraslado")]
        public decimal? Vlrenttraslado { get; set; }
        [JsonProperty(PropertyName = "Vlrcompradoxent")]
        public decimal? Vlrcompradoxent { get; set; }
        [JsonProperty(PropertyName = "Vlrxcomp")]
        public decimal? Vlrxcomp { get; set; }
        [JsonProperty(PropertyName = "Vlrtraslado")]
        public decimal? Vlrtraslado { get; set; }
        [JsonProperty(PropertyName = "Vlrproy")]
        public decimal? Vlrproy { get; set; }
        [JsonProperty(PropertyName = "Vlrproyejec")]
        public decimal? Vlrproyejec { get; set; }
        [JsonProperty(PropertyName = "Vlrini")]
        public decimal? Vlrini { get; set; }
        [JsonProperty(PropertyName = "Vlrejec")]
        public decimal? Vlrejec { get; set; }
        [JsonProperty(PropertyName = "exp_23")]
        public decimal? IdFecha { get; set; }
        public decimal? descuento { get; set; }
    


    }



    #region clases de campos calculados
    public class OrdenesPrecioCompraDTO
    {
        public string Referencia1 { get; set; }
        public decimal? PromVlrUnit { get; set; }
        public decimal? comp { get; set; }

    }

    public class PedDTO
    {
        public string Referencia1 { get; set; }
        public decimal? ped { get; set; }
        public decimal? aprob { get; set; }

    }

    public class SaliDTO
    {

        public string Referencia1 { get; set; }
        public decimal? cant { get; set; }
        public string tiposa { get; set; }

    }

    public class CostoEntradoPrecioEntradoDTO
    {
        public string Referencia1 { get; set; }
        public decimal? costoentrado { get; set; }
        public decimal? cantent { get; set; }
        public decimal? precioentrado { get; set; }

    }

    public class SaldoPptoDTO
    {

        public string Referencia3 { get; set; }
        public decimal? saldoppto { get; set; }

    }

    public class SaliVlrPromDTO
    {

        public string Referencia1 { get; set; }
        public decimal? vlrpromsal { get; set; }
    }
    #endregion





    #region clases de campos para el informe

    public class ConsolidadoGlobal {

        public string Presupuesto { get; set; }
        public string Capitulo { get; set; }
        public decimal? Vlrproy { get; set; }
        public decimal? Vlrejecutado { get; set; }
        public decimal? Causado { get; set; }
        public decimal? Ejecutado { get; set; }
        public int? Clasificacion { get; set; }
        public decimal? VlrCausado { get; set; }
        public decimal? Area { get; set; }
        public decimal? Vlrmt2vivienda { get; set; }
        public decimal? Vlrxvivienda { get; set; }
        public int? Nviviendas { get; set; }
    
    }

    public class DetallesCostosIndirectos
    {

        public string Presupuesto { get; set; }
        public string Capitulo { get; set; }
        public decimal? Vlrproy { get; set; }
        public decimal? Vlrejecutado { get; set; }
        public decimal? Causado { get; set; }
        public decimal? Ejecutado { get; set; }
        public int? Clasificacion { get; set; }
        public decimal? VlrCausado { get; set; }
        public decimal? Area { get; set; }
        public decimal? Vlrmt2vivienda { get; set; }
        public decimal? Vlrxvivienda { get; set; }
        public int? Nviviendas { get; set; }
    }

    public class GruposCostosIndirectos
    {

        public string Presupuesto { get; set; }
        public string Capitulo { get; set; }
        public decimal? Vlrproy { get; set; }
        public decimal? Vlrejecutado { get; set; }
        public decimal? Causado { get; set; }
        public decimal? Ejecutado { get; set; }
        public int? Clasificacion { get; set; }
        public decimal? VlrCausado { get; set; }
        public decimal? Area { get; set; }
        public decimal? Vlrmt2vivienda { get; set; }
        public decimal? Vlrxvivienda { get; set; }
        public int? Nviviendas { get; set; }
    }

    public class ConsolidadoCostosIndirectos {

        public string Presupuesto { get; set; }
        public string Capitulo { get; set; }
        public decimal? Vlrproy { get; set; }
        public decimal? Vlrejecutado { get; set; }
        public decimal? Causado { get; set; }
        public decimal? Ejecutado { get; set; }
        public int? Clasificacion { get; set; }
        public decimal? VlrCausado { get; set; }
        public decimal? Area { get; set; }
        public decimal? Vlrmt2vivienda { get; set; }
        public decimal? Vlrxvivienda { get; set; }
        public int? Nviviendas { get; set; }
    
    }
    
    public class DetallesCostosDirectos
    {
        public string Referencia1 { get; set; }
        public string Presupuesto { get; set; }
        public decimal? Vlrproy { get; set; }
        public decimal? Vlrejecutado { get; set; }
        public decimal? Causado { get; set; }
        public decimal? Ejecutado { get; set; }
        public int? Clasificacion { get; set; }
        public decimal? VlrCausado { get; set; }
        public decimal? Area { get; set; }
        public decimal? Vlrmt2vivienda { get; set; }
        public decimal? Vlrxvivienda { get; set; }
        public int? Nviviendas { get; set; }
        public string Nombreclasi { get; set; }
    }

    public class GruposCostosDirectos
    {
        public string Referencia1 { get; set; }
        public string Presupuesto { get; set; }
        public decimal? Vlrproy { get; set; }
        public decimal? Vlrejecutado { get; set; }
        public decimal? Causado { get; set; }
        public decimal? Ejecutado { get; set; }
        public int? Clasificacion { get; set; }
        public decimal? VlrCausado { get; set; }
        public decimal? Area { get; set; }
        public decimal? Vlrmt2vivienda { get; set; }
        public decimal? Vlrxvivienda { get; set; }
        public int? Nviviendas { get; set; }
        public string Nombreclasi { get; set; }
    }

    public class ConsolidadoCostosDirectos
    {
        public string Referencia1 { get; set; }
        public string Presupuesto { get; set; }
        public decimal? Vlrproy { get; set; }
        public decimal? Vlrejecutado { get; set; }
        public decimal? Causado { get; set; }
        public decimal? Ejecutado { get; set; }
        public int? Clasificacion { get; set; }
        public decimal? VlrCausado { get; set; }
        public decimal? Area { get; set; }
        public decimal? Vlrmt2vivienda { get; set; }
        public decimal? Vlrxvivienda { get; set; }
        public int? Nviviendas { get; set; }
        public string Nombreclasi { get; set; }
    }

    public class DescripcionProyect{
    
        public int? Id {get;set;}
        public string Proyecto {get;set;}
        public int? Nviviendas {get;set;}
        public decimal? Area {get;set;}
    }
    #endregion

}
