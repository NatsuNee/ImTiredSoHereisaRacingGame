using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody sphereRB;
    public Rigidbody carRB;

    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;
    public float maxSpeed;
    public float currentSpeed;
    public LayerMask groundLayer;

    private float moveInput;
    private float turnInput;
    private bool isCarGrounded;

    private float normalDrag;
    public float modifiedDrag;

    public float alignToGroundTime;

    void Start()
    {
        // Detach Sphere from car
        sphereRB.transform.parent = null;
        carRB.transform.parent = null;

        normalDrag = sphereRB.drag;
    }

    void Update()
    {

        //Grab Current Speed from Motor
        float currentSpeedVar = (((int)carRB.velocity.magnitude));

        // Get Input
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        // Calculate Turning Rotation
        if (currentSpeedVar != 0)
        {
            float newRot = turnInput * turnSpeed * Time.deltaTime;

            if (isCarGrounded)
                transform.Rotate(0, newRot, 0, Space.World);
        }

        // Set Cars Position to Our Sphere
        transform.position = sphereRB.transform.position;

        // Raycast to the ground and get normal to align car with it.
        RaycastHit hit;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundLayer);

        // Rotate Car to align with ground
        Quaternion toRotateTo = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotateTo, alignToGroundTime * Time.deltaTime);

        // Calculate Movement Direction
        //moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;
        if (moveInput == 1 & currentSpeed <= maxSpeed) 
        {
            currentSpeed += fwdSpeed;
            sphereRB.drag = 2.4f;
        }
        else if (moveInput == -1 & currentSpeed <= maxSpeed)
        {
            currentSpeed -= revSpeed;
            sphereRB.drag = 4.3f;
        }
        else if (moveInput == 0)
        {
            const double V = 0.9992;
            currentSpeed = (float)(currentSpeed * V);
            sphereRB.drag = 3f;
        }

        // Calculate Drag
        //sphereRB.drag = isCarGrounded ? normalDrag : modifiedDrag;
    }

    private void FixedUpdate()
    {
        if (isCarGrounded)
            sphereRB.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration); // Add Movement
        else
            sphereRB.AddForce(transform.up * -200f); // Add Gravity

        carRB.MoveRotation(transform.rotation);

    }
}