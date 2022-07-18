using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnInvisibility : MonoBehaviour
{
    bool isVisible = true;
    [SerializeField] float timeToDestroyOnInvisibility = 0.5f;
    float timeToDestroyOnInvisibilityCounter;
    [SerializeField] bool reportIfDisabled = false;
    int i;
    private void OnBecameInvisible()
    {
        isVisible = false;
    }
    private void OnDisable() 
    {
        ResetVariables();
    }
    void ResetVariables()
    {
        timeToDestroyOnInvisibilityCounter = timeToDestroyOnInvisibility;
        isVisible = true;
    }
    void Update()
    {
        if(!isVisible)
        {
            CountDown();
        }
        if(CountDownFinished())
        {
            if(reportIfDisabled)
            {
                GameManager.Instance.FruitFallen();
            }
            gameObject.SetActive(false);
        }
    }
    void CountDown()
    {
        timeToDestroyOnInvisibilityCounter -= Time.deltaTime;
    }
    bool CountDownFinished()
    {
        return timeToDestroyOnInvisibilityCounter <= 0;
    }
}
