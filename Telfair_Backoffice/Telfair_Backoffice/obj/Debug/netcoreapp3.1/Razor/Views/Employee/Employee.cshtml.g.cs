#pragma checksum "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae91df756a7b5f1f1829429d60a937e9ac8d25e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Employee), @"mvc.1.0.view", @"/Views/Employee/Employee.cshtml")]
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
#nullable restore
#line 2 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
using Telfair_Backend.Classes.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae91df756a7b5f1f1829429d60a937e9ac8d25e5", @"/Views/Employee/Employee.cshtml")]
    public class Views_Employee_Employee : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Telfair_Backend.Classes.Models.EmployeeModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/backoffice.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Employee";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
 using (Html.BeginForm("SaveEmployee", "Employee", FormMethod.Post, new { enctype = "multipart/form-data", data_ajax = "false"

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
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
                <h3 class=""box-title"">User</h3>
            </div>
            <div class=""box-body"">
                <div class=""row"">
");
            WriteLiteral("                    <div class=\"col-md-6\">\r\n                        <div class=\"form-group\">\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 24 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 25 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.HiddenFor(m => m.MyId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 26 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.HiddenFor(m => m.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 27 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.HiddenFor(m => m.PersonId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 28 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.HiddenFor(m => m.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 29 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.HiddenFor(m => m.UserRoleId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 30 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.HiddenFor(m => m.RoleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                ");
#nullable restore
#line 32 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.Label("First Name*"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 33 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.TextBoxFor(m => m.FirstName, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 36 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.Label("Middle Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 37 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.TextBoxFor(m => m.MiddleName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 40 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.Label("Last Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 41 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.TextBoxFor(m => m.LastName, new { @class = "form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 44 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.Label("User Name*"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 45 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.TextBoxFor(m => m.UserName, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n");
#nullable restore
#line 48 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                 if (ViewBag.isEdit != null && ViewBag.isEdit == true)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                               Write(Html.Label("Password*"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                               Write(Html.PasswordFor(m => m.HashCode, new { @class = "form-control", onkeyup = "testPassword()" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p id=\"password_suggestion\" style=\"color: red;\"></p>\r\n                                    <i>(Keep password field empty if you don\'t want to change it)</i>\r\n");
#nullable restore
#line 54 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                               Write(Html.Label("Password*"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                               Write(Html.PasswordFor(m => m.HashCode, new { @class = "form-control", onkeyup = "testPassword()", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p id=\"password_suggestion\" style=\"color: red;\"></p>\r\n");
#nullable restore
#line 60 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 63 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.Label("Role"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 64 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.DropDownListFor(m => m.RoleId, (SelectList)ViewBag.Roles, "--Select role--", new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n\r\n                            <div id=\"SubjectSection\" class=\"form-group has-feedback ;\" style=\"overflow-y: auto; max-height: 600px; max-width: 2000px;width:1000px;\">\r\n                                ");
#nullable restore
#line 68 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                           Write(Html.HiddenFor(model => model.Subjects));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                <table id=""Lesson"" class=""table table-bordered table-hover"" style=""display: none;"">
                                    <thead>
                                        <tr>
                                            <td><b>Subject</b></td>
                                            <td><b>Grade</b></td>
                                        </tr>
                                    </thead>
");
#nullable restore
#line 77 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                      
                                        List<EmployeeSubjectModel> employeeSubjects = Model.EmployeeSubjects as List<EmployeeSubjectModel>;
                                        if (employeeSubjects != null)
                                        {
                                            foreach (var employeeSubject in employeeSubjects)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td><input type=\"checkbox\" name=\"SelectedEmployeeSubjects\"");
            BeginWriteAttribute("value", " value=\"", 5048, "\"", 5082, 1);
#nullable restore
#line 84 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
WriteAttributeValue("", 5056, employeeSubject.SubjectId, 5056, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onchange=\"getSelected();\"");
            BeginWriteAttribute("checked", " checked=\"", 5109, "\"", 5146, 1);
#nullable restore
#line 84 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
WriteAttributeValue("", 5119, employeeSubject.Selected, 5119, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /> ");
#nullable restore
#line 84 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                                                                                                                                                                                                Write(employeeSubject.SubjectName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 85 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                                   Write(employeeSubject.LevelNodeName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                                </tr>\r\n                                                <script>console.log(\'");
#nullable restore
#line 87 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                                                 Write(employeeSubject.Selected);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')</script>\r\n");
#nullable restore
#line 88 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                            }
                                        }
                                        else
                                        {

                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </table>
                                <table id=""Grades"" class=""table table-bordered table-hover"" style=""display: none;"">
                                    <thead>
                                        <tr>
                                            <td><b>Children's Grade</b></td>
                                        </tr>
                                    </thead>
");
#nullable restore
#line 102 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                      
                                        List<ParentChildrenNodeModel> listGrade = ViewBag.Grades as List<ParentChildrenNodeModel>;
                                        if (listGrade != null)
                                        {
                                            foreach (var grade in listGrade)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td><input type=\"checkbox\" name=\"SelectedEmployeeSubjects\"");
            BeginWriteAttribute("value", " value=\"", 6696, "\"", 6717, 1);
#nullable restore
#line 109 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
WriteAttributeValue("", 6704, grade.NodeId, 6704, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("checked", " checked=\"", 6718, "\"", 6743, 1);
#nullable restore
#line 109 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
WriteAttributeValue("", 6728, grade.Selected, 6728, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onchange=\"getSelected();\" /> ");
#nullable restore
#line 109 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                                                                                                                                                                       Write(grade.NodeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                </tr>\r\n");
#nullable restore
#line 111 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                            }
                                        }
                                        else
                                        {

                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </table>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral(@"    <div class=""col-md-12"">
        <!-- general form elements -->
        <div class=""box-footer"">
            <div class=""row"" align=""right"">
                <div class=""btn-group"">
                    <button type=""submit"" id=""save_button"" class=""btn btn-info"">SAVE</button>
                    <a href=""/Employee/ViewEmployee""><button type=""button"" class=""btn btn-info"">CANCEL</button></a>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 138 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae91df756a7b5f1f1829429d60a937e9ac8d25e522299", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script type=""text/javascript"">       
        function getSelected() {
            var subjects = """";
          

            $('input[type=checkbox]').each(function () {
                if (this.checked) {
                    subjects += this.value + "","";
                  
                }
            });
            $(""#Subjects"").val(subjects);    
            return false;
        }

        function roleChange() {
            var rolename = $(""#RoleId :selected"").text();
            var rolevalue = $(""#RoleId :selected"").val();
            $(""#RoleName"").val(rolename);
            console.log(rolename == 'Administrator');
            if (rolename == 'Administrator') {
                $(""#Lesson"").css('display', 'none');
                $(""#Grades"").css('display', 'none');
            }
            else if (rolename == 'Parents') {
                $(""#Lesson"").css('display', 'none');
                $(""#Grades"").css('display', 'block');
            }
            else i");
                WriteLiteral(@"f (rolevalue == '' || rolevalue == undefined || rolevalue == null) {
                $(""#Lesson"").css('display', 'none');
                $(""#Grades"").css('display', 'none');
            }
            else {
                $(""#Lesson"").css('display', 'block');
                $(""#Grades"").css('display', 'none');
            }
        }

        $(document)
            .ready(function () {
                roleChange();
                getSelected();
            $(function () {
                $(""#RoleId"").change(function () {
                    getSelected();
                    roleChange();
                });
            });
        });

    </script>

");
            }
            );
            WriteLiteral("    <script>\r\n        (function () {\r\n            var link = document.getElementById(\"user-link\");\r\n            if (link) link.classList.add(\"active_link\");\r\n        })();\r\n    </script>\r\n\r\n");
#nullable restore
#line 203 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
 if (ViewBag.error != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Error\', \'");
#nullable restore
#line 203 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                                             Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'error\'); </script> ");
#nullable restore
#line 203 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                                                                                       }

#line default
#line hidden
#nullable disable
#nullable restore
#line 204 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
 if (ViewBag.success != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Success\', \'");
#nullable restore
#line 204 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
                                                                 Write(ViewBag.success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'success\'); </script> ");
#nullable restore
#line 204 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Employee\Employee.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Telfair_Backend.Classes.Models.EmployeeModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
