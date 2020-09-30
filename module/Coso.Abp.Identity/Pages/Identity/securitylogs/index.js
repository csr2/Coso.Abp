$(function () {

    var l = abp.localization.getResource('CosoAbpIdentity');

    var _identitySecurityLog = coso.abp.identity.application.identitySecurityLog;

    var dataTable = $('#SecurityLogs').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        //responsive: true,
        order: [[0, "desc"]],
        ajax: abp.libs.datatables.createAjax(_identitySecurityLog.getList, function () {
            var StartTime = $("#StartTime").val();
            var EndTime = $("#EndTime").val();
            var ApplicationName = $("#ApplicationName").val();
            var Identity = $("#Identity").val();
            var Action = $("#Action").val();
            var UserName = $("#UserName").val();
            var ClientId = $("#ClientId").val();
            var CorrelationId = $("#CorrelationId").val();
            var model = {
                startTime: StartTime,
                endTime: EndTime,
                applicationName: ApplicationName,
                identity: Identity,
                actions: Action,
                userName: UserName,
                clientId: ClientId,
                correlationId: CorrelationId
            };
            return model;
        }),
        columnDefs: [
            { data: "creationTime", width: "10%" },
            { data: "action", width: "10%" },
            { data: "clientIpAddress", width: "10%" },
            { data: "browserInfo",width:"20%" },
            { data: "applicationName", width: "10%"},
            { data: "identity", width: "10%"},
            { data: "userName", width: "10%" },
            { data: "clientId", width: "10%"},
            { data: "correlationId", width: "10%"}
        ]
    }));


    $('#search').click(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });


});


