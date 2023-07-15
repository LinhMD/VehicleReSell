namespace VehicleReSell.Business.Service.Core;

public interface IFirebaseServiceIntegration
{
    public Task<string> UploadFileAsync(Stream file, string name);

}