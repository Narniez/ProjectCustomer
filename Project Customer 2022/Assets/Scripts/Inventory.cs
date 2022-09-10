using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public  class Inventory : MonoBehaviour
{
    public bool hasKey = false;
    public bool hasLivingRoomKey = false;

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            hasKey = !hasKey;
            hasLivingRoomKey = !hasLivingRoomKey;

            if(hasKey == true)
            {
                //Debug.Log("Got the Key!");
            }
        }
    }
}
