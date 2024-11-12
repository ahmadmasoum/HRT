$(function () {
    var l = abp.localization.getResource('HRT');
    var candidateService = window.hRT.controllers.candidates.candidate;

    var dataTable = $('#CandidatesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(hRT.candidates.candidate.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('HRT.Candidates.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('DownloadResume'),
                                    visible: abp.auth.isGranted('HRT.Candidates'),
                                    action: function (data) {
                                        var downloadWindow = window.open(
                                            abp.appPath + "api/app/candidates/download-candidate-resume/" + data.record.resumeName,
                                            "_blank"
                                        );
                                        downloadWindow.focus();

                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('HRT.Candidates.Delete'),
                                    confirmMessage: function (data) {
                                        return l('CandidateDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        hRT.candidates.candidate
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('FullName'),
                    data: "fullName"
                },
                {
                    title: l('Department'),
                    data: "department",
                    render: function (data) {
                        return l('Enum:DepartmentType.' + data);
                    }
                },
                {
                    title: l('DateOfBirth'),
                    data: "dateOfBirth",
                    dataFormat: "datetime"
                },
                {
                    title: l('Experience'),
                    data: "experience"
                },
                {
                    title: l('AppliedOn'), data: "creationTime",
                    dataFormat: "datetime"
                }
            ]
        })
    );

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
});
