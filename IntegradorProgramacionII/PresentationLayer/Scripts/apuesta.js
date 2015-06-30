$(document).ready(function () {
    var apuestas = new Array();
    $('#apostar').click(function () {
        apostar();
    });
    $('#enviarapuesta').click(function () {
        EnviarApuestas();
    });

    function apostar() {
        modalidad = $('#modalidad').val();
        switch (modalidad) {
            case "Pleno" : 
                 apuesta = {
                        "modalidad" : $('#modalidad').val(),
                         numeros: [$('#numero').val()],
                        "dinero": $('#dinero').val()            
                 }
                 $('#apuestas-realizadas').append("<tr><td>" + apuesta.modalidad + "</td><td>" + apuesta.numeros[0] + "</td><td>" + apuesta.dinero + "</td></tr>");
                break;
            case "Semi" : 
                apuesta = {
                    "modalidad" : $('#modalidad').val(),
                     numeros: [$('#numero').val(), $('#numero1').val()],
                    "dinero": $('#dinero').val()            
                }
                $('#apuestas-realizadas').append("<tr><td>" + apuesta.modalidad + "</td><td>" + apuesta.numeros[0] + " - " + apuesta.numeros[1] + "</td><td>" + apuesta.dinero + "</td></tr>");
                break;
            case "Calle": case "Cubre":
                apuesta = {
                    "modalidad": $('#modalidad').val(),
                    numeros: [$('#numero').val(), $('#numero1').val(), $('#numero2').val()],
                    "dinero": $('#dinero').val()
                }
            default:

        }
        
        apuestas.push(apuesta);
        $('#formapuesta')[0].reset();
        console.log(apuestas);
        
    }

    function EnviarApuestas() {
        var elegido = $('#elegido').val();
        var datos = {
            apostado: apuestas,
            elegido: elegido
        };
        $.ajax({
            type: "POST",
            url: "/Home/RecibirApuesta",
            dataType: "json",
            data: JSON.stringify(datos),
            contentType: "application/json; charset=utf-8",
            error: function (error) {
                alert("fail !!!");
            }
        });
    }
});