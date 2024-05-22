namespace TorneoTenis.API.Services.Autentication.Interfaces
{
    public interface IEncryptionService
    {
        public string Encrypt(string text);
        public string Decrypt(string text);
    }
}
