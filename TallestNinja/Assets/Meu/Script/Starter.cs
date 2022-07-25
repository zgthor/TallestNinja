using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] float timeUntilGameStart;
    void Start()
    {
        StartCoroutine(StartGame());
    }
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(timeUntilGameStart);
        EventManager.Instance.FireEventOnGameStart();
        StopCoroutine(StartGame());
    }
}
