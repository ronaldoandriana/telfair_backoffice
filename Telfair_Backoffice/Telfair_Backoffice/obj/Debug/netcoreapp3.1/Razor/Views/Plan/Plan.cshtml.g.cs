#pragma checksum "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9bab96e71d825e191d53e668ceae76ff5a0b4572"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Plan_Plan), @"mvc.1.0.view", @"/Views/Plan/Plan.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bab96e71d825e191d53e668ceae76ff5a0b4572", @"/Views/Plan/Plan.cshtml")]
    public class Views_Plan_Plan : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Telfair_Backend.Classes.Models.PlanModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Plan";
    var role = (string)ViewBag.RoleName;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
 using (Html.BeginForm("SavePlan", "Plan", FormMethod.Post, new { enctype = "multipart/form-data", data_ajax = "false"

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
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
                <h3 class=""box-title"">Weekly Plan</h3>
            </div>
            <div class=""box-body"">
                <div class=""row"">
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            ");
#nullable restore
#line 22 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                       Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 23 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                       Write(Html.HiddenFor(m => m.MyId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 24 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                       Write(Html.HiddenFor(m => m.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 26 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.Label("Grade"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 27 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.DropDownListFor(m => m.NodeLevelId, (SelectList)ViewBag.NodeLevelType, "--Select grade--", new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                <span asp-validation-for=""NodeLevelId"" class=""text-danger""></span>
                            </div>
                            <div class=""form-group has-feedback"">
                                <label>Subject</label>
                                ");
#nullable restore
#line 32 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.DropDownListFor(m => m.SubjectId, (SelectList)ViewBag.Subject, "--Select grade first--", new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 35 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.Label("Level"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 36 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.DropDownListFor(m => m.LessonId, (SelectList)ViewBag.Lesson, "--Select subject first--", new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <span asp-validation-for=\"LessonId\" class=\"text-danger\"></span>\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 40 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.Label("Teacher"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 41 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.DropDownListFor(m => m.EmployeeIds, (SelectList)ViewBag.Employee, "--Select teacher--", new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <span asp-validation-for=\"EmployeeIds\" class=\"text-danger\"></span>\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 45 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.Label("Plan Type"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 46 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.DropDownListFor(m => m.PlanTypeId, (SelectList)ViewBag.PlanType, "--Select plan type--", new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <span asp-validation-for=\"PlanTypeId\" class=\"text-danger\"></span>\r\n                            </div>\r\n\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 51 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.LabelFor(m => m.Note));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 52 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.TextBoxFor(m => m.Note, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-md-6\">\r\n                        <div class=\"form-group\">\r\n");
            WriteLiteral("                            <div id=\"duration\" class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 61 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.LabelFor(m => m.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 62 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.TextBoxFor(m => m.Duration, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n");
            WriteLiteral("                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 66 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.LabelFor(m => m.Aims));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 67 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.TextBoxFor(m => m.Aims, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 70 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.LabelFor(m => m.Activities));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 71 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.TextBoxFor(m => m.Activities, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 74 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.LabelFor(m => m.Materials));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 75 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.TextBoxFor(m => m.Materials, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n");
            WriteLiteral("                                <div id=\"noofchildren\" class=\"form-group has-feedback\">\r\n                                    ");
#nullable restore
#line 80 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                               Write(Html.Label("No of Children"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 81 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                               Write(Html.TextBoxFor(m => m.NoOfChildren, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                                <div id=\"days\" class=\"form-group has-feedback\">\r\n                                    ");
#nullable restore
#line 84 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                               Write(Html.HiddenFor(model => model.Days, new { htmlAttributes = new { id = "days" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                    <table id=""Lesson"" class=""table table-bordered table-hover"">
                                        <thead>
                                            <tr>
                                                <td><b>Days</b></td>
                                            </tr>
                                            <tr>
                                                <td><input id=""chkMonday"" type=""checkbox"" value=""Monday"" onchange=""getSelected();"" /> Monday </td>
                                                <td><input id=""chkTuesday"" type=""checkbox"" value=""Tuesday"" onchange=""getSelected();"" /> Tuesday </td>
                                                <td><input id=""chkWednesday"" type=""checkbox"" value=""Wednesday"" onchange=""getSelected();"" /> Wednesday </td>
                                                <td><input id=""chkThursday"" type=""checkbox"" value=""Thursday"" onchange=""getSelected();"" /> Thursday </td>
                                          ");
            WriteLiteral(@"      <td><input id=""chkFriday"" type=""checkbox"" value=""Friday"" onchange=""getSelected();"" /> Friday </td>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
");
            WriteLiteral("                        </div>\r\n                    </div>\r\n                    <div class=\"col-md-6\">\r\n                        <div class=\"form-group\">\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 107 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.LabelFor(m => m.Method));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 108 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.TextAreaFor(m => m.Method, new { @class = "form-control", @required = "required", style = "height: 200px" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 111 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.LabelFor(m => m.OutcomesNotes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 112 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.TextBoxFor(m => m.OutcomesNotes, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">

                            <div class=""form-group has-feedback"">
                                ");
#nullable restore
#line 120 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.Label("Date From"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
            WriteLiteral("                                <input class=\"form-control\" data-val=\"true\" data-val-required=\"The DateFrom field is required.\" id=\"DateFrom\"");
            BeginWriteAttribute("min", " min=\"", 8159, "\"", 8205, 1);
#nullable restore
#line 122 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
WriteAttributeValue("", 8165, DateTime.Now.ToString("MM'/'dd'/'yyyy"), 8165, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"DateFrom\" required=\"required\" type=\"date\"");
            BeginWriteAttribute("value", " value=\"", 8254, "\"", 8304, 1);
#nullable restore
#line 122 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
WriteAttributeValue("", 8262, DateTime.Now.ToString("yyyy'-'MM'-'dd"), 8262, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 126 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.Label("Date To"));

#line default
#line hidden
#nullable disable
            WriteLiteral("      <br />\r\n");
            WriteLiteral("                                <input class=\"form-control\" data-val=\"true\" data-val-required=\"The DateFrom field is required.\" id=\"DateTo\"");
            BeginWriteAttribute("min", " min=\"", 8874, "\"", 8920, 1);
#nullable restore
#line 128 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
WriteAttributeValue("", 8880, DateTime.Now.ToString("MM'/'dd'/'yyyy"), 8880, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"DateTo\" required=\"required\" type=\"date\"");
            BeginWriteAttribute("value", " value=\"", 8967, "\"", 9028, 1);
#nullable restore
#line 128 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
WriteAttributeValue("", 8975, DateTime.Now.AddDays(5).ToString("yyyy'-'MM'-'dd"), 8975, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 131 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.LabelFor(m => m.Week));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 132 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.TextBoxFor(m => m.Week, new { @type = "number", @class = "form-control", @min = 1, @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 135 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.LabelFor(m => m.Term));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 136 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.TextBoxFor(m => m.Term, new { @type = "number", @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 139 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.Label("Date of Issue"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 140 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                           Write(Html.TextBoxFor(m => m.DateOfIssue, new { @class = "form-control", @readonly = true }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral(@"    <div class=""col-md-12"">
        <!-- general form elements -->
        <div class=""box-footer"">
            <div class=""row"" align=""right"">
                <div class=""btn-group"">
                    <button type=""submit"" class=""btn btn-info"">SAVE</button>
                    <a href=""/Plan/ViewMyPlan""><button type=""button"" class=""btn btn-info"">CANCEL</button></a>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 160 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"


}

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        var employee = '';
        $(document)
            .ready(function () {

                  $(function () {
                        var days = $(""#Days"").val();

                        if(days != null)
                        {
                           if( days.indexOf(""Monday"" ) != -1 )
                                $(""#chkMonday"").prop(""checked"", true);
                           if( days.indexOf(""Tuesday"" ) != -1 )
                                $(""#chkTuesday"").prop(""checked"", true);
                           if( days.indexOf(""Wednesday"" ) != -1 )
                                $(""#chkWednesday"").prop(""checked"", true);;
                           if( days.indexOf(""Thursday"" ) != -1 )
                                $(""#chkThursday"").prop(""checked"", true);
                           if( days.indexOf(""Friday"" ) != -1 )
                                $(""#chkFriday"").prop(""checked"", true);         
                        }
           ");
                WriteLiteral(@"         });

                $(function () {
                    $(""#NodeLevelId"").change(function () {
                        $.getJSON(""/Subject/ViewSubjectByLevel"", { levelId: $(""#NodeLevelId option:selected"").val() },
                            function (results) {
                                $(""#SubjectId"").empty();
                                // var select = ""<option>--Select--</option>""
                                var options = ""<option value=''>--Select subject--</option>"";
                                $.each(results, function (i, subject) {
                                    options += '<option value = ' + subject.id + '>' + subject.name + '</option>';
                                });
                                $(""#SubjectId"").append(options);

                            });

                        var level = $(""#NodeLevelId option:selected"").val();

                        if (level === 'ac97591f-15fd-4c5a-aa2c-ba1b965245a6' || level === 'cb3d9100-3078");
                WriteLiteral(@"-496f-8f43-5dd35b03b4d5'|| level === 'a1acc9c4-35e7-40a1-8e97-01120ec26c13' || level === 'a1acc9c4-35e7-40a1-8e97-01120ec26c14')
                        {
                            //$(""#duration"").show();
                            //$(""#noofchildren"").show();
                            //$(""#days"").show();
                        }
                        else
                        {
                            //$(""#duration"").hide();
                            //$(""#noofchildren"").hide();
                            //$(""#days"").hide();
                        }
                    });
                });

                $(function () {
                    $(""#SubjectId"").change(function () {
                        $.getJSON(""/Curriculum/GetLessonsBySubject"", { subjectId: $(""#SubjectId option:selected"").val() },
                            function (results) {
                                $(""#LessonId"").empty();
                                // var select = ""<option>--Sel");
                WriteLiteral(@"ect--</option>""
                                var options = ""<option value=''>--Select Level--</option>"";
                                $.each(results, function (i, subject) {
                                    options += '<option value = ' + subject.id + '>' + subject.name + '</option>';
                                });
                                $(""#LessonId"").append(options);

                            });

                        $.getJSON(""/Plan/GetEmployeesBySubject"", { id: $(""#SubjectId option:selected"").val() },
                            function (results) {
                                employee = results;
                                $(""#EmployeeIds"").empty();
                                // var select = ""<option>--Select--</option>""
                                var options = ""<option value=''>--Select teacher--</option>"";
                                $.each(results, function (i, employee) {
                                    options += '<option value ");
                WriteLiteral(@"= ' + employee.id + '>' + employee.fullName + '</option>';
                                });
                                $(""#EmployeeIds"").append(options);

                            });



                    });
                });
            });

         function getSelected() 
        {    
            var days = """";

            $('input[type=checkbox]').each(function () {
                if (this.checked) {
                    days += this.value + "","";                   
                }
            });
            $(""#Days"").val(days);          
            return false;
        }

    </script>
");
            }
            );
            WriteLiteral("\r\n    <script>\r\n        (function () {\r\n            var link = document.getElementById(\"plan-link\");\r\n            if (link) link.classList.add(\"active_link\");\r\n        })();\r\n    </script>\r\n\r\n");
#nullable restore
#line 275 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
 if (ViewBag.error != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Error\', \'");
#nullable restore
#line 275 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                                                             Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'error\'); </script> ");
#nullable restore
#line 275 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                                                                                                       }

#line default
#line hidden
#nullable disable
#nullable restore
#line 276 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
 if (ViewBag.success != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Success\', \'");
#nullable restore
#line 276 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
                                                                 Write(ViewBag.success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'success\'); </script> ");
#nullable restore
#line 276 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\Plan.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Telfair_Backend.Classes.Models.PlanModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
