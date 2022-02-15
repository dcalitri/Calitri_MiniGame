using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10;
    public float leftInput;
    public float forwardInput;
    private float zRange = 5;
    private float xRange = 10;
    public GameObject projectilePrefab;
    private float lastCallTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        leftInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.back * Time.deltaTime * speed * leftInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * forwardInput);
        
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastCallTime > 0.5f)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            lastCallTime = Time.time;
        }
    }
}
