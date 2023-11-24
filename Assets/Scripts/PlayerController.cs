using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject cam;
    private AudioSource source;


    private Vector2 bodyMovement;
    private Vector2 cameraMovement;

    [SerializeField] private float bodyMoveSpeed;
    [SerializeField] private float camMoveSpeed;
    private Vector2 rotationCamera;


    [SerializeField] private Transform weapon;
    [SerializeField] private GameObject bladeAmmo;


    private float zBladeRotation;
    private float zBladeSpeedRotation = 10f;

    [SerializeField] private float distToPickUp;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0).gameObject;
        source = GetComponent<AudioSource>();
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


        zBladeRotation += zBladeRotation;

        Vector3 forwardDirCam = cam.transform.TransformDirection(Vector3.forward) * distToPickUp;
        Debug.DrawRay(transform.position, forwardDirCam, Color.green);
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
                GameObject blade = Instantiate(bladeAmmo, transform.position, transform.rotation);
                blade.transform.Rotate(0f, 0f, zBladeRotation);
            };
        }
    }

    public void Grab(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RaycastHit hit;
            Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, distToPickUp); 
            if (hit.transform.tag == "Flower")
            {
                Debug.Log("Touché");
                hit.transform.gameObject.SetActive(false);
                source.Play();
            }
        }
    }
}
