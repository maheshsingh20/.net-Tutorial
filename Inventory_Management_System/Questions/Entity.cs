using System;
namespace InventoryManagementSystem
{
  public class Entity
  {
    public string Name { get; set; } = "";
    public string Model { get; set; } = "";
    public int warrantyPeriod { get; set; }
    public int wattage { get; set; }
    public string Manufacturing_Date { get; set; } = "";
  }
}