using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementTurnPopupScript : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public void PopUp()
    {
        popUpBox.SetActive(true);
        animator.SetTrigger("MovementPop");
    }
}
