using System.Collections;

public enum Type
{
    PRINCESS,
    WARRIOR,
    RECOLLECTOR,
    COARSE,
    ALL
}

public class LoggingMessage {
    public Type unitType;
    public string unitName;
    public System.DateTime date;
    public string message;

    public LoggingMessage(Type unitType, string message, string unitName)
    {
        this.unitType = unitType;
        this.message = message;
        this.unitName = unitName;
        date = System.DateTime.Now;
    }
}
