using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSelection : MonoBehaviour
{
    public GameObject alertPng;
    public GameObject alvo;
        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Define alvo para missão principal
            GameObject alertObj;
            alertObj = GameObject.FindGameObjectWithTag("missionAlert");
            Destroy(alertObj);
            Instantiate(alertPng, new Vector3(alvo.transform.position.x, alvo.transform.position.y + 2.0f, alvo.transform.position.z), Quaternion.identity);
        }
    }
}
