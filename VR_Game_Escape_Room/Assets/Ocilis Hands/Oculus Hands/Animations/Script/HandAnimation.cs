using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class HandAnimation : MonoBehaviour
{
    [SerializeField]
    private InputActionReference gripReference;
    [SerializeField]
    private InputActionReference triggerReference;

    private float _gripValue;
    private float _triggerValue;
    private new Animator animation;

    private void Start()
    {
        animation = this.GetComponent<Animator>();
    }


    void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }

    private void AnimateGrip()
    {
        _gripValue = gripReference.action.ReadValue<float>();
        animation.SetFloat("Grip", _gripValue);
    }
    private void AnimateTrigger()
    {
        _triggerValue = triggerReference.action.ReadValue<float>();

        animation.SetFloat("Trigger", _triggerValue);

    }
}
