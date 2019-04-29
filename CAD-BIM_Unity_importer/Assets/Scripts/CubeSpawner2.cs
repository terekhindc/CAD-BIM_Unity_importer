using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;
using Unity.Transforms;
using Unity.Transforms2D;
using UnityEngine.Rendering;
using Unity.Rendering;
using UnityEngine.SceneManagement;

public class CubeSpawner2 {

    private static EntityManager entityManager;
    private static MeshInstanceRenderer cubeRenderer;
    private static EntityArchetype cubeArchetype;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initalize()
    {
        entityManager = World.Active.GetOrCreateManager<EntityManager>();

        cubeArchetype = entityManager.CreateArchetype(
            typeof(Position2D),
            typeof(Heading2D),
            typeof(TransformMatrix),
            typeof(MoveSpeed));
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitalizeWithScene()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Spawner2")
        {
            cubeRenderer = GameObject.FindObjectOfType<MeshInstanceRendererComponent>().Value;

            for (int i = 0; i < 100000; i++)
            {
                SpawnCube();
            }
        }
        
    }

	private static void SpawnCube()
    {


        Entity cubeEntity = entityManager.CreateEntity(cubeArchetype);

        Vector2 direction = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));

        entityManager.SetComponentData(cubeEntity, new Position2D { Value = new Vector2(5f, 5f) });
        entityManager.SetComponentData(cubeEntity, new Heading2D { Value = direction });
        entityManager.SetComponentData(cubeEntity, new MoveSpeed { speed = 5 });

        entityManager.AddSharedComponentData(cubeEntity, cubeRenderer);
    }
}
