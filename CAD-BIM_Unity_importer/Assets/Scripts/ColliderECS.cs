using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Rendering;
using Unity.Rendering;

[Serializable]
[MaximumChunkCapacity(128)]
public struct ColliderECS : ISharedComponentData
{
    public Collider collider;
}

public class RenderMeshProxy : SharedComponentDataProxy<ColliderECS>
{
    
}
