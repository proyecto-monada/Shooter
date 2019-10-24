
using UnityEngine;

public class Target : MonoBehaviour
{
    public float vida = 50.0f;


    public void TakeDamage(float daño)
    {
        vida -= daño;

        if (vida <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
