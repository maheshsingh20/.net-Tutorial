namespace m1Assessment_Practise.Questions.Question13;

class ProductImporter
{
    private readonly List<Product> _products = new();

    public ImportResult ImportProducts(string csvPath)
    {
        if (!File.Exists(csvPath))
            throw new FileNotFoundException("CSV file not found", csvPath);

        var result = new ImportResult();
        var lines = File.ReadAllLines(csvPath);

        for (int i = 1; i < lines.Length; i++)
        {
            int rowNumber = i + 1;
            try
            {
                var parts = lines[i].Split(',');
                
                if (parts.Length != 3)
                {
                    result.Errors.Add(new ImportError
                    {
                        RowNumber = rowNumber,
                        Reason = "Invalid column count"
                    });
                    continue;
                }

                var product = new Product
                {
                    ProductId = parts[0].Trim(),
                    Name = parts[1].Trim(),
                    Price = decimal.Parse(parts[2].Trim())
                };

                if (string.IsNullOrWhiteSpace(product.ProductId))
                {
                    result.Errors.Add(new ImportError
                    {
                        RowNumber = rowNumber,
                        Reason = "ProductId is empty"
                    });
                    continue;
                }

                if (product.Price <= 0)
                {
                    result.Errors.Add(new ImportError
                    {
                        RowNumber = rowNumber,
                        Reason = "Price must be positive"
                    });
                    continue;
                }

                _products.Add(product);
                result.InsertedCount++;
            }
            catch (FormatException)
            {
                result.Errors.Add(new ImportError
                {
                    RowNumber = rowNumber,
                    Reason = "Invalid price format"
                });
            }
            catch (Exception ex)
            {
                result.Errors.Add(new ImportError
                {
                    RowNumber = rowNumber,
                    Reason = ex.Message
                });
            }
        }

        return result;
    }

    public void DisplayProducts()
    {
        Console.WriteLine("\n=== Imported Products ===");
        foreach (var p in _products)
        {
            Console.WriteLine($"{p.ProductId}: {p.Name} - {p.Price:C}");
        }
    }
}
