using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDangerScript : MonoBehaviour
{

    public float dangerTimer;
    public float lowestDangerTime;
    float lastDangerTime;

    public float dangerWait;
    public float dangerLifeTime;
    int dangerCount = 0;

    public GameObject warning;
    public GameObject danger;

    public float dangerOffset;
    float dangerOffsetY;
    float dangerOffsetX;

    // Start is called before the first frame update
    void Start()
    {
        lastDangerTime = Time.time;
        dangerOffsetY = Screen.height / dangerOffset;
        dangerOffsetX = Screen.width / dangerOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastDangerTime > dangerTimer)
        {
            SpawnWarning();
            lastDangerTime = Time.time;
            dangerCount += 1;
        }   
        if(dangerCount >= 3)
        {
            dangerCount = 0;
            if(dangerTimer > lowestDangerTime)
            {
                dangerTimer -= 0.5f;
            }
            else if(dangerTimer < lowestDangerTime)
            {
                dangerTimer = lowestDangerTime;
            }
        }
    }

    void SpawnWarning()
    {
        var spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, dangerOffsetY)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height - dangerOffsetY)).y);
        var spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(dangerOffsetX, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - dangerOffsetX, 0)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        var warningGO = Instantiate(warning, spawnPosition, Quaternion.identity);

        SpawnDanger(spawnPosition, warningGO);
        Debug.Log("WarningSpawned");
    }

    void SpawnDanger(Vector2 spawnPosition, GameObject warning)
    {
        StartCoroutine(WaitDanger(dangerWait, spawnPosition, warning));
    }

    void DestroyDanger(GameObject danger)
    {
        StartCoroutine(WaitDestroy(dangerLifeTime, danger));
    }

    IEnumerator WaitDanger(float time, Vector2 spawnPosition, GameObject warning)
    {
        yield return new WaitForSeconds(time);
        Destroy(warning);
        var dangerGO = Instantiate(danger, spawnPosition, Quaternion.identity);
        DestroyDanger(dangerGO);
        Debug.Log("DangerSpawned");
    }

    IEnumerator WaitDestroy(float time, GameObject danger)
    {
        yield return new WaitForSeconds(time);
        Destroy(danger);
        Debug.Log("DangerDestroyed");
    }
}
