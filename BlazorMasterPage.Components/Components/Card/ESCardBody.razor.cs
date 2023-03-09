using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorMasterPage.Components.Helpers;

namespace BlazorMasterPage.Components.Components
{
    public partial class ESCardBody : ESComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(ClassProvider.CardBody());
            base.BuildClasses(builder);
        }
    }
}