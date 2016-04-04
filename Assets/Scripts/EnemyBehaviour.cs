using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Projectile missile = col.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            Debug.Log("hit by projectile");
        }
    }

}
