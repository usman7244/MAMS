#pragma checksum "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\Crop\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c587830a3935307fa2a893acb49c98c5104e4ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Crop_Index), @"mvc.1.0.view", @"/Views/Crop/Index.cshtml")]
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
#line 1 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\_ViewImports.cshtml"
using MAMS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\_ViewImports.cshtml"
using MAMS.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\_ViewImports.cshtml"
using MAMS_Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c587830a3935307fa2a893acb49c98c5104e4ea", @"/Views/Crop/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61d46c292f630bad82e0e912ebed5dbf5bbab2f0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Crop_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MAMS_Models.Model.Crop>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ToolTip.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CropAdd", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Crop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-left: 10px;  font-size: 11px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditCrop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(" btn btn-circle btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/confirm.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/confirm.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\Crop\Index.cshtml"
  
    ViewData["Title"] = "Crop";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c587830a3935307fa2a893acb49c98c5104e4ea6965", async() => {
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
            WriteLiteral("\r\n\r\n<!-- #region Crop Lis --> \r\n<div class=\"card \">\r\n    <div class=\"card-header card-header-primary\">\r\n        <h5 class=\"card-title\"><i class=\"fab fa-pagelines\"></i> Crops List</h5>\r\n");
            WriteLiteral("    </div>\r\n    <div class=\"card-body\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c587830a3935307fa2a893acb49c98c5104e4ea8291", async() => {
                WriteLiteral(" <i class=\"fas fa-leaf\"></i> Add Crop");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        <div class=""table-responsive"">
            <table class=""table"" id=""tblDetailList"">
                <thead class="" text-primary"">
                <th width=""3%"" tabindex=""0"" class=""bold"" aria-controls=""tblDetailList"" rowspan=""1""
                    colspan=""1"">
                    # &nbsp;
                </th>
                <th width=""15%"" tabindex=""0"" class=""bold""
                    arial-sort=""descending"" aria-controls=""tblDetailList"" rowspan=""1"" colspan=""1"">
                    Name
                </th>

                <th width=""10%"" tabindex=""0"" class=""bold""
                    arial-sort=""descending"" aria-controls=""tblDetailList"" rowspan=""1"" colspan=""1"">
                    Created Date
                </th>
                <th width=""5%"" tabindex=""0"" class=""bold""
                    arial-sort=""descending"" aria-controls=""tblDetailList"" rowspan=""1"" colspan=""1"">
                    Created By
                </th>
                <th width=""10%"" tabindex=""0"" class=""sor");
            WriteLiteral("ting bold\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\"> Actions&nbsp;&nbsp;&nbsp;</th>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 38 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\Crop\Index.cshtml"
                      
                        int num = 1;
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\Crop\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td width=\"3%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\"> &nbsp;");
#nullable restore
#line 44 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\Crop\Index.cshtml"
                                                                                                                                Write(num);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td width=\"5%\" tabindex=\"0\" class=\"sorting_1 id\" rowspan=\"1\" colspan=\"1\" style=\"display:none;\">");
#nullable restore
#line 45 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\Crop\Index.cshtml"
                                                                                                                      Write(item.UID);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp;</td>\r\n                            <td width=\"5%\" tabindex=\"0\" class=\"sorting_1\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\">");
#nullable restore
#line 46 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\Crop\Index.cshtml"
                                                                                                                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\">");
#nullable restore
#line 47 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\Crop\Index.cshtml"
                                                                                                                          Write(item.CreatedDate.ToString("dd/M/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\">");
#nullable restore
#line 48 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\Crop\Index.cshtml"
                                                                                                                          Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"datatable_orders\" rowspan=\"1\" colspan=\"1\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c587830a3935307fa2a893acb49c98c5104e4ea14184", async() => {
                WriteLiteral("<i class=\"fa fa-edit\" data-toggle=\"tooltip\" data-placement=\"bottom\" title=\"Edit Crop\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 50 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\Crop\Index.cshtml"
                                                                                 WriteLiteral(item.UID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                <a class=\"btn btn-circle btn-sm\" name=\"btnDel\"");
            BeginWriteAttribute("id", " id=\"", 3138, "\"", 3152, 1);
#nullable restore
#line 51 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\Crop\Index.cshtml"
WriteAttributeValue("", 3143, item.UID, 3143, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-trash\" data-toggle=\"tooltip\" data-placement=\"bottom\" title=\"Delete Crop\"></i></a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 54 "D:\Projects\MAMS_WEB\MAMS_WEB\MAMS\MAMS\Views\Crop\Index.cshtml"
                        num++;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- #endregion -->\r\n<!-- #region Scripts -->\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2c587830a3935307fa2a893acb49c98c5104e4ea17821", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c587830a3935307fa2a893acb49c98c5104e4ea19000", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral(@"<!-- #endregion -->
<!-- #region   javascript -->
<script type=""text/javascript"">
    $(document).ready(function () {
        $('[data-toggle=""tooltip""]').tooltip();
        $(""#tblDetailList"").on('click', ""a[name='btnDel']"", function () {
            
            var uId = $.trim($(this).closest('tr').find(""td:eq(1)"").text());
            $.confirm({
                theme: 'modern',//material modern
                title: 'DELETE!',
                content: 'Are you sure you want to delete Crop?',
                type: 'green',
                typeAnimated: true,
                buttons:
                {
                    tryAgain:
                    {
                        text: 'No',
                        btnClass: 'btn-green',
                    }, warning:
                    {
                        text: 'Yes',
                        btnClass: 'btn-blue',
                        action: function () {
                            
                            $.ajax({");
            WriteLiteral(@"
                                type: ""post"",
                                url: ""/Crop/DeleteCrop"",
                                data: { cropId: uId },
                                success: function (data) {
                                    
                                    if (data == 1) {
                                        location.reload();
                                    }
                                    else {
                                        alert(""Crop Delete faild"");
                                    }


                                }
                            });
                        }
                    }


                }
            });


        });

    });
</script>
<!-- #endregion -->
<!-- #region Style -->
<style>
    a.btn.btn-circle.btn-sm {
        border: 0px;
        background-color: rgb(204 204 204 / 15%);
        font-size: 10px;
        color: darkgreen;
        padding: 5px
    }
</style>
<!-- #en");
            WriteLiteral("dregion -->\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MAMS_Models.Model.Crop>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
