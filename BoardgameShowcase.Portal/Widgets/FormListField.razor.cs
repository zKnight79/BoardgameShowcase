using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace BoardgameShowcase.Portal.Widgets
{
    public partial class FormListField<T>
    {
        [Inject] private ILogger<FormListField<T>> Logger { get; set; } = default!;

        [Parameter] public IEnumerable<T> Values { get; set; } = default!;
        [Parameter] public EventCallback<IEnumerable<T>> ValuesChanged { get; set; }
        [Parameter] public IDictionary<T, string> Options { get; set; } = default!;
        [Parameter] public string FieldLabel { get; set; } = string.Empty;
        [Parameter] public bool IsDisabled { get; set; } = false;

        private string[] SelectedItems
        {
            get => Values.Select(x => $"{x}").ToArray();
            set
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                Values = from val in Array.ConvertAll(value, x => (T?)converter.ConvertFromString(x))
                         where val is not null
                         select val;
                ValuesChanged.InvokeAsync(Values).Wait();
            }
        }

        private int OptionCount => Options?.Count ?? 2;
    }
}
