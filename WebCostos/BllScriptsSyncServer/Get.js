//Metodo _GET
//Metodo para devolver los datos 
_GET = function (URL) {
    var Objecto;
    $.ajax({
        type: "GET",
        url: URL,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            Objecto =JSON.parse(result.d);
        },
        error: function (result) {
            console.log(JSON.stringify(result));
        }
    });
    return Objecto;
}