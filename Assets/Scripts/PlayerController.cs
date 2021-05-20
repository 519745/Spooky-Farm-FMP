using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveSpeed;

    private Animator anim;

    private bool playerMoving;
    private Vector2 lastMove;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    private ShakeBehaviour shakeData;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        transform.GetChild(0).gameObject.SetActive(false);

        GameObject Enemy = GameObject.Find("Enemy");
        Enemy.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        playerMoving = false;

        if (!attacking)
        {

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));

            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);

                transform.GetChild(0).gameObject.SetActive(true);
            }

        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
            transform.GetChild(0).gameObject.SetActive(false);
        }

        anim.SetFloat("Move X", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("Move Y", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMove X", lastMove.x);
        anim.SetFloat("LastMove Y", lastMove.y);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Enemy")
        {
            //ShakeBehaviour.shakeDuration = 1;
            shakeData = GameObject.Find("Main Camera").GetComponent<ShakeBehaviour>();
            shakeData.shakeDuration = 1;
        }
    }

}