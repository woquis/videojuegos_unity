using UnityEngine;

public class Destriur : MonoBehaviour {
    // Este script debe ir en el objeto "Pelota"

    private void OnCollisionEnter2D(Collision2D collision) {
        // Si la pelota choca con el jugador, se destruye
        if (collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }

    // Alternativa si usas Collider2D con "Is Trigger" activado:
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}
