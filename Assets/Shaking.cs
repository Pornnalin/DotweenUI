using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Shaking : MonoBehaviour
{
    RectTransform rectTransform;
    public Image invenIma;
    public Image blink;
    public List<Image> imagesWhite;
    public Gradient[] gradient;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

    }
    public void Update()
    {
        
    }
    public void FuncShaking()
    {      
        rectTransform.DOShakePosition(.1f, 10);
        rectTransform.DOShakeScale(.2f, 0.2f);        
    }
    public void FuncBink()
    {
        blink.DOFade(1, .1f);
        Invoke(nameof(BinkWait), 0.05f);

    }
    public void FuncColor()
    {
      

        for (int i = 0; i < imagesWhite.Count; i++)
        {
            int num = Random.Range(0, gradient.Length);
            imagesWhite[i].DOGradientColor(gradient[num], 0.5f);
           
        }
        invenIma.color = Random.ColorHSV();
    }


    void BinkWait()
    {

        blink.DOFade(0, 0.1f);

    }
}
