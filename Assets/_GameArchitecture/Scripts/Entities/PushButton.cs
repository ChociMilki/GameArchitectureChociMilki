using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// enables button push that changes the mesh renderer material on hover exit/enter  for an elevator found in Game Architecture scene. 
/// does not call on hover unity event, but that could be added and is found and expounded upon  in "PushButtonLetterInput" script . Interactor functionality 
/// possible via enabling SimpleInteractor through ISelectable 
public class PushButton : MonoBehaviour, ISelectable
{
    [SerializeField] private Material _defaultColour;
    [SerializeField] private Material _hoverColour;
    [SerializeField] private MeshRenderer _renderer;

    public UnityEvent onPush;

    public void OnHoverEnter()
    {
        _renderer.material = _hoverColour;

    }

    public void OnHoverExit()
    {
        _renderer.material = _defaultColour;

    }

    public void OnSelect()
    {
        onPush?.Invoke();
    }


}
