using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controll : MonoBehaviour
{
    Rigidbody2D RB;
    SpriteRenderer SR;
    [SerializeField] float Y;
    [SerializeField] float Speed;
    float inputX, inputY;

    public int HP;

    Animator Anim;
    Animation Damage_Anim;
    [SerializeField] GameObject Bomb;

    [SerializeField]  Text Health;

    void Start()
    {
        HP = 3;
        Health.text = "Health Point: " + HP;
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        //if (Input.GetAxis("Horizontal")!=0)
        //{
        //    inputX = Input.GetAxis("Horizontal");
        //}
        //if (Input.GetAxis("Vertical") != 0)
        //{
        //    inputY = Input.GetAxis("Vertical");
        //}
        RB.velocity = new Vector2(inputX * Speed, inputY * Speed);
        Anim.SetFloat("Horizontal", inputX);
        Anim.SetFloat("Vertical", inputY);
        Anim.SetFloat("Speed", RB.velocity.sqrMagnitude);




        if (Input.GetKeyDown(KeyCode.Space))
        {
            BombDrop();
        }
        float pos = Y - transform.position.y;
        SR.sortingOrder = (int)pos;
    }

    private void BombDrop()
    {
        Instantiate(Bomb, this.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject, 0.2f);
            Damage_Anim = GetComponent<Animation>();
            Damage_Anim.Play("Damage");
            HP -= 1;
            Health.text = "Health Point: " + HP;
        }
        if (collision.gameObject.tag == "Bekon")
        {
            Destroy(collision.gameObject, 0);
            Damage_Anim = GetComponent<Animation>();
            Damage_Anim.Play("Heal");
            HP += 1;
            Health.text = "Health Point: " + HP;
        }
    }


    public void MoveVertical(float Input_AxisY)
    {
        inputY = Input_AxisY;
    }
    public void MoveHorizontal(float Input_AxisX)
    {
        inputX = Input_AxisX;
    }
    public void Bomba()
    {
        BombDrop();
    }
}
