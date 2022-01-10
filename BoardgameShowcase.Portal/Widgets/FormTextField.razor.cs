using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Widgets
{
    public partial class FormTextField
    {
        [Parameter] public string FieldValue { get; set; } = default!;
        [Parameter] public EventCallback<string> FieldValueChanged { get; set; }
        [Parameter] public string FieldLabel { get; set; } = string.Empty;
        [Parameter] public string FieldPlaceholder { get; set; } = string.Empty;
        [Parameter] public string InvalidityHint { get; set; } = string.Empty;
        [Parameter] public bool IsRequired { get; set; } = false;
        [Parameter] public bool IsReadonly { get; set; } = false;

        private ElementReference InputField { get; set; }

        public async Task InputValueChanged(ChangeEventArgs eventArgs)
        {
            string? newValue = eventArgs?.Value as string;
            if (newValue is not null)
            {
                await FieldValueChanged.InvokeAsync(newValue);
            }
        }

        public async Task SetFocus()
        {
            await InputField.FocusAsync();
        }
    }
}
