using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : Unit
{
    private int Lives = 6;
    public int Lives1
    {
        get { return Lives; }
        set
        {
            if (value < 7) Lives = value;
            LivesBar.Refresh();
        }
    }
    private LivesBar LivesBar;

    private float Speed = 3.0f;
    private float JumpPower = 8f;

    private float horizontalSpeed = 0.04f;
    private float moveInput;

    private bool IsGround = false;
    Rigidbody2D RigidBody;
    Animator Animator;
    SpriteRenderer Sprite;

    public int Bonuce = 0;
    public Text ControllBonuce;

    private int checkhit = 0;
    public Collider2D attackTrigger;

    public GameObject FinishPanel;

    private CharState State
    {
        get { return (CharState)Animator.GetInteger("State");  }
        set { Animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        LivesBar = FindObjectOfType<LivesBar>();
        RigidBody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Sprite = GetComponentInChildren<SpriteRenderer>();
        attackTrigger.enabled = false;
    }

    private void FixedUpdate()
    {
        CheckGround();
        transform.Translate(moveInput, 0, 0); //contol
    } 

    private void Update()
    {
        if (moveInput != 0 && IsGround && checkhit == 0) State = CharState.run;
        if (moveInput == 0 && IsGround && checkhit == 0) State = CharState.idle;
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (IsGround && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        ControllBonuce.text = " " + "Score: " + Bonuce;
    }

    public void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Speed * Time.deltaTime);
        Sprite.flipX = direction.x < 0.0f;

        //if(IsGround) State = CharState.run;
    }

    public void Jump()
    {
        if(IsGround)
        RigidBody.AddForce(transform.up * JumpPower, ForceMode2D.Impulse);
    }

    public override void ReceiveDamage()
    {
        Lives1--;
        if(Lives < 1)
        {
            PlayerPrefs.SetInt("Score", 0);
            FinishPanel.SetActive(true);
        }
        RigidBody.velocity = Vector3.zero;
        RigidBody.AddForce(transform.up * 7.0F, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);
        IsGround = colliders.Length > 1;

        if(!IsGround) State = CharState.jump;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Cristal")
        {
            if (PlayerPrefs.GetInt("MaxScore") <= Bonuce)
                PlayerPrefs.SetInt("MaxScore", Bonuce);
            PlayerPrefs.SetInt("Score", Bonuce);
            FinishPanel.SetActive(true);
        }
        if(collision.gameObject.tag == "Enemy")
        {
            ReceiveDamage();
        }
    }
    public void ButtonRightDown()
    {
        moveInput = horizontalSpeed;
        if (transform.localScale.x < 0) // поворот персонажа вправо
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
    public void ButtonLeftDown()
    {
        moveInput = -horizontalSpeed;
        if (transform.localScale.x > 0)// поворот персонажа влево
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
    public void ButtonHit() //удар
    {
        attackTrigger.enabled = true;
        checkhit = 1;
        State = CharState.hit;
    }
    public void Stop() // остановка когда кнопку отжали
    {
        moveInput = 0;
    }
    public void StopHit() // остановка удара когда кнопку отжали
    {
        checkhit = 0;
        attackTrigger.enabled = false;
    }

}


public enum CharState
{
    idle,
    run,
    jump,
    hit
}

