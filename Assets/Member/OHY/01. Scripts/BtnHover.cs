using UnityEngine;
using UnityEngine.EventSystems;

namespace Member.OHY._01._Scripts
{
    public class BtnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Hover Settings")]
        [SerializeField] private float hoverScale = 1.1f;
        [SerializeField] private float duration = 0.1f;

        private Vector3 _originalScale;

        void Start()
        {
            _originalScale = transform.localScale;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.localScale = _originalScale * hoverScale;
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = _originalScale;
        }
    }
}