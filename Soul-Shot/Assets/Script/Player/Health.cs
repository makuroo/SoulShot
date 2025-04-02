using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int startingHp = 3;
    public int currentHp;

    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberofFlashes;
    private SpriteRenderer spriteRend;
    [SerializeField] private AudioManager manager;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        currentHp = startingHp;
        Physics2D.IgnoreLayerCollision(12, 13, false);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("trap"))
        {
            manager.PlayAttackedSound();
            if (currentHp > 0)
            {
                TakeDamage(1);
                StartCoroutine(Immune());
            }
            Die();
        }
    }

    public void Die()
    {
        if (currentHp == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Immune()
    {
        Physics2D.IgnoreLayerCollision(12, 13, true);
        for (int i = 0; i < numberofFlashes; i++)
        {
            spriteRend.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberofFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberofFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(12, 13, false);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
    }
}
