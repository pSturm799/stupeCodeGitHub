#pragma checksum "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "793d55c04a56bb77f8cbc3f62371d57edff4b950"
// <auto-generated/>
#pragma warning disable 1591
namespace AppSettingsDemo.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\_Imports.razor"
using AppSettingsDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\_Imports.razor"
using AppSettingsDemo.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\_Imports.razor"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>AppSettings Values</h1>\r\n\r\n");
            __builder.OpenElement(1, "p");
            __builder.AddMarkupContent(2, "\r\n    MySetting Value: ");
            __builder.AddContent(3, 
#nullable restore
#line 7 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\Pages\Index.razor"
                      mySetting

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(4, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n");
            __builder.OpenElement(6, "p");
            __builder.AddMarkupContent(7, "\r\n    SubSetting Value: ");
            __builder.AddContent(8, 
#nullable restore
#line 10 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\Pages\Index.razor"
                       subSetting

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(9, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n");
            __builder.OpenElement(11, "p");
            __builder.AddMarkupContent(12, "\r\n    Connection String Value: ");
            __builder.AddContent(13, 
#nullable restore
#line 13 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\Pages\Index.razor"
                              connectionString

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(14, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 18 "C:\Users\psturm\OneDrive - Cosmo Consult AG\Coding\IntroToAppSettings\AppSettingsDemo\Pages\Index.razor"
 
    string mySetting = "";
    string subSetting = "";
    string connectionString = "";

    protected override void OnInitialized()
    {
        
    //mySetting = _config.GetValue<string>("MySetting");
        var azureJson = _config.GetSection("Azure");
        mySetting = azureJson["MySetting"];
        subSetting = _config.GetValue<string>("MainSetting:SubSetting");
        connectionString = _config.GetConnectionString("Default");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IConfiguration _config { get; set; }
    }
}
#pragma warning restore 1591