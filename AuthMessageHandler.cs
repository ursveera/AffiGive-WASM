using System.Net.Http.Headers;

public class AuthMessageHandler : DelegatingHandler
{
    private readonly AuthService _auth;

    public AuthMessageHandler(AuthService auth)
    {
        _auth = auth;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(_auth.Token))
        {
            await _auth.LoadTokenAsync();
        }
        if (!string.IsNullOrEmpty(_auth.Token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _auth.Token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
