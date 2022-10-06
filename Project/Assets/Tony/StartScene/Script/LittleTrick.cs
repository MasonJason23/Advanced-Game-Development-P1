using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LittleTrick : MonoBehaviour, IPointerEnterHandler
{
    private bool hasMove = false;
    public Transform _transform;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(hasMove == false)
        {
            hasMove = true;
            this.transform.position = _transform.position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
