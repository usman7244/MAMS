#pragma checksum "C:\Users\zimal\source\repos\usman7244\MAMS\MAMS\MAMS\Views\Farmer\AccountDetail.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9a07c9bb24d279cba63282661e5bc2fae3e60a52a99b6ceeb7adf07ec158e43d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Farmer_AccountDetail), @"mvc.1.0.view", @"/Views/Farmer/AccountDetail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"9a07c9bb24d279cba63282661e5bc2fae3e60a52a99b6ceeb7adf07ec158e43d", @"/Views/Farmer/AccountDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"ef334624d63a4a377201f1b11d23227a9e30c3f5c4a7bac670a801724be296cd", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Farmer_AccountDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- #region Farmer detail form -->
<div class=""wrapper "">
    <div class=""content"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""card"">
                        <div class=""card-header card-header-primary"">
                            <h4 class=""card-title"">Edit Profile</h4>
                        </div>
                        <div class=""card-body"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a07c9bb24d279cba63282661e5bc2fae3e60a52a99b6ceeb7adf07ec158e43d4107", async() => {
                WriteLiteral(@"
                                <div class=""row"">
                                    <div class=""col-md-5"">
                                        <div class=""form-group"">
                                            <label class=""bmd-label-floating"">Company (disabled)</label>
                                            <input type=""text"" class=""form-control"" >
                                        </div>
                                    </div>
                                    <div class=""col-md-3"">
                                        <div class=""form-group"">
                                            <label class=""bmd-label-floating"">Username</label>
                                            <input type=""text"" class=""form-control"">
                                        </div>
                                    </div>
                                    <div class=""col-md-4"">
                                        <div class=""form-group"">
                                  ");
                WriteLiteral(@"          <label class=""bmd-label-floating"">Email address</label>
                                            <input type=""email"" class=""form-control"">
                                        </div>
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-md-6"">
                                        <div class=""form-group"">
                                            <label class=""bmd-label-floating"">Fist Name</label>
                                            <input type=""text"" class=""form-control"">
                                        </div>
                                    </div>
                                    <div class=""col-md-6"">
                                        <div class=""form-group"">
                                            <label class=""bmd-label-floating"">Last Name</label>
                                            <input type=""text"" ");
                WriteLiteral(@"class=""form-control"">
                                        </div>
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-md-12"">
                                        <div class=""form-group"">
                                            <label class=""bmd-label-floating"">Adress</label>
                                            <input type=""text"" class=""form-control"">
                                        </div>
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-md-4"">
                                        <div class=""form-group"">
                                            <label class=""bmd-label-floating"">City</label>
                                            <input type=""text"" class=""form-control"">
                        ");
                WriteLiteral(@"                </div>
                                    </div>
                                    <div class=""col-md-4"">
                                        <div class=""form-group"">
                                            <label class=""bmd-label-floating"">Country</label>
                                            <input type=""text"" class=""form-control"">
                                        </div>
                                    </div>
                                    <div class=""col-md-4"">
                                        <div class=""form-group"">
                                            <label class=""bmd-label-floating"">Postal Code</label>
                                            <input type=""text"" class=""form-control"">
                                        </div>
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-md-12"">
  ");
                WriteLiteral(@"                                      <div class=""form-group"">
                                            <label>About Me</label>
                                            <div class=""form-group"">
                                                <label class=""bmd-label-floating""> Lamborghini Mercy, Your chick she so thirsty, I'm in that two seat Lambo.</label>
                                                <textarea class=""form-control"" rows=""5""></textarea>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <button type=""submit"" class=""btn btn-primary pull-right btn-round"">Follow</button>
                                <div class=""clearfix""></div>
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
                </div>
            </div>
        </div>
    </div>
</div>
<!-- #endregion -->
<!-- #region   Style/CSS -->
<style>
.card-header.card-header-primary {
    background: linear-gradient( 60deg, #00acc1, #00acc1) !important;
} 
i.material-icons {
    float: left;
} 
input.form-control {
    border: 0px !important;
}
</style>
<!-- #endregion -->");
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
