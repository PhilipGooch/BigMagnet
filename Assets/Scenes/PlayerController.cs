using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject CameraBoom;
    public Camera PlayerCamera;


    public float MovementScaler;

    private Vector3 MovementForce;
    private Vector3 OtherForces;

    private Vector3 rotation;
    public float lookSpeed;

    public float ZoomSpeed;

    


    void Start()
    {

        OtherForces = new Vector3(0, 0, 0);
    }

    void Update()
    {
        
        


        Vector3 horizontal = Input.GetAxisRaw("Horizontal") * transform.right;
        Vector3 vertical = Input.GetAxisRaw("Vertical") * transform.forward;

        Vector3 direction = horizontal + vertical;

        MovementForce = direction * MovementScaler;
        gameObject.GetComponent<Rigidbody>().velocity = MovementForce + OtherForces;

        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        transform.eulerAngles = new Vector3(0, rotation.y, 0);

        rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
        CameraBoom.transform.eulerAngles = transform.eulerAngles + new Vector3(rotation.x, 0, 0);

        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            PlayerCamera.transform.localPosition += new Vector3(0, 0, Input.GetAxisRaw("Mouse ScrollWheel") * ZoomSpeed);
        }

    }
}
