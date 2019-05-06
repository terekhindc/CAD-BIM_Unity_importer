using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ObjectClickSystem : ComponentSystem
{

    protected override void OnUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);
        }
    }
}