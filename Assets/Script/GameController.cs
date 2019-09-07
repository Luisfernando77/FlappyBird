using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public GameObject gamerOverText;
    public bool gameOver;
    public float scrollSpeed = -1.5f;
    private int score;
    public Text scoreText;

    private void Awake()
    {
        if (GameController.instance == null)
        {
            GameController.instance = this;
        }
        else if (GameController.instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("GameController ha sido instanciado por segunda vez. Esto no deberia pasar");
        }


    }
    // Start is called before the first frame update
    public void BirdScore()
    {
        if (gameOver) return;

        score++;
        scoreText.text = "Score: " + score;
        SoundSystem.instance.PlayCoin();
    }


    public void BirdDie()
    {
        gamerOverText.SetActive(true);
        gameOver = true;

    }
    private void OnDestroy()
    {
        if (GameController.instance == this)
        {
            GameController.instance = null;
        }


    }
}

