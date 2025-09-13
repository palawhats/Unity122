using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float damage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerStats"))
        {
            Debug.Log("Player hit by spikes");
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
