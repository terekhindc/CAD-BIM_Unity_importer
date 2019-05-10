using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ObjectSpawnerProxy : MonoBehaviour, IConvertGameObjectToEntity
{    
    public Vector3 position;    

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var objectSpawner = new ObjectSpawner 
        {
            position = position
        };

        entity = dstManager.CreateEntity();        
    }

}
