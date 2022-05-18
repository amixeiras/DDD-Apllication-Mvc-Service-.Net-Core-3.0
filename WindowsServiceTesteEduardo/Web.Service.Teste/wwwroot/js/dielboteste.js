var table = undefined;
$(function () {
    table = $('#mesa_trabalho').DataTable({
        bLengthChange: false,
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
        "scrollX": true,
        "language": {
            "search": "Busca:",
            "info": "Exibindo _START_ / _END_ de _TOTAL_ linhas",
            "infoEmpty": "Sem registros",
            "zeroRecords": "Registros não encontrados",
            "infoFiltered": "(Filtrados de _MAX_ registros)",
            "paginate": {
                "next": "Proximo",
                "previous": "Anterior"
            },
            "order": [],
            columnDefs: [
            ],
            columns: [
                { data: 'Serviço' },
                { data: 'Nome da Máquina' },
                { data: 'Data Última Execução' }
            ]
        }
    });

    table.columns.adjust().draw();
});