using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Popup : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private bool closeOnClickOutside;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (closeOnClickOutside)
        {
            gameObject.SetActive(false);
        }
    }
}
