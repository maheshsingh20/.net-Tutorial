// Question 20: Role-Based Access Control (RBAC) Engine
namespace m1Assessment_Practise.Questions.Question20;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 20: RBAC Engine ===\n");

        var rbac = new RBACEngine();

        var admin = new User { UserId = "U001", Role = Role.Admin };
        var manager = new User { UserId = "U002", Role = Role.Manager, ApprovalLimit = 100000 };
        var agent = new User { UserId = "U003", Role = Role.Agent };

        var loan1 = new Resource { ResourceId = "L001", OwnerId = "U003", Amount = 50000 };
        var loan2 = new Resource { ResourceId = "L002", OwnerId = "U004", Amount = 150000 };

        Console.WriteLine($"Admin can approve loan: {rbac.Authorize(admin, Permission.ApproveLoan, loan1)}");
        Console.WriteLine($"Manager can approve 50K loan: {rbac.Authorize(manager, Permission.ApproveLoan, loan1)}");
        Console.WriteLine($"Manager can approve 150K loan: {rbac.Authorize(manager, Permission.ApproveLoan, loan2)}");
        Console.WriteLine($"Agent can view own loan: {rbac.Authorize(agent, Permission.ViewSelf, loan1)}");
        Console.WriteLine($"Agent can view other's loan: {rbac.Authorize(agent, Permission.ViewSelf, loan2)}");
        Console.WriteLine($"Agent can approve loan: {rbac.Authorize(agent, Permission.ApproveLoan, loan1)}");
    }
}
