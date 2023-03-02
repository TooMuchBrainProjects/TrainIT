namespace View.Services;

public class DateManager
{
    public event EventHandler? SelectedDateChanged;

    private DateTime? _selectedDate;
    public DateTime SelectedDate
    {
        get { return _selectedDate ??= DateTime.Today; }
        set
        {
            _selectedDate = value;
            
            // raise event
            OnSelectedDateChanged();
        }
    }

    public bool MaxDateReached { get; private set; }

    public readonly DateTime Today;
    
    public MudDatePicker? DatePicker { get; set; }

    public DateManager()
    {
        Today = DateTime.Today;
        SelectedDate = Today;

        SelectedDateChanged += new EventHandler(HandleDateChangeAsync);
    }

    public void HandleDateChangeAsync(object? sender, EventArgs e)
    {
        MaxDateReached = SelectedDate == Today;
    }

    public void PrevDate()
    {
        SelectedDate = SelectedDate.AddDays(-1);
    }

    public void NextDate()
    {
        SelectedDate = SelectedDate.AddDays(1);
    }
    
    public async Task DatePickerToday()
    {
        await DatePicker!.GoToDate(DateTime.Today);
        DatePicker.Close();
    }

    protected virtual void OnSelectedDateChanged()
    {
        SelectedDateChanged?.Invoke(this, EventArgs.Empty);
    }
}