using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;

    private bool canTakeDamage = true;
    private Animator anim;

    // เพิ่มตัวอ้างอิง UI
    public HealthBar healthBar;     // ลาก HealthBar ลง Inspector
    public GameOverUI gameOverUI;   // ลาก GameOverUI ลง Inspector

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        health = maxHealth;

        // เซ็ตค่าเริ่มต้นให้ UI
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(health);
        }
    }

    public void TakeDamage(float damage)
    {
        if (!canTakeDamage)
            return;

        health -= damage;
        if (health < 0) health = 0;

        anim.SetBool("Damage", true);

        // อัพเดต UI
        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }

        if (health <= 0)
        {
            // Player ตาย
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponentInParent<GatherInput>().DisableControls();
            Debug.Log("Player is dead");

            if (gameOverUI != null)
            {
                gameOverUI.ShowGameOver();
            }
        }

        StartCoroutine(DamagePrevention());
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.5f);

        if (health > 0)
        {
            canTakeDamage = true;
            anim.SetBool("Damage", false);
        }
        else
        {
            anim.SetBool("Death", true);
        }
    }
}
