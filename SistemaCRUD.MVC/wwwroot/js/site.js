function DialogDelete(id) {
    bootbox.confirm({
        message: 'Confirma a exclusão do Fonecedor?',
        callback: function (confirmacao) {

            if (confirmacao) {
                Delete(id);
                bootbox.alert('Registro excluído com sucesso.');
                window.reload();
            }

            else
                bootbox.alert('Operação cancelada.');

        },
        buttons: {
            cancel: { label: 'Cancelar', className: 'btn-default' },
            confirm: { label: 'EXCLUIR', className: 'btn-danger' }

        }
    });
}

function Delete(id) {
    console.log(id)
    $.ajax({
        url: "Empresa/Delete",
        method: 'Post',
        dataType: 'json',
        data:"id="+ id,
        error: function () {
            console.log('Erro na requisição.');
        }
    });
}