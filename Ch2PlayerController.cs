using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private int score;
    private int lives;
    public float speed;
    public float jumpForce;
    public Text Score;
    public Text Win;
    public Text Lives;
    public Text Lose;
    public GameObject Player;
    public AudioClip Victory;
    public bool PlayVictory;

    void Start() {

        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        SetScoreText();
        lives = 3;

        Win.text = "";
        Lose.text = "";

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
        if (score == 4)
        {
            transform.position = new Vector3(-6.7f, 36.72f, 0f);
        }
        if (lives <= 0)
        {
            Destroy(Player);
        }
    }


void SetScoreText()
    {
        Score.text = "Score: " + score.ToString();
        if (score >= 8)
        {
            Win.text = "You Win!";
        }
    }

    void SetLivesText()
    {
        Lives.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            Lose.text = "Game Over";
        }
    }

    void Awake()
    {
        PlayVictory = true;
    }

    void Playvictory()
    {
        if (PlayVictory)
        {
            
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") {
            
            if(Input.GetKey(KeyCode.UpArrow)) {

                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
}
