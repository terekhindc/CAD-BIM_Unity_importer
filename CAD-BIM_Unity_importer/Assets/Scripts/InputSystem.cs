using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;
using Unity.Transforms;

public class InputSystem : ComponentSystem
{
    struct Filter
    {
        public ComponentDataArray<MoveData> moveData;
        public ComponentDataArray<SpeedData> speed;

        public readonly int Length;
    }

    [Inject]
    Filter data;

    protected override void OnUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        for (int i = 0; i < data.Length; i++)
        {
            var tempData = data.moveData[i];
            tempData.Horizontal = horizontal * data.speed[i].value;
            tempData.Vertical = vertical * data.speed[i].value;
            data.moveData[i] = tempData;
        }
       
    }
}
