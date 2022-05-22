using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 0.25f;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float dx = Input.GetAxis("Mouse X");
        float dy = Input.GetAxis("Mouse Y");
        var eulerAngles = transform.eulerAngles;
        transform.eulerAngles = new Vector3(eulerAngles.x - dy * sensitivity , eulerAngles.y + dx * sensitivity, 0);
        
        Vector3 direction = Vector3.zero;
        if (Input.GetKey (KeyCode.W)){
            direction += new Vector3(0, 0 , 1);
        }
        if (Input.GetKey (KeyCode.S)){
            direction += new Vector3(0, 0, -1);
        }
        if (Input.GetKey (KeyCode.A)){
            direction += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            direction += new Vector3(1, 0, 0);
        }
        if (Input.GetKey (KeyCode.Space)){
            direction += new Vector3(0, 1, 0);
        }
        if (Input.GetKey (KeyCode.LeftControl)){
            direction += new Vector3(0, -1, 0);
        }
        transform.Translate(direction);
    }
}