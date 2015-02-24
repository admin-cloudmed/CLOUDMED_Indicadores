jQuery(document).ready(function () {
    totalProtocolos();
    setInterval("totalProtocolos()", 5000);
    $(":radio").click(function () {
        $("#IdEmpresa").val(this.value)
    })
})

function totalProtocolos() {
    $.ajax({
        url: "/Protocolos/AutoCompleteTotalProtocolos",
        data: { idempresa: $("#IdEmpresa").val()},
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            odometer.innerHTML = data;
        }
    });
}


