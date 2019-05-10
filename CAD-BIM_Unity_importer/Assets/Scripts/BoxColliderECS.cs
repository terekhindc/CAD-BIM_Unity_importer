using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct BoxColliderECS : IComponentData
{
    public Diagonal diagonal;
}

public struct Diagonal
{    
    public Vector3 startPoint;
    public Vector3 endPoint;

    public Diagonal (Vector3 start, Vector3 end)
    {
        startPoint = start;
        endPoint = end;
    }
}
