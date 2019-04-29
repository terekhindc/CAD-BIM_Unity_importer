using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

[Serializable]
public struct SpeedData : IComponentData
{
    public int value;
}


public class SpeedComponent : ComponentDataWrapper<SpeedData>
{


}
