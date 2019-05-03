using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float moveForward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        Vector3 direction = new Vector3(moveHorizontal, 0, moveForward);

        transform.Translate(direction);
    }
}