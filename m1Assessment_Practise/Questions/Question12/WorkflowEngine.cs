namespace m1Assessment_Practise.Questions.Question12;

class WorkflowEngine
{
    private readonly Dictionary<string, LoanApplication> _applications = new();
    private readonly Dictionary<(LoanState, LoanAction), LoanState> _transitions = new()
    {
        { (LoanState.Draft, LoanAction.Submit), LoanState.Submitted },
        { (LoanState.Submitted, LoanAction.StartReview), LoanState.InReview },
        { (LoanState.InReview, LoanAction.Approve), LoanState.Approved },
        { (LoanState.InReview, LoanAction.Reject), LoanState.Rejected },
        { (LoanState.Approved, LoanAction.Disburse), LoanState.Disbursed }
    };

    public void CreateApplication(string appId)
    {
        _applications[appId] = new LoanApplication { ApplicationId = appId };
        Console.WriteLine($"Created application {appId} in Draft state");
    }

    public void ChangeState(string appId, LoanAction action)
    {
        if (!_applications.ContainsKey(appId))
            throw new ArgumentException($"Application {appId} not found");

        var app = _applications[appId];
        var currentState = app.CurrentState;

        if (!_transitions.TryGetValue((currentState, action), out var newState))
        {
            throw new InvalidOperationException(
                $"Invalid transition: Cannot {action} from {currentState} state");
        }

        app.History.Add(new StateTransition
        {
            FromState = currentState,
            Action = action,
            ToState = newState,
            Timestamp = DateTime.Now
        });

        app.CurrentState = newState;
        Console.WriteLine($"{appId}: {currentState} -> {newState} (Action: {action})");
    }

    public void DisplayHistory(string appId)
    {
        if (!_applications.ContainsKey(appId))
            return;

        var app = _applications[appId];
        Console.WriteLine($"\n=== History for {appId} ===");
        foreach (var transition in app.History)
        {
            Console.WriteLine($"{transition.Timestamp:HH:mm:ss} - {transition.FromState} -> {transition.ToState} ({transition.Action})");
        }
        Console.WriteLine($"Current State: {app.CurrentState}");
    }
}
