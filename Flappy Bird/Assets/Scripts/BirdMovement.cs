using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdMovement : MonoBehaviour
{
    public static bool GameOver = false;
    public static bool start = false;
    public float force;
    private Rigidbody2D rb;
    public AudioSource jumpSound;
    public AudioSource pointSound;
    public AudioSource hitSound;
    public AudioSource deathSound;
    // Start is called before the first frame update
    void Start()
    {
        start = false;
        GameOver = false;
        rb = this.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            start = true;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (Input.touchCount > 0 && !GameOver && start)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                rb.velocity = Vector2.up * force;
                jumpSound.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameOver && start)
        {
            if (collision.tag == "point")
            {
                Score.IncScore();
                pointSound.Play();
            }
            else if (collision.tag == "Pipe")
            {
                hitSound.Play();
                deathSound.Play();
                GameOver = true;
            }
        }
    }
}
