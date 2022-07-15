namespace CustomException;

[System.Serializable]
public class UserNameNotAvailableException : System.Exception
{
    public UserNameNotAvailableException() { }
    public UserNameNotAvailableException(string message) : base(message) { }
    public UserNameNotAvailableException(string message, System.Exception inner) : base(message, inner) { }
    protected UserNameNotAvailableException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

