using System.Collections.Generic;
using UnityEngine;

public class CoinGenerate : Command
{
    private GameObject coin;

    public CoinGenerate(GameObject target) : base(target)
    {
        coin = target;
    }

    public override GameObject Execute(Transform parent)
    {
        return GenerateCollect(parent);
    }

    public GameObject GenerateCollect(Transform parent)
    {
        return coin.GetComponent<Collectables>()?.ShowUpCollectableItem(parent);
    }
}
