using UnityEngine;

namespace Generate{

    public abstract class Command
    {
        public GameObject target;
        public abstract GameObject Execute(Transform parent);
        public Command(GameObject target)
        {
            this.target = target;
        }

    }

}