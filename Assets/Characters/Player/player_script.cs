using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private CharacterController controlador;
    public float velocidad = 6f;
    public float gravedad = -9.81f;
    private Vector3 velocidadMovimiento;

    void Start()
    {
        controlador = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Obtener teclas de movimiento (WASD / Flechas)
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        // Calcular dirección basada en hacia dónde mira el objeto
        Vector3 direccion = transform.right * movX + transform.forward * movZ;

        // Mover el personaje en esa dirección
        controlador.Move(direccion * velocidad * Time.deltaTime);

        // Aplicar gravedad básica
        if (controlador.isGrounded && velocidadMovimiento.y < 0)
        {
            velocidadMovimiento.y = -2f;
        }

        velocidadMovimiento.y += gravedad * Time.deltaTime;
        controlador.Move(velocidadMovimiento * Time.deltaTime);
    }
}