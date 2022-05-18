using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPlayer : MonoBehaviour
{
    public Player player;

    public string myDirection;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        myDirection = player.direction;
    }

    // Update is called once per frame
    void Update()
    {
        //Move to direction player is looking;
        switch (myDirection)
        {
            case "right":
                transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
                break;
            case "left":
                transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
                break;
            case "back":
                transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
                break;
            case "front":
                transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
                break;
        }
    }
}
