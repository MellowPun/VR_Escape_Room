using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Material lens;

    private Light _light;
    private AudioSource _audioSource;

    void Start()
    {
        _light = GetComponentInChildren<Light>();
        _audioSource = GetComponent<AudioSource>();
        
    }
    public void LightOn()
    {
        _audioSource.Play();
        lens.EnableKeyword("_EMISSION");
        _light.enabled = true;
    }

    public void LightOff()
    {
        _audioSource.Play();
        lens.DisableKeyword("_EMISSION");
        _light.enabled = false;
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Socket"))
        {
            LightOff();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        LightOn();
    }

}
