namespace m1Assessment_Practise.Questions.Question8;

class CacheItem<TValue>
{
    public TValue Value { get; set; }
    public DateTime ExpiryTime { get; set; }
    public DateTime LastAccessed { get; set; }

    public CacheItem(TValue value, DateTime expiryTime)
    {
        Value = value;
        ExpiryTime = expiryTime;
        LastAccessed = DateTime.Now;
    }
}
