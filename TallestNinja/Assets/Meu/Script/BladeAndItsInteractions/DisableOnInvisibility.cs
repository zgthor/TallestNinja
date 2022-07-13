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
    private void OnBecameInvisible()
    {
        isVisible = false;
    }
    private void OnBecameVisible()
    {
        itHasAppeared = true;
        isVisible = true;
    }
    void Start()
    {
        isVisible = true;
    }
    private void OnEnable()
    {
        timeToDestroyOnInvisibilityCounter = timeToDestroyOnInvisibility;
        itHasAppeared = false;
    }
    private void OnDisable() 
    {
        itHasAppeared = false;
    }
    void Update()
    {
        if(!isVisible && itHasAppeared)
        {
            CountDown();
        }
        if(CountDownFinished())
        {
            if(reportIfDisabled)
            {
                GameManager.Instance.FruitFallen();
                Debug.Log("bruh");
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
