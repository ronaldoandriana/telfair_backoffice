#pragma checksum "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Role\AccessControl.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bfed39f66b8fd0e8a13f24660961db908d657ef0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_AccessControl), @"mvc.1.0.view", @"/Views/Role/AccessControl.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfed39f66b8fd0e8a13f24660961db908d657ef0", @"/Views/Role/AccessControl.cshtml")]
    public class Views_Role_AccessControl : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Telfair_Backend.Classes.Models.RoleAccessControlModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Role\AccessControl.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Role access control";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Role\AccessControl.cshtml"
 using (Html.BeginForm("UpdateRole", "Role", FormMethod.Post, new { enctype = "multipart/form-data", data_ajax = "false", onsubmit = "return confirm('Are you sure to save changes?');" }))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <!-- left column -->
    <div class=""col-md-12"">
        <!-- general form elements -->
        <div class=""box box-primary"">
            <div class=""box-header with-border"">
                <h3 class=""box-title"">Role access control</h3>
            </div>
            <div class=""box-body"">

                <div class=""row"">
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <div class=""form-group has-feedback"">
                                ");
#nullable restore
#line 23 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Role\AccessControl.cshtml"
                           Write(Html.Label("Role"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 24 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Role\AccessControl.cshtml"
                           Write(Html.DropDownListFor(m => m.RoleId, (SelectList)ViewBag.Roles, "--Select role--", new { @class = "form-control", @required = "required", onchange = "loadRoleMenu()" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                            <div class=""form-group has-feedback"">
                                <label>Accessible link</label>
                                <div id=""accessible_link"">
                                    <p>Select role first</p>
                                </div>
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
                    <button id=""btnSubmit"" type=""submit"" class=""btn btn-info"">SAVE</button>
");
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 50 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Role\AccessControl.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bfed39f66b8fd0e8a13f24660961db908d657ef06177", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 54 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Role\AccessControl.cshtml"
 if (ViewBag.error != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Error\', \'");
#nullable restore
#line 54 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Role\AccessControl.cshtml"
                                                             Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'error\'); </script>");
#nullable restore
#line 54 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Role\AccessControl.cshtml"
                                                                                                      }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Role\AccessControl.cshtml"
 if (ViewBag.success != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Success\', \'");
#nullable restore
#line 55 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Role\AccessControl.cshtml"
                                                                 Write(ViewBag.success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'success\'); </script>");
#nullable restore
#line 55 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Role\AccessControl.cshtml"
                                                                                                              }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script type=""text/javascript"">
    (function () {
        var link = document.getElementById(""role-link"");
        if (link) link.classList.add(""active_link"");
    })();
    function loadRoleMenu() {
        var accessible_link = document.getElementById('accessible_link');
        if ($(""#RoleId option:selected"").val() !== '') {
            $.getJSON(""/Role/GetMenuByRoleId"", { roleId: $(""#RoleId option:selected"").val() },
                function (results) {
                    accessible_link.innerHTML = BuildDom(results.data);
                });
        }
        else {
            if (accessible_link) {
                accessible_link.innerHTML = ""<p>Select role first</p>"";
            }
        }
    }

    function BuildDom(data) {
        var dom = '';
        dom += '<table class=""table"">'+
                    '<thead>'+
                        '<tr>'+
                          '<th scope=""col"">Menu</th>'+
                          '<th scope=""col"">Liens</th>'+
            ");
            WriteLiteral(@"              '<th scope=""col"">Autoriser</th>'+
                        '</tr>'+
                    '</thead>'+
                    '<tbody>';
        for (var i = 0; i < data.length; i++) {
                dom += '<tr>'+
                            '<th scope=""row"">' + data[i].menuName + '</th>' +
                            '<td>' + data[i].linkModels[0].name + '</td>' +
                            '<td><input type=""checkbox"" ' + check(data[i].linkModels[0].cheked)+' /></td>'+
                '</tr>';
            for (var j = 1; j < data[i].linkModels.length; j++) {
                dom += '<tr>' +
                    '<th scope=""row""></th>' +
                    '<td>' + data[i].linkModels[j].name + '</td>' +
                    '<td><input type=""checkbox"" ' + check(data[i].linkModels[j].cheked) + ' /></td>' +
                    '</tr>';
            }
        }
        dom += '</tbody>' +
            '</table>';
        return dom;
    }

    function check(isChecked) {
        if ");
            WriteLiteral("(isChecked === true) return \'checked=\"checked\"\';\r\n        else if (isChecked === false) return \'unchecked=\"unchecked\"\';\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Telfair_Backend.Classes.Models.RoleAccessControlModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
