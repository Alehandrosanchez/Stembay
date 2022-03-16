using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D RB;
    SpriteRenderer SR;
    [SerializeField] float Speed;
    Animator Anim;
    [SerializeField] Animation Damage_Anim;
    int inputX, inputY;
    RaycastHit2D Ray;
    Vector2 Move_Direction;
    [SerializeField] float Distance_To_Rotate;
    [SerializeField] float Time_To_Rotate_MIN, Time_To_Rotate_MAX;
    Coroutine Cor;
    private void Start()
    {
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        Cor=StartCoroutine(Input());
    }
    private void Update()
    {
        RB.velocity = new Vector2(inputX * Speed, inputY * Speed);
        Physics2D.queriesStartInColliders = false;
        Move_Direction = new Vector2(inputX, inputY);
        Ray = Physics2D.Raycast(this.transform.position, Move_Direction,100);
        Debug.DrawLine(this.transform.position, Ray.point, Color.green);
        if (Ray.collider.tag == "Stone" && Vector2.Distance(this.transform.position, Ray.point)> Distance_To_Rotate)
        {
            if (Cor==null)
            {
                Cor = StartCoroutine(Input());
            }
            else
            {
                StopCoroutine(Cor);
                Cor = StartCoroutine(Input());
            }
            
        }
        Anim.SetFloat("Horizontal", inputX);
        Anim.SetFloat("Vertical", inputY);
        Anim.SetFloat("Speed", RB.velocity.sqrMagnitude);
    }
    IEnumerator Input()
    {
        inputX = Random.Range(1,-2);
        inputY = Random.Range(1, -2);
        if (inputX!=0)
        {
            inputY = 0;
        }
        Move_Direction = new Vector2(inputX, inputY);
        yield return new WaitForSeconds(Random.Range(Time_To_Rotate_MIN, Time_To_Rotate_MAX));
        Cor = StartCoroutine(Input());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Damage_Anim = GetComponent<Animation>();
            Damage_Anim.Play("Damage");
        }
    }


}
