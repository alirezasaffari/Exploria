using RestSharp;

namespace app.Helpers;

public class Request
{
    private readonly string _baseUrl;
    public Request(string baseUrl)
    {
        _baseUrl = baseUrl;
    }
    public async Task<string?> Execute(string address, Method method = Method.Get, int timeout = -1, object? body = null, List<(string name, string value)>? headers = null, List<(string name, string value)>? parameters = null, CancellationToken cancellationToken = new())
    {
        //await Task.Delay(7000,cancellationToken);
        var options = new RestClientOptions(_baseUrl)
        {
            MaxTimeout = timeout,
        };
        var client = new RestClient(options);
        var request = new RestRequest(address, method);
        if (headers != null)
        {
            foreach (var (name, value) in headers)
            {
                request.AddHeader(name, value);
            }
        }

        if (parameters != null)
        {
            foreach (var (name, value) in parameters)
            {
                request.AddParameter(name, value);
            }
        }

        if (body != null)
        {
            request.AddBody(body);
        }

        var response = await client.ExecuteAsync(request,cancellationToken);
        return response?.Content;
    }
}