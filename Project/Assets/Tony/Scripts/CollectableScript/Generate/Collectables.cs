using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int itemID;
    public float waitSecond;

    private void OnEnable() 
    {
        EventHandler.CollectableItemAwake += StartCount;
    }

    private void OnDisable() 
    {
        EventHandler.CollectableItemAwake -= StartCount;
    }

    public GameObject ShowUpCollectableItem(Transform parent)
    {
        GameObject target = Instantiate(this.gameObject, parent);
        return target;
    }

    private void StartCount(GameObject gameObject)
    {
        StartCoroutine("WaitAndGotoObjectPool", gameObject);
    }

    IEnumerator WaitAndGotoObjectPool(GameObject gameObject)
    {
        yield return new WaitForSeconds(waitSecond);
        if(CollectableManager.Instance.collectablePool.Contains(gameObject.GetComponent<Collectables>()) == false)  CollectableManager.Instance.collectablePool.Add(gameObject.GetComponent<Collectables>());
        gameObject.transform.position = new Vector3(500,500,500);
    }

}
