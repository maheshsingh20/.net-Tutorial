namespace m1Assessment_Practise.Questions.Question3;

class ResilientPaymentGateway
{
    private CircuitState _circuitState = CircuitState.Closed;
    private readonly TimeSpan _circuitOpenDuration = TimeSpan.FromSeconds(30);
    private readonly TimeSpan _failureWindow = TimeSpan.FromMinutes(1);
    private readonly Queue<DateTime> _recentFailures = new();
    private readonly object _lock = new();
    private DateTime _circuitOpenedAt;
    private int _callCount = 0;

    public async Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            if (_circuitState == CircuitState.Open)
            {
                if (DateTime.Now - _circuitOpenedAt > _circuitOpenDuration)
                {
                    _circuitState = CircuitState.HalfOpen;
                    Console.WriteLine("Circuit moved to HALF-OPEN");
                }
                else
                {
                    return new PaymentResult { Success = false, Message = "Circuit is OPEN - failing fast" };
                }
            }
        }

        int maxRetries = 3;
        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                var result = await SimulatePaymentCall(request, cancellationToken);
                
                if (result.Success)
                {
                    lock (_lock)
                    {
                        if (_circuitState == CircuitState.HalfOpen)
                        {
                            _circuitState = CircuitState.Closed;
                            _recentFailures.Clear();
                            Console.WriteLine("Circuit CLOSED after successful call");
                        }
                    }
                    return result;
                }
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"Attempt {attempt} failed with timeout");
                if (attempt == maxRetries)
                {
                    RecordFailure();
                    return new PaymentResult { Success = false, Message = "Payment failed after retries" };
                }
                await Task.Delay(1000 * attempt, cancellationToken);
            }
        }

        RecordFailure();
        return new PaymentResult { Success = false, Message = "Payment failed" };
    }

    private void RecordFailure()
    {
        lock (_lock)
        {
            var now = DateTime.Now;
            _recentFailures.Enqueue(now);

            while (_recentFailures.Count > 0 && (now - _recentFailures.Peek()) > _failureWindow)
            {
                _recentFailures.Dequeue();
            }

            if (_recentFailures.Count >= 5)
            {
                _circuitState = CircuitState.Open;
                _circuitOpenedAt = now;
                Console.WriteLine("Circuit OPENED due to 5 failures in 1 minute");
            }
        }
    }

    private async Task<PaymentResult> SimulatePaymentCall(PaymentRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(100, cancellationToken);
        _callCount++;
        if (_callCount <= 7)
        {
            throw new TimeoutException("Gateway timeout");
        }
        return new PaymentResult { Success = true, Message = "Payment processed" };
    }
}
