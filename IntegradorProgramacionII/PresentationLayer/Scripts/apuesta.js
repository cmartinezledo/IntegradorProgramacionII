$(document).ready(function () {
        var apuestas = new Array();
        CrearNumeros(0);
    $('#apostar').click(function () {
        console.log($('.m-fichas').text());
        console.log($('#fichas').val());
        if ($('#fichas').val() === "") {
            alert("Completar la cantidad de fichas");
        } else {
            if ($('#fichas').val() < 1 || $('#fichas').val() > parseInt($('#m-fichas').text())) {
                alert("Su apuesta supera el valor de fichas que posee");
            } else { 
                apostar();
                $("#btn-jugar").removeAttr('disabled');
                borrar();
                CrearNumeros(0);
            }
        }
    });
        $('#modalidad').change(function () {
        borrar();
        switchapuestas();
    });
    $('#btn-comprar').click(function() {
        $('#comprar').show();
    });
    $('#premio-cerrar').click(function() {
        $('#perdiste').hide();
        $('#ganaste').hide();
        $('.added').remove();
        borrarApuestas();
    });
    $('#premio-cerrar1').click(function () {
        $('#perdiste').hide();
        $('#ganaste').hide();
        $('.added').remove();
        borrarApuestas();
    });
    $('#btncomprar').click(function () {
        if ($('#fichas-comprar').val() <= parseInt($('.m-dinero').text()) && $('#fichas-comprar').val() >= 0 && $('#fichas-comprar').val() != "") {
            Comprar();
            $('#comprar').hide();
        } else {
            alert("No te alcanza la plata!");
        }
    });
    function borrar() {
        $('#numeros span').remove();
        $('#sel-menu').remove();
        $('#sel-menu1').remove();
        $('#sel-menu2').remove();
        $('#sel-menu3').remove();
        $('#sel-menu4').remove();
        $('#sel-menu5').remove();
        $('#numero1').remove();
        $('#numero2').remove();
        $('#numero3').remove();
    }
    function borrarApuestas() {
        $('#apuestas-realizadas .add').remove();
        $('#btn-jugar').attr('disabled');
        borrar();
        apuestas = [];
        console.log(apuestas);
        CrearNumeros(0);
        RULETA_APP2.levantar();
    }
    function CrearNumeros(num) {
        num = num;
        $('#numeros').append("<select id='sel-menu'>");
        for (var i = 0; i < 37; i++) {
            $('#sel-menu').append("<option id='numero' value" + i + ">" + i + "</option>");
        }
        $('#numeros').append("</select>");
        if (num !== 0) {
            for (var k = 1; k < num; k++) {
                $('#numeros').append("<select id='sel-menu" + k + "'>");
            
            for (var j = 0; j < 37; j++) {
                $("#sel-menu"+k+"").append("<option id='numero"+k+"' value" + j + ">" + j + "</option>");
            }
            }
            $('#numeros').append("</select>");
        }
    }
    function switchapuestas() {
        modalidad = $('#modalidad').val();
        switch (modalidad) {
            case "Pleno":
                CrearNumeros(0);
                break;
            case "Semi":
                CrearNumeros(2);                
                break;
            case "Calle":
                CrearNumeros(2);
                break;
            case "Cuadro":
                CrearNumeros(4);
                break;
            case "Cubre":
                $('#numeros').append("<span id='numero'>0, 1, 2, 3<span>");
                break;
            case "Linea":
                CrearNumeros(6);
                break;
            case "Columna":
                $('#numeros').append("<select id='sel-menu'><option id='numero' value='46'>1° Columna</option><option id='numero' value='47'>2° Columna</option><option id='numero' value='48'>3° Columna</option></select>");
                break;
            case "Docena":
                $('#numeros').append("<select id='sel-menu'><option id='numero' value='41'>1° Docena</option><option id='numero' value='42'>2° Docena</option><option id='numero' value='43'>3° Docena</option></select>");
                break;
            case "Color":
                $('#numeros').append("<select id='sel-menu'><option id='numero' value='39'>Rojo</option><option id='numero' value='40'>Negro</option></select>");
                break;
            case "Paridad":
                $('#numeros').append("<select id='sel-menu'><option id='numero' value='37'>Par</option><option id='numero' value='38'>Impar</option></select>");
                break;
            case "1-18/19-36":
                $('#numeros').append("<select id='sel-menu'><option id='numero' value='44'>1-18</option><option id='numero' value='45'>19-36</option></select>");
                break;
            default:
        }
    }

    function apostar() {
        modalidad = $('#modalidad').val();
        switch (modalidad) {
            case "Pleno" : 
                 apuesta = {
                        "modalidad" : $('#modalidad').val(),
                        numeros: [$('#sel-menu option:selected').val()],
                        "fichas": $('#fichas').val()            
                 }
                 $('#apuestas-realizadas').append("<tr class='add'><td>" + apuesta.modalidad + "</td><td>" + apuesta.numeros[0] + "</td><td>" + apuesta.fichas + "</td></tr>");
                break;
            case "Semi" : 
                apuesta = {
                    "modalidad" : $('#modalidad').val(),
                    numeros: [$('#sel-menu option:selected').val(), $('#sel-menu1 option:selected').val()],
                    "fichas": $('#fichas').val()            
                }
                $('#apuestas-realizadas').append("<tr class='add'><td>" + apuesta.modalidad + "</td><td>" + apuesta.numeros[0] + " - " + apuesta.numeros[1] + "</td><td>" + apuesta.fichas + "</td></tr>");
                break;
            case "Calle":
                apuesta = {
                    "modalidad": "Calle",
                    numeros: [$('#sel-menu option:selected').val(), $('#sel-menu1 option:selected').val()],
                    "fichas": $('#fichas').val()
                }
                $('#apuestas-realizadas').append("<tr class='add'><td>" + apuesta.modalidad + "</td><td>" + apuesta.numeros[0] + " - " + apuesta.numeros[1] + "</td><td>" + apuesta.fichas + "</td></tr>");
                break;
            case "Cubre":
                apuesta = {
                    "modalidad": "Cubre",
                    numeros: [0, 1, 2, 3],
                    "fichas": $('#fichas').val()
                }
                $('#apuestas-realizadas').append("<tr class='add'><td>" + apuesta.modalidad + "</td><td>" + apuesta.numeros[0] + " - " + apuesta.numeros[1] + " - " + apuesta.numeros[2] + " - " + apuesta.numeros[3] + "</td><td>" + apuesta.fichas + "</td></tr>");
                break;
            case "Cuadro":
                apuesta = {
                    "modalidad": "Cuadro",
                    numeros: [$('#sel-menu option:selected').val(), $('#sel-menu1 option:selected').val(), $('#sel-menu2 option:selected').val(), $('#sel-menu3 option:selected').val()],
                    "fichas": $('#fichas').val()
                }
                $('#apuestas-realizadas').append("<tr class='add'><td>" + apuesta.modalidad + "</td><td>" + apuesta.numeros[0] + " - " + apuesta.numeros[1] + " - " + apuesta.numeros[2] + " - " + apuesta.numeros[3] + "</td><td>" + apuesta.fichas + "</td></tr>");
                break;
            case "Linea":
                apuesta = {
                    "modalidad": "Linea",
                    numeros: [$('#sel-menu option:selected').val(), $('#sel-menu1 option:selected').val(), $('#sel-menu2 option:selected').val(), $('#sel-menu3 option:selected').val(),$('#sel-menu4 option:selected').val(), $('#sel-menu5 option:selected').val()],
                    "fichas": $('#fichas').val()
                }
                $('#apuestas-realizadas').append("<tr class='add'><td>" + apuesta.modalidad + "</td><td>" + apuesta.numeros[0] + " - " + apuesta.numeros[1] + " - " + apuesta.numeros[2] + " - " + apuesta.numeros[3] + " - " + apuesta.numeros[4] + " - " + apuesta.numeros[5] + "</td><td>" + apuesta.fichas + "</td></tr>");
                break;
            case "Columna":
                apuesta = {
                    "modalidad": $('#modalidad').val(),
                    numeros: [$('#sel-menu option:selected').val()],
                    "fichas": $('#fichas').val()
                }
                switch ($('#sel-menu option:selected').val()) {
                    case '46':
                        $('#apuestas-realizadas').append("<tr class='add'><td>" + apuesta.modalidad + "</td><td>" + "1° Columna" + "</td><td>" + apuesta.fichas + "</td></tr>");
                        break;
                    case '47':
                        $('#apuestas-realizadas').append("<tr class='add'><td>" + apuesta.modalidad + "</td><td>" + "2° Columna" + "</td><td>" + apuesta.fichas + "</td></tr>");
                        break;
                    default:
                        $('#apuestas-realizadas').append("<tr class='add'><td>" + apuesta.modalidad + "</td><td>" + "3° Columna" + "</td><td>" + apuesta.fichas + "</td></tr>");
                }
                break;
            case "Docena":
                apuesta = {
                    "modalidad": $('#modalidad').val(),
                    numeros: [$('#sel-menu option:selected').val()],
                    "fichas": $('#fichas').val()
                }
                switch ($('#sel-menu option:selected').val()) {
                    case '41':
                        $('#apuestas-realizadas').append("<tr class='add'><td>" + apuesta.modalidad + "</td><td>" + "1° Docena" + "</td><td>" + apuesta.fichas + "</td></tr>");
                        break;
                    case '42':
                        $('#apuestas-realizadas').append("<tr class='add'><td>" + apuesta.modalidad + "</td><td>" + "2° Docena" + "</td><td>" + apuesta.fichas + "</td></tr>");
                        break;
                    default:
                        $('#apuestas-realizadas').append("<tr class='add'><td>" + apuesta.modalidad + "</td><td>" + "3° Docena" + "</td><td>" + apuesta.fichas + "</td></tr>");
                }
                break;
            case "Color":
                apuesta = {
                    "modalidad": "Chances Simples",
                    numeros: [$('#sel-menu option:selected').val()],
                    "fichas": $('#fichas').val()
                }
                switch ($('#sel-menu option:selected').val()) {
                    case '39':
                        $('#apuestas-realizadas').append("<tr class='add'><td>" + $('#modalidad').val() + "</td><td>" + "Rojo" + "</td><td>" + apuesta.fichas + "</td></tr>");
                        break;
                    default:
                        $('#apuestas-realizadas').append("<tr class='add'><td>" + $('#modalidad').val() + "</td><td>" + "Negro" + "</td><td>" + apuesta.fichas + "</td></tr>");
                }
                break;
            case "Paridad":
                apuesta = {
                    "modalidad": "Chances Simples",
                    numeros: [$('#sel-menu option:selected').val()],
                    "fichas": $('#fichas').val()
                }
                switch ($('#sel-menu option:selected').val()) {
                    case '37':
                        $('#apuestas-realizadas').append("<tr class='add'><td>" + $('#modalidad').val() + "</td><td>" + "Par" + "</td><td>" + apuesta.fichas + "</td></tr>");
                        break;
                    default:
                        $('#apuestas-realizadas').append("<tr class='add'><td>" + $('#modalidad').val() + "</td><td>" + "Impar" + "</td><td>" + apuesta.fichas + "</td></tr>");
                }
                break;
            case "1-18/19-36":
                apuesta = {
                    "modalidad": "Chances Simples",
                    numeros: [$('#sel-menu option:selected').val()],
                    "fichas": $('#fichas').val()
                }
                switch ($('#sel-menu option:selected').val()) {
                    case '44':
                        $('#apuestas-realizadas').append("<tr class='add'><td>" + $('#modalidad').val() + "</td><td>" + "1-18" + "</td><td>" + apuesta.fichas + "</td></tr>");
                        break;
                    default:
                        $('#apuestas-realizadas').append("<tr class='add'><td>" + $('#modalidad').val() + "</td><td>" + "19-36" + "</td><td>" + apuesta.fichas + "</td></tr>");
                }
                break;
            default:
        }

        $('#m-fichas').text(parseInt($('#m-fichas').text()) - apuesta.fichas);
        apuestas.push(apuesta);
    }

    function refrescar(datos) {
        $('#m-fichas').text(datos.Data.fichas);
        $('.m-victorias').text(datos.Data.victorias);
        $('.m-partidas').text(datos.Data.jugadas);
    };

    function refrescarFichas(datos) {
        $('#m-fichas').text(datos.Data.fichas);
        $('#money').text(datos.Data.dinero);
    };

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
            success: function (data) {
                var jsonData = JSON.stringify(data);
                var jsonParse = JSON.parse(jsonData);

                if (jsonParse.Data.gano == false) {
                    
                    $('#perdiste #premio').append("<h3 class='added'>Salio el numero " + jsonParse.Data.salio + "</h3>");
                    $('#perdiste').show(1000);
                } else {

                    $('#ganaste #premio').append("<h3 class='added'>Salio el numero " + jsonParse.Data.salio + "</h3>");
                    $('#ganaste').show(1000);
                }
                refrescar(jsonParse);
            },
            error: function (error) {
                alert("Se perdio la conexion!!!");
            }
        });
    }
        function Comprar() {
            var datos = {
                fichas: $('#fichas-comprar').val(),
            };
            $.ajax({
                type: "POST",
                url: "/Home/Comprar",
                dataType: "json",
                data: JSON.stringify(datos),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonData = JSON.stringify(data);
                    var jsonParse = JSON.parse(jsonData);
                    refrescarFichas(jsonParse);
                },
                error: function (error) {
                    alert("Se perdio la conexion!!!");
                }
            });
        }
    
    window.RULETA_APP = {};
    window.RULETA_APP.enviarApuestas = EnviarApuestas;
});