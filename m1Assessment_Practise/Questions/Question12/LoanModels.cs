namespace m1Assessment_Practise.Questions.Question12;

enum LoanState { Draft, Submitted, InReview, Approved, Rejected, Disbursed }
enum LoanAction { Submit, StartReview, Approve, Reject, Disburse }

class StateTransition
{
    public LoanState FromState { get; set; }
    public LoanAction Action { get; set; }
    public LoanState ToState { get; set; }
    public DateTime Timestamp { get; set; }
}

class LoanApplication
{
    public string ApplicationId { get; set; } = "";
    public LoanState CurrentState { get; set; } = LoanState.Draft;
    public List<StateTransition> History { get; set; } = new();
}
