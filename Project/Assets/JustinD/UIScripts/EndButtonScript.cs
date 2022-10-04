using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButtonScript : MonoBehaviour
{
    public Button endButton;

    void Start()
    {
        // button starts non-interactable
        endButton.interactable = !endButton.interactable;
    }

    // set to interactable
    public void becomeInteractable()
    {
        endButton.interactable = endButton.interactable;
    }

    // set to not interactable
    public void becomeUninteractable()
    {
        endButton.interactable = !endButton.interactable;
    }
}
