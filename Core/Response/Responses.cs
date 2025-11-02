using System.Text.Json.Serialization;
using Core.ValueObjects.ResponseVO;

namespace Core.Response;

public  class Responses<T>
{
    [JsonConstructor] 
    public Responses(T data){}

    public Responses(T? data, string? message, Code? code)
    {
        Data = data;
        Message = message;
        Code = code;
    }

    public static Responses<T> Success(T? data) =>
        new Responses<T>(data, "Ok",Code.Ok());
    
    public static Responses<T> Created(T? data) =>
        new Responses<T>(data, "Created",Code.Created());
    
    public static Responses<T> BadRequest(T? data) =>
        new Responses<T>(data, "Bad Request",Code.BadResquest());
    
    public static Responses<T> NotFound(T? data) =>
        new Responses<T>(data, "Not Found",Code.NotFound());
    
    public static Responses<T> InternalServerError(T? data) =>
        new Responses<T>(data, "Internal Server Error",Code.InternalServerError());

    public string? Message { get; set; }
    public  Code Code{ get; set; }
    public  T? Data { get; set; }
}