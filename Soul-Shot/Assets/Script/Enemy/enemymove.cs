using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    public Rigidbody2D enemy;
    private bool isFlip = true;
    [SerializeField] float speed = 1f;
 

    // Start is called before the first frame update
    void Start()
    {
        isFlip = true;
        enemy = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isFlip)
        {
            enemy.linearVelocity = new Vector2(-speed, 0f);
        }
        else
        {
            enemy.linearVelocity = new Vector2(speed, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("left"))
        {
            isFlip = !isFlip;
            transform.localScale = new Vector2(  Mathf.Sign(enemy.linearVelocity.x), transform.localScale.y);
        }
        
    }

}
