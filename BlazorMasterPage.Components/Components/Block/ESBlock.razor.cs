using BlazorMasterPage.Components.Components;
using BlazorMasterPage.Components.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorMasterPage.Components.Components 
{
    public partial class ESBlock : ESComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append("xf-card");
            base.BuildClasses(builder);
        }
    }
}
