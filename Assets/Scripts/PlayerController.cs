using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionAsset playerAction;
    public float accelerationSpeed;
    public float rotationSpeed;
    public GameObject bullet;
    public float bulletLifeTime;
    public AudioSource bulletSound;

    private readonly float rotationSpeedOffset = 100.0f;
    private bool isRotating = false;
    private Vector3 rotatingDirection = Vector3.zero;

    private bool isAccelerating = false;

    private void Awake()
    {
        InitializeInputs();
    }

    private void Update()
    {
        if (isRotating)
        {
            transform.Rotate(rotationSpeed * rotationSpeedOffset * Time.deltaTime * rotatingDirection);
        }

        if (isAccelerating) 
        {
            transform.Translate(accelerationSpeed * Time.deltaTime * Vector3.up);
        }
    }

    private void InitializeInputs()
    {
        InputActionMap gameplayInputMap = playerAction.FindActionMap("Gameplay");
        InputAction rotationAction = gameplayInputMap.FindAction("Rotation");
        InputAction accelerationAction = gameplayInputMap.FindAction("Acceleration");
        InputAction actionAction = gameplayInputMap.FindAction("Action");

        rotationAction.started += StartRotating;
        rotationAction.canceled += StopRotating;
        accelerationAction.started += StartAccelerating;
        accelerationAction.canceled += StopAccelerating;
        actionAction.performed += OnShoot;
    }

    private void StartRotating(InputAction.CallbackContext context)
    {
        float rotationValue = context.ReadValue<float>();
        rotatingDirection = new(0, 0, -rotationValue);
        isRotating = true;
    }

    private void StopRotating(InputAction.CallbackContext context)
    {
        rotatingDirection = Vector3.zero;
        isRotating = false;
    }

    private void StartAccelerating(InputAction.CallbackContext context) 
    {
        isAccelerating = true;
    }

    private void StopAccelerating(InputAction.CallbackContext context) 
    {
        isAccelerating = false;
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        GameObject bulletClone = Instantiate(bullet);
        bulletClone.transform.position = transform.position;
        bulletClone.transform.eulerAngles = transform.eulerAngles;
        bulletSound.Play();
    }
}
