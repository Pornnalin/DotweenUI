using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]private Image child;
    Color currentColor;   
    [SerializeField] private Transform parentTarget;
    public MouseHandle handle;
    public Shaking shaking;
    
    public void Start()    {
       
        child = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {       
        parentTarget = handle.nameTra;
     
    }
   

    public void OnBeginDrag(PointerEventData eventData)
    {
      
        child.transform.DOScale(new Vector3(1f, 1f, 1f), .5f).SetEase(Ease.OutElastic);
    }
   
    public void OnDrag(PointerEventData eventData)
    {        
        child.transform.position = eventData.position;
        child.transform.SetParent(transform.root, true);
        child.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = child.transform.position;
        child.transform.DOScale(new Vector3(.5f, .5f, .5f), .5f).SetEase(Ease.OutElastic);
        child.transform.SetParent(parentTarget, false);
       
        child.transform.position = parentTarget.transform.position;

        child.raycastTarget = true;
       

        shaking.FuncBink();
        shaking.FuncShaking();
        shaking.FuncColor();
    }
    public void Hover()
    {
        child.color = Random.ColorHSV();
        currentColor = child.color;
       
    }
    public void ExitHover()
    {
        child.color = currentColor;
    }

  
}
