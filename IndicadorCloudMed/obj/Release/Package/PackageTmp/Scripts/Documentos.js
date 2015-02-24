jQuery(document).ready(function () {
    setInterval("totalDocumentos()", 5000);
    $(":radio").click(function () {
        $("#IdEmpresa").val(this.value)
    })
})

function totalDocumentos() {
    $.ajax({
        url: "/Documentos/AutoCompleteTotalDocumentos",
        data: { idempresa: $("#IdEmpresa").val() },
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            odometer.innerHTML = data;
        }
    });
}
