using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveAxis;
    public float velocity = 6f;
    private Vector3 MovementVelocity;
    private Animator animator;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveAxis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        animator.SetFloat("PosX", moveAxis.x);
        animator.SetFloat("PosZ", moveAxis.z);

        Vector3 direction = new Vector3(moveAxis.x, 0f, moveAxis.z).normalized;


        if (direction.magnitude >= 0.1f)
        {
            Quaternion bearing = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, bearing, 25f * Time.deltaTime);
        }

        if (controller.isGrounded && MovementVelocity.y < 0)
        {
            MovementVelocity.y = -2f;
        }
        else
        {
            MovementVelocity.y += -9.8f * Time.deltaTime;
        }

        Vector3 finalMove = direction * velocity;
        finalMove.y = MovementVelocity.y;
        controller.Move(finalMove * Time.deltaTime);
    }
}