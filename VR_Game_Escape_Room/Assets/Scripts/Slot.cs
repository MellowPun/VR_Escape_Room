using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Slot : MonoBehaviour
{
    public GameObject itemInSlot;
    public Image slotImage;
    public OpenVRControllerWMR controller;
    public OVRHand
    Color originalColor;

    private void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;

    }

    private void OnTriggerStay(Collider other)
    {
        if(itemInSlot != null) 
        {
            return;
        }
        GameObject obj = other.gameObject;
        if (OpenVRHMD){

        }
    }
}
