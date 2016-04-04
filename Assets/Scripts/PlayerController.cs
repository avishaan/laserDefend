using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    public float padding = 1;
    public float startingPosition = -4.0f;
    public GameObject projectile;
    public float projectileSpeed;
    public float fireRate = 0.2f;

    float xmin = -5;
    float xmax = 5;

    // Use this for initialization
    void Start()
    {
        // distance between camera and player
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.00000001f, fireRate);
            // beam.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            CancelInvoke("Fire");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // player restricted to gamespace
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);

        transform.position = new Vector3(newX, startingPosition, 0);
    }

    void Fire()
    {
        GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D rigidBodyBeam = beam.GetComponent<Rigidbody2D>();
        rigidBodyBeam.velocity = new Vector3(0, projectileSpeed, 0);
    }
}
