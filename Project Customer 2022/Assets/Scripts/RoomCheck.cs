using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCheck : MonoBehaviour
{
    [SerializeField] public bool isInLivingRoom = false;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if(other.tag == "Player")
        {
            isInLivingRoom = !isInLivingRoom;
        }
    }
}
