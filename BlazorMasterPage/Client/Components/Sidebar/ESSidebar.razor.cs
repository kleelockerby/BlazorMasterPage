using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorMasterPage.Components.Components;
using BlazorMasterPage.Components.Helpers;

namespace BlazorMasterPage.Client
{
    public partial class ESSidebar : ESComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string HeaderText { get; set; }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append("es-sidebar");
            base.BuildClasses(builder);
        }
    }
}
