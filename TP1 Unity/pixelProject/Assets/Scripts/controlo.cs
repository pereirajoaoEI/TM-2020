using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controlo : MonoBehaviour
{

    public int totpontos;
    public Text pontosText;

public GameObject gameOver;

    public static controlo contr;
   

    void Start()
    {
        contr = this;
    }

    public void UpdateScoreText()
    {
        pontosText.text = totpontos.ToString();
    }

    public void ShowGameOver()
    {
    gameOver.SetActive(true);
    }

    public void RestartGame( string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

}
