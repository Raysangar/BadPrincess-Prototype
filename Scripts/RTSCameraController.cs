using UnityEngine;
using System.Collections;

public class RTSCameraController : MonoBehaviour
{
    private const int ZoomSpeed = 50;
    private const int ZoomMin = 25;
    private const int ZoomMax = 100;
    private const int PanSpeed = 50;
    private const int PanAngleMin = 50;
    private const int PanAngleMax = 80;

    // Update is called once per frame
    void Update()
    {
        // Mouse Buttons and Edge Scrolling Stuff
        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;
        int scrollDistance = 5;
        float scrollSpeed = 200;
        float ScrollAmount = scrollSpeed * Time.deltaTime;

        //mouse left
        if (mousePosX < scrollDistance)
        {
            transform.Translate(-ScrollAmount, 0, 0, Space.World);
        }
        //mouse right
        if (mousePosX >= (Screen.width - scrollDistance))
        {
            transform.Translate(ScrollAmount, 0, 0, Space.World);
        }
        //mouse down
        if (mousePosY < scrollDistance)
        {
            transform.Translate(0, 0, -ScrollAmount, Space.World);
        }
        //mouse up
        if (mousePosY >= (Screen.height - scrollDistance))
        {
            transform.Translate(0, 0, ScrollAmount, Space.World); ;
        }

        //Keyboard controls 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, ScrollAmount, Space.World); ;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -ScrollAmount, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-ScrollAmount, 0, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(ScrollAmount, 0, 0, Space.World);
        }
    }
}