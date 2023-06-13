using UnityEngine;

public class AnimalRigidbodyRotation : MonoBehaviour
{
    [SerializeField] private float sensetivity = 1.5f;
    [SerializeField] private float smooth = 10;
    [SerializeField] private Transform character;

    private float yRotation;
    private float xRotation;

    private AnimalRigitbodyMovement animal;
    private Transform _animal;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        yRotation = 180f;
        xRotation = 0;    
    }

    private void Update()
    {       
        yRotation += Input.GetAxis("Mouse X") * sensetivity;
        xRotation -= Input.GetAxis("Mouse Y") * sensetivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);       
    }

    private void FixedUpdate()
    {
        RotateCharacter();
    }

    private void RotateCharacter()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(xRotation, yRotation, 0), Time.deltaTime * smooth);
        character.rotation = Quaternion.Lerp(character.rotation, Quaternion.Euler(0, yRotation, 0), Time.deltaTime * smooth);
    }  
}
