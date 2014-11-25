using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {
    private GameObject unit;
    private Vector3 targetPosition;
    public int speed = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                targetPosition.x = hitInfo.point.x;
                targetPosition.y = hitInfo.point.y;
                targetPosition.z = hitInfo.point.z;
            }
        }
        if (unit != null)
        {
            
                unit.transform.LookAt(new Vector3(targetPosition.x, 0, targetPosition.z));
                unit.transform.position = Vector3.MoveTowards(unit.transform.position, targetPosition, speed * Time.deltaTime);
                //unit.transform.Translate(hitInfo.point.x, unit.transform.position.y, hitInfo.point.z);
        }
	}

    public void setUnit(GameObject unit)
    {
        if (this.unit != null)
            this.unit.renderer.material.color = Color.white;
        this.unit = unit;
        if (this.unit != null)
        {
            this.unit.renderer.material.color = Color.blue;
            targetPosition = unit.transform.position;
        }
    }
}
