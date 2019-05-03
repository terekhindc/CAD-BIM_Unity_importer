﻿using System;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Samples.HelloCube_06
{
    [RequiresEntityConversion]
    public class HelloSpawnerProxy : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
    {
        public GameObject Prefab;
        public int CountX;
        public int CountY;
        public static int counter;

        // Referenced prefabs have to be declared so that the conversion system knows about them ahead of time
        public void DeclareReferencedPrefabs(List<GameObject> gameObjects)
        {
            counter++;
            Debug.Log(counter);
            gameObjects.Add(Prefab);
        }

        // Lets you convert the editor data representation to the entity optimal runtime representation

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var spawnerData = new HelloSpawner
            {
                // The referenced prefab will be converted due to DeclareReferencedPrefabs.
                // So here we simply map the game object to an entity reference to that prefab.
                Prefab = conversionSystem.GetPrimaryEntity(Prefab),
                CountX = CountX,
                CountY = CountY
            };
            dstManager.AddComponentData(entity, spawnerData);
        }
    }
}