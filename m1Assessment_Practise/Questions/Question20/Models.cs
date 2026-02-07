namespace m1Assessment_Practise.Questions.Question20;

enum Role { Admin, Manager, Agent }
enum Permission { CreateLoan, ApproveLoan, RejectLoan, ViewAll, ViewSelf }

class User
{
    public string UserId { get; set; } = "";
    public Role Role { get; set; }
    public decimal ApprovalLimit { get; set; }
}

class Resource
{
    public string ResourceId { get; set; } = "";
    public string OwnerId { get; set; } = "";
    public decimal Amount { get; set; }
}
