using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandInput : MonoBehaviour
{
    public InputActionProperty pinchAnimAction;
    public InputActionProperty gripAnimAction;

    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerVal = pinchAnimAction.action.ReadValue<float>();
        float gripVal = gripAnimAction.action.ReadValue<float>();

        handAnimator.SetFloat("Trigger", triggerVal);
        handAnimator.SetFloat("Grip", gripVal);
    }
}
