//var urlapp = "http://190.146.2.135:80/CostosVIP";
//var urlapplocal = "http://190.146.2.135:80/Costos";
var urlapp = "http://localhost:51731";
var urlapplocal = "http://localhost:2279";

/*Funcion para eliminar el area cada vez que se actualize*/
function EliminarAreas(Proyecto, Id) {


    $.ajax({
        type: "POST",
        url: "Servicios/AreasWS.asmx/Eliminar",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "Proyecto": Proyecto }),
        dataType: 'json',
        async: false,
        success: function (result) {
            GuardarSalidas(Proyecto, Id);
        },
        error: function (error) {
            $.unblockUI();
            EliminarFecha(Id);
            sweetAlert("Error", "ha ocurrido un error al eliminar la fecha");
            console.log(JSON.stringify(error) + "Eliminar Areas");

        }
    });

}
/*----------------------------------------------------------------------------------------------*/

/*Funcion para eliminar la fecha cuando ocurra un error*/
function EliminarFecha(Id) {

    $.ajax({

        type: "POST",
        url: "Servicios/FechasWS.asmx/EliminarFecha",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',

        data: JSON.stringify({ "Id": Id }),
        success: function (result) {

            console.log(result.d);

        },
        error: function (error) {

            sweetAlert("Error", "ha ocurrido un error al eliminar la fecha");
            console.log(JSON.stringify(error) + " eliminar Fechas");

        }
    });


}
/*----------------------------------------------------------------------------------------------*/

/*Funcion para guardar la fecha en la base de datos*/
function GuardarFechas() {


    // unblock when ajax activity stops 


    var par = $('#CmbProyectos').val();
    var o = par.split("-");
    var Proyecto = o[0];
    var fil = o[1];



    var ent = {};
    ent.Id = 1;
    ent.Proyecto = Proyecto,
    ent.Fecha = "",
    ent.Tipo = "True"

    var parametrosJSON = { Cat: ent };

    console.log(JSON.stringify(parametrosJSON));

    $.blockUI({
        message: "Cargando.............",
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        }

    });

    var Id;
    $.ajax({

        type: "POST",
        url: "Servicios/FechasWS.asmx/InsertarFecha",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',

        data: JSON.stringify(parametrosJSON),
        success: function (result) {

            console.log(result.d);
            Id = result.d;

            EliminarAreas(Proyecto, Id);

        },
        error: function (error) {
            $.unblockUI();
            sweetAlert("Error", "ha ocurrido un error al insertar la fecha");
            console.log(JSON.stringify(error) + " Guardar Fechas");
            EliminarFecha(Id);
        }
    });


}
/*----------------------------------------------------------------------------------------------*/

/*Trae las Salidas de multifox*/
function GuardarSalidas(Proyecto,IdFecha) {
    $.ajax({
        type: "POST",
        url: urlapp+"/Servicios/SalidasWS.asmx/Salidas",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "Proyecto": Proyecto,"IdFecha": IdFecha}),
        dataType: 'json',
        async: false,
        success: function (result) {
            InsertarSalidas(result.d, IdFecha);
            GuardarOrdenes(Proyecto, IdFecha);
          

        },
        error: function (error) {
          
            $.unblockUI();
            sweetAlert("Error", "ha ocurrido un error al traer Salidas");
            console.log(JSON.stringify(error)+"Traer Salidas");
            EliminarFecha(IdFecha);

           
        }
    });

    
}
/*----------------------------------------------------------------------------------------------*/
/*Trae las Ordenes de multifox */
function GuardarOrdenes(Proyecto, IdFecha) {

   

    $.ajax({
        type: "POST",
        url:  urlapp + "/Servicios/OrdenesWS.asmx/Ordenes",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "Proyecto": Proyecto, "IdFecha": IdFecha }),
        dataType: 'json',
        async: false,
        success: function (result) {

            InsertarOrdenes(result.d, IdFecha);
            GuardarPedidos(Proyecto, IdFecha);
           
        },
        error: function (error) {
           
            $.unblockUI();
            sweetAlert("Error", "ha ocurrido un error al traer las ordenes");
            console.log(JSON.stringify(error) + " Traer Ordenes");
            EliminarFecha(IdFecha);


           
        }
    });

    
}
/*----------------------------------------------------------------------------------------------*/
/*Trae las Pedidos de multifox */
function GuardarPedidos(Proyecto, IdFecha) {


   

    $.ajax({
        type: "POST",
        url: urlapp + "/Servicios/PedidosWS.asmx/Pedidos",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "Proyecto": Proyecto, "IdFecha": IdFecha }),
        dataType: 'json',
        async: false,
       
        success: function (result) {

            InsertarPedidos(result.d, IdFecha);
            GuardarDescuentos(Proyecto, IdFecha);
            
          
        },
        error: function (error) {
         
            $.unblockUI();
            sweetAlert("Error", "ha ocurrido un error al traer los pedidos");
            console.log(JSON.stringify(error) + "Traer Pedidos");
            EliminarFecha(IdFecha);


           
        }
    });

    
}
/*----------------------------------------------------------------------------------------------*/
/*Trae las CostoEntrado de multifox */
function GuardarCostoEntrado(Proyecto, IdFecha) {


   

    $.ajax({
        type: "POST",
        url: urlapp + "/Servicios/CostoEntradoWS.asmx/CostoEntrado",
        data: JSON.stringify({ "Proyecto": Proyecto, "IdFecha": IdFecha }),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        async: false,
        success: function (result) {
            InsertarCostoEntrado(result.d, IdFecha);
            GuardarCostosPptoProg(Proyecto, IdFecha, "IND");
           
        },
        error: function (error) {
           
            $.unblockUI();
            sweetAlert("Error", "ha ocurrido un error al traer el costo entrado");
            console.log(JSON.stringify(error) + " Traer CostoEntrado");
            EliminarFecha(IdFecha);


           
        }
    });

    
}
/*----------------------------------------------------------------------------------------------*/

/*Trae los descuentos de multifox */
function GuardarDescuentos(Proyecto, IdFecha) {




    $.ajax({
        type: "POST",
        url: urlapp + "/Servicios/DescuentosWS.asmx/Descuentos",
        data: JSON.stringify({ "Proyecto": Proyecto, "IdFecha": IdFecha }),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        async: false,
        success: function (result) {
            InsertarDescuentos(result.d, IdFecha);
            GuardarCostoEntrado(Proyecto, IdFecha);

        },
        error: function (error) {

            $.unblockUI();
            sweetAlert("Error", "ha ocurrido un error al traer los descuentos");
            console.log(JSON.stringify(error) + " Traer CostoEntrado");
            EliminarFecha(IdFecha);



        }
    });


}
/*----------------------------------------------------------------------------------------------*/

/*Trae las CostosPptoProg de multifox */
function GuardarCostosPptoProg(Proyecto, IdFecha,Filtro) {

   

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        async: false,
        url:urlapp+"/Servicios/CostoPptoProgWS.asmx/CostosPptoProg",
        data: JSON.stringify({ "Proyecto": Proyecto, "IdFecha": IdFecha, "Filtro": Filtro }),
        
        success: function (result) {

            InsertarCostosPptoProg(result.d, IdFecha);
            GuardarAreas(Proyecto, IdFecha);
         
        },
        error: function (error) {
           
            $.unblockUI();
            sweetAlert("Error", "ha ocurrido un error al traer el costospptoprog");
            console.log(JSON.stringify(error) + "Traer CostosPptoProg");
            EliminarFecha(IdFecha);


           
        }
    });

    
}
/*----------------------------------------------------------------------------------------------*/

/*Trae las Areas de multifox */
function GuardarAreas(Proyecto, IdFecha) {

   

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        async: false,
        url: urlapp + "/Servicios/AreasWS.asmx/Areas",
       
        success: function (result) {
            
         
            InsertarAreas(result.d, IdFecha);
            
        },
        error: function (error) {
           
            $.unblockUI();
            sweetAlert("Error", "ha ocurrido un error al guardar el area");
            console.log(JSON.stringify(error) + "Traer Areas");
            EliminarFecha(IdFecha);


           
        }
    });

    
}
/*----------------------------------------------------------------------------------------------*/

/*Inserta en la tabla costoEntrado*/
function InsertarCostoEntrado(respuesta,IdFecha) {

   

    $.ajax({
        type: "POST",
        dataType: "text",
        contentType: "application/x-www-form-urlencoded;charset=ISO-8859-1",
        url: urlapplocal+"/Servicios/Recibir.asmx/InsertarTablaCostoEntrado",
        data: "dtBuildSQL=" +encodeValue(respuesta),
        async: false,
       
        success: function (result) {
           console.log(result);
         },
        error: function (error) {

            $.unblockUI();
            sweetAlert("Error", "ha ocurrido un error al insertar el costo entrado");
            console.log(JSON.stringify(error) + "Insertar CostoEntrado");
            EliminarFecha(IdFecha);

        }
    });

}
/*----------------------------------------------------------------------------------------------*/

/*Inserta en la tabla pedidos*/
function InsertarPedidos(respuesta,IdFecha) {

   

    $.ajax({
        type: "POST",
        dataType: "text",
        data: "dtBuildSQL=" +encodeValue(respuesta),
        async: false,
       
        url: urlapplocal + "/Servicios/Recibir.asmx/InsertarTablaPedidos",
        success: function (result) {

            console.log(result);

        },
        error: function (error) {

            $.unblockUI();
            sweetAlert("Error", "ha ocurrido un error al insertar los pedidos");
            console.log(JSON.stringify(error) + "Insertar Pedidos");
            EliminarFecha(IdFecha);

        }
    });




}
/*----------------------------------------------------------------------------------------------*/

/*Inserta en la tabla Ordenes*/
function InsertarOrdenes(respuesta,IdFecha) {

   

    $.ajax({
        type: "POST",
        dataType: "text",
        data: "dtBuildSQL=" + encodeValue(respuesta),
        async: false,
        
        url: urlapplocal + "/Servicios/Recibir.asmx/InsertarTablaOrdenes",
        success: function (result) {

            console.log(result);

        },
        error: function (error) {

            $.unblockUI();
            sweetAlert("Error", "ha ocurrido un error al insertar las ordenes");
            console.log(JSON.stringify(error) + "Insertar Ordenes");
            EliminarFecha(IdFecha);

        }
    });

}
/*----------------------------------------------------------------------------------------------*/

/*Inserta en la tabla costoPptoProg*/
function InsertarCostosPptoProg(respuesta,IdFecha) {

   

    $.ajax(
    {
        type: "POST",
        dataType: "text",
        data: "dtBuildSQL=" +encodeValue(respuesta),
        async: false,
       
        url: urlapplocal + "/Servicios/Recibir.asmx/InsertarTablaCostoPptoProg",
        success: function (result) {

           console.log("Ok CostosPptoProg");
        }
       ,
        error: function (error) {
            $.unblockUI();
            sweetAlert("Error", "ha ocurrido un error al insertar el costopptoprog");
            console.log(JSON.stringify(error) + "Insertar CostosPptoProg");
            EliminarFecha(IdFecha);

        }
    });




}
/*----------------------------------------------------------------------------------------------*/

/*Inserta en la tabla Salidas*/
function InsertarSalidas(respuesta,IdFecha) {

   

    $.ajax(
           {
               type: "POST",
               dataType: "text",
               contentType: "application/x-www-form-urlencoded;charset=ISO-8859-1",
               async: false,
               url: urlapplocal + "/Servicios/Recibir.asmx/InsertarTablaSalidas",
               data: "dtBuildSQL=" +encodeValue(respuesta),
               success: function (result) {
                   console.log(result);
               },
               error: function (error) {
                   $.unblockUI();
                   sweetAlert("Error", "ha ocurrido un error al insertar las salidas");
                   console.log(JSON.stringify(error) + "Insertar Salidas");
                   EliminarFecha(IdFecha);

               }
           }

      );
}
/*----------------------------------------------------------------------------------------------*/

/*Inserta en la tabla Salidas*/
function InsertarAreas(respuesta) {

   

    $.ajax(
           {
               type: "POST",
               dataType: "text",
               async: false,
               url: urlapplocal + "/Servicios/Recibir.asmx/InsertarAreas",
               data: "dtBuildSQL=" + encodeValue(respuesta),
               complete: function () {
                   $.unblockUI();
               },
               success: function (result) {
                 
                   console.log(result);
                   location.reload();
               },
               error: function (error) {
                   $.unblockUI();
                   sweetAlert("Error", "ha ocurrido un error al insertar el area");
                   console.log(JSON.stringify(error) + "Insertar Areas");
                

               }
           }

      );
}
/*----------------------------------------------------------------------------------------------*/

/*Inserta en la tabla Salidas*/
function InsertarDescuentos(respuesta, IdFecha) {



    $.ajax(
           {
               type: "POST",
               dataType: "text",
               contentType: "application/x-www-form-urlencoded;charset=ISO-8859-1",
               async: false,
               url: urlapplocal + "/Servicios/Recibir.asmx/InsertarTablaDescuentos",
               data: "dtBuildSQL=" + encodeValue(respuesta),
               success: function (result) {
                   console.log(result);
               },
               error: function (error) {
                   $.unblockUI();
                   sweetAlert("Error", "ha ocurrido un error al insertar los Descuentos");
                   console.log(JSON.stringify(error) + "Insertar Descuentos");
                   EliminarFecha(IdFecha);

               }
           }

      );
}
/*----------------------------------------------------------------------------------------------*/

/*funcion para convertir UTF8*/
function encodeValue(val) {
    var encodedVal;
    if (!encodeURIComponent) {
        encodedVal = escape(val);
        /* fix the omissions */
        encodedVal = encodedVal.replace(/@/g, '%40');
        encodedVal = encodedVal.replace(/\//g, '%2F');
        encodedVal = encodedVal.replace(/\+/g, '%2B');
    }
    else {
        encodedVal = encodeURIComponent(val);
        /* fix the omissions */
        encodedVal = encodedVal.replace(/~/g, '%7E');
        encodedVal = encodedVal.replace(/!/g, '%21');
        encodedVal = encodedVal.replace(/\(/g, '%28');
        encodedVal = encodedVal.replace(/\)/g, '%29');
        encodedVal = encodedVal.replace(/'/g, '%27');
    }
    /* clean up the spaces and return */
    return encodedVal.replace(/\%20/g, '+');
}
/*----------------------------------------------------------------------------------------------*/

