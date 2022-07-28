using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   public void GamePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void StartGameFirstScreen()
    {
        SceneManager.LoadScene("GameStart");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
