
(function () {
    $(function () {

        var l = abp.localization.getResource('CosoAbpCore');



        var detailModal = new abp.ModalManager(abp.appPath + 'Auditing/Detail');

        var dataTable = $('#Auditing').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
            //responsive: true,
            order: [[4, "desc"]],
            ajax: abp.libs.datatables.createAjax(coso.abp.core.auditing.auditLog.getList, function () {
                var UserName = $("#UserName").val();
                var Url = $("#Url").val();
                var MinExecutionDuration = $("#MinExecutionDuration").val();
                var MaxExecutionDuration = $("#MaxExecutionDuration").val();
                var ApplicationName = $("#ApplicationName").val();
                var CorrelationId = $("#CorrelationId").val();
                var HttpStatusCode = $("#HttpStatusCode").val();
                var HttpMethod = $("#HttpMethod").val();
                var HasException = $("#HasException").val();
                var model = {
                    httpMethod: HttpMethod,
                    userName: UserName,
                    httpStatusCode: HttpStatusCode,
                    startTime: null,
                    endTime: null,
                    url: Url,
                    applicationName: ApplicationName,
                    correlationId: CorrelationId,
                    maxExecutionDuration: MaxExecutionDuration,
                    minExecutionDuration: MinExecutionDuration,
                    hasException: HasException,
                    includeDetails: false
                };
                return model;
            }),
            columnDefs: [
                {
                    rowAction: {
                        items:
                            [
                                {
                                    text: "<i class=\"mr-1 fa fa-search\"></i>" + l('Detail'),
                                    action: function (data) {
                                        detailModal.open({ id: data.record.id });
                                    }
                                }
                            ]
                    },
                    width: "3%"
                },
                {
                    data: "httpStatusCode",
                    render: function (data, type, row, meta) {
                        // console.log(row);
                        var httpStatusCode = row.httpStatusCode != null ? "<span class=\"badge badge-danger\">" + row.httpStatusCode + "</span>" : "";
                        var badge = "badge-danger";
                        if (row.httpMethod == "GET") {
                            badge = "badge-dark";
                        }
                        if (row.httpMethod == "DELETE") {
                            badge = "badge-danger";
                        }
                        if (row.httpMethod == "POST") {
                            badge = "badge-success";
                        }
                        var httpMethod = "<span class=\"badge " + badge + "\">" + row.httpMethod + "</span>";
                        return httpStatusCode + "&nbsp;&nbsp;" + httpMethod + "&nbsp;&nbsp;" + row.url;

                        //return row.isPublished ?
                        //    "<span class=\"badge badge-danger\"><i class=\"fa fa-circle\"> " + l('StatusTrue') + "</i> </span>"
                        //    : "<span class=\"badge badge-success\"><i class=\"fa fa-circle\"> " + l('StatusFale') + "</i> </span>";
                    }
                },
                { data: "userName", "width": "15%" },
                { data: "clientIpAddress", "width": "12%" },
                { data: "executionTime", "width": "18%" }
            ]
        }));

        $('#search').click(function (e) {
            e.preventDefault();
            dataTable.ajax.reload();
        });

        detailModal.onResult(function () {
            dataTable.ajax.reload();
        });



    });
})();



