using Microsoft.AspNetCore.Http;

public class UrlServico
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UrlServico(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string ObterUrlServidor()
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        if (request == null)
            return string.Empty;

        string urlServidor = $"{request.Scheme}://{request.Host}";
        return urlServidor;
    }
}
