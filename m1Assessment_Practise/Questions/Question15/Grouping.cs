namespace m1Assessment_Practise.Questions.Question15;

class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
{
    private readonly List<TElement> _elements;

    public TKey Key { get; }

    public Grouping(TKey key, List<TElement> elements)
    {
        Key = key;
        _elements = elements;
    }

    public IEnumerator<TElement> GetEnumerator() => _elements.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}
