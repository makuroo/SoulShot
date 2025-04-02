using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    private bool hit;
    private float direction;
    private float lifetime;
    public GameObject player;

    private BoxCollider2D boxCollider;
    private Animator anim;
    [SerializeField] private AudioManager manager;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // if hit collider stop
        if (hit) return;
        // bullet move to designed way
        float movementspeed = speed * Time.deltaTime * direction;
        transform.Translate(-movementspeed, 0, 0);

        //if >5 seconds bullet disappear
        lifetime += Time.deltaTime;
        if (lifetime > 5) Deactivate();
    }

    //after bullet hit
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.gameObject.CompareTag("left"))
        {
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("Explode");
        }

        if (collision.gameObject.CompareTag("enemy")){
            manager.PlayAttackedSound();
            Destroy(collision.gameObject);
        }
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScalex = transform.localScale.x;
        if (_direction != 180)
        {
            localScalex = -localScalex;
        }

        transform.localScale = new Vector3(localScalex, transform.localScale.y, transform.localScale.z);
    }
    //deactivate bullet after explode
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
