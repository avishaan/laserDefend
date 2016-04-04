using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
					transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
					transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
