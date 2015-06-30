﻿$(document).ready(function () {
    var apuestas = new Array();
    $('#apostar').click(function () {
        apostar();     
    });
    $('#enviarapuesta').click(function () {
        EnviarApuesta();
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