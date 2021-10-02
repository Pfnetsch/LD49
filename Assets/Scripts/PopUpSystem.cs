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

    public void PopUp(string name, string description, List<string> unlocks)
    {
        popUpBox.SetActive(true);
        popupName.text = name;
        pupupDescription.text = description;
        animator.SetTrigger("open");
    }
    public void PopDown()
    {
        Debug.Log("trying to close window. Maybe works");
        popUpBox.SetActive(false);
        animator.SetTrigger("close");
    }
}
