using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Rendering;

public class ObjectSpawnerSystem : ComponentSystem
{

    private static EntityManager entityManager;    
    private static EntityArchetype cubeArchetype;
    static Entity entity;
    static Translation translation;
    BoxCollider col = new BoxCollider();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initalize()
    {        
        entityManager = World.Active.EntityManager;
        cubeArchetype = entityManager.CreateArchetype(typeof(ObjectSpawner), typeof(Translation), typeof(BoxColliderECS));
        Debug.Log(entityManager.World);

    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitalizeWithScene()
    {
        CreateOneObject();
    }

    static void CreateOneObject ()
    {
        entity = entityManager.CreateEntity(cubeArchetype);

        ObjectSpawner objectSpawner = new ObjectSpawner
        {
            position = new Vector3(1, 2, 3),
        };

        translation = new Translation
        {
            Value = new float3(objectSpawner.position)
        };

        Vector3 start = new Vector3(0, 0, 0);
        Vector3 end = new Vector3(10, 10, 10);

        BoxColliderECS boxCollider = new BoxColliderECS
        {
            diagonal = new Diagonal(start, end)
        };

        entityManager.SetComponentData(entity, objectSpawner);
        entityManager.SetComponentData(entity, translation);
        entityManager.SetComponentData(entity, boxCollider);

        TextComponent.SetMessage(objectSpawner.index, "Асгард");
    }

    static void CreateFixedCountObject(int count)
    {
        entity = entityManager.CreateEntity(cubeArchetype);

        ObjectSpawner objectSpawner = new ObjectSpawner
        {
            position = new Vector3(1, 2, 3),
            index = 0            
        };

        TextComponent.SetMessage(objectSpawner.index, "Асгард");

        translation = new Translation
        {
            Value = new float3(objectSpawner.position)
        };

        entityManager.SetComponentData(entity, objectSpawner);
        entityManager.SetComponentData(entity, translation);
        entityManager.SetComponentData(entity, translation);
    }


    protected override void OnUpdate()
    {        
        
    }

}

static class TextComponent
{

    static Dictionary<int, string> messages = new Dictionary<int, string>();

    public static void SetMessage (int index, string text)
    {
        messages.Add(index, text);
    }

    public static string GetMessage(int index)
    {
        return messages[index];
    }
}
