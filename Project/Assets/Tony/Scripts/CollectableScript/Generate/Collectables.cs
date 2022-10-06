using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generate
{

    public class Collectables : MonoBehaviour
    {
        public int itemID;
        //private Coroutine coroutine;

        private void OnEnable()
        {
            EventHandler.CollectItem += CollectCoin;
        }

        private void OnDisable()
        {
            EventHandler.CollectItem -= CollectCoin;
        }

        public GameObject ShowUpCollectableItem(Transform parent)
        {
            GameObject target = Instantiate(this.gameObject, parent);
            return target;
        }

        // private void StartCount(GameObject gameObject)
        // {
        //     coroutine = StartCoroutine("WaitAndGotoObjectPool", gameObject);
        // }

        // IEnumerator WaitAndGotoObjectPool(GameObject gameObject)
        // {
        //     if (CollectableManager.Instance.collectablePool.Contains(gameObject.GetComponent<Collectables>()) == false) CollectableManager.Instance.collectablePool.Add(gameObject.GetComponent<Collectables>());
        //     gameObject.transform.position = new Vector3(500, 500, 500);
        // }

        public void CollectCoin(GameObject _gameObject)
        {
            if (CollectableManager.Instance.collectablePool.Contains(_gameObject.GetComponent<Collectables>()) == false) CollectableManager.Instance.collectablePool.Add(_gameObject.GetComponent<Collectables>());
            _gameObject.transform.position = new Vector3(500, 500, 500);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                // EventHandler.CallCollectItem(this.gameObject);
                // EventHandler.CallAfterCollectItem();
            }
        }

    }
}