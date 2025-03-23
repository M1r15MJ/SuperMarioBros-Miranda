using UnityEngine;

public class MuevePersonaje : MonoBehaviour
{
    public float velocidadX = 5f;
    public float velocidadY = 10f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Asegurar que se obtiene el Rigidbody2D
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() // Se usa FixedUpdate para manejar la física
    {
        float movHorizontal = Input.GetAxisRaw("Horizontal");

        // Asegurar que Mario se mueve cambiando la velocidad
        if (rb != null) // Evitar errores si rb no está asignado
        {
            rb.linearVelocity = new Vector2(movHorizontal * velocidadX, rb.linearVelocity.y);
        }
        else
        {
            Debug.LogError("Rigidbody2D no asignado a Mario. Asegúrate de que tiene un Rigidbody2D.");
        }

        // Activar animación de caminar
        animator.SetBool("Walking", movHorizontal != 0);

        // Girar el personaje según dirección
        if (movHorizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (movHorizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void Update()
    {
        // Salto
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, velocidadY);
            animator.SetTrigger("Jumping");
            enSuelo = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}

