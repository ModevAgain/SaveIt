using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{

    public static GameManagerScript Instance;

    public ParticleSystem prefab;

    GameObject Highscore;

    [HideInInspector]
    public int highscore = 0;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameScene"))
        {
            OnMouseClick();
        }

        Highscore = GameObject.FindGameObjectWithTag("Highscore");
        if (Highscore != null)
        {
            Highscore.GetComponent<TextMeshProUGUI>().text = "Highscore:" + highscore.ToString();
        }
    }

    public void LoadScene (string name) => SceneManager.LoadScene(name);

    public void SetNewHighscore(int score)
    {
        highscore = score;
    }

    private void OnMouseClick()
    {
        Debug.Log("Click");
        ParticleSystem ps = Instantiate(prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity) as ParticleSystem;
        Destroy(ps.gameObject, ps.startLifetime);
    }
}
