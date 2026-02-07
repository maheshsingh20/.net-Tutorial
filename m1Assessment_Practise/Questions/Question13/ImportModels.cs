namespace m1Assessment_Practise.Questions.Question13;

class ImportError
{
    public int RowNumber { get; set; }
    public string Reason { get; set; } = "";
}

class ImportResult
{
    public int InsertedCount { get; set; }
    public List<ImportError> Errors { get; set; } = new();
}
