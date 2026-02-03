using System;
using System.Text.Json;

public class SimulatorService
{
    private string _state = "Inactive";
    private string? _port;
    private JsonElement? _data; 

    public string Open(string port)
    {
        _port = port;
        _state = "PortOpen";
        return $"[OK] Port {_port} opened.";
    }

    public string Start()
    {
        _state = "Enabled";
        return "[OK] Simulator started (polling ON).";
    }

    public string Vend(int index)
    {
        if (_state != "Enabled" && _state != "SessionIdle")
            return "[ERR] Simulator not ready.";
        _state = "Vend";
        _state = "SessionIdle";
        return $"[OK] Vend request for product {index} approved. Delivery done.";
    }

    public string Close()
    {
        _state = "Inactive";
        return "[OK] Simulator closed.";
    }

    public string State() => $"[STATE] {_state} on {_port}";

    public string PrintData(JsonElement data)
    {
        _data = data;

        if (data.TryGetProperty("Product", out JsonElement productGet))
        {
            string? product = productGet.GetString();
            Console.WriteLine($"Product: {product}");
            return $"[OK] Product: {product}";
        }
        else
        {
            Console.WriteLine("No product found");
            return "[WARN] No product found";
        }
    }

}
