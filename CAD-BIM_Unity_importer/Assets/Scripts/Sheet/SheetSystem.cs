using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SheetSystem : ComponentSystem
{    
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Sheet text) =>
        {
            Debug.Log(text.a);
        });
    }
}
