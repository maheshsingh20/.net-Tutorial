// Question 12: Workflow Engine (State Machine)
namespace m1Assessment_Practise.Questions.Question12;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 12: Workflow Engine (State Machine) ===\n");

        var workflow = new WorkflowEngine();
        workflow.CreateApplication("LOAN001");

        try
        {
            workflow.ChangeState("LOAN001", LoanAction.Submit);
            workflow.ChangeState("LOAN001", LoanAction.StartReview);
            workflow.ChangeState("LOAN001", LoanAction.Approve);
            workflow.ChangeState("LOAN001", LoanAction.Disburse);

            workflow.DisplayHistory("LOAN001");

            Console.WriteLine("\n--- Attempting invalid transition ---");
            workflow.ChangeState("LOAN001", LoanAction.Reject);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
