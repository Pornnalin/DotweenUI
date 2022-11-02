using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class DoTestTween : MonoBehaviour ,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    public GameObject prefab;
    public Ease ease;
    public List<GameObject> games;
    public List<MeshRenderer> meshes;
    public RectTransform rec;
    public Material mete;
    public const string setColor = "Color_F9729B21";
    // Start is called before the first frame update
    void Start()
    {
        // orign = transform.localScale;
        StartCoroutine(wait());
        //StartCoroutine(waitImage());
    }
    //ui
    IEnumerator waitImage()
    {
        int a = 6;
        for (int i = 1; i < a; i++)
        {

            Vector3 pos = new Vector3(i, 0, 0) * 10;
            Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, pos);
            GameObject go = Instantiate(prefab, screenPoint - rec.sizeDelta / 2f, Quaternion.identity);
            go.GetComponent<Image>().color = Random.ColorHSV();
            go.transform.DOScale(2f, 2f).SetEase(ease);
            go.transform.SetParent(rec.transform, false);
            games.Add(go);
            yield return new WaitForSeconds(0.7f);
        }
        StartCoroutine(destory());

    }
    //Obj
    IEnumerator wait()
    {
        int a = 5;
        for (int i = 0; i < a; i++)
        {
            float random = Random.Range(1, 10);
            float random2 = Random.Range(1, 10);
            float random3 = Random.Range(1, 10);
            Vector3 pos = new Vector3(i, 0, 0) * 10;
            GameObject go = Instantiate(prefab, pos, Quaternion.identity);
            meshes.Add(go.GetComponent<MeshRenderer>());
            go.transform.DOScale(5f, 2f).SetEase(ease);
            go.transform.SetParent(transform, false);
            games.Add(go);
            RandomColor(i, random, random2, random3);
            yield return new WaitForSeconds(0.7f);

        }

        Debug.Log("Done_1");
        StartCoroutine(destory());

    }

    private void RandomColor(int i,float random,float random2,float random3)
    {
        //mete = GetComponent<MeshRenderer>().sharedMaterial;
        //meshes[0].GetComponent<Material>().SetColor("Color", Random.ColorHSV());
        // Debug.Log(meshes[0].GetComponent<MeshRenderer>().sharedMaterial);
        
        meshes[i].GetComponent<MeshRenderer>().sharedMaterial.SetColor(setColor, new Color(random, random2, random3, 1) * 20); 
    }

    IEnumerator destory()
    {
        for (int i = games.Count - 1; i >= 0; i--)  
        {
           // Debug.Log(i);
            games[i].transform.DOScale(0, 2f).SetEase(ease);
            yield return new WaitForSeconds(0.7f);
        }
       // StartCoroutine(wait());


        Debug.Log("Done_2");
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(games[0].GetComponent<Renderer>());
    }
   
    public void Hover()
    {
        //transform.DOScale(new Vector3(orign.x + 1.5f, orign.y + 1.5f, orign.z + 1.5f), time).SetEase(easeH);
  
    }
    public void ExitHover()
    {
        //transform.DOScale(orign, time).SetEase(easeO);
    }
   

    public void OnBeginDrag(PointerEventData eventData)
    {
       // image.transform.position = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
       // image.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // transform.position = image.transform.position;
    }
}
