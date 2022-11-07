using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Move : MonoBehaviour
{
 
    public Transform player;
    public Transform targetPos;
    // Start is called before the first frame update
    void Start()
    {
       ;
    }

    // Update is called once per frame
    void Update()
    {
       
        FuncRay();

    }
    void FuncRay()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100))
            {
                targetPos = hit.collider.transform;
                player.transform.DOScale(0, .5f).SetEase(Ease.OutElastic);
                player.transform.DOScale(2, .1f).SetEase(Ease.OutElastic);
                player.transform.DOScale(1, .5f).SetEase(Ease.OutElastic);
                player.transform.DOMove(new Vector3(targetPos.position.x, 0, targetPos.position.z), .25f).SetEase(Ease.OutElastic);
                //Debug.Log(hit.collider.name);
            }
        }
    }
  
    
}
