jQuery(document).ready(function () {
    totalAutorizacoes();
    setInterval("totalAutorizacoes()", 5000);
    $(":radio").click(function () {
        $("#IdEmpresa").val(this.value)
    })
})

function totalAutorizacoes() {
    $.ajax({
        url: "/Autorizacoes/AutoCompleteTotalAutorizacoes",
        data: { idempresa: $("#IdEmpresa").val() },
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            odometer.innerHTML = data;
        }
    });
}

