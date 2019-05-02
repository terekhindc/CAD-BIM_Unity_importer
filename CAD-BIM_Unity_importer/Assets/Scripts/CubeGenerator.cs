using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Rendering;
using Unity.Entities;
using Unity.Transforms;

public class CubeGenerator
{
    private static EntityManager entityManager;
    private static RenderMesh cubeRenderer;
    private static EntityArchetype cubeArchetype;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initalize()
    {
        entityManager = World.Active.EntityManager;
        cubeArchetype = entityManager.CreateArchetype(typeof(Translation), typeof(Rotation));
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitalizeWithScene()
    {        
        cubeRenderer = GameObject.FindObjectOfType<RenderMeshProxy>().Value;        

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

    private static void SpawnCube(int i, int j, int k)
    {
        Entity cubeEntity = entityManager.CreateEntity(cubeArchetype);

        Vector3 position = new Vector3(2f * i, 2f * j, 2f * k);

        entityManager.SetComponentData(cubeEntity, new Translation{ Value = position });

        entityManager.AddSharedComponentData(cubeEntity, cubeRenderer);
    }
}
