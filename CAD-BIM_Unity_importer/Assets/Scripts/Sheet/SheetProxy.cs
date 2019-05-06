using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SheetProxy : MonoBehaviour, IConvertGameObjectToEntity
{

    public char a;

    public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
    {
        var data = new Sheet { a = a};
        entityManager.AddComponentData(entity, data);
    }

}
