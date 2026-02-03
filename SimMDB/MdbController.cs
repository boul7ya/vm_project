using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

[ApiController]
[Route("mdb")]
public class MdbController : ControllerBase
{
    private readonly SimulatorService VMC;
    public MdbController(SimulatorService vmc) => VMC = vmc;

    [HttpPost("open/{port}")]
    public string Open([FromRoute] string port) => VMC.Open(port);

    [HttpPost("start")]
    public string Start() => VMC.Start();

    [HttpPost("vend/{index:int}")]
    public string Vend([FromRoute] int index) => VMC.Vend(index);

    [HttpPost("close")]
    public string Close() => VMC.Close();

    [HttpGet("state")]
    public string State() => VMC.State();

    [HttpPost("data")]
    public string Data([FromBody] JsonElement body) => VMC.PrintData(body);
}
