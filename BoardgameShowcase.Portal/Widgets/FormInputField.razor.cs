using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Widgets
{
    public partial class FormInputField<T>
    {
        [Inject] private ILogger<FormInputField<T>> Logger { get; set; } = default!;
        
        [Parameter] public T Value { get; set; } = default!;
        [Parameter] public EventCallback<T> ValueChanged { get; set; }
        [Parameter] public string FieldLabel { get; set; } = string.Empty;
        [Parameter] public string FieldPlaceholder { get; set; } = string.Empty;
        [Parameter] public string InvalidityHint { get; set; } = string.Empty;
        [Parameter] public bool IsRequired { get; set; } = false;
        [Parameter] public bool IsReadonly { get; set; } = false;
        [Parameter] public bool SelectOnFocus { get; set; } = false;

        private ElementReference InputField { get; set; }

        private string InputType => Value switch
        {
            int => "number",
            _ => "text"
        };

        private async Task InputValueChanged(ChangeEventArgs eventArgs)
        {
            if (eventArgs.Value is string newValue)
            {
                Type type = typeof(T);
                try
                {
                    T newValAsT = (T)Convert.ChangeType(newValue, type);
                    await ValueChanged.InvokeAsync(newValAsT);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, $"Unable to convert {newValue} to {type.Name}");
                }
            }
        }

        public async Task SetFocus()
        {
            await InputField.FocusAsync();
        }
    }
}
