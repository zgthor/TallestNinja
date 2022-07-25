using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SlowDownTime))]
public class TimeManager : MonoBehaviour
{
    SlowDownTime slowDownTime;
    void Start()
    {
        slowDownTime = GetComponent<SlowDownTime>();
    }
    void OnEnable()
    {
        EventManager.Instance.OnLosingSequenceStart += EnableSlowTime;
    }
    void OnDisable()
    {
        EventManager.Instance.OnLosingSequenceStart -= EnableSlowTime;
    }
    void EnableSlowTime()
    {
        slowDownTime.enabled = true;
    }
}
