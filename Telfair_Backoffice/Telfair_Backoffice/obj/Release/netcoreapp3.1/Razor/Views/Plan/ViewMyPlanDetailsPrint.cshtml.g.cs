#pragma checksum "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a1ae3ad03b6dbc34f90f6113b9da1fe1de15fb5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Plan_ViewMyPlanDetailsPrint), @"mvc.1.0.view", @"/Views/Plan/ViewMyPlanDetailsPrint.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a1ae3ad03b6dbc34f90f6113b9da1fe1de15fb5", @"/Views/Plan/ViewMyPlanDetailsPrint.cshtml")]
    public class Views_Plan_ViewMyPlanDetailsPrint : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Telfair_Backend.Classes.Models.PlanModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/bower_components/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/bower_components/font-awesome/css/font-awesome.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/bower_components/Ionicons/css/ionicons.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/bower_components/jvectormap/jquery-jvectormap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/dist/css/AdminLTE.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/dist/css/skins/_all-skins.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hold-transition login-page"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
  
    ViewData["Title"] = "ViewPlan";

    Layout = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a1ae3ad03b6dbc34f90f6113b9da1fe1de15fb56302", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <title>SAIMLTD | Log in</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content=""width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"" name=""viewport"">
    <!-- Bootstrap 3.3.7 -->
    <link rel=""stylesheet"" href=""../../bower_components/bootstrap/dist/css/bootstrap.min.css"">
    <!-- Font Awesome -->
    <link rel=""stylesheet"" href=""../../bower_components/font-awesome/css/font-awesome.min.css"">
    <!-- Ionicons -->
    <link rel=""stylesheet"" href=""../../bower_components/Ionicons/css/ionicons.min.css"">
    <!-- Theme style -->
    <link rel=""stylesheet"" href=""../../dist/css/AdminLTE.min.css"">
    <!-- iCheck -->
    <link rel=""stylesheet"" href=""../../plugins/iCheck/square/blue.css"">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <");
                WriteLiteral(@"!--[if lt IE 9]>
    <script src=""https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js""></script>
    <script src=""https://oss.maxcdn.com/respond/1.4.2/respond.min.js""></script>
    <![endif]-->
    <!-- Google Font -->
    <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"">


    <!-- Bootstrap 3.3.7 -->
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2a1ae3ad03b6dbc34f90f6113b9da1fe1de15fb58059", async() => {
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
                WriteLiteral("\r\n    <!-- Font Awesome -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2a1ae3ad03b6dbc34f90f6113b9da1fe1de15fb59267", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- Ionicons -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2a1ae3ad03b6dbc34f90f6113b9da1fe1de15fb510471", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- jvectormap -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2a1ae3ad03b6dbc34f90f6113b9da1fe1de15fb511678", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- Theme style -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2a1ae3ad03b6dbc34f90f6113b9da1fe1de15fb512886", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- AdminLTE Skins. Choose a skin from the css/skins\r\n    folder instead of downloading all of them to reduce the load. -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2a1ae3ad03b6dbc34f90f6113b9da1fe1de15fb514200", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a1ae3ad03b6dbc34f90f6113b9da1fe1de15fb516100", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 56 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
     using (Html.BeginForm())
{


#line default
#line hidden
#nullable disable
                WriteLiteral("    <div id=\"Grid\" class=\"form-group has-feedback\">\r\n        <p><h1>Pre-Primary & Primary Weekly Plan</h1></p>\r\n        <table class=\"table\">\r\n            <tr>\r\n                <td>\r\n                    Date issued:  ");
#nullable restore
#line 64 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
                             Write(Convert.ToString(string.Format("{0:dd/MM/yyyy}", Model.ElementAt(0).DateOfIssue)));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td>\r\n                    Name of Teacher: ");
#nullable restore
#line 69 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
                                Write(Html.DisplayFor(modelItem => Model.ElementAt(0).EmployeeNames));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    Week: ");
#nullable restore
#line 72 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
                     Write(Html.DisplayFor(modelItem => Model.ElementAt(0).Week));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td>\r\n");
                WriteLiteral("                    From: ");
#nullable restore
#line 78 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
                     Write(Convert.ToString(string.Format("{0:dd/MM/yyyy}", Model.ElementAt(0).DateFrom)));

#line default
#line hidden
#nullable disable
                WriteLiteral(" To ");
#nullable restore
#line 78 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
                                                                                                        Write(Convert.ToString(string.Format("{0:dd/MM/yyyy}", Model.ElementAt(0).DateTo)));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n\r\n                    Class: ");
#nullable restore
#line 82 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
                      Write(Html.DisplayFor(modelItem => Model.ElementAt(0).NodeLevelName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td>\r\n                    Note: ");
#nullable restore
#line 88 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
                     Write(Html.DisplayFor(modelItem => Model.ElementAt(0).Note));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    Term: ");
#nullable restore
#line 91 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
                     Write(Html.DisplayFor(modelItem => Model.ElementAt(0).Term));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n            </tr>\r\n        </table>\r\n\r\n\r\n        <table class=\"table\">\r\n            <tr>\r\n                <th>\r\n                    Lesson Titles\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 103 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
               Write(Html.DisplayNameFor(model => model.Aims));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 106 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
               Write(Html.DisplayNameFor(model => model.Activities));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 109 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
               Write(Html.DisplayNameFor(model => model.Materials));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 112 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
               Write(Html.DisplayNameFor(model => model.Method));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 115 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
               Write(Html.DisplayNameFor(model => model.OutcomesNotes));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>Date</th>\r\n            </tr>\r\n\r\n");
#nullable restore
#line 120 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
             foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 124 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
               Write(Html.DisplayFor(modelItem => item.LessonName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 127 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
               Write(Html.DisplayFor(modelItem => item.Aims));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 130 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
               Write(Html.DisplayFor(modelItem => item.Activities));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 133 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
               Write(Html.DisplayFor(modelItem => item.Materials));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 136 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
               Write(Html.DisplayFor(modelItem => item.Method));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 139 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
               Write(Html.DisplayFor(modelItem => item.OutcomesNotes));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
                WriteLiteral("                    From: ");
#nullable restore
#line 143 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
                     Write(Convert.ToString(string.Format("{0:dd/MM/yyyy}", item.DateFrom)));

#line default
#line hidden
#nullable disable
                WriteLiteral(" To ");
#nullable restore
#line 143 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
                                                                                          Write(Convert.ToString(string.Format("{0:dd/MM/yyyy}", item.DateTo)));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 146 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n        </table>\r\n    </div>\r\n");
#nullable restore
#line 153 "C:\SAIM\TELFAIR\Telfair_Backoffice\Telfair_Backoffice\Telfair_Backoffice\Views\Plan\ViewMyPlanDetailsPrint.cshtml"
                                                                             

    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <!-- /.login-box -->
    <!-- jQuery 3 -->
    <script src=""../../bower_components/jquery/dist/jquery.min.js""></script>
    <!-- Bootstrap 3.3.7 -->
    <script src=""../../bower_components/bootstrap/dist/js/bootstrap.min.js""></script>
    <!-- iCheck -->
    <script src=""../../plugins/iCheck/icheck.min.js""></script>
    <script type=""text/javascript"" src=""https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
    
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n \r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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