using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
    public float speed;
    public GameObject playerObj;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
    }
}
