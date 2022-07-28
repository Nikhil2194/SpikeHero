using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectorScript : MonoBehaviour

{
    public TextMeshProUGUI scoreText;
    private int score;

    void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }


    

    void OnTriggerEnter2D(Collider2D target)
    {
        IncreaseScore();
          target. gameObject.SetActive(false); //When this hits any object deactive arrow
    }
}

