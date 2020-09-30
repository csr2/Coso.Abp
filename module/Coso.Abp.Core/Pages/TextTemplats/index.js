(function ($) {


    var l = abp.localization.getResource('CosoAbpCore');
    var _textTemplatsAppService = coso.abp.core.textTemplats.templateDefinition;
    var _editModal = new abp.ModalManager(abp.appPath + 'TextTemplats/TemplatContents');

    $(function () {
        var _dataTable = $('#TextTemplatsTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            order: [[1, "asc"]],
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
            //iDisplayLength: 10,
        //responsive: true,
            ajax: abp.libs.datatables.createAjax(_textTemplatsAppService.getList, function () {
                var filter = $("#filter").val();
                var model = {
                    filterText: filter
                };
                return model;
            }),
            columnDefs: [
                {
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('CosoAbpCore.TestTemplats.Update'),
                                    action: function (data) {
                                        location.href = abp.appPath + 'TextTemplats/TemplatContents?name=' + data.record.name;
                                    }
                                }
                            ]
                    }
                },
                {
                    data: "name"
                },
                {
                    data: "isInlineLocalized",
                    render: function (data, type, row, meta) {
                        return row.isInlineLocalized ?
                            "<div class=\"text-center text-success\"><i class=\"fa fa-check\"></i></div>"
                            : "<div class=\"text-center text-danger\"><i class=\"fa fa-times\"></i></div>";
                    }
                },
                {
                    data: "isLayout",
                    render: function (data, type, row, meta) {
                        return row.isLayout ?
                            "<div class=\"text-center text-success\"><i class=\"fa fa-check\"></i></div>"
                            : "<div class=\"text-center text-danger\"><i class=\"fa fa-times\"></i></div>";
                    }
                },
                {
                    data: "layout"
                },
                {
                    data: "defaultCultureName"
                },
            ]
        }));
        $('#search').click(function (e) {
            e.preventDefault();
            _dataTable.ajax.reload();
        });

        $('#filter').change(function () {
            _dataTable.ajax.reload();
        });

        _createModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _editModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        $('#CreateUser').click(function (e) {
            e.preventDefault();
            _createModal.open();
        });
    });
})(jQuery);
