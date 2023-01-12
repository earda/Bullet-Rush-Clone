using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    private Vector2 _clickPosition;
    [SerializeField] private Image _viewPivot;
    public Vector2 Direction { get; private set; }
    public void OnPointerDown(PointerEventData eventData)
    { 
        _clickPosition = eventData.position;
        _viewPivot.enabled =true;
        _viewPivot.transform.position = _clickPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector3.zero;
        _viewPivot.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var delta = eventData.position - _clickPosition;
        Direction = delta.normalized;
        
    }
}