using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {
    private ArrayList units;
    private Vector3 targetPosition;
    public int speed = 10;
	// Use this for initialization
	void Start () {
        units = new ArrayList();
        targetPosition = -Vector3.one;
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
        if (units != null && targetPosition != -Vector3.one)
        {
            foreach (GameObject unit in units)
            {
                unit.transform.LookAt(new Vector3(targetPosition.x, 0, targetPosition.z));
                unit.transform.position = Vector3.MoveTowards(unit.transform.position, targetPosition, speed * Time.deltaTime);
                //unit.transform.Translate(hitInfo.point.x, unit.transform.position.y, hitInfo.point.z);
            }
        }
	}

    public void setUnits(ArrayList units)
    {
        foreach (GameObject unit in this.units)
            unit.renderer.material.color = Color.white;
        this.units = units;
        foreach (GameObject unit in this.units)
            unit.renderer.material.color = Color.blue;
    }

    public void setUnit(GameObject unit)
    {
        foreach (GameObject oldUnit in units)
            oldUnit.renderer.material.color = Color.white;
        units = new ArrayList();
        if (unit != null)
        {
            unit.renderer.material.color = Color.blue;
            units.Add(unit);
        }
    }
}
