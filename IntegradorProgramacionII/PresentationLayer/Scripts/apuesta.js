$(document).ready(function () {
    var apuestas = new Array();
    $('#apostar').click(function () {
        apostar();
    }); 

    function apostar() {
        var apuesta = {
            "modalidad" : $('#modalidad').val(),
            "numero": $('#numero').val(),
            "dinero": $('#dinero').val()            
        }

        apuestas.push(apuesta);
        $('#formapuesta')[0].reset();
        console.log(apuestas);

        $('#apuestas-realizadas').append("<tr><td>" + apuesta.modalidad + "</td><td>" + apuesta.numero + "</td><td>" + apuesta.dinero + "</td></tr>");
    }
});