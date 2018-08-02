using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    bool ArrowInput = false;

    [SerializeField]
    bool wasdInput = false;

    public float Speed = 5;
    Animator anim;
    public SpriteRenderer[] player;
    SpriteRenderer sprite;


    //Transform currentTF;


    // Use this for initialization
    void Start()
    {
        ArrowInput = false;
        wasdInput = true;

        anim = GetComponentInChildren<Animator>();

        player = GetComponentsInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //for short ref to this gameObjcts position
        //currentTF = gameObject.transform;


        //if no input go to idle state
        if (!Input.anyKey)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
        }


        if (wasdInput == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate((-1f * Speed), 0f, 0f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate((-1f * Speed), 0f, 0f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                transform.Translate(0, 0, 0);
                anim.SetBool("isIdle", true);
                anim.SetBool("isWalking", false);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (anim.GetBool("walk") == false)
                {
                    anim.SetBool("walk", true);

                }
                else
                {
                    anim.SetBool("walk", false);
                }

            }



        }
        if (ArrowInput == true)
        {

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1, 0, 0) * Speed;
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
                foreach (var sprite in player)
                {
                    sprite.GetComponent<SpriteRenderer>().flipX = true;
                }

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-1, 0, 0) * Speed;
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
                foreach (var sprite in player)
                {
                    sprite.GetComponent<SpriteRenderer>().flipX = false;
                }

            }
        }

    }
}
