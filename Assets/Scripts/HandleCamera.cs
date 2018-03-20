using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCamera : MonoBehaviour {
    
    public float moveSpeed = 2f, zoomSpeed = 2f;
    public int minZoom = 40, maxZoom = 80;
    
    private Vector3 move;
    private Vector3 cameraOffset;
    private Vector3 rotation;
    private byte numOfRotations = 1;

    void Start ()
    {
        move = Vector3.zero;
        cameraOffset = transform.position;
        rotation = new Vector3(45.0f, 90.0f, 0.0f);
    }

    void Update()
    {
        PanCamera();
        ZoomCamera();
        RotateCamera();
    }

    void PanCamera()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if      (numOfRotations == 1 && transform.position.x <= 200) { move.x =  moveSpeed; }
            else if (numOfRotations == 2 && transform.position.z >= 350) { move.z = -moveSpeed; }
            else if (numOfRotations == 3 && transform.position.x >= 350) { move.x = -moveSpeed; }
            else if (numOfRotations == 4 && transform.position.z <= 150) { move.z =  moveSpeed; }
            transform.position += move;
            cameraOffset = transform.position;
            move = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if      (numOfRotations == 1 && transform.position.x >= -250) { move.x = -moveSpeed; }
            else if (numOfRotations == 2 && transform.position.z <=  730) { move.z =  moveSpeed; }
            else if (numOfRotations == 3 && transform.position.x <=  730) { move.x =  moveSpeed; }
            else if (numOfRotations == 4 && transform.position.z >= -250) { move.z = -moveSpeed; }
            transform.position += move;
            cameraOffset = transform.position;
            move = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if      (numOfRotations == 1 && transform.position.z <= 440) { move.z =  moveSpeed; }
            else if (numOfRotations == 2 && transform.position.x <= 440) { move.x =  moveSpeed; }
            else if (numOfRotations == 3 && transform.position.z >=  50) { move.z = -moveSpeed; }
            else if (numOfRotations == 4 && transform.position.x >=  50) { move.x = -moveSpeed; }
            transform.position += move;
            cameraOffset = transform.position;
            move = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if      (numOfRotations == 1 && transform.position.z >=  50) { move.z = -moveSpeed; }
            else if (numOfRotations == 2 && transform.position.x >=  50) { move.x = -moveSpeed; }
            else if (numOfRotations == 3 && transform.position.z <= 450) { move.z =  moveSpeed; }
            else if (numOfRotations == 4 && transform.position.z <= 450) { move.x =  moveSpeed; }
            transform.position += move;
            cameraOffset = transform.position;
            move = Vector3.zero;
        }
    }

    void ZoomCamera ()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize > minZoom) // zoom in, 
        {
            Camera.main.orthographicSize -= zoomSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize < maxZoom) // zoom out
        {
            Camera.main.orthographicSize += zoomSpeed;
        }
    }

    void RotateCamera()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if      (numOfRotations == 1) { cameraOffset += new Vector3( 300.0f, 0.0f,  300.0f); numOfRotations++;   }
            else if (numOfRotations == 2) { cameraOffset += new Vector3( 300.0f, 0.0f, -300.0f); numOfRotations++;   }
            else if (numOfRotations == 3) { cameraOffset += new Vector3(-300.0f, 0.0f, -300.0f); numOfRotations++;   }
            else if (numOfRotations == 4) { cameraOffset += new Vector3(-300.0f, 0.0f,  300.0f); numOfRotations = 1; }
            rotation += new Vector3(0.0f, 90.0f, 0.0f);
            transform.position = cameraOffset;
            transform.rotation = Quaternion.Euler(rotation);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if      (numOfRotations == 1) { cameraOffset += new Vector3( 300.0f, 0.0f, -300.0f); numOfRotations = 4; }
            else if (numOfRotations == 2) { cameraOffset += new Vector3(-300.0f, 0.0f, -300.0f); numOfRotations--;   }
            else if (numOfRotations == 3) { cameraOffset += new Vector3(-300.0f, 0.0f,  300.0f); numOfRotations--;   }
            else if (numOfRotations == 4) { cameraOffset += new Vector3( 300.0f, 0.0f,  300.0f); numOfRotations--;   }
            rotation -= new Vector3(0.0f, 90.0f, 0.0f);
            transform.position = cameraOffset;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
