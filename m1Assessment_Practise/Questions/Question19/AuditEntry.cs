namespace m1Assessment_Practise.Questions.Question19;

class AuditEntry
{
    public string EntityName { get; set; } = "";
    public string PropertyName { get; set; } = "";
    public object? OldValue { get; set; }
    public object? NewValue { get; set; }
    public DateTime Timestamp { get; set; }
}
