using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorMasterPage.Components.Helpers;

namespace BlazorMasterPage.Components.Components
{
    public partial class ESCardHeader : ESComponentBase
    {
        [Parameter] public string? Title { get; set; }
        [Parameter] public bool ShowBorder { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }

        protected ClassBuilder? HeaderClassBuilder { get; private set; }
        protected string HeaderClassNames => HeaderClassBuilder.Class;

        public ESCardHeader()
        {
            HeaderClassBuilder = new ClassBuilder(BuildHeaderClasses);
        }

        protected override void BuildClasses(ClassBuilder builder)
        {
            if (ClassProvider != null)
            {
                builder.Append(ClassProvider.CardHeader());
                base.BuildClasses(builder); 
            }
        }

        private void BuildHeaderClasses(ClassBuilder builder)
        {
            builder.Append("es-header-text");
            builder.Append("es-header-border", ShowBorder);
        }
    }
}