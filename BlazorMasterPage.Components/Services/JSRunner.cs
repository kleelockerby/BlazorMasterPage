using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMasterPage.Components.Services
{
    public abstract class JSRunner : IJSRunner
    {
        protected readonly IJSRuntime runtime;

        private const string BLAZORMASTERPAGE_NAMESPACE = "blazorise";

        public JSRunner(IJSRuntime runtime)
        {
            this.runtime = runtime;
        }

        public ValueTask<bool> InitializeTextEdit(ElementReference elementRef, string elementId, string maskType, string editMask)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.textEdit.initialize", elementRef, elementId, maskType, editMask);
        }

        public ValueTask<bool> DestroyTextEdit(ElementReference elementRef, string elementId)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.textEdit.destroy", elementRef, elementId);
        }

        /*public ValueTask<bool> InitializeNumericEdit<TValue>(DotNetObjectReference<NumericEditAdapter> dotNetObjectRef, ElementReference elementRef, string elementId, int decimals, string decimalsSeparator, decimal? step, TValue min, TValue max)
        {
            var (minFromType, maxFromType) = Converters.GetMinMaxValueOfType<TValue>();

            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.numericEdit.initialize",
                dotNetObjectRef,
                elementRef,
                elementId,
                decimals,
                decimalsSeparator,
                step,
                min.IsEqual(default) ? minFromType : min,
                max.IsEqual(default) ? maxFromType : max);
        }*/

        public ValueTask<bool> DestroyNumericEdit(ElementReference elementRef, string elementId)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.numericEdit.destroy", elementRef, elementId);
        }

        public virtual ValueTask<bool> InitializeTooltip(ElementReference elementRef, string elementId)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.tooltip.initialize", elementRef, elementId);
        }

        public virtual ValueTask<bool> InitializeButton(ElementReference elementRef, string elementId, bool preventDefaultSubmit)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.button.initialize", elementRef, elementId, preventDefaultSubmit);
        }

        public ValueTask<bool> DestroyButton(string elementId)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.button.destroy", elementId);
        }

        public ValueTask<bool> AddClass(ElementReference elementRef, string classname)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.addClass", elementRef, classname);
        }

        public ValueTask<bool> RemoveClass(ElementReference elementRef, string classname)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.removeClass", elementRef, classname);
        }

        public ValueTask<bool> ToggleClass(ElementReference elementId, string classname)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.toggleClass", elementId, classname);
        }

        public ValueTask<bool> AddClassToBody(string classname)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.addClassToBody", classname);
        }

        public ValueTask<bool> RemoveClassFromBody(string classname)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.removeClassFromBody", classname);
        }

        public ValueTask<bool> ParentHasClass(ElementReference elementRef, string classaname)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.parentHasClass", elementRef, classaname);
        }

        public async ValueTask SetProperty(ElementReference elementRef, string property, object value)
        {
            await runtime.InvokeVoidAsync($"{BLAZORMASTERPAGE_NAMESPACE}.setProperty", elementRef, property, value);
        }

        public ValueTask<DomElement> GetElementInfo(ElementReference elementRef, string elementId)
        {
            return runtime.InvokeAsync<DomElement>($"{BLAZORMASTERPAGE_NAMESPACE}.getElementInfo", elementRef, elementId);
        }

        public virtual ValueTask<bool> ActivateDatePicker(string elementId, string formatSubmit)
        {
            return new ValueTask<bool>(true);
        }

        public virtual ValueTask<bool> ActivateTimePicker(string elementId, string formatSubmit)
        {
            return new ValueTask<bool>(true);
        }

        /*public async ValueTask<TValue[]> GetSelectedOptions<TValue>(string elementId)
        {
            var stringValues = await runtime.InvokeAsync<string[]>($"{BLAZORMASTERPAGE_NAMESPACE}.getSelectedOptions", elementId);

            return stringValues?.Select(value =>
            {
                try
                {
                    if (string.IsNullOrEmpty(value))
                        return default;

                    return Converters.ChangeType<TValue>(value);
                }
                catch
                {
                    return default;
                }
            }).Distinct().ToArray();
        }*/

        public ValueTask SetSelectedOptions<TValue>(string elementId, IReadOnlyList<TValue> values)
        {
            return runtime.InvokeVoidAsync($"{BLAZORMASTERPAGE_NAMESPACE}.setSelectedOptions", elementId, values);
        }

        public ValueTask<bool> SetTextValue(ElementReference elementRef, object value)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.setTextValue", elementRef, value);
        }

        public ValueTask SetCaret(ElementReference elementRef, int caret)
        {
            return runtime.InvokeVoidAsync($"{BLAZORMASTERPAGE_NAMESPACE}.setCaret", elementRef, caret);
        }

        public ValueTask<int> GetCaret(ElementReference elementRef)
        {
            return runtime.InvokeAsync<int>($"{BLAZORMASTERPAGE_NAMESPACE}.getCaret", elementRef);
        }

        public abstract ValueTask<bool> OpenModal(ElementReference elementRef, bool scrollToTop);

        public abstract ValueTask<bool> CloseModal(ElementReference elementRef);

        public ValueTask<bool> OpenFileDialog(ElementReference elementRef, string elementId)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.fileEdit.open", elementRef, elementId);
        }

        public ValueTask<bool> Focus(ElementReference elementRef, string elementId, bool scrollToElement)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.focus", elementRef, elementId, scrollToElement);
        }

       /* public ValueTask<object> RegisterClosableComponent(DotNetObjectReference<CloseActivatorAdapter> dotNetObjectRef, ElementReference elementRef)
        {
            return runtime.InvokeAsync<object>($"{BLAZORMASTERPAGE_NAMESPACE}.registerClosableComponent", elementRef, dotNetObjectRef);
        }

        public ValueTask<object> UnregisterClosableComponent(ICloseActivator component)
        {
            return runtime.InvokeAsync<object>($"{BLAZORMASTERPAGE_NAMESPACE}.unregisterClosableComponent", component.ElementRef);
        }

        public ValueTask<object> RegisterBreakpointComponent(DotNetObjectReference<BreakpointActivatorAdapter> dotNetObjectRef, string elementId)
        {
            return runtime.InvokeAsync<object>($"{BLAZORMASTERPAGE_NAMESPACE}.breakpoint.registerBreakpointComponent", elementId, dotNetObjectRef);
        }

        public ValueTask<object> UnregisterBreakpointComponent(IBreakpointActivator component)
        {
            return runtime.InvokeAsync<object>($"{BLAZORMASTERPAGE_NAMESPACE}.breakpoint.unregisterBreakpointComponent", component.ElementId);
        }*/

        public ValueTask<string> GetBreakpoint()
        {
            return runtime.InvokeAsync<string>($"{BLAZORMASTERPAGE_NAMESPACE}.breakpoint.getBreakpoint");
        }

        public ValueTask<bool> ScrollIntoView(string anchorTarget)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.link.scrollIntoView", anchorTarget);
        }

        /*public ValueTask<bool> InitializeFileEdit(DotNetObjectReference<FileEditAdapter> dotNetObjectRef, ElementReference elementRef, string elementId)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.fileEdit.initialize", dotNetObjectRef, elementRef, elementId);
        }*/

        public ValueTask<bool> DestroyFileEdit(ElementReference elementRef, string elementId)
        {
            return runtime.InvokeAsync<bool>($"{BLAZORMASTERPAGE_NAMESPACE}.fileEdit.destroy", elementRef, elementId);
        }

        public ValueTask<string> ReadDataAsync(CancellationToken cancellationToken, ElementReference elementRef, int fileEntryId, long position, long length)
        {
            return runtime.InvokeAsync<string>($"{BLAZORMASTERPAGE_NAMESPACE}.fileEdit.readFileData", cancellationToken, elementRef, fileEntryId, position, length);
        }

        public ValueTask ResetFileEdit(ElementReference elementRef, string elementId)
        {
            return runtime.InvokeVoidAsync($"{BLAZORMASTERPAGE_NAMESPACE}.fileEdit.reset", elementRef, elementId);
        }
    }
}
