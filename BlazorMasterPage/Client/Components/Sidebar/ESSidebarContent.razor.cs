using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using BlazorMasterPage.Components.Components;
using BlazorMasterPage.Components.Helpers;

namespace BlazorMasterPage.Client
{
    public partial class ESSidebarContent : ESComponentBase
    {
        [Parameter] public string? Title { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }

        protected ClassBuilder? TitleClassBuilder { get; private set; }
        protected string? TitleClassNames => TitleClassBuilder?.Class;

        public ESSidebarContent()
        {
            BuildTitleClasses(TitleClassBuilder);
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append("list-group");
            base.BuildClasses(builder);
        }

        protected void BuildTitleClasses(ClassBuilder? builder)
        {
            builder?.Append("list-group-item-sub-header");
        }
    }
}