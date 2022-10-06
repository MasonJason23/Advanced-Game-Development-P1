using UnityEngine;
using System;

public class EventHandler
{
    public static event Action CollectableItemAwake;
    public static void CallCollectableItemAwake()
    {
        CollectableItemAwake?.Invoke();
    }

    public static event Action<GameObject> CollectItem;
    public static void CallCollectItem(GameObject gameObject)
    {
        CollectItem?.Invoke(gameObject);
    }

    public static event Action AfterCollectItem;
    public static void CallAfterCollectItem()
    {
        AfterCollectItem?.Invoke();
    }
}
