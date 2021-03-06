#pragma checksum "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e71806baa7f9713d35ad4d961010cf587bb35eb0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Plan_ViewMyPlan), @"mvc.1.0.view", @"/Views/Plan/ViewMyPlan.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e71806baa7f9713d35ad4d961010cf587bb35eb0", @"/Views/Plan/ViewMyPlan.cshtml")]
    public class Views_Plan_ViewMyPlan : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Telfair_Backend.Classes.Models.PlanSummaryModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
  
    Layout = "_Layout";
    var role = (string)ViewBag.RoleName;
    ViewData["Title"] = "View Weekly Plan";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-md-12"">
    <!-- general form elements -->
    <div class=""box box-primary"">
        <div class=""box-header with-border"">
            <h3 class=""box-title"">View Weekly Plan</h3>
        </div>
        <div id=""Grid"" class=""form-group has-feedback ;"">

            ");
#nullable restore
#line 18 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
       Write(Html.Hidden("role", role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <table class=\"table table-bordered table-hover\">\r\n                <tr>\r\n");
#nullable restore
#line 21 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                      
                        if (role != null && role.ToString().ToLower() == "administrator")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <th>\r\n                                Teacher\r\n                            </th>\r\n");
#nullable restore
#line 27 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <th>
                        Subject
                    </th>
                    <th>
                        Year
                    </th>
                    <th>
                        Term
                    </th>
                    <th>
                        Duration
                    </th>
                </tr>

");
#nullable restore
#line 43 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n");
#nullable restore
#line 46 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                      
                        if (role != null && role.ToString().ToLower() == "administrator")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                ");
#nullable restore
#line 50 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                           Write(Html.DisplayFor(modelItem => item.EmployeeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 52 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n");
            WriteLiteral("                        ");
#nullable restore
#line 56 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                   Write(Html.DisplayFor(modelItem => item.SubjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Level));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Term));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        <button type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2312, "\"", 2406, 11);
            WriteAttributeValue("", 2322, "LoadMyWeeklyPlans(\'", 2322, 19, true);
#nullable restore
#line 69 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
WriteAttributeValue("", 2341, item.SubjectId, 2341, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2356, "\',", 2356, 2, true);
            WriteAttributeValue(" ", 2358, "\'", 2359, 2, true);
#nullable restore
#line 69 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
WriteAttributeValue("", 2360, item.EmployeeId, 2360, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2376, "\',\'", 2376, 3, true);
#nullable restore
#line 69 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
WriteAttributeValue("", 2379, item.Term, 2379, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2389, "\',", 2389, 2, true);
            WriteAttributeValue(" ", 2391, "\'", 2392, 2, true);
#nullable restore
#line 69 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
WriteAttributeValue("", 2393, item.Week, 2393, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2403, "\');", 2403, 3, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">View Details</button>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 2481, "\"", 2509, 2);
            WriteAttributeValue("", 2488, "/Plan/Delete/", 2488, 13, true);
#nullable restore
#line 70 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
WriteAttributeValue("", 2501, item.Id, 2501, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n\r\n");
            WriteLiteral("                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 76 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n            <nav aria-label=\"Page navigation example\">\r\n                <ul class=\"pagination justify-content-center\">\r\n                    ");
#nullable restore
#line 80 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                Write(new Microsoft.AspNetCore.Html.HtmlString(ViewBag.pagination));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </ul>
            </nav>
        </div>
    </div>
</div>




<div class=""modal fade"" id=""modal-default"" >
    <div class=""modal-dialog"" style=""overflow: scroll; max-height: 600px; max-width: 2000px;width:1000px; position:relative"" >
        <div class=""modal-content""  >
            <div class=""modal-header"" >
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <h4 class=""modal-title"">Plan Details</h4>
            </div>
            <div class=""modal-body"" >
               

                    <table id=""PlanDetails"" class=""table""  >
                        <tr>
                            <th>
                                Subject
                            </th>
                            <th>
                                Lesson
                            </th>
                            <th>
                 ");
            WriteLiteral(@"               Level
                            </th>
                            <th>
                                Week
                            </th>
                            <th>
                                Day
                            </th>

                        </tr>
                    </table>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-default pull-left"" data-dismiss=""modal"">Close</button>
");
            WriteLiteral("            </div>\r\n        </div>\r\n        <!-- /.modal-content -->\r\n    </div>\r\n    <!-- /.modal-dialog -->\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        var test = '';


        function LoadMyWeeklyPlans(subjectId, employeeId,term, week) {

            //var page = document.getElementById(""Page"").value;
            $.ajax(
                {
                    type: ""GET"",
                    url: ""/Plan/ViewMyWeeklyPlans"",
                    data: { subjectId: subjectId, employeeId: employeeId,term : term, week: week },
                    contentType: ""application/json;charset=utf-8"",
                    dataType: ""json"",
                    success: function (data) {
                        $(""#PlanDetails tr:gt(0)"").remove();
                        var table = document.getElementById(""PlanDetails"");

                        var plans = data;
                        test = data;
                        var role = $('#role').val();
                        for (i = 0; i < plans.length; i++) {
                            var temp = plans[i];
                            

               ");
                WriteLiteral(@"             var row = table.insertRow();
                            //var cell1 = row.insertCell(0);
                            var cell1 = row.insertCell(0);
                            var cell2 = row.insertCell(1);
                            var cell3 = row.insertCell(2);
                            var cell4 = row.insertCell(3);
                            var cell5 = row.insertCell(4);
                            var cell6 = row.insertCell(5);
                            

                            cell1.innerHTML = temp.subjectName;
                            cell2.innerHTML = temp.lessonName;
                            cell3.innerHTML = temp.aims;
                            cell4.innerHTML = temp.week;
                            cell5.innerHTML = temp.days;

                            var btnViewSinglePlan = document.createElement('input');
                            btnViewSinglePlan.id = ""View""+temp.id;
                            btnViewSinglePlan.type = ""button"";
    ");
                WriteLiteral(@"                        btnViewSinglePlan.className = ""btn btn-primary"";
                            doClickView(btnViewSinglePlan, temp.id);
                            btnViewSinglePlan.value = ""View"";
                            cell6.appendChild(btnViewSinglePlan);
                            if (role.toLowerCase() == ""administrator"" || role.toLowerCase() == ""teacher - primary"") {
                                //var cell7 = row.insertCell(6);
                                var btnEditPlan = document.createElement('input');
                                btnEditPlan.id = ""Edit"" + temp.id;
                                btnEditPlan.type = ""button"";
                                btnEditPlan.className = ""btn btn-primary"";
                                doClickEdit(btnEditPlan, temp.id);
                                btnEditPlan.value = ""Edit"";
                                cell6.appendChild(btnEditPlan);
                            }
                        }

                     ");
                WriteLiteral(@"   $('#modal-default').modal('show');
                    }
                });

            return false;

        };

        function doClickEdit(btn, id) {
            
            btn.onclick = function () { Edit(id) }
        };

        function Edit(id) {
            location.href = '");
#nullable restore
#line 209 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                        Write(Url.Action("Edit", "Plan"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?id=\'+id;\r\n           \r\n        }\r\n\r\n        function doClickView(btn, id) {\r\n            \r\n            btn.onclick = function () { View(id) }\r\n        };\r\n\r\n        function View(id) {\r\n            location.href = \'");
#nullable restore
#line 219 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                        Write(Url.Action("ViewMyWeeklyPlansDetails", "Plan"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?planId=\'+id;\r\n           \r\n        }\r\n    </script>\r\n");
            }
            );
            WriteLiteral("    <script>\r\n        (function () {\r\n            var link = document.getElementById(\"plan-link\");\r\n            if (link) link.classList.add(\"active_link\");\r\n        })();\r\n    </script>\r\n");
#nullable restore
#line 230 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
 if (ViewBag.error != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Error\', \'");
#nullable restore
#line 230 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                                                             Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'error\'); </script> ");
#nullable restore
#line 230 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                                                                                                       }

#line default
#line hidden
#nullable disable
#nullable restore
#line 231 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
 if (ViewBag.success != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Success\', \'");
#nullable restore
#line 231 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                                                                 Write(ViewBag.success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'success\'); </script> ");
#nullable restore
#line 231 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlan.cshtml"
                                                                                                               }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Telfair_Backend.Classes.Models.PlanSummaryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
