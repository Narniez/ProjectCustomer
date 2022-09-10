using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    public TextMeshProUGUI questText = default;

    public bool fadeIn = false;
    public bool fadeOut = false;

    public CanvasGroup myUIGroup;

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if (myUIGroup.alpha < 1)
            {
                Debug.Log("?magePop");
                myUIGroup.alpha += Time.deltaTime;
                if(myUIGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (myUIGroup.alpha == 1)
            {
                myUIGroup.alpha += Time.deltaTime;
                if(myUIGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
    }
}
