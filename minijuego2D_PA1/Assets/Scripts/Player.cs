using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb2D;
    
    private float move;

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
    }
}
