#pragma checksum "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fe69fe231f08598d17697f0ada976daee7cd8ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HomeWork_ViewFile), @"mvc.1.0.view", @"/Views/HomeWork/ViewFile.cshtml")]
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
#line 1 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
using Telfair_Backend.Classes.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
using Telfair_Backend.Classes.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fe69fe231f08598d17697f0ada976daee7cd8ff", @"/Views/HomeWork/ViewFile.cshtml")]
    public class Views_HomeWork_ViewFile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("download", new global::Microsoft.AspNetCore.Html.HtmlString("download"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height: 20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "View Attachment";
    List<Attachments> related_attachments = new List<Attachments>();
    if (ViewBag.relatedFile != null)
    {
        related_attachments = ViewBag.relatedFile as List<Attachments>;
    }
    Attachments attachment = null;
    if (ViewBag.file != null)
    {
        attachment = ViewBag.file as Attachments;
    }
    string url = "";
    if(ViewBag.url != null)
    {
        url = ViewBag.url;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@" <!-- left column -->
    <div class=""col-md-12"">
        <!-- general form elements -->
        <div class=""box box-primary"">
            <div class=""box-header with-border"">
                <h3 class=""box-title"">View Attachment</h3>
            </div>
");
#nullable restore
#line 30 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
             if (attachment != null && attachment.Status == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div id=\"Grid\">\r\n                    <p>File name: <b>");
#nullable restore
#line 33 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
                                Write(attachment.FileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                    <p>File type: <b>");
#nullable restore
#line 34 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
                                Write(attachment.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                    <p>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fe69fe231f08598d17697f0ada976daee7cd8ff6093", async() => {
                WriteLiteral("<i class=\"fa fa-download\"> Download</i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1113, "~/", 1113, 2, true);
#nullable restore
#line 35 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
AddHtmlAttributeValue("", 1115, attachment.FilePath, 1115, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</p>\r\n                    <div class=\"row\">\r\n                        <div class=\"col-md-12\">\r\n");
#nullable restore
#line 38 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
                             if (!string.IsNullOrEmpty(url) && (url.ToLower().Contains("://localhost") || url.ToLower().Contains("://127.0.0.1")))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <embed");
            BeginWriteAttribute("src", " src=\"", 1527, "\"", 1554, 2);
            WriteAttributeValue("", 1533, "/", 1533, 1, true);
#nullable restore
#line 40 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
WriteAttributeValue("", 1534, attachment.FilePath, 1534, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100%\" height=\"600px\"></embed>\r\n");
#nullable restore
#line 41 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
                            }
                            else if (attachment.Type.Equals("mp4") || attachment.Type.Equals("jpg"))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <embed");
            BeginWriteAttribute("src", " src=\"", 1796, "\"", 1823, 2);
            WriteAttributeValue("", 1802, "/", 1802, 1, true);
#nullable restore
#line 44 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
WriteAttributeValue("", 1803, attachment.FilePath, 1803, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100%\" height=\"600px\"></embed>\r\n");
#nullable restore
#line 45 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
                            }
                            else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <iframe");
            BeginWriteAttribute("src", " src=\"", 1969, "\"", 2053, 5);
            WriteAttributeValue("", 1975, "https://docs.google.com/viewer?url=", 1975, 35, true);
#nullable restore
#line 47 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
WriteAttributeValue("", 2010, url, 2010, 6, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2016, "/", 2016, 1, true);
#nullable restore
#line 47 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
WriteAttributeValue("", 2017, attachment.FilePath, 2017, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2039, "&embedded=true", 2039, 14, true);
            EndWriteAttribute();
            WriteLiteral(" width=\'100%\' height=\'600px\' frameborder=\'0\'></iframe>\r\n");
#nullable restore
#line 48 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 52 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div id=\"Grid\">\r\n                    <p><i>This attachment is no longer available. Maybe it is deleted.</i></p>\r\n                </div>\r\n");
#nullable restore
#line 58 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n");
#nullable restore
#line 62 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
 if (related_attachments.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-12\">\r\n        <div class=\"box box-primary\">\r\n            <div class=\"box-header with-border\">\r\n                <h3 class=\"box-title\">Related files</h3>\r\n            </div>\r\n            <div id=\"Grid\">\r\n");
#nullable restore
#line 70 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
                 foreach (Attachments file in related_attachments)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7fe69fe231f08598d17697f0ada976daee7cd8ff12912", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2874, "~/icons/", 2874, 8, true);
#nullable restore
#line 72 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
AddHtmlAttributeValue("", 2882, file.Type + ".png", 2882, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 72 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
                                                                                    Write(file.FileName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span style=\"float: right;\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fe69fe231f08598d17697f0ada976daee7cd8ff14857", async() => {
                WriteLiteral("<i class=\"fa fa-download\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2960, "~/", 2960, 2, true);
#nullable restore
#line 72 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
AddHtmlAttributeValue("", 2962, file.FilePath, 2962, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" &nbsp;&nbsp;&nbsp; <a");
            BeginWriteAttribute("href", " href=\"", 3070, "\"", 3111, 2);
            WriteAttributeValue("", 3077, "/HomeWork/ViewFile?fileId=", 3077, 26, true);
#nullable restore
#line 72 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
WriteAttributeValue("", 3103, file.Id, 3103, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span><i class=\"fa fa-eye\"></i></span></a></span></p>\r\n");
#nullable restore
#line 73 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 77 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>\r\n    (function () {\r\n        var link = document.getElementById(\"homework-link\");\r\n        if (link) link.classList.add(\"active_link\");\r\n    })();\r\n</script>\r\n\r\n\r\n");
#nullable restore
#line 87 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
 if (ViewBag.error != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Error\', \'");
#nullable restore
#line 87 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
                                                             Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'error\'); </script> ");
#nullable restore
#line 87 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
                                                                                                       }

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
 if (ViewBag.success != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <script> showNotification(\'Success\', \'");
#nullable restore
#line 88 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
                                                                 Write(ViewBag.success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'success\'); </script> ");
#nullable restore
#line 88 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\HomeWork\ViewFile.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591