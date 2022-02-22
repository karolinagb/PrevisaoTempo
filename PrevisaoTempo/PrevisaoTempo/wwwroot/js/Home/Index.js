$(document).ready(function () {

    $(".select2").select2();

    $("#cidadeSelecionada").change(function () {
        $('#buscarCidadePorNome').submit();
    });

});
