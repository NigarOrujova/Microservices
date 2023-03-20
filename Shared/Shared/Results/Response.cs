using System.Text.Json.Serialization;

namespace CodeAcademy.Shared.Results;

public class Response<T> {
    public T? Data { get; private set; }

    [JsonIgnore]
    public int StatusCode { get; private set; }

    [JsonIgnore]
    public bool IsSuccessful { get; private set; }

    public ICollection<string>? Errors { get; private set; }

    // Static Factory Method
    public static Response<T> Success(T data, int statusCode)
        => new Response<T> {
            Data = data,
            StatusCode = statusCode
        };

    /// <summary>
    /// No Return Type Actions ( update, delete etc. )
    /// </summary>
    /// <param name="statusCode"></param>
    /// <returns></returns>
    public static Response<T> Success(int statusCode)
        => new Response<T> {
            Data = default(T),
            StatusCode = statusCode,
            IsSuccessful = true
        };

    public static Response<T> Fail(string errors, int statusCode)
         => new Response<T> {
             Data = default(T),
             StatusCode = statusCode,
             IsSuccessful = false,
             Errors = new List<string> { errors }
         };

    public static Response<T> Fail(List<string> errors, int statusCode)
        => new Response<T> {
            Data = default(T),
            StatusCode = statusCode,
            IsSuccessful = false,
            Errors = errors
        };
}
