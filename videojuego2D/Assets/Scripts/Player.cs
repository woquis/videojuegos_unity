using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float velocidad = 5;
    private Rigidbody2D rb2D;
    private float mover;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mover = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(mover * velocidad, rb2D.linearVelocity.y);

        if (mover != 0)
            transform.localScale = new Vector3(Mathf.Sign(mover), 1, 1);

    }
}