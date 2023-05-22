function GetCidades(id) {
    var url = "https://localhost:7042/api/cidade?id=" + id;
    console.log(id)

    $.ajax({
        url: url,
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            AddCidade(data)
        },
        error: function () {
            console.log('Erro na requisição.');
        }
    });

}
function AddCidade(cidades) {
    divCidade = document.getElementById("CidadeForm");
    divCidade.style.display = "";
    selectCidade = document.getElementById("SelectCidade");
    VereficaSelect(selectCidade);
    for (i = 0; i < cidades.length; i++) {
        var cidade = cidades[i];
        var novaOpcao = document.createElement("option");
        novaOpcao.value = cidade.idCidade;
        novaOpcao.textContent = cidade.nome;
        selectCidade.appendChild(novaOpcao);
    }
}
function VereficaSelect(select) {

    while (select.length > 0) {
        var i = 1;
        select.remove(0);
        console.log("quantidade que rodo aqui", i)
        i++;
    }
}