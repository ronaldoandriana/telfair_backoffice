#pragma checksum "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5cd925c0186c29a152ab7dcd5aec73e6a474e98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Department_ViewDepartment), @"mvc.1.0.view", @"/Views/Department/ViewDepartment.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5cd925c0186c29a152ab7dcd5aec73e6a474e98", @"/Views/Department/ViewDepartment.cshtml")]
    public class Views_Department_ViewDepartment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Telfair_Backend.Classes.Models.NodeModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "View Department";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <!-- left column -->
<div class=""col-md-12"">
    <!-- general form elements -->
    <div class=""box box-primary"">
        <div class=""box-header with-border"">
            <h3 class=""box-title"">View Department</h3>
        </div>
        <div id=""Grid"">

            <table class=""table"">
                <tr>
                    <th>
                        ");
#nullable restore
#line 22 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
                   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 25 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
                   Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n\r\n");
#nullable restore
#line 30 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 34 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 37 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1220, "\"", 1255, 2);
            WriteAttributeValue("", 1227, "/Department/Edit?id=", 1227, 20, true);
#nullable restore
#line 40 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
WriteAttributeValue("", 1247, item.Id, 1247, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                            <a href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1308, "\"", 1340, 3);
            WriteAttributeValue("", 1318, "deleteUser(\'", 1318, 12, true);
#nullable restore
#line 41 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
WriteAttributeValue("", 1330, item.Id, 1330, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1338, "\')", 1338, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 44 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n            <nav aria-label=\"Page navigation example\">\r\n                <ul class=\"pagination justify-content-center\">\r\n                    ");
#nullable restore
#line 48 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
                Write(new Microsoft.AspNetCore.Html.HtmlString(ViewBag.pagination));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </ul>\r\n            </nav>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 54 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"




}

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
 if (ViewBag.error != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Error\', \'");
#nullable restore
#line 59 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
                                                             Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'error\'); </script> ");
#nullable restore
#line 59 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
                                                                                                       }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
 if (ViewBag.success != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Success\', \'");
#nullable restore
#line 60 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
                                                                 Write(ViewBag.success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'success\'); </script> ");
#nullable restore
#line 60 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Department\ViewDepartment.cshtml"
                                                                                                               }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    (function () {
        var link = document.getElementById(""department-link"");
        if (link) link.classList.add(""active_link"");
    })();
</script>

<script type=""text/javascript"">
    function deleteUser(id) {
        if (confirm(""Do you want to delete this item?"")) {
            window.location.href = ""/Department/Delete/"" + id;
        }
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Telfair_Backend.Classes.Models.NodeModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
