using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace BoardgameShowcase.Portal.Widgets
{
    public partial class FormSelectField<T>
    {
        [Inject] private ILogger<FormSelectField<T>> Logger { get; set; } = default!;

        [Parameter] public T Value { get; set; } = default!;
        [Parameter] public EventCallback<T> ValueChanged { get; set; }
        [Parameter] public IDictionary<T, string> Options { get; set; } = default!;
        [Parameter] public string FieldLabel { get; set; } = string.Empty;
        [Parameter] public string InvalidityHint { get; set; } = string.Empty;
        [Parameter] public bool IsRequired { get; set; } = false;
        [Parameter] public bool IsDisabled { get; set; } = false;

        private async Task SelectValueChanged(ChangeEventArgs eventArgs)
        {
            if (eventArgs.Value is string newValue)
            {
                Type type = typeof(T);
                try
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                    T? newValAsT = (T?)converter.ConvertFromString(newValue);
                    await ValueChanged.InvokeAsync(newValAsT);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, $"Unable to convert {newValue} to {type.Name}");
                }
            }
        }
    }
}
