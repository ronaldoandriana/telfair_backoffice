#pragma checksum "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9290f473f71ca92df415af2d666188fa6471880e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Department_Department), @"mvc.1.0.view", @"/Views/Department/Department.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9290f473f71ca92df415af2d666188fa6471880e", @"/Views/Department/Department.cshtml")]
    public class Views_Department_Department : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Telfair_Backend.Classes.Models.NodeModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Department";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
 using (Html.BeginForm("SaveDepartment", "Department", FormMethod.Post, new { enctype = "multipart/form-data", data_ajax = "false"

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
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
                <h3 class=""box-title"">Add new department</h3>
            </div>
            <div class=""box-body"">

                <div class=""row"">
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <div class=""form-group has-feedback"">
                                ");
#nullable restore
#line 23 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
                           Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 24 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
                           Write(Html.HiddenFor(m => m.MyId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 25 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
                           Write(Html.HiddenFor(m => m.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 26 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
                           Write(Html.LabelFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 27 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
                           Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 30 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
                           Write(Html.LabelFor(m => m.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 31 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
                           Write(Html.TextBoxFor(m => m.Description, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div>\r\n                                ");
#nullable restore
#line 34 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
                           Write(Html.HiddenFor(m => m.NodeTypeId, new { id = "NodeTypeId" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n\r\n\r\n");
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral(@"    <div class=""col-md-12"">
        <!-- general form elements -->
        <div class=""box-footer"">
            <div class=""row"" align=""right"">
                <div class=""btn-group"">
                    <button id=""btnSubmit"" type=""submit"" class=""btn btn-info"">SAVE</button>
                    <a href=""/Department/ViewDepartment""><button type=""button"" class=""btn btn-info"">CANCEL</button></a>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 62 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 65 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
 if (ViewBag.error != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Error\', \'");
#nullable restore
#line 65 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
                                                             Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'error\'); </script> ");
#nullable restore
#line 65 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
                                                                                                       }

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
 if (ViewBag.success != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Success\', \'");
#nullable restore
#line 66 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
                                                                 Write(ViewBag.success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'success\'); </script> ");
#nullable restore
#line 66 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\Department.cshtml"
                                                                                                               }

#line default
#line hidden
#nullable disable
            WriteLiteral("<script>\r\n    (function () {\r\n        var link = document.getElementById(\"department-link\");\r\n        if (link) link.classList.add(\"active_link\");\r\n    })();\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Telfair_Backend.Classes.Models.NodeModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
