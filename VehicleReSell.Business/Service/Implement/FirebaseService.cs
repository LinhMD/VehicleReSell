using CrudApiTemplate.CustomException;
using Firebase.Auth;
using Firebase.Storage;
using VehicleReSell.Business.Service.Core;

namespace VehicleReSell.Business.Service.Implement;

public class FirebaseService : IFirebaseServiceIntegration
{
    private const string ApiKey = "AIzaSyAK1fQuzIYWfOSLx_0BzlPogTl3d7YROkM";
    private const string Bucket = "vehicleresell.appspot.com";
    private const string AuthEmail = "linhmd@gmail.com";
    private const string AuthPassword = "123456789";


    public async Task<string> UploadFileAsync(Stream file, string name)
    {
        var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
        var authLink = auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword).Result;
        var task = new FirebaseStorage(Bucket, new FirebaseStorageOptions()
        {
            AuthTokenAsyncFactory = () => Task.FromResult(authLink.FirebaseToken),
            ThrowOnCancel = true,
        });
        try
        {
            return  await task.Child("file").Child(name).PutAsync(file);
        }
        catch (Exception e)
        {
            throw new ModelValueInvalidException(e.Message);
        }
    }

}