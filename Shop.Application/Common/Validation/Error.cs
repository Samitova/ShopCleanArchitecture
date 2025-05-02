namespace Shop.Application.Common.Validation;
public class Error : IEquatable<Error>
{
    public static readonly Error None = new (string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "The spesified result value is null.");
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string Message { get; }
 
    public static implicit operator string(Error error) => error.Code;

    public static bool operator ==(Error? er1, Error? er2)
    {
        if (er1 is null && er2 is null)
        {
            return true;
        }
        if (er1 is null || er2 is null)
        {
            return false;
        }

        return er1.Equals(er2);
    }

    public static bool operator !=(Error? er1, Error? er2)
        => !(er1 == er2);

    public virtual bool Equals(Error? other)
    {
        if (other is null)
        {
            return false;
        }

        return Code == other.Code && Message == other.Message;
    }

    public override bool Equals(object? obj)
        => obj is Error error && Equals(error);

    public override int GetHashCode()
        => HashCode.Combine(Code, Message);

    public override string ToString()
        => Code;
}
