using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionMessageUI : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField]private GameObject uiPanel;
    [SerializeField] private TextMeshProUGUI _messageText;

    private void Start()
    {
        mainCam = Camera.main;
        _messageText.enabled = false;
    }

    private void LateUpdate()
    {
        //var rotation = mainCam.transform.rotation;
        //transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool isDisplayed = false;
    public void SetUp(string messageText)
    {
        _messageText.text = messageText;
        _messageText.enabled = true;
        isDisplayed = true;
    }

    public void Close()
    {
        _messageText.enabled = false;
        isDisplayed = false;
    }
}
