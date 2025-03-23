using UnityEngine;

public class ToadPatrulla : MonoBehaviour
{
    public float velocidad = 2f;  // Velocidad con la que se mueve Toad
    public Transform puntoA, puntoB;  // Puntos de patrullaje

    private bool moviendoDerecha = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    void Update()
    {
        if (moviendoDerecha)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            if (transform.position.x >= puntoB.position.x)
                moviendoDerecha = false;
        }
        else
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            if (transform.position.x <= puntoA.position.x)
                moviendoDerecha = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Detecta si choca con Mario
        {
            Debug.Log("Toad chocó con Mario.");
            // Aquí puedes agregar código para restar vida o reiniciar el nivel.
        }
    }
}
