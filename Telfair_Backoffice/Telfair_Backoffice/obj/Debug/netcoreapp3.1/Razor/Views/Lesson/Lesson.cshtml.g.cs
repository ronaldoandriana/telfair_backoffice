#pragma checksum "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8194460e2ce77fca3e9adf475f91140b749e9383"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lesson_Lesson), @"mvc.1.0.view", @"/Views/Lesson/Lesson.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8194460e2ce77fca3e9adf475f91140b749e9383", @"/Views/Lesson/Lesson.cshtml")]
    public class Views_Lesson_Lesson : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Telfair_Backend.Classes.Models.LessonModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Level";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
 using (Html.BeginForm("SaveLesson", "Lesson", FormMethod.Post, new { enctype = "multipart/form-data", data_ajax = "false"

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                                                                                                                                                                                              }))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <!-- left column -->
    <div class=""col-md-12"">
        <!-- general form elements -->
        <div class=""box box-primary"">
            <div class=""box-header with-border"">
                <h3 class=""box-title"">Level</h3>
            </div>
            <div class=""box-body"">
                <div class=""row"">
");
            WriteLiteral("                    <div class=\"col-md-6\">\r\n                        <div class=\"form-group\">\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 23 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                           Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 24 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                           Write(Html.HiddenFor(m => m.MyId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 25 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                           Write(Html.HiddenFor(m => m.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 26 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                           Write(Html.LabelFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 27 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                           Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 30 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                           Write(Html.LabelFor(m => m.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 31 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                           Write(Html.TextBoxFor(m => m.Description, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                <label>Department:</label>\r\n                                ");
#nullable restore
#line 35 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                           Write(Html.DropDownListFor(m => m.DepartmentNodeId, (SelectList)ViewBag.NodeDepartment, "--Select departement--", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                <label>Grade</label>\r\n                                ");
#nullable restore
#line 39 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                           Write(Html.DropDownListFor(m => m.LevelNodeId, (SelectList)ViewBag.NodeLevel, "--Select department first--", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                <label>Subject</label>\r\n                                ");
#nullable restore
#line 43 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                           Write(Html.DropDownListFor(m => m.SubjectId, (SelectList)ViewBag.Subject, "--Select grade first--", new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                <span asp-validation-for=""SubjectId"" class=""text-danger""></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
            WriteLiteral(@"    <div class=""col-md-12"">
        <!-- general form elements -->
        <div class=""box-footer"">
            <div class=""row"" align=""right"">
                <div class=""btn-group"">
                    <button type=""submit"" class=""btn btn-info"">SAVE</button>
                    <a href=""/Lesson/ViewLesson""><button type=""button"" class=""btn btn-info"">CANCEL</button></a>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 64 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">

        $(document)
            .ready(function () {

                $(function () {
                    $(""#LevelNodeId"").change(function () {
                        $.getJSON(""/Subject/ViewSubjectByLevel"", { levelId: $(""#LevelNodeId option:selected"").val() },
                            function (results) {
                                $(""#SubjectId"").empty();
                                //LoadLessons($(""#Subjects option:selected"").val());

                                // var select = ""<option>--Select--</option>""
                                var options = ""<option>--Select subject--</option>"";
                                $.each(results, function (i, subject) {
                                    options += '<option value = ' + subject.id + '>' + subject.name + '</option>';
                                });
                                $(""#SubjectId"").append(options);

                            });
                    });
");
                WriteLiteral(@"                });

                $(function () {
                    $(""#DepartmentNodeId"").change(function () {
                        $.getJSON(""/Lesson/GetNodesByParent"", { parentNodeId: $(""#DepartmentNodeId option:selected"").val() },
                            function (results) {
                                $(""#LevelNodeId"").empty();
                                $(""#SubjectId"").empty();
                                //LoadLessons($(""#Subjects option:selected"").val());
                                // var select = ""<option>--Select--</option>""
                                var options = ""<option>--Select grade--</option>"";
                                $.each(results, function (i, subject) {
                                    options += '<option value = ' + subject.id + '>' + subject.name + '</option>';
                                });
                                $(""#LevelNodeId"").append(options);
                                $(""#SubjectId"").append(""<option>-");
                WriteLiteral("-Select grade first--</option>\");\r\n\r\n                            });\r\n                    });\r\n                });\r\n            });\r\n\r\n    </script>\r\n\r\n");
            }
            );
            WriteLiteral("    <script>\r\n        (function () {\r\n            var link = document.getElementById(\"lesson-link\");\r\n            if (link) link.classList.add(\"active_link\");\r\n        })();\r\n    </script>\r\n\r\n\r\n");
#nullable restore
#line 122 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
 if (ViewBag.error != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Error\', \'");
#nullable restore
#line 122 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                                                             Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'error\'); </script> ");
#nullable restore
#line 122 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                                                                                                       }

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
 if (ViewBag.success != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Success\', \'");
#nullable restore
#line 123 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
                                                                 Write(ViewBag.success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'success\'); </script> ");
#nullable restore
#line 123 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Lesson\Lesson.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Telfair_Backend.Classes.Models.LessonModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
