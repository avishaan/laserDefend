using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject projectile;
    public float health = 150f;
    public float projectileSpeed = 10f;

    void Update()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -0.9f, 0);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Projectile missile = col.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            if (health <= 0)
            {
                missile.Hit();
                Destroy(gameObject);
            }
        }
    }

}
