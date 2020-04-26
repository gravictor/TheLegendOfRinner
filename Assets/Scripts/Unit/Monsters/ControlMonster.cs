using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControlMonster : Unit
{
    public int reward;
    public GameObject Hero;
    public float speed;
    public int health;
    private Vector3 Direction;
    Rigidbody2D rbEnemy;
    SpriteRenderer spEnemy;
    public Character rewards;
    void Awake()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        spEnemy = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        Direction = transform.right;
    }
    void Update()
    {
        Moving();
        if (health <= 0)
        {
            rewards.Bonuce += reward;
            Destroy(gameObject);
        }
    }
    public void Damage(int Damage)
    {
        rbEnemy.velocity = Vector3.zero;
        rbEnemy.AddForce(transform.up * 5.0F, ForceMode2D.Impulse);
        health -= Damage;
    }
    void Moving()// джижение мобов
    {
        //if (Vector3.Distance(Hero.transform.position, gameObject.transform.position) < 2)
        if (Mathf.Abs(Hero.transform.position.x - gameObject.transform.position.x) < 4)
        {
            if (Hero.transform.position.x < gameObject.transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                rbEnemy.velocity = new Vector2(-speed, rbEnemy.velocity.y);
            }
            else if (Hero.transform.position.x > gameObject.transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);
            }
        }
        else
        {
            spEnemy.flipX = Direction.x > 0.0f;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.4F + transform.right * Direction.x, 0.00001F);

        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>())) Direction *= -1.0F;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + Direction, speed * Time.deltaTime);
        }
    }
}
