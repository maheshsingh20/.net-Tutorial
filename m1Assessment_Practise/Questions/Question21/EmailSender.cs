namespace m1Assessment_Practise.Questions.Question21;

class EmailSender
{
    private readonly int _maxEmailsPerSecond;
    private readonly SemaphoreSlim _throttle;
    private int _sentCount = 0;

    public EmailSender(int maxEmailsPerSecond)
    {
        _maxEmailsPerSecond = maxEmailsPerSecond;
        _throttle = new SemaphoreSlim(maxEmailsPerSecond);
    }

    public async Task<BulkSendReport> SendBulkAsync(List<Email> emails)
    {
        var report = new BulkSendReport { TotalEmails = emails.Count };
        var retryQueue = new Queue<(Email email, int attemptCount)>();

        foreach (var email in emails)
        {
            retryQueue.Enqueue((email, 0));
        }

        var startTime = DateTime.Now;
        var tasks = new List<Task>();

        while (retryQueue.Count > 0)
        {
            var (email, attemptCount) = retryQueue.Dequeue();

            tasks.Add(Task.Run(async () =>
            {
                await _throttle.WaitAsync();
                
                try
                {
                    var elapsed = (DateTime.Now - startTime).TotalSeconds;
                    var expectedDelay = (_sentCount / (double)_maxEmailsPerSecond) - elapsed;
                    
                    if (expectedDelay > 0)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(expectedDelay));
                    }

                    bool success = await SendEmailAsync(email);
                    Interlocked.Increment(ref _sentCount);

                    if (success)
                    {
                        lock (report)
                        {
                            report.SuccessCount++;
                        }
                    }
                    else
                    {
                        if (attemptCount < 2)
                        {
                            lock (retryQueue)
                            {
                                retryQueue.Enqueue((email, attemptCount + 1));
                            }
                        }
                        else
                        {
                            lock (report)
                            {
                                report.FailureCount++;
                                report.FailedRecipients.Add(email.To);
                            }
                        }
                    }
                }
                finally
                {
                    _throttle.Release();
                }
            }));

            if (tasks.Count >= _maxEmailsPerSecond)
            {
                await Task.WhenAll(tasks);
                tasks.Clear();
            }
        }

        if (tasks.Count > 0)
        {
            await Task.WhenAll(tasks);
        }

        return report;
    }

    private async Task<bool> SendEmailAsync(Email email)
    {
        await Task.Delay(50);
        return new Random().Next(100) >= 10;
    }
}
