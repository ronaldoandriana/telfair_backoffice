function showNotification(title, message, type) {
    window.createNotification({
        closeOnClick: true,
        displayCloseButton: true,
        positionClass: 'nfc-bottom-right',
        showDuration: 5000,
        theme: type
    })({
        title: title,
        message: message
    });
}

function loadRole() {
    $(function () {
        $("#RoleId").change(function () {
            var accessible_link = document.getElementById('accessible_link');
            if ($("#DepartmentNodeId option:selected").val() !== '') {
                //$.getJSON("/BackOffice/Lesson/GetNodesByParent", { parentNodeId: $("#DepartmentNodeId option:selected").val() },
                //    function (results) {
                //        console.log(result);
                //    });
                accessible_link.innerHTML = "<p>Change DOM</p>";
            }
            else {
                if (accessible_link) {
                    accessible_link.innerHTML = "<p>Select role first 2</p>";
                }
            }
        });
    });
}

function load_my_children_grade() {
    $.getJSON("/Department/LoadGrade", {},
        function (results) {
            if (results.status == 1) {
                $("#ulgrade").empty();
                var dom = createDomGrade(results.data);
                $("#ulgrade").html(dom);
            }
            else if (results.status == 0) {
                showNotification('Error', results.message, 'error');
            }
        });
}


function createDomGrade(data) {
    var dom = "";
    if (data.length <= 0) {
        dom += "<li class='treeview' style='height: auto;'>" +
            "<a href='#'>" +
            "<i class='fa fa-times'></i> You don't have children"+
            "</a>";
        dom += "</li>";
    }
    else {
        for (var i = 0; i < data.length; i++) {
            dom += "<li style='height: auto;'>" +
                "<a href='/HomeWork/ViewHomeWork?grade=" + data[i].nodeId + "'>" +
                "<i class='fa fa-graduation-cap'></i> " + data[i].nodeName +
                "</a>";
            dom += "</li>";
        }
    }
    return dom;
}

function load_department_and_grade() {
    $.getJSON("/Department/LoadDepartmentAndGrade", {},
        function (results) {
            if (results.status == 1) {
                $("#uldepartment").empty();
                var dom = createDom(results.data);
                $("#uldepartment").html(dom);
            }
            else if (results.status == 0) {
                showNotification('Error', results.message, 'error');
            }
        });
}

function createDom(data) {
    var dom = "";
    for (var i = 0; i < data.length; i++) {
        dom += "<li class='treeview' style='height: auto;'>"+
            "<a href='#'>" +
            "<i class='fa fa-graduation-cap'></i> " + data[i].departmentName +
                        "<span class='pull-right-container'>"+
                            "<i class='fa fa-angle-left pull-right'></i>"+
                        "</span>"+
            "</a>";
        dom += "<ul class='treeview-menu' style='display: none;'>";
        for (var j = 0; j < data[i].grades.length; j++) {
            dom += "<li><a href='#" + data[i].grades[j].gradeId + "'><i class='fa fa-folder'></i> " + data[i].grades[j].gradeName + "</a></li>";
        }
        dom += "</ul>";
        dom += "</li>";
    }
    return dom;
}