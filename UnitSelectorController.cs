using UnityEngine;
using System.Collections;

public class UnitSelectorController : MonoBehaviour {
    private UnitController unitController;

	// Use this for initialization
	void Start () {
        unitController = gameObject.GetComponent<UnitController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.layer.Equals(8))
                    unitController.setUnit(hitInfo.transform.gameObject);
                else
                    unitController.setUnit(null);
            }
        }
	}
}
