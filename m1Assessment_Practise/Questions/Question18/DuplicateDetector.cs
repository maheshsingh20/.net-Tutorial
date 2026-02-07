namespace m1Assessment_Practise.Questions.Question18;

class DuplicateDetector
{
    public List<DuplicateGroup> FindDuplicates(List<Customer> customers)
    {
        var duplicates = new List<DuplicateGroup>();
        var processed = new HashSet<int>();

        for (int i = 0; i < customers.Count; i++)
        {
            if (processed.Contains(customers[i].Id))
                continue;

            var group = new List<int> { customers[i].Id };
            var reasons = new List<string>();

            for (int j = i + 1; j < customers.Count; j++)
            {
                if (processed.Contains(customers[j].Id))
                    continue;

                var (isDuplicate, reason) = AreDuplicates(customers[i], customers[j]);
                if (isDuplicate)
                {
                    group.Add(customers[j].Id);
                    processed.Add(customers[j].Id);
                    if (!reasons.Contains(reason))
                        reasons.Add(reason);
                }
            }

            if (group.Count > 1)
            {
                duplicates.Add(new DuplicateGroup
                {
                    CustomerIds = group,
                    Reason = string.Join(", ", reasons)
                });
                processed.Add(customers[i].Id);
            }
        }

        return duplicates;
    }

    private (bool isDuplicate, string reason) AreDuplicates(Customer c1, Customer c2)
    {
        if (!string.IsNullOrWhiteSpace(c1.Phone) && c1.Phone == c2.Phone)
            return (true, "Same phone");

        if (!string.IsNullOrWhiteSpace(c1.Email) && c1.Email == c2.Email)
            return (true, "Same email");

        double similarity = CalculateNameSimilarity(c1.Name, c2.Name);
        if (similarity >= 0.80)
            return (true, $"Name similarity {similarity:P0}");

        return (false, "");
    }

    private double CalculateNameSimilarity(string name1, string name2)
    {
        if (string.IsNullOrWhiteSpace(name1) || string.IsNullOrWhiteSpace(name2))
            return 0;

        int distance = LevenshteinDistance(name1.ToLower(), name2.ToLower());
        int maxLength = Math.Max(name1.Length, name2.Length);
        return 1.0 - ((double)distance / maxLength);
    }

    private int LevenshteinDistance(string s1, string s2)
    {
        int[,] d = new int[s1.Length + 1, s2.Length + 1];

        for (int i = 0; i <= s1.Length; i++)
            d[i, 0] = i;
        for (int j = 0; j <= s2.Length; j++)
            d[0, j] = j;

        for (int j = 1; j <= s2.Length; j++)
        {
            for (int i = 1; i <= s1.Length; i++)
            {
                int cost = s1[i - 1] == s2[j - 1] ? 0 : 1;
                d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
            }
        }

        return d[s1.Length, s2.Length];
    }
}
