using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TextFiller : MonoBehaviour {
    public Type unitType;
    LoggingManager loggingManager;
    public Text logText;
    Dictionary<string, Type> unitTypeDictionary;

	// Use this for initialization
	void Start () {
        loggingManager = GameObject.Find("LogManager").GetComponent<LoggingManager>();
        unitType = Type.ALL;
        unitTypeDictionary = new Dictionary<string, Type>();
        unitTypeDictionary.Add("ALL", Type.ALL);
        unitTypeDictionary.Add("COARSE", Type.COARSE);
        unitTypeDictionary.Add("WARRIOR", Type.WARRIOR);
        unitTypeDictionary.Add("RECOLLECTOR", Type.RECOLLECTOR);
        unitTypeDictionary.Add("PRINCESS", Type.PRINCESS);
	}
	
	// Update is called once per frame
	void Update () {
        logText.text = "";
        ArrayList log = loggingManager.getUnitLog(unitType);
        foreach (LoggingMessage message in log)
            logText.text += getMessageStringDate(message) + " -> " + message.unitName + " " + message.message + "\n";
	}

    private string getMessageStringDate(LoggingMessage message)
    {
        return message.date.Hour + ":" + message.date.Minute + ":" + message.date.Second;
    }

    public void changeUnitType(string unitType)
    {
        this.unitType = unitTypeDictionary[unitType];
    }
}
