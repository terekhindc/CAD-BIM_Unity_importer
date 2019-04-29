using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;
using Unity.Transforms;
using UnityEngine.Rendering;
using Unity.Rendering;
using UnityEngine.SceneManagement;

public class BigCubeSpawner
{

    private static EntityManager entityManager;
    private static MeshInstanceRenderer cubeRenderer;
    private static EntityArchetype cubeArchetype;



    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initalize()
    {
        entityManager = World.Active.GetOrCreateManager<EntityManager>();

        cubeArchetype = entityManager.CreateArchetype(typeof(Position), typeof(TransformMatrix));
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitalizeWithScene()
    {
        Scene scene = SceneManager.GetActiveScene();

        Debug.Log(scene.name);
        if (scene.name == "Spawner1")
        {
            cubeRenderer = GameObject.FindObjectOfType<MeshInstanceRendererComponent>().Value;

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        SpawnCube(i, j, k);
                    }
                }
            }
        }        
    }

    private static void SpawnCube(int i, int j, int k)
    {

        
        Entity cubeEntity = entityManager.CreateEntity(cubeArchetype);

        Vector3 position = new Vector3(2f*i, 2f*j, 2f*k);

        entityManager.SetComponentData(cubeEntity, new Position { Value = position });

        entityManager.AddSharedComponentData(cubeEntity, cubeRenderer);
    }
}
