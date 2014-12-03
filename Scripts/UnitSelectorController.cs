using UnityEngine;
using System.Collections;

public class UnitSelectorController : MonoBehaviour {
    private static Rect selectionRectangle = new Rect(0,0,0,0);
    private UnitController unitController;
    private Vector3 startClick = -Vector3.one;
    private GameObject[] units;

	void Start () {
        unitController = gameObject.GetComponent<UnitController>();
        units = GameObject.FindGameObjectsWithTag("Unit");
	}
	
	void Update () {
        UpdateSelectionRectangle();
        if (Input.GetButtonUp("Fire1"))
        {
            if (selectionRectangle.width == 0 && selectionRectangle.height == 0)
                shootRay();
            else
                unitController.setUnits(GetSelectedUnits());
        }
	}

    private void UpdateSelectionRectangle()
    { 
        if (Input.GetButtonDown("Fire1"))
            startClick = Input.mousePosition;
        if (Input.GetButton("Fire1"))
            scaleSelectionRectangle();
        if (Input.GetButtonUp("Fire1"))
        {
            transformNegativeScales();
            startClick = -Vector3.one;
        }
    }

    private ArrayList GetSelectedUnits()
    {
        ArrayList selectedUnits = new ArrayList();
        foreach (GameObject unit in units)
        {
            if (unit.renderer.isVisible)
            {
                Vector3 unitPositionOnCamera = Camera.main.WorldToScreenPoint(unit.transform.position);
                unitPositionOnCamera.y = transformYAxisFromScreenToWorld(unitPositionOnCamera.y);
                if (selectionRectangle.Contains(unitPositionOnCamera))
                    selectedUnits.Add(unit);
            }
        }
        return selectedUnits;
    }

    private void scaleSelectionRectangle()
    {
        selectionRectangle = new Rect(startClick.x, transformYAxisFromScreenToWorld(startClick.y), Input.mousePosition.x - startClick.x,
            transformYAxisFromScreenToWorld(Input.mousePosition.y) - transformYAxisFromScreenToWorld(startClick.y));
    }

    private static float transformYAxisFromScreenToWorld(float y)
    {
        return Screen.height - y;
    }

    private void transformNegativeScales()
    {
        if (selectionRectangle.width < 0)
            transformRectangleWidth();
        if (selectionRectangle.height < 0)
            transformRectangleHeight();
    }

    private void transformRectangleWidth()
    {
        selectionRectangle.y += selectionRectangle.width;
        selectionRectangle.width = -selectionRectangle.width;
    }

    private void transformRectangleHeight()
    {
        selectionRectangle.x += selectionRectangle.height;
        selectionRectangle.height = -selectionRectangle.height;
    }

    private void shootRay()
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
