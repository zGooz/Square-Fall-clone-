
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction Click;

    public void OnPointerClick(PointerEventData eventData)
    {
        Click?.Invoke();
    }
}
