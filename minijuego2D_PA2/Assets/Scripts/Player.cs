using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public Animator animator;           //Crear animacion de personaje

    public int coins;
    public TMP_Text textCoins;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         rb2D = GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
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

        animator.SetFloat("Speed",Mathf.Abs(move));
        animator.SetFloat("VerticalVelocity",rb2D.linearVelocity.y); //velocidad en eje vertical del personaje
        animator.SetBool("isGrounded", isGrounded);
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            textCoins.text=coins.ToString();
        }
        if (collision.transform.CompareTag("Spikes")) //colision con obstaculo
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
        if (collision.transform.CompareTag("Barrel"))
        {
            Vector2 knockbackDir = (rb2D.position - (Vector2)collision.transform.position).normalized;
            rb2D. linearVelocity = Vector2. zero;
            rb2D.AddForce(knockbackDir * 3, ForceMode2D. Impulse);

            BoxCollider2D[] colliders = collision.gameObject.GetComponents<BoxCollider2D>();

            foreach (BoxCollider2D col in colliders)
            {
                col.enabled = false;
            }
        
            collision.GetComponent<Animator>().enabled=true;
            Destroy(collision.gameObject, 0.5f);
        }
    }
}

