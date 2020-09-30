(function () {
    $(function () {

        var l = abp.localization.getResource('CosoAbpIdentity');

        var _organizationUnitService = coso.abp.identity.application.organizationUnit;

        var _createModal = new abp.ModalManager(abp.appPath + 'Identity/organizationunits/CreateModal');
        var _editModal = new abp.ModalManager(abp.appPath + 'Identity/organizationunits/EditModal');
        var _addUserModal = new abp.ModalManager(abp.appPath + 'Identity/organizationunits/AddUserModal');
        var _addRoleModal = new abp.ModalManager(abp.appPath + 'Identity/organizationunits/AddRoleModal');
        var organizationTree = {

            $tree: $('#OrganizationUnitEditTree'),
            $emptyInfo: $('#OrganizationUnitTreeEmptyInfo'),
            show: function () {
                organizationTree.$tree.show();
            },
            hide: function () {
                organizationTree.$tree.hide();
            },
            unitCount: 0,
            setUnitCount: function (unitCount) {
                organizationTree.unitCount = unitCount;
                if (unitCount) {
                    organizationTree.show();
                } else {
                    organizationTree.hide();
                }
            },
            refreshUnitCount: function () {
                organizationTree.setUnitCount(organizationTree.$tree.jstree('get_json').length);
            },
            selectedOu: {
                id: null,
                displayName: null,
                code: null,
                set: function (ouInTree) {
                    if (!ouInTree) {
                        organizationTree.selectedOu.id = null;
                        organizationTree.selectedOu.displayName = null;
                        organizationTree.selectedOu.code = null;
                    } else {
                        organizationTree.selectedOu.id = ouInTree.id;
                        organizationTree.selectedOu.displayName = ouInTree.original.displayName;
                        organizationTree.selectedOu.code = ouInTree.original.code;
                    }
                    members.init();
                    members.load();
                    roles.init();
                    roles.load();
                }
            },
            contextMenu: function (node) {

                var items = {
                    editUnit: {
                        label: l('Edit'),
                        action: function (data) {
                            _editModal.open({
                                Id: node.original.id
                            });
                            _editModal.onResult(function (obj, evnt) {
                                var instance = $.jstree.reference(data.reference);
                                var updatedOu = evnt.responseText;
                                node.original.displayName = updatedOu.displayName;
                                instance.rename_node(node, organizationTree.generateTextOnTree(updatedOu));
                               // organizationTree.$tree.jstree('refresh');
                            });
                            _editModal.onResult = function (obj, evnt) { };
                        }
                    },

                    addSubUnit: {
                        label: l('AddSubUnit'),
                        action: function () {
                            organizationTree.addUnit(node.id);
                        }
                    },
                    'delete': {
                        label: l("Delete"),
                        action: function (data) {
                            var instance = $.jstree.reference(data.reference);
                            abp.message.confirm(
                                l('Remove:' + organizationTree.selectedOu.displayName),
                                function (isConfirmed) {
                                    if (isConfirmed) {
                                        coso.abp.identity.application.organizationUnit['delete'](node.id).done(function () {
                                            abp.notify.success(l('SuccessfullyDeleted'));
                                            instance.delete_node(node);
                                            organizationTree.refreshUnitCount();
                                        }).fail(function (err) {
                                            setTimeout(function () { abp.message.error(err.message); }, 500);
                                        });;
                                    }
                                }
                            );
                        }
                    }
                }
                return items;
            },
            addUnit: function (parentId) {
                _createModal.open({
                    ParentId: parentId
                });
                _createModal.onResult(function (obj, evnt) {
                    var instance = $.jstree.reference(organizationTree.$tree);
                    var newOu = evnt.responseText;
                    instance.create_node(
                        newOu.parentId ? instance.get_node(newOu.parentId) : '#',
                        {
                            id: newOu.id,
                            parent: newOu.parentId ? newOu.parentId : '#',
                            code: newOu.code,
                            displayName: newOu.displayName,
                            memberCount: 0,
                            text: organizationTree.generateTextOnTree(newOu),
                            state: {
                                opened: true
                            }
                        });
                    organizationTree.refreshUnitCount();
                    _createModal.onResult = function (obj, evnt) { };
                });
            },
            generateTextOnTree: function (ou) {
                var itemClass = ou.memberCount > 0 ? ' ou-text-has-members' : ' ou-text-no-members';
                // return '<span title="' + ou.code + '" class="ou-text' + itemClass + '" data-ou-id="' + ou.id + '">' + ou.displayName + ' (<span class="ou-text-member-count">' + ou.memberCount + '</span>) <i class="fa fa-caret-down text-muted"></i></span>';
                return '<span title="' + ou.code + '" class="ou-text' + itemClass + '" data-ou-id="' + ou.id + '">' + ou.displayName + '</span>';
            },
            incrementMemberCount: function (ouId, incrementAmount) {
                var treeNode = organizationTree.$tree.jstree('get_node', ouId);
                treeNode.original.memberCount = treeNode.original.memberCount + incrementAmount;
                organizationTree.$tree.jstree('rename_node', treeNode, organizationTree.generateTextOnTree(treeNode.original));
            },
            getTreeDataFromServer: function (callback) {
                _organizationUnitService.getList({}).done(function (result) {
                    var treeData = _.map(result.items, function (item) {
                        return {
                            id: item.id,
                            parent: item.parentId ? item.parentId : '#',
                            code: item.code,
                            displayName: item.displayName,
                            memberCount: item.memberCount,
                            text: organizationTree.generateTextOnTree(item),
                            state: {
                                opened: true
                            }
                        };
                    });

                    callback(treeData);
                });
            },
            init: function () {
                organizationTree.getTreeDataFromServer(function (treeData) {
                    //console.log(treeData.length);
                    organizationTree.setUnitCount(treeData.length);
                    organizationTree.$tree
                        .on('changed.jstree', function (e, data) {
                            if (data.selected.length != 1) {
                                organizationTree.selectedOu.set(null);
                            } else {
                                var selectedNode = data.instance.get_node(data.selected[0]);
                                organizationTree.selectedOu.set(selectedNode);
                            }
                        })
                        .on('move_node.jstree', function (e, data) {
                            abp.message.confirm(
                                l('Move:' + data.node.original.displayName),
                                function (isConfirmed) {
                                    if (isConfirmed) {
                                        _organizationUnitService.move(
                                            data.node.id,
                                            data.parent
                                        ).done(function () {
                                            abp.notify.success(l('SuccessfullyMoved'));
                                        }).fail(function (err) {
                                            organizationTree.$tree.jstree('refresh'); //rollback
                                            setTimeout(function () { abp.message.error(err.message); }, 500);
                                        });
                                    } else {
                                        organizationTree.$tree.jstree('refresh'); //rollback
                                    }
                                }
                            );
                        })
                        .jstree({
                            'core': {
                                data: treeData,
                                multiple: false,
                                check_callback: function (operation, node, node_parent, node_position, more) {
                                    return true;
                                }
                            },
                            types: {
                                "default": {
                                    "icon": ""
                                },
                                "file": {
                                    "icon": "jstree-themeicon"
                                }
                            },
                            contextmenu: {
                                items: organizationTree.contextMenu
                            },
                            sort: function (node1, node2) {
                                if (this.get_node(node2).original.displayName < this.get_node(node1).original.displayName) {
                                    return 1;
                                }

                                return -1;
                            },
                            plugins: [
                                'types',
                                'contextmenu',
                                //'wholerow',
                                'sort',
                                'dnd'
                            ]
                        });
                    $('#AddRootUnitButton').click(function (e) {
                        e.preventDefault();
                        organizationTree.addUnit(null);
                    });
                    organizationTree.$tree.on('click', '.ou-text .fa-caret-down', function (e) {
                        e.preventDefault();

                        var ouId = $(this).closest('.ou-text').attr('data-ou-id');
                        setTimeout(function () {
                            organizationTree.$tree.jstree('show_contextmenu', ouId);
                        }, 100);
                    });
                });
            },
            reload: function () {
                organizationTree.getTreeDataFromServer(function (treeData) {
                    organizationTree.setUnitCount(treeData.length);
                    organizationTree.$tree.jstree(true).settings.core.data = treeData;
                    organizationTree.$tree.jstree('refresh');
                });
            }
        };

        var members = {

            $table: $('#OuMembersTable'),
            $emptyInfo: $('#selectmembers'),
            $addUserToOuButton: $('#AddUserToOuButton'),
            dataTable: null,
            showTable: function () {
                members.$emptyInfo.hide();
                members.$table.show();
                members.$addUserToOuButton.show();
            },
            hideTable: function () {
                members.$addUserToOuButton.hide();
                members.$table.hide();
                members.$emptyInfo.hide();
            },

            load: function () {
                if (!organizationTree.selectedOu.id) {
                    members.hideTable();
                    return;
                }
                members.showTable();
                this.dataTable.ajax.reload();
            },

            add: function (users) {
                var ouId = organizationTree.selectedOu.id;
                if (!ouId) {
                    return;
                }

                var userIds = _.pluck(users, "value");
                _organizationUnitService.addUsersToOrganizationUnit({
                    organizationUnitId: ouId,
                    userIds: userIds
                }).done(function () {
                    abp.notify.success(l('SuccessfullyAdded'));
                    organizationTree.incrementMemberCount(ouId, userIds.length);
                    members.load();
                });
            },

            remove: function (user) {
                var ouId = organizationTree.selectedOu.id;
                if (!ouId) {
                    return;
                }
                _organizationUnitService.removeFromOrganizationUnit({
                    userId: user.record.id,
                    ouId: ouId
                }).done(function () {
                    abp.notify.success(l('SuccessfullyDeleted'));
                    organizationTree.incrementMemberCount(ouId, -1);
                    members.load();
                });
            },

            openAddModal: function () {
                var ouId = organizationTree.selectedOu.id;
                if (!ouId) {
                    return;
                }
                _addUserModal.open({ OuId: ouId });
                //_addUserModal.open({
                //    title: l('SelectAUser'),
                //    organizationUnitId: ouId
                //}, function (selectedItems) {
                //    members.add(selectedItems);
                //});
            },
            init: function () {
                this.dataTable = members.$table.find("#organizationMembersTable").DataTable(abp.libs.datatables.normalizeConfiguration({
                    processing: true,
                    serverSide: true,
                    scrollX: true,
                    paging: true,
                    searching: false,
                    autoWidth: false,
                    scrollCollapse: true,
                    responsive: true,
                    bRetrieve: true,
                    iDisplayLength: 25,
                    ajax: abp.libs.datatables.createAjax(_organizationUnitService.getMembers, function () {
                        var id = organizationTree.selectedOu.id;
                        var model = {
                            ouId: id
                        };
                        return model;
                    }),
                    columnDefs: [
                        {
                            rowAction: {
                                items:
                                    [
                                        {
                                            text: l('Delete'),
                                            confirmMessage: function (data) {
                                                return l('DeletionConfirmationMessage', data.record.id);
                                            },
                                            action: function (data) {
                                                members.remove(data);
                                            }
                                        }
                                    ]
                            }, width: "15%"
                        },
                        {
                            data: "userName"
                        },
                        {
                            data: "name"
                        },
                    ]
                }));


                $('#AddUserToOuButton').click(function (e) {
                    e.preventDefault();
                    members.openAddModal();
                });
                $('#btnRefresh').click(function (e) {
                    e.preventDefault();
                    members.load();
                });
                members.hideTable();

            }
        }
        var roles = {
            $table: $('#OuRolesTable'),
            $roleInfo: $('#selectroles'),
            $addRoleToOuButton: $('#AddRoleToOuButton'),
            dataTable: null,
            showTable: function () {
                roles.$roleInfo.hide();
                roles.$table.show();
                roles.$addRoleToOuButton.show();
            },
            hideTable: function () {
                roles.$addRoleToOuButton.hide();
                roles.$table.hide();
                roles.$roleInfo.hide();
            },
            load: function () {
                if (!organizationTree.selectedOu.id) {
                    roles.hideTable();
                    return;
                }
                roles.showTable();
                this.dataTable.ajax.reload();
            },
            add: function (users) {
                var ouId = organizationTree.selectedOu.id;
                if (!ouId) {
                    return;
                }
                var userIds = _.pluck(users, "value");
                _organizationUnitService.addUsersToOrganizationUnit({
                    organizationUnitId: ouId,
                    userIds: userIds
                }).done(function () {
                    abp.notify.success(l('SuccessfullyAdded'));
                    organizationTree.incrementMemberCount(ouId, userIds.length);
                    roles.load();
                });
            },
            remove: function (user) {
                var ouId = organizationTree.selectedOu.id;
                if (!ouId) {
                    return;
                }
                _organizationUnitService.removeRoleFromOrganizationUnit({
                    userId: user.record.id,
                    ouId: ouId
                }).done(function () {
                    abp.notify.success(l('SuccessfullyDeleted'));
                    organizationTree.incrementMemberCount(ouId, -1);
                    roles.load();
                });
            },
            openAddModal: function () {
                var ouId = organizationTree.selectedOu.id;
                if (!ouId) {
                    return;
                }
                _addRoleModal.open({ OuId: ouId });
            },
            init: function () {
                this.dataTable = roles.$table.find("#organizationRolesTable").DataTable(abp.libs.datatables.normalizeConfiguration({
                    processing: true,
                    serverSide: true,
                    scrollX: true,
                    paging: true,
                    searching: false,
                    autoWidth: false,
                    scrollCollapse: true,
                    responsive: true,
                    bRetrieve: true,
                    iDisplayLength: 25,
                    ajax: abp.libs.datatables.createAjax(_organizationUnitService.getRoles, function () {
                        var id = organizationTree.selectedOu.id;
                        var model = {
                            ouId: id
                        };
                        return model;
                    }),
                    columnDefs: [
                        {
                            rowAction: {
                                items:
                                    [
                                        {
                                            text: l('Delete'),
                                            confirmMessage: function (data) {
                                                return l('DeletionConfirmationMessage', data.record.id);
                                            },
                                            action: function (data) {
                                                roles.remove(data);
                                            }
                                        }
                                    ]
                            }, width: "15%"
                        },
                        {
                            data: "name"
                        },
                    ]
                }));
                $('#AddRoleToOuButton').click(function (e) {
                    e.preventDefault();
                    roles.openAddModal();
                });
                $('#btnRoleRefresh').click(function (e) {
                    e.preventDefault();
                    roles.load();
                });
                roles.hideTable();
            }
        }
        organizationTree.init();
    });
})();



