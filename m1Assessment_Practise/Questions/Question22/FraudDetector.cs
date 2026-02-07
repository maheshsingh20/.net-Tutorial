namespace m1Assessment_Practise.Questions.Question22;

class FraudDetector
{
    public List<FraudAlert> DetectFraud(List<FraudTransaction> transactions)
    {
        var alerts = new List<FraudAlert>();
        alerts.AddRange(DetectHighValueTransactions(transactions));
        alerts.AddRange(DetectMultipleCities(transactions));
        return alerts;
    }

    private List<FraudAlert> DetectHighValueTransactions(List<FraudTransaction> transactions)
    {
        var alerts = new List<FraudAlert>();
        var cardGroups = transactions.GroupBy(t => t.CardNumber);

        foreach (var cardGroup in cardGroups)
        {
            var highValueTxns = cardGroup
                .Where(t => t.Amount > 50000)
                .OrderBy(t => t.Timestamp)
                .ToList();

            for (int i = 0; i < highValueTxns.Count; i++)
            {
                var windowTxns = highValueTxns
                    .Skip(i)
                    .TakeWhile(t => (t.Timestamp - highValueTxns[i].Timestamp).TotalMinutes <= 2)
                    .ToList();

                if (windowTxns.Count >= 3)
                {
                    alerts.Add(new FraudAlert
                    {
                        CardNumber = cardGroup.Key,
                        Rule = "3+ high-value transactions (>50K) within 2 minutes",
                        TransactionIds = windowTxns.Select(t => t.TransactionId).ToList()
                    });
                    break;
                }
            }
        }

        return alerts;
    }

    private List<FraudAlert> DetectMultipleCities(List<FraudTransaction> transactions)
    {
        var alerts = new List<FraudAlert>();
        var cardGroups = transactions.GroupBy(t => t.CardNumber);

        foreach (var cardGroup in cardGroups)
        {
            var sortedTxns = cardGroup.OrderBy(t => t.Timestamp).ToList();

            for (int i = 0; i < sortedTxns.Count - 1; i++)
            {
                for (int j = i + 1; j < sortedTxns.Count; j++)
                {
                    var timeDiff = (sortedTxns[j].Timestamp - sortedTxns[i].Timestamp).TotalMinutes;
                    
                    if (timeDiff > 10)
                        break;

                    if (sortedTxns[i].City != sortedTxns[j].City)
                    {
                        alerts.Add(new FraudAlert
                        {
                            CardNumber = cardGroup.Key,
                            Rule = $"Card used in 2 cities within 10 minutes: {sortedTxns[i].City} and {sortedTxns[j].City}",
                            TransactionIds = new List<string> { sortedTxns[i].TransactionId, sortedTxns[j].TransactionId }
                        });
                        break;
                    }
                }
            }
        }

        return alerts;
    }
}
