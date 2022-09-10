using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TasksUI : MonoBehaviour
{
    public RoomCheck roomCheck;
    public Text text;
    public Text taskComplete;
    public bool taskCompleted;

    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Find the living room key";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTaskUI()
    {
        
        if(!inventory.hasLivingRoomKey)
        {
            text.text = "Go to the living room.";
        }

        if (inventory.hasLivingRoomKey && roomCheck.isInLivingRoom == true)
        {
            text.text = "Task Completed :)";
            taskCompleted = true;
        }
    }
}
