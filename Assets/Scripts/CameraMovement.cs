using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    
    void Update()
    {
        if(Input.GetKey("w")){
            transform.Translate(Vector3.up * Time.deltaTime * 3f);
        }
        if(Input.GetKey("s")){
            transform.Translate(Vector3.down * Time.deltaTime* 3f);
        }
        if(Input.GetKey("a")){
            transform.Translate(Vector3.left * Time.deltaTime* 3f);
        }
        if(Input.GetKey("d")){
            transform.Translate(Vector3.right * Time.deltaTime* 3f);
        }
        cam.orthographicSize += Input.mouseScrollDelta.y * 0.2f;
    }
}
