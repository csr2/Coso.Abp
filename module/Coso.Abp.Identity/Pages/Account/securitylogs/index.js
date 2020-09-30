$(function () {

    var l = abp.localization.getResource('ProjectReport');

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
        ajax: abp.libs.datatables.createAjax(_identitySecurityLog.getUserList, function () {
            var StartTime = $("#StartTime").val();
            var EndTime = $("#EndTime").val();
            var Action = $("#Action").val();
            var model = {
                startTime: StartTime,
                endTime: EndTime,
                actions: Action
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


