using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICreapIn : MonoBehaviour
{
    CanvasGroup currentCanvasGroup;
    UICreapIn thisClass;
    // Start is called before the first frame update
    void Start()
    {
        GetClassesComponents();
    }
    void GetClassesComponents()
    {
        currentCanvasGroup = gameObject.GetComponent<CanvasGroup>();
        thisClass = gameObject.GetComponent<UICreapIn>();
    }

    void Update()
    {
        if (isTimeToStop())
        {
            FullyDisplayCanvas();
            DisableThisClass();
        }
        else
        {
            SlowlyShowCanvas();
        }
    }
    bool isTimeToStop()
    {
        return Time.timeScale <= 0;
    }
    void FullyDisplayCanvas()
    {
        currentCanvasGroup.alpha = 1;
    }
    void DisableThisClass()
    {
        thisClass.enabled = false;
    }
    void SlowlyShowCanvas()
    {
        currentCanvasGroup.alpha = 1 - Time.timeScale;
    }
}
