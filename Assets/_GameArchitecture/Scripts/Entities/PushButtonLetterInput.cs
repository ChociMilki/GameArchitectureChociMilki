using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class PushButtonLetterInput : MonoBehaviour, ISelectable
{
    public UnityEvent onPush;
    public UnityEvent onHoverEnter;
    public UnityEvent onHoverExit; 
    
public void OnHoverEnter()
    {
        onHoverEnter?.Invoke();     }
    public void OnHoverExit()
    {
        onHoverExit?.Invoke(); 
    }
    public void OnSelect()
    {
        ; onPush?.Invoke();
    }
}
