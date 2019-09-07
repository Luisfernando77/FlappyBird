using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float upForce = 50f;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        if (isDead) return;

        if (Input.GetMouseButton(0))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * upForce);
            anim.SetTrigger("Flaps");
            SoundSystem.instance.PlayJump3();

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        isDead = true;
        anim.SetTrigger("Die");
        //gameController.BirdDie();
        Invoke("BirdDie", 1f);
        rb2d.velocity = Vector2.zero;
        SoundSystem.instance.PlayDead();

    }

    private void BirdDie()
    {
        GameController.instance.BirdDie();
    }

}
