using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseHandle : MonoBehaviour
{
    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData evenData;
    [SerializeField] EventSystem m_EventSystem;
    [SerializeField] RectTransform canvasRect;
    public Transform nameTra;
   
    void Update()
    {
        evenData = new PointerEventData(m_EventSystem);
        evenData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(evenData, results);

        foreach (var item in results)
        {
            nameTra = item.gameObject.transform;            
            //Debug.Log("Hit " + item.gameObject.name);
        }

    }

}
