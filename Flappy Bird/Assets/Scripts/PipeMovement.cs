using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!BirdMovement.GameOver && BirdMovement.start)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            if (this.transform.position.x < -2)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
