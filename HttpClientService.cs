using System;
using System.Net.Http;

public class HttpClientService
{
    private readonly HttpClient _httpClient_;

    public HttpClientService()
    {
        _httpClient_ = new HttpClient
        {
            BaseAddress = new Uri("https://icanhazdadjoke.com/")
        };
        
        _httpClient_.DefaultRequestHeaders.Add("Accept", "application/json");

    }

    public HttpClient GetHttpClient()
    {
        return _httpClient_;
    }
}
