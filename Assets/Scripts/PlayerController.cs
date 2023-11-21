using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject cam;

    private Vector2 bodyMovement;
    private Vector2 cameraMovement;

    [SerializeField] private float bodyMoveSpeed;
    [SerializeField] private float camMoveSpeed;
    private Vector2 rotationCamera;


    [SerializeField] private Transform weapon;
    [SerializeField] private GameObject bladeAmmo;
    private float xBladeRotation;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0).gameObject;
    }


    void Start()
    {
        UnityEngine.Cursor.visible = false;
    }


    void Update()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        // body
        Vector3 forward = transform.forward * bodyMovement.y;
        Vector3 right = transform.right * bodyMovement.x;
        rb.velocity =  (forward + right + new Vector3(0f, rb.velocity.y, 0f)) * bodyMoveSpeed;

        // camera
        rotationCamera.x -= cameraMovement.y * Time.deltaTime * camMoveSpeed;
        rotationCamera.x = Mathf.Clamp(rotationCamera.x, -45, 45);
        rotationCamera.y += cameraMovement.x * Time.deltaTime * camMoveSpeed;
        cam.transform.localRotation = Quaternion.Euler(rotationCamera.x, 0, 0);
        //Rotating the player
        transform.localRotation = Quaternion.Euler(0, rotationCamera.y, 0);
        


        //ËMathf.PingPong(xBladeRotation, Time.deltaTime * 10f);
    }


    public void Move(InputAction.CallbackContext context)
    {
        bodyMovement = context.ReadValue<Vector2>().normalized;
    }

    public void Look(InputAction.CallbackContext context)
    {
        cameraMovement = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {   

    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Shoot 
            {
                Instantiate(bladeAmmo, transform.position, transform.rotation);
            };
        }
    }
}
