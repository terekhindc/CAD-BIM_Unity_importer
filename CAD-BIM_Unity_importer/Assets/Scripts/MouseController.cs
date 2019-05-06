using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    void Update()
    {
        float rotX = Input.GetAxis("Mouse Y") * -1;
        float rotY = Input.GetAxis("Mouse X");

        transform.eulerAngles += new Vector3(rotX, rotY, 0);

        Ray ray = Camera.main.ScreenPointToRay((Input.mousePosition));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            print(hit.transform.name);
        }
    }
}