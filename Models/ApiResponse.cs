namespace MyApi.Models;

/// <summary>
/// Standard wrapper for all API responses.
/// Ensures consistent response structure across success and error cases.
/// </summary>
/// <typeparam name="T">Type of the data being returned.</typeparam>
public class ApiResponse<T>
{
    /// <summary>
    /// Indicates whether the request was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// A message describing the result of the operation.
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// The actual data returned by the API.
    /// Can be null in error responses.
    /// </summary>
    public T? Data { get; set; }
}