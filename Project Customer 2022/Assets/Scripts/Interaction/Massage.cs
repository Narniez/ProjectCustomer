using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Massage : Interactable
{
    public TextMeshProUGUI questText = default;
    public TextMeshProUGUI pressF = default;
    public TextMeshProUGUI quest = default;

    public GameObject go;

    bool isTalking = false;
    public override void OnFocus()
    {
        /*        pressF.enabled = true;*/
        if (isTalking)
        {
            pressF.gameObject.SetActive(false);
        }
        else if (isTalking == false)
        {
            pressF.gameObject.SetActive(true);
        }

        Debug.Log("lookat");
    }

    public override void OnInteract()
    {
        go.SetActive(true);
        isTalking = true;    

        StartCoroutine(imWaiting());

        IEnumerator imWaiting()
        {
            /*isTalking = false;*/
            quest.gameObject.SetActive(false);
            yield return new WaitForSeconds(3);
            go.SetActive(false);
        }     
    }

    public override void OnLoseFocus()
    {
        pressF.gameObject.SetActive(false);
        /*        pressF.enabled = false;*/
        Debug.Log("lose");
    }

}
