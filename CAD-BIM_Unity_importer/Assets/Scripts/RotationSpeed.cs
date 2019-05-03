﻿using System;
using Unity.Entities;

namespace Samples.HelloCube_02
{
    // Serializable attribute is for editor support.
    [Serializable]
    public struct RotationSpeed : IComponentData
    {
        public float RadiansPerSecond;
    }
}

