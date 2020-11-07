using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<UnityEngine.UI.Text>().text = score.ToString();
        if (BirdMovement.GameOver)
        {
           button.SetActive(true);
        }
    }

    public static void IncScore()
    {
        score++;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
