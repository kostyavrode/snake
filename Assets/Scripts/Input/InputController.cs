using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector2 DistanceToClick(Vector2 headPos)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToViewportPoint(mousePos);
        mousePos.y = 1;
        mousePos = Camera.main.ViewportToWorldPoint(mousePos);
        Vector2 distance = new Vector2(mousePos.x - headPos.x, mousePos.y - headPos.y);
        return distance;
    }
}
