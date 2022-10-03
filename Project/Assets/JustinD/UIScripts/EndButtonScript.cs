using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButtonScript : MonoBehaviour
{
    public Button endButton;
    // Start is called before the first frame update
    void Start()
    {
        endButton.interactable = !endButton.interactable;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void becomeInteractable()
    {
        endButton.interactable = endButton.interactable;
    }

    public void becomeUninteractable()
    {
        endButton.interactable = !endButton.interactable;
    }
}
