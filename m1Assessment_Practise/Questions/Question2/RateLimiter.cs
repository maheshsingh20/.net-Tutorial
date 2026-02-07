namespace m1Assessment_Practise.Questions.Question2;

class RateLimiter
{
    private readonly int _maxRequests;
    private readonly TimeSpan _timeWindow;
    private readonly Dictionary<string, Queue<DateTime>> _clientRequests = new();
    private readonly object _lock = new();

    public RateLimiter(int maxRequests, TimeSpan timeWindow)
    {
        _maxRequests = maxRequests;
        _timeWindow = timeWindow;
    }

    public bool AllowRequest(string clientId, DateTime now)
    {
        if (string.IsNullOrWhiteSpace(clientId))
            throw new ArgumentException("ClientId cannot be empty");

        lock (_lock)
        {
            if (!_clientRequests.ContainsKey(clientId))
            {
                _clientRequests[clientId] = new Queue<DateTime>();
            }

            var requests = _clientRequests[clientId];

            while (requests.Count > 0 && (now - requests.Peek()) > _timeWindow)
            {
                requests.Dequeue();
            }

            if (requests.Count >= _maxRequests)
            {
                return false;
            }

            requests.Enqueue(now);
            return true;
        }
    }
}
