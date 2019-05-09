using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

public struct ObjectSpawner : IComponentData
{
    public int index;
    public Vector3 position;    
}
