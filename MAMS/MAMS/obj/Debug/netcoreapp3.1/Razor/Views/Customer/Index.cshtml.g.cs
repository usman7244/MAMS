#pragma checksum "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6dd61d4fd33141a29f51fa2e2144ba016c5b4c368f1f67631b112df4eee726f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Index), @"mvc.1.0.view", @"/Views/Customer/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\_ViewImports.cshtml"
using MAMS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\_ViewImports.cshtml"
using MAMS.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\_ViewImports.cshtml"
using MAMS_Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"6dd61d4fd33141a29f51fa2e2144ba016c5b4c368f1f67631b112df4eee726f4", @"/Views/Customer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"ef334624d63a4a377201f1b11d23227a9e30c3f5c4a7bac670a801724be296cd", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Customer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MAMS_Models.Model.Customer>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ToolTip.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "NewCustomerAdd", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-left: 10px;  font-size: 11px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CustomerEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(" btn btn-circle btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
  
    ViewData["Title"] = "Customer";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6dd61d4fd33141a29f51fa2e2144ba016c5b4c368f1f67631b112df4eee726f46187", async() => {
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
            WriteLiteral(@"

<!-- #region  Customer List  -->
<div id=""divDetails"" class=""col-md-12 col-sm-12"">
    <div class=""card "">
        <div class=""card-header card-header-primary"">
            <h5 class=""card-title""><i class=""material-icons"" style=""vertical-align: sub;"">people_alt</i> Customer List</h5>
");
            WriteLiteral("        </div>\r\n        <div class=\"card-body\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6dd61d4fd33141a29f51fa2e2144ba016c5b4c368f1f67631b112df4eee726f47653", async() => {
                WriteLiteral(" <i class=\"material-icons\" style=\"vertical-align: middle;\">person_add</i> Add Customer");
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
            <div class=""table-responsive"" style=""height:600px"">
                <table class=""table"" id=""tblDetailList"">
                    <thead class="" text-primary"">
                        <tr>
                            <th width=""3%"" tabindex=""0"" class=""bold"" aria-controls=""tblDetailList"" rowspan=""1""
                                colspan=""1"">
                                # &nbsp;
                            </th>
                            <th width=""10%"" tabindex=""0"" class=""bold""
                                arial-sort=""descending"" aria-controls=""tblDetailList"" rowspan=""1"" colspan=""1"">
                                Name
                            </th>
                            <th width=""10%"" tabindex=""0"" class=""bold""
                                arial-sort=""descending"" aria-controls=""tblDetailList"" rowspan=""1"" colspan=""1"">
                                Phone
                            </th>
                            <th width=""10%"" tabindex=""0"" class=""bold""
            WriteLiteral(@"
                                arial-sort=""descending"" aria-controls=""tblDetailList"" rowspan=""1"" colspan=""1"">
                                CNIC
                            </th>
                            <th width=""10%"" tabindex=""0"" class=""bold""
                                arial-sort=""descending"" aria-controls=""tblDetailList"" rowspan=""1"" colspan=""1"">
                                Type
                            </th>
                            <th width=""10%"" tabindex=""0"" class=""bold""
                                arial-sort=""descending"" aria-controls=""tblDetailList"" rowspan=""1"" colspan=""1"">
                                Shop Name
                            </th>
                            <th width=""10%"" tabindex=""0"" class=""bold""
                                arial-sort=""descending"" aria-controls=""tblDetailList"" rowspan=""1"" colspan=""1"">
                                City
                            </th>
                            <th width=""10%"" tabindex=""0"" class=""b");
            WriteLiteral(@"old""
                                arial-sort=""descending"" aria-controls=""tblDetailList"" rowspan=""1"" colspan=""1"">
                                Created Date
                            </th>
                            <th width=""10%"" tabindex=""0"" class=""bold""
                                arial-sort=""descending"" aria-controls=""tblDetailList"" rowspan=""1"" colspan=""1"">
                                Created By
                            </th>
                            <th width=""10%"" tabindex=""0"" class=""sorting bold"" aria-controls=""tblDetailList"" rowspan=""1"" colspan=""1""> Actions&nbsp;&nbsp;&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 61 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                          
                            int num = 1;
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\"> &nbsp;");
#nullable restore
#line 67 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                                                                                                                                     Write(num);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\" style=\"display:none;\"> &nbsp;");
#nullable restore
#line 68 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                                                                                                                                                           Write(item.UID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\"> &nbsp;");
#nullable restore
#line 69 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                                                                                                                                     Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\"> &nbsp;");
#nullable restore
#line 70 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                                                                                                                                     Write(item.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\"> &nbsp;");
#nullable restore
#line 71 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                                                                                                                                     Write(item.CNIC);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\"> &nbsp;");
#nullable restore
#line 72 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                                                                                                                                     Write(item.CusType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\"> &nbsp;");
#nullable restore
#line 73 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                                                                                                                                     Write(item.ComShopName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\"> &nbsp;");
#nullable restore
#line 74 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                                                                                                                                     Write(item.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\"> &nbsp;");
#nullable restore
#line 75 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                                                                                                                                     Write(item.CreatedDate.ToString("dd/M/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"tblDetailList\" rowspan=\"1\" colspan=\"1\"> &nbsp;");
#nullable restore
#line 76 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                                                                                                                                     Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td width=\"10%\" tabindex=\"0\" class=\"sorting\" aria-controls=\"datatable_orders\" rowspan=\"1\" colspan=\"1\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6dd61d4fd33141a29f51fa2e2144ba016c5b4c368f1f67631b112df4eee726f418136", async() => {
                WriteLiteral("<i class=\"fa fa-edit\" data-toggle=\"tooltip\" data-placement=\"bottom\" title=\"Edit Customer\"></i>");
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
#line 78 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
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
            WriteLiteral("\r\n                                    <a class=\"btn btn-circle btn-sm\" name=\"btnDel\"");
            BeginWriteAttribute("id", " id=\"", 5825, "\"", 5839, 1);
#nullable restore
#line 79 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
WriteAttributeValue("", 5830, item.UID, 5830, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-trash\" data-toggle=\"tooltip\" data-placement=\"bottom\" title=\"Delete Customer\"></i></a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 82 "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Customer\Index.cshtml"
                            num++;
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
<!-- #endregion -->
<!-- #region  alert -->
<div id=""alertSuccess"" data-notify=""container"" class=""col-11 col-md-4 alert alert-success alert-with-icon animated fadeInDown"" role=""alert"" data-notify-position=""top-center"" style=""display: inline-block; margin: 15px auto; position: fixed; transition: all 0.5s ease-in-out 0s; z-index: 1031; top: 20px; left: 0px; right: 0px;"">
    <button type=""button"" aria-hidden=""true"" class=""close"" data-notify=""dismiss"" style=""position: absolute; right: 10px; top: 50%; margin-top: -9px; z-index: 1033;"">
        <i class=""material-icons"">close</i>
    </button><i data-notify=""icon"" class=""material-icons"">add_alert</i><span data-notify=""title""></span> <span data-notify=""message""><b>Customer</b> <br>Customer Delete successfuly!</span>
    <a");
            BeginWriteAttribute("href", " href=\"", 6976, "\"", 6983, 0);
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\" data-notify=\"url\"></a>\r\n</div>\r\n<!-- #region Scripts -->\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n   \r\n\r\n");
            }
            );
            WriteLiteral(@"<!-- #endregion -->
<!-- #region   javascript -->
<script type=""text/javascript"">
    $(""#alertSuccess"").hide();
    $(""#alertDanger"").hide();
    $(document).ready(function () {
        $('[data-toggle=""tooltip""]').tooltip();
        $(""#tblDetailList"").on('click', ""a[name='btnDel']"", function () {

            var uId = $.trim($(this).closest('tr').find(""td:eq(1)"").text());
            $.confirm({

                theme: 'modern',
                title: 'DELETE!',
                content: 'Are you sure you want to delete?',
                type: 'green',
                typeAnimated: true,
                buttons:
                {
                    tryAgain:
                    {
                        text: 'No',
                        btnClass: 'btn-green',
                    },
                    warning:
                    {
                        text: 'Yes',
                        btnClass: 'btn-blue',
                        action: function () {

             ");
            WriteLiteral(@"               $.ajax({

                                type: ""post"",
                                url: ""/Customer/DeleteCustomer"",
                                data: { cusId: uId },
                                success: function (data) {
                                    console.log(data);

                                    $('#alertSuccess').show();
                                    setTimeout(function () {
                                        window.location.href = '/Customer/Index';
                                    }, 2000);
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
<!-- #endregion --");
            WriteLiteral(">\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MAMS_Models.Model.Customer>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591