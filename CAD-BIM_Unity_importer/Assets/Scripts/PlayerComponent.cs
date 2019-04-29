using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

[Serializable]
public struct Tag : ISharedComponentData {
    public string tag;

}

public class PlayerComponent : SharedComponentDataWrapper<Tag> {}

