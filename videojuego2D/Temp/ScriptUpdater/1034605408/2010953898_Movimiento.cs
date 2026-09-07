using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Movimiento")]
    public float speed = 5f;          // Velocidad horizontal
    public float jumpForce = 12f;     // Fuerza de salto

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Movimiento horizontal con Input.GetAxisRaw (respuesta instantánea)
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Salto solo si está en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // Detecta colisión con el suelo
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}
