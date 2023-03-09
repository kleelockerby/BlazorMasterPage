using BlazorMasterPage.Components.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMasterPage.Components 
{
    public class BootstrapStyleProvider : StyleProvider
    {
        public override string ModalShow() => "display: block; padding-right: 17px;";

        public override string ModalBodyMaxHeight(int maxHeight) => $"max-height: {maxHeight}vh; overflow-y: auto;";

        public override string ProgressBarValue(int value) => $"width: {value}%";

        public override string ProgressBarSize(Size size) => null;

    }
}
