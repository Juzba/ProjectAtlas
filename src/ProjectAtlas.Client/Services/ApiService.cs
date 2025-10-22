﻿using System.Text;
using System.Text.Json;

namespace ProjectAtlas.Client.Services;

public interface IApiService
{
    Task<T?> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default);
    Task<T?> GetAsync<T>(string endpoint, int id, CancellationToken cancellationToken = default);
    Task<T?> PostAsync<T, TRequest>(string endpoint, TRequest dataOutput, CancellationToken cancellationToken = default);
    Task<T?> PutAsync<T, TRequest>(string endpoint, int id, TRequest dataOutput, CancellationToken cancellationToken = default);
    Task<T?> PutAsync<T, TRequest>(string endpoint, string id, TRequest dataOutput, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string endpoint, int id, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string endpoint, string id, CancellationToken cancellationToken = default);
}



public class ApiService(HttpClient httpClient) : IApiService
{

    private readonly HttpClient _httpClient = httpClient;


    public async Task<T?> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<T>(content);
            }
            else

            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while making the API request: {ex.Message}", ex);
        }
    }



    public async Task<T?> GetAsync<T>(string endpoint, int id, CancellationToken cancellationToken = default)
    {
        try
        {
            string url = $"{endpoint}/{id}";
            HttpResponseMessage response = await _httpClient.GetAsync(url, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<T>(content);
            }
            else
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while making the API request: {ex.Message}", ex);
        }
    }



    public async Task<T?> PostAsync<T, TRequest>(string endpoint, TRequest dataOutput, CancellationToken cancellationToken = default)
    {
        try
        {
            var json = JsonSerializer.Serialize(dataOutput);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<T>(responseContent);
            }
            else
            {
                string errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new HttpRequestException($"Error: {response.StatusCode}. Details: {errorContent}");
            }
        }
        catch (HttpRequestException ex)
        {
            throw new HttpRequestException($"HTTP request failed: {ex.Message}", ex);
        }
        catch (JsonException ex)
        {
            throw new JsonException($"Failed to serialize request or deserialize response: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new Exception($"An unexpected error occurred while making the API request: {ex.Message}", ex);
        }
    }


    // PUT-ASYNC WITH INT ID //
    public async Task<T?> PutAsync<T, TRequest>(string endpoint, int id, TRequest dataOutput, CancellationToken cancellationToken = default)
    {
        try
        {
            var json = JsonSerializer.Serialize(dataOutput);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = $"{endpoint}/{id}";
            HttpResponseMessage response = await _httpClient.PutAsync(url, content, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<T>(responseContent);
            }
            else
            {
                string errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new HttpRequestException($"Error: {response.StatusCode}. Details: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while making the PUT request: {ex.Message}", ex);
        }
    }

    // PUT-ASYNC WITH STRING ID //
    public async Task<T?> PutAsync<T, TRequest>(string endpoint, string id, TRequest dataOutput, CancellationToken cancellationToken = default)
    {
        try
        {
            var json = JsonSerializer.Serialize(dataOutput);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = $"{endpoint}/{id}";
            HttpResponseMessage response = await _httpClient.PutAsync(url, content, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<T>(responseContent);
            }
            else
            {
                string errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new HttpRequestException($"Error: {response.StatusCode}. Details: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while making the PUT request: {ex.Message}", ex);
        }
    }


    // DELETE-ASYNC WITH INT ID //
    public async Task<bool> DeleteAsync(string endpoint, int id, CancellationToken cancellationToken = default)
    {
        try
        {
            string url = $"{endpoint}/{id}";
            HttpResponseMessage response = await _httpClient.DeleteAsync(url, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                string errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new HttpRequestException($"Error: {response.StatusCode}. Details: {errorContent}");
            }
        }
        catch (HttpRequestException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception($"An unexpected error occurred while making the DELETE request: {ex.Message}", ex);
        }
    }

    // DELETE-ASYNC WITH STRING ID //
    public async Task<bool> DeleteAsync(string endpoint, string id, CancellationToken cancellationToken = default)
    {
        try
        {
            string url = $"{endpoint}/{id}";
            HttpResponseMessage response = await _httpClient.DeleteAsync(url, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                string errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new HttpRequestException($"Error: {response.StatusCode}. Details: {errorContent}");
            }
        }
        catch (HttpRequestException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception($"An unexpected error occurred while making the DELETE request: {ex.Message}", ex);
        }
    }
}
