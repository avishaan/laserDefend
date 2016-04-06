using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject projectile;
    public float health = 150f;
    public float projectileSpeed = 10f;
    public float shotsPerSecond = 0.5f;
    public int scoreValue = 123;
    public AudioClip fireSound;
    public AudioClip deathSound;

    private ScoreKeeper scoreKeeper;

    void Start()
    {
        // get score gameobject (from hierarchy)
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        float probability = shotsPerSecond * Time.deltaTime;

        if (Random.value < probability)
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 startPosition = transform.position;
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);

        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
    void Die()
    {

        Destroy(gameObject);
        // add a score
        scoreKeeper.Score(scoreValue);

        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Projectile missile = col.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Die();
            }
        }
    }

}
