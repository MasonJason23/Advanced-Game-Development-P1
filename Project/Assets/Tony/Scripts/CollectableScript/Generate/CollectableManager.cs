using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generate{

    public class CollectableManager : MonoBehaviour
    {
        #region singleton part
        public static CollectableManager Instance { get => instance; }
        private static CollectableManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        #endregion

        #region Generate Collectable Object part
        public Vector3 mapCenter;
        public Collectables Coin; //We can change Coin to be a list, that way we can pick random things to generate.
        public Command coinGenerate; // Same as top, we can make a command list to generate collectable items.

        [Header("Value for random position")]
        [SerializeField] private float maxRandomRange;
        [SerializeField] private float minRandomRange;
        [SerializeField] private Transform coinParent;

        //private List<Command> generateCommand = new List<Command>();
        public List<Collectables> collectablePool = new List<Collectables>();

        private void Start()
        {
            coinGenerate = new CoinGenerate(Coin.gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                GenerateCollectableItem();
            }
        }

        private Vector3 RandomPosition()
        {
            float randomX = Random.Range(minRandomRange, maxRandomRange);
            int pOn = 0;
            while (pOn == 0)
            {
                pOn = Random.Range(-1, 2);
            }

            randomX *= pOn;
            pOn = 0;

            float randomZ = Random.Range(minRandomRange, maxRandomRange);

            while (pOn == 0)
            {
                pOn = Random.Range(-1, 2);
            }
            randomZ *= pOn;
            if (Coin == null)
                Debug.Log("Error");

            Vector3 randomPosition = new Vector3(randomX + mapCenter.x, mapCenter.y, mapCenter.z + randomZ);

            return randomPosition;

        }
        private void GenerateCollectableItem()
        {
                var position = RandomPosition();
                GameObject collectableItem = collectablePool.Find(s => s.itemID == Coin.itemID)?.gameObject;

                if(collectableItem != null)
                {
                    collectableItem.transform.position = RandomPosition();
                    collectablePool.Remove(collectableItem.GetComponent<Collectables>());
                }
                else
                {
                    collectableItem = coinGenerate.Execute(coinParent);
                    collectableItem.transform.position = position;
                }

                EventHandler.CallCollectableItemAwake(collectableItem);
        }
        #endregion
    }

}