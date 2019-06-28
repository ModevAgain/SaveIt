using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{

    public HighscoreScript score;
    Rigidbody2D rb;
    public float forceMultiplicator = 1f;

    Animator anim;

    //HighscoreScript currentScore;
    //public GameObject scoreCanvas;
    //GameManagerScript gameMan;

    // Start is called before the first frame update
    void Start()
    {
        //gameMan = GameManagerScript.Instance;
        //currentScore = scoreCanvas.GetComponent<HighscoreScript>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        Debug.Log("Click2222");
        anim.Play("Hit");
        rb.velocity = Vector2.zero;
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var heading = gameObject.transform.position - mousePosition;
        heading = new Vector3(heading.x, heading.y, 0);
        //var distance = heading.magnitude;
        //var forceDirection = heading/distance;
        var forceDirection = heading.normalized;
        rb.AddForce(forceDirection * forceMultiplicator);
        Debug.Log(forceDirection);
        score.NewScore();
    }
}
