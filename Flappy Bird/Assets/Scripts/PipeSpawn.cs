using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public float waitTime = 2.0f;
    public float timer = 0.0f;
    public GameObject pipe;
    public float heightRange;
    public bool start;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        timer = 0.0f;
        while (!start)
        {
            timer += Time.deltaTime;

            // Check if we have reached beyond 2 seconds.
            // Subtracting two is more accurate over time than resetting to zero.
            if (timer > waitTime)
            {
                start = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (start && !BirdMovement.GameOver && BirdMovement.start)
        {
            timer += Time.deltaTime;

            // Check if we have reached beyond 2 seconds.
            // Subtracting two is more accurate over time than resetting to zero.
            if (timer > waitTime)
            {
                GameObject nextPipe = Instantiate(pipe);
                nextPipe.transform.position = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
                // Remove the recorded 2 seconds.
                timer = timer - waitTime;
            }
        }
    }
}
