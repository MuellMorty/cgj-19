using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorsshairMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        transform.position = new Vector3(mouse.x, mouse.y, 0.0f);
    }
}
