using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb2d;
    public Sprite lowHealth;
    public Sprite mediumHealth;
    public Sprite FullHealth;
    public const string Right = "right";
    public const string Left = "left";
    public float jumpAmount;
    public int ObjectiveNumber;
    public int Life;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * (Time.deltaTime * Speed);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * (Time.deltaTime * Speed);
        }

        if (ObjectiveNumber <= 0)
        {
            FindObjectOfType<GameContorller>().GameClear();
        }

        if (Life <= 0)
        {
            FindObjectOfType<GameContorller>().GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            Debug.Log("apple gone");
        }
        else if (other.CompareTag("GoldenApple"))
        {
            Destroy(other.gameObject);

            Debug.Log("GoldenApple");

            ObjectiveNumber -= 1;
        }
        else if (other.CompareTag("Breath"))
        {
            Life -= 1;
            Debug.Log("" + Life);
        }
    }

    private void FixedUpdate()
    {
        PlayerHealth();
    }

    private void PlayerHealth()
    {
        if (Life < 3)
        {
            spriteRenderer.sprite = lowHealth;
        }
        else if (Life < 5)
        {
            spriteRenderer.sprite = mediumHealth;
        }
        else
        {
            spriteRenderer.sprite = FullHealth;
        }
    }

   
}
