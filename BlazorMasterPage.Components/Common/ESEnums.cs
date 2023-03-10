using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMasterPage.Components.Common 
{
    public enum LinkClasses
    {
        ComboBoxButton,
        SidebarButton,
        SidebarFlyoutButton,
        TabButton
    }

    public enum Target
    {
        None,
        Self,
        Blank,
        Parent,
        Top,
    }
}
