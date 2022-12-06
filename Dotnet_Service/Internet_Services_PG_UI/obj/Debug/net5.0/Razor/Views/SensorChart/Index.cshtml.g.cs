#pragma checksum "X:\Studia\InformatykaSemestr7\NetWeb\Internet_Services_PG\Dotnet_Service\Internet_Services_PG_UI\Views\SensorChart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75cf0e9c3885bbd59c038299d0cb845b0e89bded"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SensorChart_Index), @"mvc.1.0.view", @"/Views/SensorChart/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75cf0e9c3885bbd59c038299d0cb845b0e89bded", @"/Views/SensorChart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_SensorChart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<title>");
#nullable restore
#line 1 "X:\Studia\InformatykaSemestr7\NetWeb\Internet_Services_PG\Dotnet_Service\Internet_Services_PG_UI\Views\SensorChart\Index.cshtml"
  Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" - Sensor Chart</title>  
<script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>

<div id=""chart_div"">hj</div>    

<script type=""text/javascript"">

google.charts.load('current', {  
    packages: ['corechart', 'bar']  
});
google.charts.setOnLoadCallback(LoadDataPressure);

    function LoadDataPressure(){
        $.ajax({  

            url: 'Pressure',  
            dataType: ""json"",  
            type: ""GET"",  
            error: function(xhr, status, error) {  
                var err = eval(""("" + xhr.responseText + "")"");  
                toastr.error(err.message);  
            },  
            success: function(data) {  
                SensorChartPressure(data);  
                return false;  
            }  
        });  
        return false;  
    }

    function SensorChartPressure(data) {  
        var dataArray = [  
            ['Date', 'pressureValue']  
        ];  
        $.each(data, function(i, item) {  
            da");
            WriteLiteral(@"taArray.push([item.date, item.value]);  
        });  
        var data = google.visualization.arrayToDataTable(dataArray);  
        var options = {  
            title: 'Sensor Pressure ',  
            chartArea: {  
                width: '50%'  
            },  
            colors: [ '#7b1fa2'],  
            hAxis: {  
                title: 'Date',  
                minValue: 0  
            },  
            vAxis: {  
                title: 'Value [C]'  
            }  
        };  
        var chart = new google.visualization.LineChart(document.getElementById('chart_div'));  

        chart.draw(data, options);  
        return false;  
    } 
</script>");
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
