namespace m1Assessment_Practise.Questions.Question7;

class ValidationError
{
    public int RecordIndex { get; set; }
    public List<string> Errors { get; set; } = new();
}

class ValidationReport
{
    public int TotalRecords { get; set; }
    public int ValidCount { get; set; }
    public int InvalidCount { get; set; }
    public List<ValidationError> Errors { get; set; } = new();
}
