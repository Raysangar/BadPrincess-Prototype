using UnityEngine;
using System.Collections;

public class TrapLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Unit" || other.gameObject.tag == "Enemy")
        {
            Debug.Log("TURAPU CAADO OPEN");
            animation.Play("Up Down");  
        }
    }

}
