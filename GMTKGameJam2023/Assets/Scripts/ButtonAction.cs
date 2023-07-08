using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonAction : MonoBehaviour
{
    public string sceneName;
    public UnityEvent onClick;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        onClick.Invoke();
    }
}
