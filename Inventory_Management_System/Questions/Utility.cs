namespace InventoryManagementSystem
{
  public static class Utility
  {
    public static bool ValidateEntityDetails(string name, string model, int warrantyPeriod, int wattage, string manufacturingDate)
    {
      if (string.IsNullOrWhiteSpace(name))
      {
        throw new InvalidEntityDataException("Invalid name");
      }

      if (string.IsNullOrWhiteSpace(model))
      {
        throw new InvalidEntityDataException("Invalid model");
      }

      if (warrantyPeriod < 0)
      {
        throw new InvalidEntityDataException("Invalid warranty period");
      }

      if (wattage < 0)
      {
        throw new InvalidEntityDataException("Invalid wattage");
      }
      if (!DateTime.TryParse(manufacturingDate, out _))
      {
        throw new InvalidEntityDataException("Invalid manufacturing date");
      }
      return true;
    }
  }
}