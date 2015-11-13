var app = angular.module('serviceCostos',['angular-loading-bar'])
  .config(['cfpLoadingBarProvider', function(cfpLoadingBarProvider) {
      cfpLoadingBarProvider.includeSpinner = false;
  }]);


app.filter('euro', function () {
    return function (text) {
      //  text = text.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1 ");
        var t = currencyFormatDE(text)
        return t;
    };


    function currencyFormatDE(num) {
        return num
           .toFixed(2) // always two decimal digits
           .replace(".", ",") // replace decimal point character with ,
           .replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.")// use . as a separator
    }
});


app.controller('CostosController', function ($scope, $http) {
    
   // var urlapp = "http://190.146.2.135:80/Costos";
    var urlapp = "http://localhost:2279";
   
   /*Metodo inicial para llamar cuando se inicializa la pagina*/
    $scope.init = function () {
         $scope.CargarProyectos();
    }

    /*Metodod para cargar las semanas en los combox*/
    $scope.cfechas=function(){
        
        $scope.CargarFechas();
        $scope.CargarFechasLineaBase();
    }

    /*-------------------------SEMANA ACTUAL--------------------------------*/

    /*Metodo para cargar la semana actual*/
     $scope.CargarSemanaActual = function () {
        
        var urlx = urlapp+"/Servicios/InformeSemanaActual.asmx/CargarCostosSemanaActual";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            ignoreLoadingBar: true,
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaA.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana actual");
            $scope.DetalleCostosIndirectosSemanaActual();

        })
          .error(function (error) {
              console.log("Error al cargar los costos de la semana actual" + error);
        });

      }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar los detallesindirectos de la semana actual*/
     $scope.DetalleCostosIndirectosSemanaActual = function () {
         
         var urlx = urlapp+"/Servicios/InformeSemanaActual.asmx/DetalleCostosIndirectosSemanaActual";
         

         $http({
             ignoreLoadingBar: true,
             url: urlx,
             dataType: 'json',
             method: 'POST',
             data: { IdFecha: $scope.SemanaA.Id },
             headers: {
                 "Content-Type": "application/json"
             }
         }).success(function (response) {
             console.log("Ok semana actual detallesindirectos");
             $scope.DetCostosIndirectosSemanaActual = JSON.parse(response.d);
             $scope.GruposCostosIndirectosSemanaActual();
         })
          .error(function (error) {
              console.log("Error al cargar detallescostosindirectos de la semana actual" + error);
         });
      }
     /*-------------------------------------------------------------------------*/
    /*Metodo para cargar los gruposindirectos de la semana actual*/
     $scope.GruposCostosIndirectosSemanaActual = function () {

        
         var urlx = urlapp+"/Servicios/InformeSemanaActual.asmx/GruposCostosIndirectosSemanaActual";
         var ent = {};
         ent.IdFecha = 2;
         var parametrosJSON = { IdFecha: ent };

         $http({
             ignoreLoadingBar: true,
             url: urlx,
             dataType: 'json',
             method: 'POST',
             data: { IdFecha: $scope.SemanaA.Id },
             headers: {
                 "Content-Type": "application/json"
             }
         }).success(function (response) {
             console.log("Ok semana actual gruposindirectos");
             $scope.GruCostosIndirectosSemanaActual = JSON.parse(response.d);
             $scope.ConsolidadoCostosIndirectosSemanaActual();
         })
          .error(function (error) {
              console.log("Error al cargar gruposcostosindirectos de la semana actual" + error);
          });
     }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar el consolidadoindirecto de la semana actual*/
     $scope.ConsolidadoCostosIndirectosSemanaActual = function () {
        
         var urlx = urlapp+"/Servicios/InformeSemanaActual.asmx/ConsolidadoCostosIndirectosSemanaActual";
         var ent = {};
         ent.IdFecha = 2;
         var parametrosJSON = { IdFecha: ent };

         $http({
             ignoreLoadingBar: true,
             url: urlx,
             dataType: 'json',
             method: 'POST',
             data: { IdFecha: $scope.SemanaA.Id },
             headers: {
                 "Content-Type": "application/json"
             }
         }).success(function (response) {
             console.log("Ok semana actual consolidadoindirectos");
             $scope.ConCostosIndirectosSemanaActual = JSON.parse(response.d);
             $scope.DetalleCostosDirectosSemanaActual();

         })
          .error(function (error) {
              console.log("Error al cargar el consolidadocostosindirectos de la semana actual" + error);
          });
     }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar los detallesDirectos de la semana actual*/
     $scope.DetalleCostosDirectosSemanaActual = function () {
        
         var urlx = urlapp+"/Servicios/InformeSemanaActual.asmx/DetalleCostosDirectosSemanaActual";
         var ent = {};
         ent.IdFecha = 2;
         var parametrosJSON = { IdFecha: ent };

         $http({

             ignoreLoadingBar: true,
             url: urlx,
             dataType: 'json',
             method: 'POST',
             data: { IdFecha: $scope.SemanaA.Id },
             headers: {
                 "Content-Type": "application/json"
             }
         }).success(function (response) {
             console.log("Ok semana actual detalle Directos");
             $scope.DetCostosDirectosSemanaActual = JSON.parse(response.d);
             $scope.GruposCostosDirectosSemanaActual();
             
         })
          .error(function (error) {
              console.log("Error al cargar detallescostosdirectos de la semana actual" + error);
          });
     }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar los gruposDirectos de la semana actual*/
     $scope.GruposCostosDirectosSemanaActual = function () {
         
         var urlx = urlapp+"/Servicios/InformeSemanaActual.asmx/GruposCostosDirectosSemanaActual";
         var ent = {};
         ent.IdFecha = 2;
         var parametrosJSON = { IdFecha: ent };

         $http({
             ignoreLoadingBar: true,
             url: urlx,
             dataType: 'json',
             method: 'POST',
             data: { IdFecha: $scope.SemanaA.Id },
             headers: {
                 "Content-Type": "application/json"
             }
         }).success(function (response) {
             console.log("Ok semana actual grupos Directos");
             $scope.GruCostosDirectosSemanaActual = JSON.parse(response.d);
             $scope.ConsolidadoCostosDirectosSemanaActual();
         })
          .error(function (error) {
              console.log("Error al cargar gruposcostosDirectos de la semana actual" + error);
          });
     }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar el consolidadoDirectos de la semana actual*/
    $scope.ConsolidadoCostosDirectosSemanaActual = function () {

       
        var urlx = urlapp+"/Servicios/InformeSemanaActual.asmx/ConsolidadoCostosDirectosSemanaActual";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            ignoreLoadingBar: true,
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaA.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana actual consolidado costos Directos");
            $scope.ConCostosDirectosSemanaActual = JSON.parse(response.d);
            $scope.ConsolidadoGlobal();

        })
         .error(function (error) {
             console.log("Error al cargar el consolidadocostosDirectos de la semana actual" + error);
         });
    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar el total global de todo*/
    $scope.ConsolidadoGlobal = function () {


        var urlx = urlapp+"/Servicios/InformeSemanaActual.asmx/ListaConsolidadoGlobal";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaA.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok total global semana actual");
            $scope.TotalGlobal = JSON.parse(response.d);
            $("#Contenido").css("display", "block");

        })
         .error(function (error) {
             console.log("Error al cargar el global de la semana actual" + error);
         });
    }
    /*-------------------------FIN SEMANA ACTUAL--------------------------------*/



    /*-------------------------SEMANA PASADA--------------------------------*/

    /*Metodo para cargar la semana pasada*/
    $scope.CargarSemanaPasada = function () {

        var urlx = urlapp+"/Servicios/InformeSemanaPasada.asmx/CargarCostosSemanaPasada";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({

            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaP.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana pasada");
            $scope.DetalleCostosIndirectosSemanaPasada();

        })
          .error(function (error) {
              console.log("Error al cargar los costos de la semana pasada" + error);
          });

    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar los detallesindirectos de la semana pasada*/
    $scope.DetalleCostosIndirectosSemanaPasada = function () {

        var urlx = urlapp+"/Servicios/InformeSemanaPasada.asmx/DetalleCostosIndirectosSemanaPasada";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaP.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana pasada detallesindirectos");
            $scope.DetCostosIndirectosSemanaPasada = JSON.parse(response.d);
            $scope.GruposCostosIndirectosSemanaPasada();
        })
         .error(function (error) {
             console.log("Error al cargar detallescostosindirectos de la semana pasada" + error);
         });
    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar los gruposindirectos de la semana pasada*/
    $scope.GruposCostosIndirectosSemanaPasada = function () {


        var urlx = urlapp+"/Servicios/InformeSemanaPasada.asmx/GruposCostosIndirectosSemanaPasada";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaP.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana pasada gruposindirectos");
            $scope.GruCostosIndirectosSemanaPasada = JSON.parse(response.d);
            $scope.ConsolidadoCostosIndirectosSemanaPasada();
        })
         .error(function (error) {
             console.log("Error al cargar gruposcostosindirectos de la semana pasada" + error);
         });
    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar el consolidadoindirecto de la semana pasada*/
    $scope.ConsolidadoCostosIndirectosSemanaPasada = function () {

        var urlx = urlapp+"/Servicios/InformeSemanaPasada.asmx/ConsolidadoCostosIndirectosSemanaPasada";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaP.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana pasada consolidadoindirectos");
           
            $scope.ConCostosIndirectosSemanaPasada = JSON.parse(response.d);
            $scope.DetalleCostosDirectosSemanaPasada();

        })
         .error(function (error) {
             console.log("Error al cargar el consolidadocostosindirectos de la semana pasada" + error);
         });
    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar los detallesDirectos de la semana pasada*/
    $scope.DetalleCostosDirectosSemanaPasada = function () {

        var urlx = urlapp+"/Servicios/InformeSemanaPasada.asmx/DetalleCostosDirectosSemanaPasada";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaP.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana pasada detalle Directos");
            $scope.DetCostosDirectosSemanaPasada = JSON.parse(response.d);
            $scope.GruposCostosDirectosSemanaPasada();

        })
         .error(function (error) {
             console.log("Error al cargar detallescostosdirectos de la semana pasada" + error);
         });
    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar los gruposDirectos de la semana pasada*/
    $scope.GruposCostosDirectosSemanaPasada = function () {

        var urlx = urlapp+"/Servicios/InformeSemanaPasada.asmx/GruposCostosDirectosSemanaPasada";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaP.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana pasada grupos Directos");
            $scope.GruCostosDirectosSemanaPasada = JSON.parse(response.d);
            $scope.ConsolidadoCostosDirectosSemanaPasada();
        })
         .error(function (error) {
             console.log("Error al cargar gruposcostosDirectos de la semana pasada" + error);
         });
    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar el consolidadoDirectos de la semana pasada*/
    $scope.ConsolidadoCostosDirectosSemanaPasada = function () {


        var urlx = urlapp+"/Servicios/InformeSemanaPasada.asmx/ConsolidadoCostosDirectosSemanaPasada";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaP.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana pasada consolidado costos Directos");
           
            $scope.ConCostosDirectosSemanaPasada = JSON.parse(response.d);


        })
         .error(function (error) {
             console.log("Error al cargar el consolidadocostosDirectos de la semana pasada" + error);
         });
    }
   
    /*-------------------------FIN SEMANA PASADA--------------------------------*/




    /*-------------------------SEMANA LINEABASE--------------------------------*/
    /*Metodo para cargar la semana lineabase*/
    $scope.CargarSemanaLineaBase = function () {

        var urlx = urlapp+"/Servicios/InformeSemanaLineaBase.asmx/CargarCostosSemanaLineaBase";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({

            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaL.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana lineabase");
            $scope.DetalleCostosIndirectosSemanaLineaBase();

        })
          .error(function (error) {
              console.log("Error al cargar los costos de la semana lineabase" + error);
          });

    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar los detallesindirectos de la semana lineabase*/
    $scope.DetalleCostosIndirectosSemanaLineaBase = function () {

        var urlx = urlapp+"/Servicios/InformeSemanaLineaBase.asmx/DetalleCostosIndirectosSemanaLineaBase";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaL.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana lineabase detallesindirectos");
            $scope.DetCostosIndirectosSemanaLineaBase = JSON.parse(response.d);
            $scope.GruposCostosIndirectosSemanaLineaBase();
        })
         .error(function (error) {
             console.log("Error al cargar detallescostosindirectos de la semana lineabase" + error);
         });
    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar los gruposindirectos de la semana lineabase*/
    $scope.GruposCostosIndirectosSemanaLineaBase = function () {


        var urlx = urlapp+"/Servicios/InformeSemanaLineaBase.asmx/GruposCostosIndirectosSemanaLineaBase";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaL.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana lineabase gruposindirectos");
            $scope.GruCostosIndirectosSemanaLineaBase = JSON.parse(response.d);
            $scope.ConsolidadoCostosIndirectosSemanaLineaBase();
        })
         .error(function (error) {
             console.log("Error al cargar gruposcostosindirectos de la semana lineabase" + error);
         });
    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar el consolidadoindirecto de la semana lineabase*/
    $scope.ConsolidadoCostosIndirectosSemanaLineaBase = function () {

        var urlx = urlapp+"/Servicios/InformeSemanaLineaBase.asmx/ConsolidadoCostosIndirectosSemanaLineaBase";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaL.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana lineabase consolidadoindirectos");
          
            $scope.ConCostosIndirectosSemanaLineaBase = JSON.parse(response.d);
            $scope.DetalleCostosDirectosSemanaLineaBase();

        })
         .error(function (error) {
             console.log("Error al cargar el consolidadocostosindirectos de la semana lineabase" + error);
         });
    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar los detallesDirectos de la semana lineabase*/
    $scope.DetalleCostosDirectosSemanaLineaBase = function () {

        var urlx = urlapp+"/Servicios/InformeSemanaLineaBase.asmx/DetalleCostosDirectosSemanaLineaBase";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaL.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana lineabase detalle Directos");
            $scope.DetCostosDirectosSemanaLineaBase = JSON.parse(response.d);
            $scope.GruposCostosDirectosSemanaLineaBase();

        })
         .error(function (error) {
             console.log("Error al cargar detallescostosdirectos de la semana lineabase" + error);
         });
    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar los gruposDirectos de la semana lineabase*/
    $scope.GruposCostosDirectosSemanaLineaBase = function () {

        var urlx = urlapp+"/Servicios/InformeSemanaLineaBase.asmx/GruposCostosDirectosSemanaLineaBase";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaL.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana lineabase grupos Directos");
            $scope.GruCostosDirectosSemanaLineaBase = JSON.parse(response.d);
            $scope.ConsolidadoCostosDirectosSemanaLineaBase();
        })
         .error(function (error) {
             console.log("Error al cargar gruposcostosDirectos de la semana lineabase" + error);
         });
    }
    /*-------------------------------------------------------------------------*/
    /*Metodo para cargar el consolidadoDirectos de la semana lineabase*/
    $scope.ConsolidadoCostosDirectosSemanaLineaBase = function () {


        var urlx = urlapp+"/Servicios/InformeSemanaLineaBase.asmx/ConsolidadoCostosDirectosSemanaLineaBase";
        var ent = {};
        ent.IdFecha = 2;
        var parametrosJSON = { IdFecha: ent };

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { IdFecha: $scope.SemanaL.Id },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok semana lineabase consolidado costos Directos");

            $scope.ConCostosDirectosSemanaLineaBase = JSON.parse(response.d);


        })
         .error(function (error) {
             console.log("Error al cargar el consolidadocostosDirectos de la semana lineabase" + error);
         });
    }
    /*-------------------------FIN SEMANA LINEABASE--------------------------------*/


    /*Metodo para cargar los proyectos*/
    $scope.CargarProyectos = function () {

        var urlx = urlapp + "/Servicios/ProyectosWS.asmx/ListaProyectos2";

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { Proyecto: "" },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok Proyectos" + JSON.stringify(response.d));
            $scope.Proyectos = JSON.parse(response.d);
         //   $scope.CargarFechas();

        })
         .error(function (error) {
             console.log("Error al cargar los Proyectos" + error);
         });
    }


    /*Metodo para cargar las fechas*/
    $scope.CargarFechas = function () {

        var urlx = urlapp + "/Servicios/FechasWS.asmx/Fechas";
    
        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { Proyecto: $scope.Proy.Codigo },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok fechas"+JSON.stringify(response.d));
            $scope.Fechas = JSON.parse(response.d);
            $scope.SemanaA = $scope.Fechas[0];
            $scope.SemanaP = $scope.Fechas[0];
        })
         .error(function (error) {
             console.log("Error al cargar las fechas" + error);
         });
    }

    /*Metodo para cargar las fechas linea base*/
    $scope.CargarFechasLineaBase = function () {

        var urlx = urlapp + "/Servicios/FechasWS.asmx/FechasLineaBase";

        $http({
            url: urlx,
            dataType: 'json',
            method: 'POST',
            data: { Proyecto: $scope.Proy.Codigo },
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            console.log("Ok fechas linea base" + JSON.stringify(response.d));
            $scope.FechasLineaBase = JSON.parse(response.d);
            $scope.SemanaL = $scope.FechasLineaBase[0];

        })
         .error(function (error) {
             console.log("Error al cargar las fechas lineaBase" + error);
         });
    }

    /*Click del boton para cargar las semanas*/
    $scope.Click = function () {


        $scope.CargarSemanaActual();
        $scope.CargarSemanaPasada();
        $scope.CargarSemanaLineaBase();
        
       // $document.find("#HiddenField1").val($scope.SemanaA.Id);
       
        //alert(JSON.stringify($scope.ddlFruits.Id));
    }

    /*Click para exportar el informe a excel*/
    $scope.Exportar = function () {

       /*window.open('data:application/vnd.ms-excel,' + encodeURIComponent($('#Contenido').html()));
        e.preventDefault();*/
        var blob = new Blob([document.getElementById('Contenido').innerHTML], {
            type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
        });
        saveAs(blob, "Report.xls");
    }
    });

    /*Metodo que me carga en porcentaje*/
    app.filter('percentage', function () {
        return function (input, max) {
            if (isNaN(input)) {
                return input;
            }
            return Math.floor((input * 100) / max) + '%';
        };
    });
/*-----------------------------------------*/

