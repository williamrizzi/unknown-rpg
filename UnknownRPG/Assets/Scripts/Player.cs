using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameController gameCtrl;

    public int life;
    public int damage;

    public GameObject[] objs;
    public GameObject[] uiObjs;
    public GameObject[] uiCharIcons;
    public float speed;
    public float speedMod;
    public Animator anim;

    public float x;
    public float y;
    public string direction;

    public int objSelect;
    public GameObject selectIcon;

    public GameObject allObjects;

    // Start is called before the first frame update
    void Start()
    {
        gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        life = 3;
        objSelect = 0;
        direction = "front";

        GameObject myObj = Instantiate(objs[objSelect], transform.position, Quaternion.identity);
        myObj.transform.parent = gameObject.transform;
        myObj.transform.tag = "transformation";

        //SelectedChar(); // PARA POSTERIOR

        InventoryUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameCtrl.block == false)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            Vector2 moveVelocity = new Vector2(x, y);
            moveVelocity *= (speed * speedMod) * Time.deltaTime;
            transform.Translate(moveVelocity);
        }


        if (gameCtrl.block == false)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("RB_Button")) // Troca pra esquerda
            {
                GameObject[] tempObj = GameObject.FindGameObjectsWithTag("transformation");
                if (tempObj.Length <= 0)
                {
                    if (objSelect == 0)
                    {
                        objSelect = objs.Length - 1;
                        GameObject myObj = Instantiate(objs[objSelect], transform.position, Quaternion.identity);
                        myObj.transform.parent = gameObject.transform;
                        myObj.transform.tag = "transformation";
                    }
                    else
                    {
                        objSelect--;
                        GameObject myObj = Instantiate(objs[objSelect], transform.position, Quaternion.identity);
                        myObj.transform.parent = gameObject.transform;
                        myObj.transform.tag = "transformation";
                    }
                }
                else
                {
                    for (int i = 0; i < tempObj.Length; i++)
                    {
                        Destroy(tempObj[i]);
                    }
                    if (objSelect == 0)
                    {
                        objSelect = objs.Length - 1;
                        GameObject myObj = Instantiate(objs[objSelect], transform.position, Quaternion.identity);
                        myObj.transform.parent = gameObject.transform;
                        myObj.transform.tag = "transformation";
                    }
                    else
                    {
                        objSelect--;
                        GameObject myObj = Instantiate(objs[objSelect], transform.position, Quaternion.identity);
                        myObj.transform.parent = gameObject.transform;
                        myObj.transform.tag = "transformation";
                    }
                }

                //SelectedChar(); // PARA O POSTERIOR
            }
            if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("LB_Button"))  // Troca pra direita
            {
                GameObject[] tempObj = GameObject.FindGameObjectsWithTag("transformation");
                if (tempObj.Length <= 0)
                {
                    if (objSelect == objs.Length - 1)
                    {
                        objSelect = 0;
                        GameObject myObj = Instantiate(objs[objSelect], transform.position, Quaternion.identity);
                        myObj.transform.parent = gameObject.transform;
                        myObj.transform.tag = "transformation";
                    }
                    else
                    {
                        objSelect++;
                        GameObject myObj = Instantiate(objs[objSelect], transform.position, Quaternion.identity);
                        myObj.transform.parent = gameObject.transform;
                        myObj.transform.tag = "transformation";
                    }
                }
                else
                {
                    for (int i = 0; i < tempObj.Length; i++)
                    {
                        Destroy(tempObj[i]);
                    }

                    if (objSelect == objs.Length - 1)
                    {
                        objSelect = 0;
                        GameObject myObj = Instantiate(objs[objSelect], transform.position, Quaternion.identity);
                        myObj.transform.parent = gameObject.transform;
                        myObj.transform.tag = "transformation";
                    }
                    else
                    {
                        objSelect++;
                        GameObject myObj = Instantiate(objs[objSelect], transform.position, Quaternion.identity);
                        myObj.transform.parent = gameObject.transform;
                        myObj.transform.tag = "transformation";
                    }
                }

                //SelectedChar(); //PARA O POSTERIOR
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("LB_Button"))
            {                
                GameObject.FindGameObjectWithTag("transformation").GetComponentInChildren<AnimController>().AttackAnim();
            }

        }
    }       


    void InventoryUI()
    {
        for(int i = 0; i < uiObjs.Length; i++)
        {
            if (uiObjs[i] != null)
            {
                uiObjs[i].GetComponent<SpriteRenderer>().sprite = uiCharIcons[i].GetComponent<SpriteRenderer>().sprite;
            }
        }
    }


    // PARA O POSTERIOR
    //void SelectedChar()
    //{
    //    GameObject[] tempObj = GameObject.FindGameObjectsWithTag("Selected");
    //    for (int i = 0; i < tempObj.Length; i++)
    //    {
    //        Destroy(tempObj[i]);
    //    }
    //    if (objSelect == objs.Length - 1)
    //    {            
    //        GameObject myObj = Instantiate(selectIcon, uiObjs[objSelect].transform.position, Quaternion.identity);
    //        myObj.transform.parent = uiObjs[objSelect].transform;
    //        myObj.transform.tag = "Selected";
    //    }
    //    else
    //    {            
    //        GameObject myObj = Instantiate(selectIcon, uiObjs[objSelect].transform.position, Quaternion.identity);
    //        myObj.transform.parent = uiObjs[objSelect].transform;
    //        myObj.transform.tag = "Selected";
    //    }
    //}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Npc4" && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(objs[objSelect], transform.position, Quaternion.identity); //Cria uma copia do item na mão.

            objs[objSelect] = collision.GetComponent<PropController>().myPrefab; // seta a referencia desse filho como o novo objeto do slot
            collision.GetComponent<BoxCollider2D>().enabled = false;

            GameObject myObj = Instantiate(objs[objSelect], transform.position, Quaternion.identity); //cria o novo objeto            
            myObj.transform.parent = gameObject.transform; //adiciona ele como filho

            GameObject[] tempObj = GameObject.FindGameObjectsWithTag("transformation"); //procura os objetos para destruir            
            for (int i = 0; i < tempObj.Length; i++) //destroi todos objetos anteriores
            {
                Destroy(tempObj[i]);
            }

            myObj.transform.tag = "transformation"; //seta a tag do objeto novo

            InventoryUI(); //atualiza inventario

            //Destroy(collision.gameObject); //destroi objeto pego do mapa            
        }
    }

   


}
