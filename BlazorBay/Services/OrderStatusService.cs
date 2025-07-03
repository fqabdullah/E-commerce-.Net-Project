using System.Text.Json;

public class OrderStatusService
{
    private readonly string filePath = Path.Combine("Data", "orderStatus.json");
    private Dictionary<int, string> statusMap = new();

    public OrderStatusService()
    {
        LoadFromFile();
    }

    public string GetStatus(int orderId)
    {
        return statusMap.ContainsKey(orderId) ? statusMap[orderId] : "Pending";
    }

    public void UpdateStatus(int orderId, string newStatus)
    {
        statusMap[orderId] = newStatus;
        SaveToFile();
    }

    private void LoadFromFile()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            statusMap = JsonSerializer.Deserialize<Dictionary<int, string>>(json) ?? new();
        }
    }

    private void SaveToFile()
    {
        var json = JsonSerializer.Serialize(statusMap, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public Dictionary<int, string> GetAllStatuses() => statusMap;
}
