using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnInvisibility : MonoBehaviour
{
    bool isVisible = true;
    [SerializeField] float timeToDestroyOnInvisibility = 0.5f;
    float timeToDestroyOnInvisibilityCounter;
    [SerializeField] bool reportIfDisabled = false;
    private void OnBecameInvisible()
    {
        isVisible = false;
    }
    private void OnBecameVisible()
    {
        isVisible = true;
    }
    private void OnEnable()
    {
        timeToDestroyOnInvisibilityCounter = timeToDestroyOnInvisibility;
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
