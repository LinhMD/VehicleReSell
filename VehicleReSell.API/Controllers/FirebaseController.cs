using Microsoft.AspNetCore.Mvc;
using VehicleReSell.Business.Service.Core;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FirebaseController : ControllerBase
{
    private readonly IFirebaseServiceIntegration _firebase;

    public FirebaseController(IFirebaseServiceIntegration firebase)
    {
        _firebase = firebase;
    }

    [HttpPost("files")]
    public async Task<ActionResult<string>> UploadImage(IFormFile file)
    {
        await using var stream = file.OpenReadStream();
        var fileFormat = file.FileName.Split('.').Last();
        var fileName = file.FileName[..file.FileName.LastIndexOf('.')];
        fileName = $"{fileName}_{Guid.NewGuid().ToString()}.{fileFormat}";
        return Ok(await _firebase.UploadFileAsync(stream, fileName));
    }
}