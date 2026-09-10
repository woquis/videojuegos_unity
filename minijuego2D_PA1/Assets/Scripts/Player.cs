using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb2D;
    
    private float move;
    private float jumpForce = 4f;         //fuerza del salto
    private bool isGrounded;            //si esta en el suelo o no true or false
    public Transform groundCheck;      //detectar si esta en el suelo
    public float groundRadius = 0.1f;    //para que la esfera detecta la colision con el suelo
    public LayerMask groundLayer;       //colision con la layer

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(move*speed, rb2D.linearVelocity.y);

        if (move!=0)
        transform.localScale = new Vector3(Mathf.Sign(move),1,1);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }
}
