using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveAxis;
    private float speed = 6f;
    private Vector3 MovementVelocity;
    private Animator animator;
    public Joystick joystick;
    private float xMove, yMove;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 direction = new Vector3(joystick.Horizontal, 0f, joystick.Vertical).normalized;

        //Rotation
        if (direction.magnitude >= 0.1f)
        {
            Quaternion bearing = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, bearing, 25f * Time.deltaTime);
        }

        //Gravity
        if (controller.isGrounded && MovementVelocity.y < 0)
        {
            MovementVelocity.y = -2f;
        }
        else
        {
            MovementVelocity.y += -9.8f * Time.deltaTime;
        }

        Vector3 finalmove = direction * speed;
        finalmove.y = MovementVelocity.y;
        controller.Move(finalmove * Time.deltaTime);
    }
}