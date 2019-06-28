using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreScript : MonoBehaviour
{
    //float lastTime;
    //public float cooldownTime = 1f;

    [HideInInspector]
    public int score;

    TextMeshProUGUI text;

    public GameObject textObj;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //lastTime = Time.time;
        text = textObj.GetComponent<TextMeshProUGUI>();
        text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Time.time - lastTime > cooldownTime)
        //{
        //  lastTime = Time.time;
        //}
    }
    public void NewScore()
    {
        score += 1;

        text.text = score.ToString();
    }
}
