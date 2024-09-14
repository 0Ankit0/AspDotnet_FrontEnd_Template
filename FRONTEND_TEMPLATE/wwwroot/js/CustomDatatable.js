//basic initialization of datatable
$("#dt-basic").DataTable({
    searching: true
});

//datatables with buttons
    $('#dt-buttons').DataTable({
        dom: '<"row p-2"<"col-md-6"B><"col-md-6"f>>rtip',
        buttons: [
            {
                text: 'Custom Button',
                action: function (e, dt, node, config) {
                    alert('Custom Button Clicked');
                }
            },
            'print','excel','csv','pdf'
        ]
    });

$("#dt-ColumnSearch").DataTable({
    bLengthChange: true,
    paging: true,
    ordering: true,
    info: true,
    searching: true,
    stateSave: true,
    initComplete: function () {
        this.api()
            .columns() // Index 2 corresponds to the third column (0-based index)
            .every(function (index) {
                if (index === 0) return;
                let column = this;
                let header = column.header();
                let title = header.textContent;

                // Create input element
                let input = document.createElement('input');
                input.placeholder = title;

                // Replace the content of the header with the input element
                header.replaceChildren(input);

                // Event listener for user input
                input.addEventListener('keyup', () => {
                    if (column.search() !== input.value) {
                        column.search(input.value).draw();
                    }
                });

            });
    },
    order: [
        [1, 'asc']
    ],
    buttons: [
        {
            text: 'Custom link button',
            className: 'me-2 btn btn-warning',
            action: function (e, dt, node, config) {
                window.location.href = "/home";
                window.location.assign("/home");

            }
        },
        {
            extend: 'excel',
            className: 'me-2 text-white',
            text: '<i class="icofont icofont-file-excel f-18"></i> Excel',
            exportOptions: {
                columns: ':not(.excludeExport)',
                format: {
                    header: function (data, columnIdx) {
                        // Get the title from the placeholder of the input
                        let input = document.querySelector(`thead th:eq(${columnIdx}) input`);
                        return input ? input.placeholder : data;
                    },
                    body: function (data, columnIdx, rowIdx, node) {
                        let searchInputs = getSearchInputValues();
                        // Optionally modify the data based on search inputs
                        return data;
                    }
                }
            },
        },
        {
            extend: 'csv',
            className: 'me-2 text-white',
            text: '<i class="icofont icofont-file-text f-18"></i> CSV',
            exportOptions: {
                columns: ':not(.excludeExport)',
                title: null,
                format: {
                    header: function (data, columnIdx) {
                        // Get the title from the placeholder of the input
                        let input = document.querySelector(`thead th:eq(${columnIdx}) input`);
                        return input ? input.placeholder : data;
                    },
                    body: function (data, columnIdx, rowIdx, node) {
                        let searchInputs = getSearchInputValues();
                        // Optionally modify the data based on search inputs
                        return data;
                    }
                }
            },
        },
    ]
});
function getSearchInputValues() {
    let searchInputs = {};
    document.querySelectorAll('.dataTableSearchInput').forEach(input => {
        let columnIndex = input.getAttribute('data-column-index');
        searchInputs[columnIndex] = input.value;
    });
    return searchInputs;
}

//datatable with server side processing
function ServerSideDataTable(table, url, type = 'Post', datasrc, columns, Action = false) {
    if (Action) {

    //Get controllername from the url
    var controllerName = url.split('/')[0];
    //Add edit and delete action to the column
    columns.push({
        data: null,
        render: function (data, type, row) {
            return `<div>
                <a class="btnTrash" data-guid="${row.guid}"><i class="icofont icofont-ui-delete f-20 text-danger"></i></a>
                <a class="btnEdit" href="@Url.Action(" Create","${controllerName}")?id=${row.guid}"><i class="icofont icofont-edit f-20 text-info"></i></a>
                            </div>`
        }
    });
    }
    $(table).DataTable({
        processing: true,
        serverSide: true,
        ajax: {
            url: url,
            type: type, // Specify the request type if not GET
            //contentType: "application/json; charset=utf-8",
            dataSrc: datasrc // Specify the property of the data source that you want to bind to the table
        },
        columns: columns
    });
}
