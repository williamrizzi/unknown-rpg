using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public GameController gameCtrl;

    public Player player;

    public Animator anim;

    public bool attacking;


    // isso é para posterior
    //IEnumerator WaitToStart()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    anim.Play("SpawnMage");
    //    yield return new WaitForSeconds(1.5f);
    //    gameObject.GetComponent<SpriteRenderer>().flipX = false;
    //    anim.Play("IdleFront");
    //    direction = "front";
    //}

    // Start is called before the first frame update
    void Start()
    {
        gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = gameObject.GetComponent<Animator>();

        //StartCoroutine("WaitToStart");     isso é para posterior

        //gameObject.GetComponent<SpriteRenderer>().flipX = false;
        //anim.Play("IdleFront");        
    }

    // Update is called once per frame
    void Update()
    {        
        if (player.x != 0 || player.y != 0)
        {
            if (attacking == false)
            {
                if (player.x < 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    anim.Play("WalkRight");
                    player.direction = "left";
                }
                else if (player.x > 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    anim.Play("WalkRight");
                    player.direction = "right";
                }
                else if (player.y < 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    anim.Play("WalkFront");
                    player.direction = "front";
                }
                else if (player.y > 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    anim.Play("WalkBack");
                    player.direction = "back";
                }
            }
        }
        else
        {
            if (attacking == false)
            {
                if (player.direction == "right")
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    anim.Play("IdleRight");
                }
                else if (player.direction == "left")
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    anim.Play("IdleRight");
                }
                if (player.direction == "back")
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    anim.Play("IdleBack");
                }
                if (player.direction == "front")
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    anim.Play("IdleFront");
                }
            }
        }
           
    }

    public void AttackAnim()
    {
        switch (gameObject.transform.name)
        {
            case "mage":
                StartCoroutine(MageAttack());
                break;
            case "spiked":
                //StartCoroutine(SpikedAttack());
                break;
            case "carrot":
                StartCoroutine(CarrotAttack());
                break;
            case "shooting":
                StartCoroutine(ShootingAttack());
                break;


        }

        

    }

    public IEnumerator MageAttack()
    {
        gameCtrl.block = true;
        attacking = true;
        if (player.direction == "right")
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.Play("AttackRight");
        }
        else if (player.direction == "left")
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            anim.Play("AttackRight");
        }
        if (player.direction == "back")
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.Play("AttackBack");
        }
        if (player.direction == "front")
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.Play("AttackFront");
        }
        yield return new WaitForSeconds(1.0f);
        attacking = false;
        gameCtrl.block = false;
    }    
    //public IEnumerator SpikedAttack()
    //{
    //    gameCtrl.block = true;
    //    Debug.Log("entrei spiked");
    //    yield return new WaitForSeconds(2f);
    //    gameCtrl.block = false;
    //    Debug.Log("sai");
    //}
    public IEnumerator CarrotAttack()
    {
        gameCtrl.block = true;
        attacking = true;
        if (player.direction == "right")
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.Play("AttackRight");
        }
        else if (player.direction == "left")
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            anim.Play("AttackRight");
        }
        if (player.direction == "back")
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.Play("AttackBack");
        }
        if (player.direction == "front")
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.Play("AttackFront");
        }
        yield return new WaitForSeconds(1.0f);
        attacking = false;
        gameCtrl.block = false;        
    }
    public IEnumerator ShootingAttack()
    {
        gameCtrl.block = true;
        attacking = true;
        if (player.direction == "right")
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.Play("AttackRight");
        }
        else if (player.direction == "left")
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            anim.Play("AttackRight");
        }
        if (player.direction == "back")
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.Play("AttackBack");
        }
        if (player.direction == "front")
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.Play("AttackFront");
        }
        yield return new WaitForSeconds(0.8f);
        attacking = false;
        gameCtrl.block = false;
    }





}
