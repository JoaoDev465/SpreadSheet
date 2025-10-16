using System.Text.Json.Serialization;

namespace Core.ValueObjects.ResponseVO;

public record Code
{
    public Code(int value)
    {
        Value = value;
    }

    public int Value{ get; }
    public bool IsSucces => Value is >= 200 and <= 299;
    public bool IsError => Value is >= 400 and <= 599;

    public static Code Ok() => new(200);
    public static Code Created() => new(201);
    public static Code BadResquest() => new(400);
    public static Code NotFound() => new(404);
    public static Code InternalServerError() => new(500);

   public override string ToString()
   {
       return Value.ToString();
   }
}