using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popupName;
    public TMP_Text pupupDescription;

    public void PopUp(string name, string description)
    {
        popUpBox.SetActive(true);
        popupName.text = name;
        pupupDescription.text = description;
        animator.ResetTrigger("close");
        animator.SetTrigger("open");
    }
    public void PopDown()
    {
        if (popUpBox.activeSelf)
        {
            popUpBox.SetActive(false);
            animator.ResetTrigger("open");
            animator.SetTrigger("close");
        }
    }
}