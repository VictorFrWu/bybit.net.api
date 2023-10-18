namespace bybit.net.api
{
    public interface IBybitSignatureService
    {
        string Sign(string data);
        string GeneratePostSignature(Dictionary<string, object> parameters);
        string GenerateGetSignature(Dictionary<string, object> parameters);
        string GenerateQueryString(Dictionary<string, object> parameters);
    }
}
