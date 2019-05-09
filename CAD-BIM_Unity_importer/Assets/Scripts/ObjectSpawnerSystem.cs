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
        cubeArchetype = entityManager.CreateArchetype(typeof(ObjectSpawner), typeof(Translation), typeof(Transform));
        Debug.Log(entityManager.World);

    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitalizeWithScene()
    {
        CreateFixedCountObject(10);
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

        entityManager.SetComponentData(entity, objectSpawner);
        entityManager.SetComponentData(entity, translation);        
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
    }


    protected override void OnUpdate()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
                        
            Debug.Log(World.EntityManager.GetComponentData<ObjectSpawner>(entity).position);
            Debug.Log(TextComponent.GetMessage(World.EntityManager.GetComponentData<ObjectSpawner>(entity).index));

            if (Physics.Raycast(ray,out hit))
            {
                Debug.Log (hit.collider);
            }
            
        }
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
