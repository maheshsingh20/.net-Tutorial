namespace m1Assessment_Practise.Questions.Question9;

class SalesAnalyzer
{
    public (List<RegionReport> regionReports, DateTime bestSalesDay) AnalyzeSales(List<Sale> sales)
    {
        var regionReports = sales
            .AsParallel()
            .GroupBy(s => s.Region)
            .Select(g => new RegionReport
            {
                Region = g.Key,
                TotalSales = g.Sum(s => s.Amount),
                TopCategory = g.GroupBy(s => s.Category)
                              .OrderByDescending(cg => cg.Sum(s => s.Amount))
                              .First()
                              .Key
            })
            .OrderBy(r => r.Region)
            .ToList();

        var bestSalesDay = sales
            .AsParallel()
            .GroupBy(s => s.Date.Date)
            .OrderByDescending(g => g.Sum(s => s.Amount))
            .First()
            .Key;

        return (regionReports, bestSalesDay);
    }
}
