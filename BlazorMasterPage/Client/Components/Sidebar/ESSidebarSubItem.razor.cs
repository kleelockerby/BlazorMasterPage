using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using BlazorMasterPage.Components.Components;
using BlazorMasterPage.Components.Helpers;

namespace BlazorMasterPage.Client
{
    public partial class ESSidebarSubItem : ESComponentBase
    {
        private string? _anchorClassNames;

        [Inject] protected HttpClient? Http { get; set; }
        [Parameter] public Guid? Id { get; set; }
        [Parameter] public string? IconClassNames { get; set; } = null;
        [Parameter] public string? Title { get; set; }
        [Parameter] public ESSidebarItemType SidebarItemType { get; set; }
        [Parameter] public string? AnchorClassNames { get { return _anchorClassNames; } set { _anchorClassNames = value; } }

        protected List<SidebarItemData> ItemsData = new List<SidebarItemData>();
        protected string ULClasses = "submenu";
        protected bool IsOpen { get; set; } = false;

        protected string UlClassNames
        {
            get
            {
                var cssString = ULClasses;
                cssString += IsOpen ? " open" : "";
                return cssString.Trim();
            }
        }

        protected string AnchorClasses
        {
            get
            {
                var cssString = _anchorClassNames;
                cssString += IsOpen ? " special" : "";
                return cssString.Trim();
            }
        }

        protected override void OnInitialized()
        {
            if (SidebarItemType == ESSidebarItemType.CubeView)
            {
                this.GetCubeViewsInProfileAsync(this.Id);
            }
            else if (SidebarItemType == ESSidebarItemType.Dashboard)
            {
                this.GetDashboardsInProfileAsync(this.Id);
            }
        }

        public void GetCubeViewsInProfileAsync(Guid? Id)
        {
            ItemsData.Add(new SidebarItemData("Dallas", "esChild es-CubeView-flyout", ESSidebarItemType.CubeView, new Guid("369ae14a-5469-4e0c-8f73-8febc7ba0e20"), "flyout-indent", string.Empty));
            StateHasChanged();
        }

        public void GetDashboardsInProfileAsync(Guid? Id)
        {
            ItemsData.Add(new SidebarItemData("Houstong", "esChild es-Dashboard-flyout", ESSidebarItemType.Dashboard, new Guid("b221df09-4f02-4f28-8a48-564e06a576e6"), "flyout-indent", string.Empty));
            StateHasChanged();
        }

        protected void ToggleMenu()
        {
            IsOpen = !IsOpen;
            StateHasChanged();
        }

    }
}
