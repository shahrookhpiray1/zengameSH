using UnityEngine;

public class Spammer : MonoBehaviour
{
    public Transform player;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int health = 2;
    public int damage = 1;
    public float attackCooldown = 1.5f;
    private float lastAttackTime;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        MoveTowardsPlayer();
        CheckForAttack();
    }

    // حرکت به سمت کاراکتر
    void MoveTowardsPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > attackRange) // اگر دشمن در محدوده حمله نیست
        {
            // حرکت به سمت پلیر
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, 3f * Time.deltaTime);

            // تعیین وضعیت متغیرهای انیمیشن
            if (direction.x > 0)  // اگر به سمت راست حرکت می‌کنه
            {
                transform.localScale = new Vector3(1, 1, 1); // سمت راست
                anim.SetBool("isRight", true);
                anim.SetBool("isLeft", false);
                anim.SetBool("isMoving", true); // در حال حرکت
            }
            else if (direction.x < 0) // اگر به سمت چپ حرکت می‌کنه
            {
                transform.localScale = new Vector3(-1, 1, 1); // سمت چپ
                anim.SetBool("isLeft", true);
                anim.SetBool("isRight", false);
                anim.SetBool("isMoving", true); // در حال حرکت
            }
        }
        else
        {
            // وقتی دشمن متوقف میشه
            anim.SetBool("isMoving", false);
        }
    }

    // بررسی حمله به پلیر
    void CheckForAttack()
    {
        if (Vector2.Distance(transform.position, player.position) <= attackRange && Time.time - lastAttackTime >= attackCooldown)
        {
            anim.SetTrigger("attack");
            lastAttackTime = Time.time;
            AttackPlayer();
        }
    }

    // آسیب به پلیر
    void AttackPlayer()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        foreach (Collider2D collider in hitPlayers)
        {
            if (collider.CompareTag("Player"))
            {
                collider.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetTrigger("die");
        Destroy(gameObject, 0.5f); // کمی تاخیر برای نمایش انیمیشن مرگ
    }

    // برای مشاهده محدوده حمله در ویرایشگر
    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
