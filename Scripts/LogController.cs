using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogController : MonoBehaviour {
    bool showLog;
    public GameObject log;
	// Use this for initialization
	void Start () {
        showLog = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("adjaslkdjsal");
            showLog = !showLog;
        }
        log.SetActive(showLog);
	}
}
