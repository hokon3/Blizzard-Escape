using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject snowFlakePrefab;
    public witch witchScript;
    private float timer = 0.0f;
    private float waitTime = 2.0f;
    private float minWaitTime = 1.0f;
    private float maxWaitTime = 3.0f;
    private float topCordinate;
    private float bottomCordinate;
    private float rightCordinate;
    // Start is called before the first frame update
    void Start()
    {
        topCordinate = Camera.main.orthographicSize;
        bottomCordinate = -(Camera.main.orthographicSize);
        rightCordinate = Camera.main.orthographicSize * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!witchScript.started)
            return;
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            var spawnCordinates = new Vector2(rightCordinate, Random.Range(bottomCordinate, topCordinate));
            Instantiate(snowFlakePrefab, spawnCordinates, Quaternion.identity);
            spawnCordinates = new Vector2(rightCordinate, Random.Range(bottomCordinate, topCordinate));
            Instantiate(snowFlakePrefab, spawnCordinates, Quaternion.identity);
            timer = 0.0f;
            waitTime = Random.Range(minWaitTime, maxWaitTime);
        }
    }
}
