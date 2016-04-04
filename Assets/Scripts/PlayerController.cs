using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;

		float xmin = -5;
		float xmax = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

				transform.position = new Vector3(newX, 0, 0);
    }
}
