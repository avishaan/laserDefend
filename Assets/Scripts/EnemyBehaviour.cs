using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    public float health = 150f;

    void OnTriggerEnter2D(Collider2D col)
    {
        Projectile missile = col.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            Debug.Log("hit by projectile");
            health -= missile.GetDamage();
            if (health <= 0)
            {
                missile.Hit();
                Destroy(gameObject);
            }
        }
    }

}
