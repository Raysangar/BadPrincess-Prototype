using UnityEngine;
using System.Collections;

public class LoggingManager : MonoBehaviour {
    ArrayList log;
	// Use this for initialization
	void Start () {
        log = new ArrayList();
        log.Add(new LoggingMessage(Type.PRINCESS, "dadsajdhk", "Princesita"));
        log.Add(new LoggingMessage(Type.COARSE, "dadsajdhakdskajdkashk", "Montaraz"));
        log.Add(new LoggingMessage(Type.PRINCESS, "dadsajdhk", "Princesita"));
        log.Add(new LoggingMessage(Type.COARSE, "dadsajdhakdskajdkashk", "Montaraz"));
        log.Add(new LoggingMessage(Type.PRINCESS, "dadsajdhk", "Princesita"));
        log.Add(new LoggingMessage(Type.COARSE, "dadsajdhakdskajdkashk", "Montaraz"));
        log.Add(new LoggingMessage(Type.PRINCESS, "dadsajdhk", "Princesita"));
        log.Add(new LoggingMessage(Type.COARSE, "dadsajdhakdskajdkashk", "Montaraz"));
        log.Add(new LoggingMessage(Type.PRINCESS, "dadsajdhk", "Princesita"));
        log.Add(new LoggingMessage(Type.COARSE, "dadsajdhakdskajdkashk", "Montaraz"));
        log.Add(new LoggingMessage(Type.PRINCESS, "dadsajdhk", "Princesita"));
        log.Add(new LoggingMessage(Type.COARSE, "dadsajdhakdskajdkashk", "Montaraz"));
        log.Add(new LoggingMessage(Type.PRINCESS, "dadsajdhk", "Princesita"));
        log.Add(new LoggingMessage(Type.COARSE, "dadsajdhakdskajdkashk", "Montaraz"));
        log.Add(new LoggingMessage(Type.PRINCESS, "dadsajdhk", "Princesita"));
        log.Add(new LoggingMessage(Type.COARSE, "dadsajdhakdskajdkashk", "Montaraz"));

	}

    public ArrayList getUnitLog(Type unitType)
    {
        if (unitType == Type.ALL) 
            return log;
        ArrayList unitLog = new ArrayList();
        foreach (LoggingMessage message in log)
        {
            if (message.unitType == unitType)
                unitLog.Add(message);
        }
        return unitLog;
    }

    public void addMessage(LoggingMessage message)
    {
        log.Add(message);
    }
}
