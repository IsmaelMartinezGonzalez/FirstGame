using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private CharacterController controlador;
    private Vector3 moveAxis;
    public float velocity = 6f;
    private Vector3 velocidadMovimiento;
    private Animator animator;
    void Start()
    {
        controlador = GetComponent<CharacterController>();
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

        controlador.Move(direction * velocity * Time.deltaTime);

        velocidadMovimiento.y += velocidadMovimiento.y * Time.deltaTime;
        controlador.Move(velocidadMovimiento * Time.deltaTime);
    }
}