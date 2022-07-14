using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnInvisibility : MonoBehaviour
{
    bool isVisible = true;
    bool itHasAppeared = false;
    [SerializeField] float timeToDestroyOnInvisibility = 0.5f;
    float timeToDestroyOnInvisibilityCounter;
    [SerializeField] bool reportIfDisabled = false;
    int i;
    private void OnBecameInvisible()
    {
        isVisible = false;
    }

    private void OnBecameVisible()
    {
        if(Camera.current == Camera.main)
        {
            itHasAppeared = true;
            isVisible = true;
        }
    }   
    void Start()
    {
        ResetVariables();
    }
    private void OnEnable()
    {
        ResetVariables();
    }
    private void OnDisable() 
    {
        ResetVariables();
    }
    void ResetVariables()
    {
        itHasAppeared = false;
        timeToDestroyOnInvisibilityCounter = timeToDestroyOnInvisibility;
        isVisible = true;
    }
    void Update()
    {
        if(!itHasAppeared)
        {
            return;
        }
        if(!isVisible)
        {
            CountDown();
        }
        if(CountDownFinished())
        {
            if(reportIfDisabled)
            {
                GameManager.Instance.FruitFallen();
                itHasAppeared = false;
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
