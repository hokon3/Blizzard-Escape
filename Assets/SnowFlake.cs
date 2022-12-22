using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlake : MonoBehaviour
{
    private CircleCollider2D CircleCollider2D;
    private BoxCollider2D Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        CircleCollider2D = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 0.25F);
        var vec = transform.position;
        vec.x -= (1F * Time.deltaTime);
        transform.transform.position = vec;

        if (CircleCollider2D.IsTouching(Player))
        {
            Player.BroadcastMessage("Hit");
            GameObject.Destroy(gameObject);
        }
        if (transform.position.x < -(Camera.main.orthographicSize*2))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
