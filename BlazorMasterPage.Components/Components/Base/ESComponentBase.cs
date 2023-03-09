using Microsoft.AspNetCore.Components;
using BlazorMasterPage.Components.Helpers;
using BlazorMasterPage.Components.Services;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.RenderTree;

namespace BlazorMasterPage.Components.Components
{
    public class ESComponentBase : ComponentBase, IDisposable
    {
        private string? customClass;
        private string? customStyle;
        private string? elementId;
        private Float @float = Float.None;
        private Queue<Func<Task>>? executeAfterRendereQueue;

        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object>? Attributes { get; set; }
        [Parameter] public string? Class { get => customClass; set => customClass = value; }
        [Parameter] public string? Style { get => customStyle; set => customStyle = value; }
        [Parameter] public Float Float { get => @float; set { @float = value; } }
        [Parameter] public string? ElementId { get; set; }

        [Inject] protected ClassProvider? ClassProvider { get; set; }
        [Inject] protected StyleProvider? StyleProvider { get; set; }
        [Inject] protected IIDGenerator? IDGenerator { get; set; }
        [Inject] protected IJSRunner? JSRunner { get; set; }
        
        public ElementReference ElementRef { get; set; }
        public string ClassNames => ClassBuilder.Class;
        public string StyleNames => StyleBuilder.Styles;
        
        protected ClassBuilder ClassBuilder { get; private set; }
        protected StyleBuilder StyleBuilder { get; private set; }
        protected virtual bool ShouldAutoGenerateId => false;
        protected bool Rendered { get; private set; }
        protected virtual Task OnFirstAfterRenderAsync() => Task.CompletedTask;
        
        protected DotNetObjectReference<T> CreateDotNetObjectRef<T>(T value) where T : class { return DotNetObjectReference.Create(value); }
        protected void DisposeDotNetObjectRef<T>(DotNetObjectReference<T> value) where T : class { value?.Dispose(); }

        protected bool Disposed { get; private set; }

        public ESComponentBase()
        {
            ClassBuilder = new ClassBuilder(BuildClasses);
            StyleBuilder = new StyleBuilder(BuildStyles);
        }

        protected override void OnInitialized()
        {
            if (ShouldAutoGenerateId && ElementId == null && IDGenerator != null)
            {
                ElementId = IDGenerator.Generate;
            }
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await OnFirstAfterRenderAsync();
            }

            this.Rendered = true;
            if (executeAfterRendereQueue?.Count > 0)
            {
                while (executeAfterRendereQueue.Count > 0)
                {
                    Func<Task> action = executeAfterRendereQueue.Dequeue();
                    await action();
                }
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        protected virtual void BuildClasses(ClassBuilder builder)
        {
            if (Class != null)
                builder.Append(Class);
            if (Float != Float.None && ClassProvider != null)
                builder.Append(ClassProvider.ToFloat(Float));
        }

        protected virtual void BuildStyles(StyleBuilder builder)
        {
            if (Style != null)
                builder.Append(Style);
        }

        protected void ExecuteAfterRender(Func<Task> action)
        {
            if (executeAfterRendereQueue == null)
                executeAfterRendereQueue = new Queue<Func<Task>>();
            executeAfterRendereQueue.Enqueue(action);
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            return base.SetParametersAsync(parameters);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                Disposed = true;

                if (disposing)
                {
                    executeAfterRendereQueue?.Clear();
                }
            }
        }
    }
}