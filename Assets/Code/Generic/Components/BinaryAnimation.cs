using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BinaryAnimation : MonoBehaviour
{
    public bool isActive;
    public string animatorVariableName;

    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    private void Start()
    {
        if(isActive)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }
    public void Activate()
    {
        isActive = true;
        SetAnimatorBool();
        onActivate.Invoke();
    }

    public void Deactivate()
    {
        isActive = false;
        SetAnimatorBool();
        onDeactivate.Invoke();
    }

    private void SetAnimatorBool()
    {
        gameObject.GetComponentInChildren<Animator>().SetBool(animatorVariableName, isActive);
    }

}
