using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvisibility : MonoBehaviour
{
    bool isVisible = true;
    [SerializeField] float timeToDestroyOnInvisibility;
    float timeToDestroyOnInvisibilityCounter;
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
        if(CountDownFineshed())
        {
            Destroy(gameObject);
        }
    }
    void CountDown()
    {
        timeToDestroyOnInvisibilityCounter -= Time.deltaTime;

    }
    bool CountDownFineshed()
    {
        return timeToDestroyOnInvisibilityCounter <= 0;
    }
}
