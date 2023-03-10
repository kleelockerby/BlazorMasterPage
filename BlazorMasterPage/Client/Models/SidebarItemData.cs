using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMasterPage.Client
{
    public class SidebarItemData
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string IconClassNames { get; set; }
        public string AnchorClassNames { get; set; }
        public string To { get; set; }
        public ESSidebarItemType SidebarItemType { get; set; }

        public SidebarItemData() { }

        public SidebarItemData(string title, string iconClassNames, ESSidebarItemType sidebarItemType)
        {
            this.Title = title;
            this.IconClassNames = iconClassNames;
            this.SidebarItemType = sidebarItemType;
        }

        public SidebarItemData(string title, string iconClassNames, ESSidebarItemType sidebarItemType, Guid? id, string anchorClassNames, string to)
        {
            this.Title = title;
            this.IconClassNames = iconClassNames;
            this.SidebarItemType = sidebarItemType;
            this.Id = id;
            this.AnchorClassNames = anchorClassNames;
            this.To = to;
        }
    }
}
