#pragma checksum "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3717cb2cef5b4c9db5a60e69ead98d06c844a562"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Blog), @"mvc.1.0.view", @"/Views/Blog/Blog.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3717cb2cef5b4c9db5a60e69ead98d06c844a562", @"/Views/Blog/Blog.cshtml")]
    public class Views_Blog_Blog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Telfair_Backend.Classes.Models.BlogModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
  
    ViewData["Title"] = ViewBag.title;
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
 using (Html.BeginForm("SaveBlog", "Blog", FormMethod.Post, new { enctype = "multipart/form-data", data_ajax = "false"

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                                                                                                                                                                                          }))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <!-- left column -->\r\n    <div class=\"col-md-12\">\r\n        <!-- general form elements -->\r\n        <div class=\"box box-primary\">\r\n            <div class=\"box-header with-border\">\r\n                <h3 class=\"box-title\">");
#nullable restore
#line 15 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                                 Write(ViewBag.title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
            </div>
            <div class=""box-body"">

                <div class=""row"">
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <div class=""form-group has-feedback"">
                                ");
#nullable restore
#line 23 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                           Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 24 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                           Write(Html.HiddenFor(m => m.MyId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 25 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                           Write(Html.HiddenFor(m => m.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 26 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                           Write(Html.HiddenFor(m => m.ModifiedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 27 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                           Write(Html.HiddenFor(m => m.ModifiedOn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 28 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                           Write(Html.LabelFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 29 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                           Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 32 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                           Write(Html.LabelFor(m => m.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 33 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                           Write(Html.TextAreaFor(m => m.Description, new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"form-group has-feedback\">\r\n                                ");
#nullable restore
#line 36 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                           Write(Html.LabelFor(m => m.ExpiryDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("                                <input class=\"form-control\" data-val=\"true\" data-val-required=\"The DateFrom field is required.\" id=\"ExpiryDate\"");
            BeginWriteAttribute("min", " min=\"", 2077, "\"", 2123, 1);
#nullable restore
#line 38 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
WriteAttributeValue("", 2083, DateTime.Now.ToString("MM'/'dd'/'yyyy"), 2083, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"ExpiryDate\" required=\"required\" type=\"date\"");
            BeginWriteAttribute("value", " value=\"", 2174, "\"", 2235, 1);
#nullable restore
#line 38 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
WriteAttributeValue("", 2182, DateTime.Now.AddDays(5).ToString("yyyy'-'MM'-'dd"), 2182, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral(@"    <div class=""col-md-12"">
        <!-- general form elements -->
        <div class=""box-footer"">
            <div class=""row"" align=""right"">
                <div class=""btn-group"">
                    <button id=""btnSubmit"" type=""submit"" class=""btn btn-info"">SAVE</button>
                    <button type=""button"" onclick=""cancel()"" class=""btn btn-info"">CANCEL</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 59 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    function cancel() {
        window.location.href = ""/Blog/ViewBlog"";
    }
</script>
<script>
    (function () {
        var link = document.getElementById(""blog-link"");
        if (link) link.classList.add(""active_link"");
    })();
</script>


");
#nullable restore
#line 75 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
 if (ViewBag.error != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Error\', \'");
#nullable restore
#line 75 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                                                             Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'error\'); </script> ");
#nullable restore
#line 75 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                                                                                                       }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
 if (ViewBag.success != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Success\', \'");
#nullable restore
#line 76 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
                                                                 Write(ViewBag.success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'success\'); </script> ");
#nullable restore
#line 76 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Blog\Blog.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Telfair_Backend.Classes.Models.BlogModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
