let datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $("#tblDatos").DataTable({
        "ajax": {
            "url": "/Admin/AreaP/ObtenerTodos"
        },
        "columns": [
            { "data": "descripcion" },
            { "data": "turno" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/AreaP/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="bi bi-pencil-square"></i>
                            </a>
                            <a onclick=Delete("/Admin/AreaP/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                <i class="bi bi-trash3-fill"></i>
                            </a>
                        </div>
                    `;
                }, width: "20%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay datos disponibles para mostrar en la tabla",
            "info": "Mostrando _END_ entradas de _TOTAL_ totales",
            "infoEmpty": "Mostrando 0 registros de 0 entradas",
            "infoFiltered": "(Filtrado de MAX entradas totales)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando. Espere un momento",
            "processing": "",
            "search": "Buscar:",
            "zeroRecords": "No se encontraron registros que cumplan el campo",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            },
            "aria": {
                "orderable": "Ordenar por esta columna",
                "orderableReverse": "Ordena inversa por esta columna"
            }
        }
    });
}

function Delete(url) {
    swal({
        title: "¿Estas seguro que deseas eliminar el AREA?",
        text: "¡Este registro no se podrá recuperar!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "POST",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        //actualizar la tabla
                        datatable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}