using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D RB;
    SpriteRenderer SR;
    [SerializeField] float Y;
    [SerializeField] float Speed;
    float inputX, inputY;



    Animator Anim;
    [SerializeField] Animation Damage_Anim;
    [SerializeField] GameObject Bomb;

    void Start()
    {
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        SR= GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        RB.velocity = new Vector2(inputX * Speed, inputY * Speed);
        Anim.SetFloat("Horizontal", inputX);
        Anim.SetFloat("Vertical", inputY);
        Anim.SetFloat("Speed", RB.velocity.sqrMagnitude);




        if (Input.GetKeyDown(KeyCode.Space))
        {
            BombDrop();
        }
        float pos= Y- transform.position.y;
        SR.sortingOrder = (int)pos;
    }

    private void BombDrop()
    {
        Instantiate(Bomb,this.transform.position,Quaternion.identity);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Damage_Anim = GetComponent<Animation>();
            Damage_Anim.Play("Damage");
        }
    }


    public void Move(float Input_AxisX, float Input_AxisY)
    {
        inputX = Input_AxisX;
        inputY = Input_AxisY;
    }
}
