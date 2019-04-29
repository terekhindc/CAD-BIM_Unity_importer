using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;
using Unity.Transforms;

public class MoveSystem : ComponentSystem {

    struct Filter
    {
        public ComponentDataArray<MoveData> data;
        public ComponentArray<Rigidbody> rigidbody;
        public readonly int Length;
    }

    [Inject]
    Filter playerData;

	protected override void OnUpdate()
    {
        for(int i = 0; i < playerData.Length; i++)
        {
            playerData.rigidbody[i].position += new Vector3(playerData.data[i].Horizontal, 0, playerData.data[i].Vertical) * Time.deltaTime;
        }
    }
}
