using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathEvent : MonoBehaviour
{

    HighscoreScript currentScore;
    public GameObject scoreCanvas;
    GameManagerScript gameMan;

    // Start is called before the first frame update
    void Start()
    {
        gameMan = GameManagerScript.Instance;
        currentScore = scoreCanvas.GetComponent<HighscoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            if (gameMan.highscore < currentScore.score)
            {
                gameMan.SetNewHighscore(currentScore.score);
            }
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
        }
    }

}
