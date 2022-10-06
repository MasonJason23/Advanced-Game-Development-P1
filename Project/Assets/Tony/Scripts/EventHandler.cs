using UnityEngine;
using System;

public class EventHandler
{
    public static event Action<GameObject> CollectableItemAwake;
    public static void CallCollectableItemAwake(GameObject gameObject)
    {
        CollectableItemAwake?.Invoke(gameObject);
    }
}
