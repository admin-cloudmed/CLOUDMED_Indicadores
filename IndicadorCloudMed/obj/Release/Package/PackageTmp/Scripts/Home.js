jQuery(document).ready(function () {
    //totalAutorizacoes();
    totalDocumentos();
    totalOrcamentos();
    totalProtocolos();
    totalValidacoes();

    //setInterval("totalAutorizacoes()", 5000);
    setInterval("totalDocumentos()", 5000);
    setInterval("totalOrcamentos()", 5000);
    setInterval("totalProtocolos()", 5000);
    setInterval("totalValidacoes()", 5000);
})

function playAudio() {
    var audio = new Audio('http://www.oringz.com/oringz-uploads/sounds-908-sting.mp3');
    audio.play();
}

//function totalAutorizacoes() {
//    $.ajax({
//        url: "/Autorizacoes/AutoCompleteTotalAutorizacoes",
//        data: { idempresa: 0 },
//        dataType: 'json',
//        type: 'GET',
//        success: function (data) {
//            odometerAutorizacoes.innerHTML = data;
//        }
//    });
//}

function totalDocumentos() {
    $.ajax({
        url: "/Documentos/AutoCompleteTotalDocumentos",
        data: { idempresa: 0 },
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            var qtd = Session.get('odometerDocumentos');
            if (qtd == undefined) {
                Session.set('odometerDocumentos', "0");
                qtd = 0;
            }
            if (qtd != data) {
                playAudio();
                Session.set('odometerDocumentos', data );
            }
            odometerDocumentos.innerHTML = data;
        }
    });
}

function totalOrcamentos() {
    $.ajax({
        url: "/Orcamentos/AutoCompleteTotalOrcamentos",
        data: { idempresa: 0 },
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            var qtd = Session.get('odometerOrcamentos');
            if (qtd == undefined) {
                Session.set('odometerOrcamentos', "0");
                qtd = 0;
            }
            if (qtd != data) {
                playAudio();
                Session.set('odometerOrcamentos', data);
            }
            odometerOrcamentos.innerHTML = data;
        }
    });
}

function totalProtocolos() {
    $.ajax({
        url: "/Protocolos/AutoCompleteTotalProtocolos",
        data: { idempresa: 0 },
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            var qtd = Session.get('odometerProtocolos');
            if (qtd == undefined) {
                Session.set('odometerProtocolos', "0");
                qtd = 0;
            }
            if (qtd != data) {
                playAudio();
                Session.set('odometerProtocolos', data);
            }
            odometerProtocolos.innerHTML = data;
        }
    });
}

function totalValidacoes() {
    $.ajax({
        url: "/Validacoes/AutoCompleteTotalValidacoes",
        data: { idempresa: 0 },
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            var qtd = Session.get('odometerValidacoes');
            if (qtd == undefined) {
                Session.set('odometerValidacoes', "0");
                qtd = 0;
            }
            if (qtd != data) {
                playAudio();
                Session.set('odometerValidacoes', data);
            }
            odometerValidacoes.innerHTML = data;
        }
    });
}