using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

[Serializable]
public struct MoveData : IComponentData
{
    public float Horizontal;
    public float Vertical;
}

public class MoveComponent : ComponentDataWrapper<MoveData> { }
