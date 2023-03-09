using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorMasterPage.Components.Helpers;

namespace BlazorMasterPage.Components.Components
{
    public partial class ESCard : ESComponentBase
    {
        private bool isWhiteText;
        private Background background = Background.None;

        [Parameter]
        public bool WhiteText
        {
            get => isWhiteText;
            set => isWhiteText = value;
        }

        [Parameter]
        public Background Background
        {
            get => background;
            set => background = value;
        }

        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void BuildClasses(ClassBuilder builder)
        {
            if (ClassProvider != null)
            {
                builder.Append(ClassProvider.Card());
                builder.Append(ClassProvider.CardWhiteText(), WhiteText);
                builder.Append(ClassProvider.CardBackground(Background), Background != Background.None);
                base.BuildClasses(builder); 
            }
        }
    }
}