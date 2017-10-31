using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{


    public float panSpeed = 40f;
    public Vector2 panLimit;
    public float zoomMaxLimit = 20f;
    public float zoomMinLimit = 140f;

    public float scrollSpeed = 20f;
    // Use this for initialization

    void Start()
    {
        panLimit.x = 100f;
        panLimit.y = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (GetComponent<Camera>().orthographicSize > zoomMaxLimit || GetComponent<Camera>().orthographicSize > zoomMinLimit)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            GetComponent<Camera>().orthographicSize += scroll * scrollSpeed * 100f * Time.deltaTime;
            if(GetComponent<Camera>().orthographicSize <= zoomMaxLimit)
            {
                GetComponent<Camera>().orthographicSize = 20.1f;
            }
            else if(GetComponent<Camera>().orthographicSize > zoomMinLimit)
            {
                GetComponent<Camera>().orthographicSize = 139f;
            }

               

           
        }
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
}