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
    public partial class ESSidebarItem : ESComponentBase
    {
        [Inject] protected HttpClient? Http { get; set; }
        [Inject] private NavigationManager? navigationManager { get; set; }
        [Parameter] public string? Id { get; set; }
        [Parameter] public string? AnchorClassNames { get; set; }
        [Parameter] public string? IconClassNames { get; set; } = null;
        [Parameter] public string? Title { get; set; }
        [Parameter] public string? To { get; set; }
        [Parameter] public string? NavigateTo { get; set; }
        [Parameter] public ESSidebarItemType? SidebarItemType { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }

        private List<SidebarItemData> ItemsData = new List<SidebarItemData>();

        protected ClassBuilder? ULClassBuilder { get; private set; }
        protected string? ULClassNames => ULClassBuilder?.Class;

        public ESSidebarItem()
        {
            BuildULClasses(ULClassBuilder);
        }

        protected override void OnInitialized()
        {
            switch (SidebarItemType)
            {
                case ESSidebarItemType.Workflow:
                    this.GetWorkflowItems();
                    break;
                case ESSidebarItemType.CubeView:
                    this.GetCubeViewProfilesAsync();
                    break;
                case ESSidebarItemType.Dashboard:
                    this.GetDashboardProfilesAsync();
                    break;
                case ESSidebarItemType.Document:
                    this.GetDocumentItems();
                    break;
            }
        }

        private void GetWorkflowItems()
        {
            ItemsData.Add(new SidebarItemData("Clubs", "es es-Workflow-flyout", ESSidebarItemType.Workflow));
            ItemsData.Add(new SidebarItemData("Actual", "es es-Actual-flyout", ESSidebarItemType.Workflow));
            ItemsData.Add(new SidebarItemData("2011", "es es-TimeDim-flyout", ESSidebarItemType.Workflow));
        }

        private void GetCubeViewProfilesAsync()
        {
            ItemsData.Add(new SidebarItemData("Capital Planning", "esFlyout es-PresProfile", ESSidebarItemType.CubeView, new Guid("91a3c4a3-6fb9-4faa-b547-2d628eff57b9"), "profile", string.Empty));
        }

        private void GetDashboardProfilesAsync()
        {
            ItemsData.Add(new SidebarItemData("Budgets", "esFlyout es-PresProfile", ESSidebarItemType.Dashboard, new Guid("c463dc57-2bf2-47e2-b0e8-d4e4eb110ddf"), "profile", string.Empty));
        }

        private void GetDocumentItems()
        {
            ItemsData.Add(new SidebarItemData("Public", "es es-Folder-flyout", ESSidebarItemType.Document));
            ItemsData.Add(new SidebarItemData("Users", "es es-Folder-flyout", ESSidebarItemType.Document));
            ItemsData.Add(new SidebarItemData("Admin", "es es-Folder-flyout", ESSidebarItemType.Document));
        }

        protected void ESLink_Clicked()
        {
            navigationManager.NavigateTo($"/{this.NavigateTo}");
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.ListGroupItem() );
            base.BuildClasses(builder);
        }

        private void BuildULClasses(ClassBuilder? builder) 
        {
            builder?.Append("");
        }
    }
}