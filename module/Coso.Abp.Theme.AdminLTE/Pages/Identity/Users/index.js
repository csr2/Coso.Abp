(function ($) {


    var l = abp.localization.getResource('AbpIdentity');
    var _identityUserAppService = volo.abp.identity.identityUser;
    var _editModal = new abp.ModalManager(abp.appPath + 'Identity/Users/EditModal');
    var _createModal = new abp.ModalManager(abp.appPath + 'Identity/Users/CreateModal');
    var _permissionsModal = new abp.ModalManager(abp.appPath + 'AbpPermissionManagement/PermissionManagementModal');

    $(function () {
        var _dataTable = $('#IdentityUsersTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            order: [[1, "asc"]],
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
        //responsive: true,
            ajax: abp.libs.datatables.createAjax(_identityUserAppService.getList, function () {
                var filter = $("#filter").val();
                var model = {
                    filter: filter
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
                                    visible: abp.auth.isGranted('AbpIdentity.Users.Update'),
                                    action: function (data) {
                                        _editModal.open({
                                            id: data.record.id
                                        });
                                    }
                                },
                                {
                                    text: l('Permissions'),
                                    visible: abp.auth.isGranted('AbpIdentity.Users.ManagePermissions'),
                                    action: function (data) {
                                        _permissionsModal.open({
                                            providerName: 'U',
                                            providerKey: data.record.id
                                        });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('AbpIdentity.Users.Delete'),
                                    confirmMessage: function (data) { return l('UserDeletionConfirmationMessage', data.record.userName); },
                                    action: function (data) {
                                        _identityUserAppService
                                            .delete(data.record.id)
                                            .then(function () {
                                                _dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    data: "userName"
                },
                {
                    data: "email"
                },
                {
                    data: "phoneNumber"
                },
                {
                    data: "name"
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
