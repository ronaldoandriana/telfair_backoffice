#pragma checksum "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da3a98ff5288d5d977b24bb6a46929ee508c8403"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Plan_ViewPlan), @"mvc.1.0.view", @"/Views/Plan/ViewPlan.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da3a98ff5288d5d977b24bb6a46929ee508c8403", @"/Views/Plan/ViewPlan.cshtml")]
    public class Views_Plan_ViewPlan : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Telfair_Backend.Classes.Models.PlanModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "ViewPlan";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div id=""x"">
    <div id=""y"">
        <input type=""hidden"" id=""GridHtml"" name=""GridHtml"" />
    </div>
    <div id=""Grid"">


        <table class=""table"">
            <tr>
                <th>
                    Lesson Title
                </th>
                <th>
                    ");
#nullable restore
#line 24 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
               Write(Html.DisplayNameFor(model => model.Aims));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 27 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
               Write(Html.DisplayNameFor(model => model.Activities));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 30 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
               Write(Html.DisplayNameFor(model => model.Materials));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 33 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
               Write(Html.DisplayNameFor(model => model.Method));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 36 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
               Write(Html.DisplayNameFor(model => model.OutcomesNotes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 39 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
               Write(Html.DisplayNameFor(model => model.DateFrom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 42 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
               Write(Html.DisplayNameFor(model => model.DateTo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n            </tr>\r\n\r\n");
#nullable restore
#line 46 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 50 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
                   Write(Html.DisplayFor(modelItem => item.LessonName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 53 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Aims));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 56 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Activities));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Materials));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Method));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
                   Write(Html.DisplayFor(modelItem => item.OutcomesNotes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DateFrom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 71 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DateTo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 74 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n        </table>\r\n        <nav aria-label=\"Page navigation example\">\r\n            <ul class=\"pagination justify-content-center\">\r\n                ");
#nullable restore
#line 81 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
            Write(new Microsoft.AspNetCore.Html.HtmlString(ViewBag.pagination));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </ul>\r\n        </nav>\r\n    </div>\r\n    <button type=\"submit\" id=\"btnSubmit\" class=\"btn btn-info\">Export</button>\r\n    <button type= \"button\" id=\"testbtn\" class=\"btn btn-info\">test</button>\r\n</div>\r\n");
            WriteLiteral(@"    <script type=""text/javascript"" src=""https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
    <script type=""text/javascript"">
        $(""#btnSubmit"").click(function abc() {

            var html = $(""#Grid"").html();

            // document.getElementById(""GridHtml"") = html;

            data = {
                PdfHtmlTemplate: html
            };

            $.ajax({
                url: '");
#nullable restore
#line 102 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
                 Write(Url.Action("BuildIronPDFURL", "Plan"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', //
                data: data,
                type: ""POST"",
                contentType: ""application/json; charset=utf-8"",
                success: function (result) {
                    //do something
                }
            });

        });

        $(""#testbtn"").click(function abc2() {

            var html = $(""#Grid"").html();
            $(""#GridHtml"").val(html);
            alert(html);
        });
    </script>
");
#nullable restore
#line 120 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewPlan.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Telfair_Backend.Classes.Models.PlanModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
