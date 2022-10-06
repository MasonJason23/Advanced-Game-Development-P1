using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTurnPopupScript : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("PlayerPop");
    }
}
