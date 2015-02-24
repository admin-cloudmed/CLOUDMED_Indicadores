jQuery(document).ready(function () {
    atualizaValores();
    setInterval("atualizaValores()", 5000);

    enterFirstView();  
})


function atualizaValores() {
    //totalAutorizacoes();
    totalDocumentos();
    totalOrcamentos();
    totalProtocolos();
    totalValidacoes();
}
function totalDocumentos() {
    $.ajax({
        url: "/Documentos/AutoCompleteTotalDocumentos",
        data: { idempresa: 0 },
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            odometerDocumentos.innerHTML = data;
            //var qtd = Session.get('odometerDocumentos');
            //if (qtd == undefined) {
            //    Session.set('odometerDocumentos', "0");
            //    qtd = 0;
            //}
            //if (qtd != data) {
            //    playAudio();
            //    Session.set('odometerDocumentos', data );
        }
    })
};
function totalOrcamentos() {
    $.ajax({
        url: "/Orcamentos/AutoCompleteTotalOrcamentos",
        data: { idempresa: 0 },
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            //var qtd = Session.get('odometerOrcamentos');
            //if (qtd == undefined) {
            //    Session.set('odometerOrcamentos', "0");
            //    qtd = 0;
            //}
            //if (qtd != data) {
            //    playAudio();
            //    Session.set('odometerOrcamentos', data);
            //}
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
            //var qtd = Session.get('odometerProtocolos');
            //if (qtd == undefined) {
            //    Session.set('odometerProtocolos', "0");
            //    qtd = 0;
            //}
            //if (qtd != data) {
            //    playAudio();
            //    Session.set('odometerProtocolos', data);
            //}
            odometerProtocolos.innerHTML = data;
        }
    });
}
function totalAutorizacoes() {
    $.ajax({
        url: "/Autorizacoes/AutoCompleteTotalAutorizacoes",
        data: { idempresa: 0 },
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            odometerAutorizacoes.innerHTML = data;
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
            //var qtd = Session.get('odometerValidacoes');
            //if (qtd == undefined) {
            //    Session.set('odometerValidacoes', "0");
            //    qtd = 0;
            //}
            //if (qtd != data) {
            //    playAudio();
            //    Session.set('odometerValidacoes', data);
            //}
            odometerValidacoes.innerHTML = data;
        }
    });
}



function enterFirstView() {
    $('#body').animate({ 'background-color': '#4C8EFA' }, 1000);
    outSecondView();
    outThirdView();
    $('#firstView').removeClass('animated bounceInLeft');
    $('#firstView').removeClass('animated bounceOutRight');
    $('#firstView').addClass('animated bounceInLeft');
    setTimeout(function () { enterSecondView(); }, 5000);
}

function outFirstView() {
    $('#firstView').addClass('animated bounceOutRight');
}

function enterSecondView() {
    $('#body').animate({ 'background-color': 'purple' }, 1000);
    outFirstView();
    outThirdView();
    $('#secondView').removeClass('animated bounceInLeft');
    $('#secondView').removeClass('animated bounceOutRight');
    $('#secondView').addClass('animated bounceInDown');
    setTimeout(function () { enterThirdView(); }, 5000);
}

function outSecondView() {
    $('#secondView').addClass('animated bounceOutRight');
}

function enterThirdView() {
    $('#body').animate({ 'background-color': 'green' }, 1000);
    outFirstView();
    outSecondView();
    $('#thirdView').removeClass('animated bounceInLeft');
    $('#thirdView').removeClass('animated bounceOutRight');
    $('#thirdView').addClass('animated bounceInLeft');
    setTimeout(function () { enterFirstView(); }, 5000);
}

function outThirdView() {
    $('#thirdView').addClass('animated bounceOutRight');
}





//function playAudio() {
//    var audio = new Audio('http://www.oringz.com/oringz-uploads/sounds-908-sting.mp3');
//    audio.play();
//}