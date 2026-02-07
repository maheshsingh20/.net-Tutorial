using System.Text.Json;
using System.Text.RegularExpressions;

namespace m1Assessment_Practise.Questions.Question7;

class CustomerValidator
{
    private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
    private static readonly Regex PANRegex = new(@"^[A-Z]{5}[0-9]{4}[A-Z]$", RegexOptions.Compiled);

    public ValidationReport ValidateBatch(List<string> jsonPayloads)
    {
        var report = new ValidationReport { TotalRecords = jsonPayloads.Count };

        for (int i = 0; i < jsonPayloads.Count; i++)
        {
            var errors = ValidateRecord(jsonPayloads[i]);
            
            if (errors.Count > 0)
            {
                report.InvalidCount++;
                report.Errors.Add(new ValidationError
                {
                    RecordIndex = i + 1,
                    Errors = errors
                });
            }
            else
            {
                report.ValidCount++;
            }
        }

        return report;
    }

    private List<string> ValidateRecord(string json)
    {
        var errors = new List<string>();

        try
        {
            var customer = JsonSerializer.Deserialize<CustomerApplication>(json);

            if (customer == null)
            {
                errors.Add("Invalid JSON format");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(customer.Name))
                errors.Add("Name is mandatory");

            if (string.IsNullOrWhiteSpace(customer.Email))
                errors.Add("Email is mandatory");
            else if (!EmailRegex.IsMatch(customer.Email))
                errors.Add("Invalid email format");

            if (string.IsNullOrWhiteSpace(customer.PAN))
                errors.Add("PAN is mandatory");
            else if (!PANRegex.IsMatch(customer.PAN))
                errors.Add("Invalid PAN format (expected: ABCDE1234F)");

            if (customer.Age < 18 || customer.Age > 60)
                errors.Add("Age must be between 18 and 60");
        }
        catch (JsonException)
        {
            errors.Add("JSON parsing failed");
        }

        return errors;
    }
}
