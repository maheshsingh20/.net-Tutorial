namespace m1Assessment_Practise.Questions.Question21;

class Email
{
    public string To { get; set; } = "";
    public string Subject { get; set; } = "";
    public string Body { get; set; } = "";
}

class BulkSendReport
{
    public int TotalEmails { get; set; }
    public int SuccessCount { get; set; }
    public int FailureCount { get; set; }
    public List<string> FailedRecipients { get; set; } = new();
}
