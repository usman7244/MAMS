#pragma checksum "C:\Users\Admin\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Graphs\UserSelectionGraph.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1174ea5f5b102ff71cb387d3a8e2f62770e5d5b8e5aa7817f37a58e058fa1590"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Graphs_UserSelectionGraph), @"mvc.1.0.view", @"/Views/Graphs/UserSelectionGraph.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\usman7244\MAMS\MAMS\MAMS\Views\_ViewImports.cshtml"
using MAMS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\usman7244\MAMS\MAMS\MAMS\Views\_ViewImports.cshtml"
using MAMS.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\source\repos\usman7244\MAMS\MAMS\MAMS\Views\_ViewImports.cshtml"
using MAMS_Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"1174ea5f5b102ff71cb387d3a8e2f62770e5d5b8e5aa7817f37a58e058fa1590", @"/Views/Graphs/UserSelectionGraph.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"ef334624d63a4a377201f1b11d23227a9e30c3f5c4a7bac670a801724be296cd", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Graphs_UserSelectionGraph : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/flatpickr/flatpickr.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/flatpickr/flatpickr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/canvas.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 3 "C:\Users\Admin\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Graphs\UserSelectionGraph.cshtml"
  
    ViewData["Title"] = "Graph";


#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1174ea5f5b102ff71cb387d3a8e2f62770e5d5b8e5aa7817f37a58e058fa15905440", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1174ea5f5b102ff71cb387d3a8e2f62770e5d5b8e5aa7817f37a58e058fa15906578", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<!-- #region Select start and end date --> 
<div class=""card"">
    <div class=""card-header card-header-primary"">
        <i class=""material-icons"">search</i>
        <h5 class=""card-title""> Search</h5>
    </div>
    <div class=""card-body"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1174ea5f5b102ff71cb387d3a8e2f62770e5d5b8e5aa7817f37a58e058fa15907908", async() => {
                WriteLiteral(@"
            <div class=""row"">
                <div class=""col-md-3 col-sm-3"">
                    <div class=""form-group"">
                        <label class=""control-label bold"" for=""FromDate"" id=""lblFromDate"">Start Date</label>
                        <input type=""text"" id=""FromDate"" class=""form-control form-control-inline date-picker""");
                BeginWriteAttribute("value", "\r\n                               value=\"", 776, "\"", 816, 0);
                EndWriteAttribute();
                WriteLiteral(@" title=""Enter From Date"" />
                    </div>
                </div>
                <div class=""col-md-3 col-sm-3"">
                    <div class=""form-group"">
                        <label class=""control-label bold"" for=""ToDate"" id=""lblToDate"">End Date</label>
                        <input type=""text"" id=""ToDate"" class=""form-control form-control-inline date-picker""");
                BeginWriteAttribute("value", "\r\n                               value=\"", 1204, "\"", 1244, 0);
                EndWriteAttribute();
                WriteLiteral(@" title=""Enter To Date"" />
                    </div>
                </div>
                <div class=""col-md-4 col-sm-4"">
                    <button type=""submit"" class=""btn btn-primary pull-left"">Update Profile</button>
                    <div class=""clearfix""></div>
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
</div>
            


<!-- #endregion -->
<!-- #region  date selection Graph  -->
<div class=""row"" style="" margin-bottom: 10%;"">
    <div class=""col-lg-12 col-md-12 col-sm-12"">
        <div class=""card "">
            <div class=""card-header card-header-primary"">
                <i class=""material-icons"">signal_cellular_alt</i>
                <h5 class=""card-title"">Profit/Loss in Graph</h5>
");
            WriteLiteral(@"            </div>
            <div class=""card-body"">
                <div class=""table-responsive"" style=""height:480px; overflow:hidden; "">
                    <div class=""row"">
                        <div class=""col-md-12"">
                            <!-- BEGIN CHART PORTLET-->
                            <div class=""portlet light bordered"">
                                <div class=""portlet-title"">
                                    <div class=""caption"">
                                        <i class=""icon-bar-chart font-green-haze""></i>
                                    </div>
                                    <div class=""tools"">
                                        <a href=""javascript:;"" class=""reload""> </a>
                                    </div>
                                </div>
                                <div class=""portlet-body"">
                                    <div id=""chartContainer"" style=""height: 480px; width: 100%;""></div>
                         ");
            WriteLiteral(@"       </div>
                            </div>
                            <!-- END CHART PORTLET-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- #endregion -->
<!-- #region Links JavaScript Section -->
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1174ea5f5b102ff71cb387d3a8e2f62770e5d5b8e5aa7817f37a58e058fa159012606", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("<!-- #endregion -->\r\n<!-- #region JQuery Methods -->\r\n<script type=\"text/javascript\">\r\n    window.onload = function () {\r\n        \r\n");
            WriteLiteral(@"        var cars = [];
        cars.push({ ""label"": ""1 Weak"", ""y"": 8 });
        cars.push({ ""label"": ""2 Weak"", ""y"": 7 });
        cars.push({ ""label"": ""3 Weak"", ""y"": 12 });
        cars.push({ ""label"": ""4 Weak"", ""y"": 3 });
        cars.push({ ""label"": ""1 Weak"", ""y"": 8 });
        cars.push({ ""label"": ""2 Weak"", ""y"": 7 });
        cars.push({ ""label"": ""3 Weak"", ""y"": 12 });
        cars.push({ ""label"": ""4 Weak"", ""y"": 3 });
        var options = {
            animationEnabled: true,
            title: {
                //text: ""profit Percent"",
                text: ""profit Percent by month"",
                fontSize: 25,
            },
            axisY: {
                title: ""Weekly (in %)"",
                suffix: ""%""
            },
            axisX: {
                interval: 1,
                title: ""Weeks"",
                //titleFontSize: 40
            },
            dataPointWidth: 60,
            data: [{
                type: ""column"",
                yValueFormatStri");
            WriteLiteral(@"ng: ""#,##0.0#"" % """",
                dataPoints: cars
            }
            //,{
            //    type: ""spline"",
            //    yValueFormatString: ""#,##0.0#"" % """",
            //    dataPoints: cars
            //}
            ]
        };
        $(""#chartContainer"").CanvasJSChart(options);

    }
    flatpickr('#FromDate', {
        altInput: true,
        altFormat: ""F j, Y"",
        dateFormat: ""Y-m-d"",
        defaultDate: ""today""
    });
    flatpickr('#ToDate', {
        altInput: true,
        altFormat: ""F j, Y"",
        dateFormat: ""Y-m-d"",
        defaultDate: ""today""
    });
</script>
<!-- #endregion -->

<style>
        .card-header.card-header-primary {
            background: linear-gradient( 60deg, #00acc1, #00acc1) !important;
        }

        i.material-icons {
            float: left;
        }

        a.canvasjs-chart-credit {
            display: none;
        }

        .portlet > .portlet-title > .caption > .caption-helper {
       ");
            WriteLiteral(@"     font-size: 16px !important;
        }
        /* .card-icon {
        height: 66px;
        width: 71px;
        padding: 6px !important;
    } */
        .card.card-stats {
            margin-top: 0px !important;
        }

        ul.nav.nav-tabs {
            border-bottom: 0px;
        }

        button.btn.btn-primary.pull-left {
            background-color: #088c9c;
            border-color: #00acc1;
        }
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
