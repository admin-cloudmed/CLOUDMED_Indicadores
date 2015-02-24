jQuery(document).ready(function () {
    totalOrcamentos();
    setInterval("totalOrcamentos()", 5000);
    $(":radio").click(function () {
        $("#IdEmpresa").val(this.value)
    })
})

function totalOrcamentos() {
    $.ajax({
        url: "/Orcamentos/AutoCompleteTotalOrcamentos",
        data: { idempresa: $("#IdEmpresa").val() },
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            odometer.innerHTML = data;
        }
    });
}




