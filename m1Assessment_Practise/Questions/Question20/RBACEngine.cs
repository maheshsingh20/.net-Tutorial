namespace m1Assessment_Practise.Questions.Question20;

class RBACEngine
{
    private readonly Dictionary<Role, HashSet<Permission>> _rolePermissions = new()
    {
        { Role.Admin, new HashSet<Permission> { Permission.CreateLoan, Permission.ApproveLoan, Permission.RejectLoan, Permission.ViewAll } },
        { Role.Manager, new HashSet<Permission> { Permission.CreateLoan, Permission.ApproveLoan, Permission.RejectLoan, Permission.ViewAll } },
        { Role.Agent, new HashSet<Permission> { Permission.CreateLoan, Permission.ViewSelf } }
    };

    public bool Authorize(User user, Permission permission, Resource? resource = null)
    {
        if (!_rolePermissions.TryGetValue(user.Role, out var permissions))
            return false;

        if (!permissions.Contains(permission))
            return false;

        switch (user.Role)
        {
            case Role.Agent:
                if (permission == Permission.ViewSelf && resource != null)
                {
                    return resource.OwnerId == user.UserId;
                }
                break;

            case Role.Manager:
                if (permission == Permission.ApproveLoan && resource != null)
                {
                    if (resource.Amount > user.ApprovalLimit)
                    {
                        Console.WriteLine($"Manager approval limit exceeded: {resource.Amount:C} > {user.ApprovalLimit:C}");
                        return false;
                    }
                }
                break;

            case Role.Admin:
                break;
        }

        return true;
    }
}
