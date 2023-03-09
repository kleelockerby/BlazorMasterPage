using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorMasterPage.Components.Services 
{
    public partial class BootstrapJSRunner : JSRunner
    {
        private const string BOOTSTRAP_NAMESPACE = "blazoriseBootstrap";

        public BootstrapJSRunner(IJSRuntime runtime) : base(runtime)
        {
        }

        public override ValueTask<bool> InitializeTooltip(ElementReference elementRef, string elementId)
        {
            return runtime.InvokeAsync<bool>($"{BOOTSTRAP_NAMESPACE}.tooltip.initialize", elementRef, elementId);
        }

        public override ValueTask<bool> OpenModal(ElementReference elementRef, bool scrollToTop)
        {
            return runtime.InvokeAsync<bool>($"{BOOTSTRAP_NAMESPACE}.modal.open", elementRef, scrollToTop);
        }

        public override ValueTask<bool> CloseModal(ElementReference elementRef)
        {
            return runtime.InvokeAsync<bool>($"{BOOTSTRAP_NAMESPACE}.modal.close", elementRef);
        }
    }
}
