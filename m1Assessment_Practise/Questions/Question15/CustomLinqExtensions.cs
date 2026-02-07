namespace m1Assessment_Practise.Questions.Question15;

static class CustomLinqExtensions
{
    public static IEnumerable<T> WhereEx<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (predicate(item))
                yield return item;
        }
    }

    public static IEnumerable<TResult> SelectEx<TSource, TResult>(
        this IEnumerable<TSource> source, 
        Func<TSource, TResult> selector)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));

        foreach (var item in source)
        {
            yield return selector(item);
        }
    }

    public static IEnumerable<T> DistinctEx<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        var seen = new HashSet<T>();
        foreach (var item in source)
        {
            if (seen.Add(item))
                yield return item;
        }
    }

    public static IEnumerable<IGrouping<TKey, TSource>> GroupByEx<TSource, TKey>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector) where TKey : notnull
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

        var groups = new Dictionary<TKey, List<TSource>>();

        foreach (var item in source)
        {
            var key = keySelector(item);
            if (!groups.ContainsKey(key))
                groups[key] = new List<TSource>();
            
            groups[key].Add(item);
        }

        foreach (var kvp in groups)
        {
            yield return new Grouping<TKey, TSource>(kvp.Key, kvp.Value);
        }
    }
}
