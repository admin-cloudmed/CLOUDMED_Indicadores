jQuery(document).ready(function () {
    totalValidacoes();
    setInterval("totalValidacoes()", 5000);
    $(":radio").click(function () {
        $("#IdEmpresa").val(this.value)
    })
})

function totalValidacoes() {
    $.ajax({
        url: "/Validacoes/AutoCompleteTotalValidacoes",
        data: { idempresa: $("#IdEmpresa").val() },
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            odometer.innerHTML = data;
        }
    });
}


