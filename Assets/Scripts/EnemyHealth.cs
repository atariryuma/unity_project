using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth = 3;

    private int currentHealth;

    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(1);
            }
            Destroy(gameObject);
        }
    }
}
