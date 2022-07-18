using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DisableCinemachineAfterATime : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] CinemachineTargetGroup cinemachineTargetGroup;
    [SerializeField] CinemachineBrain cinemachineBrain;
    void Start()
    {
        StartCoroutine(WaitingForSeconds());
    }
    IEnumerator WaitingForSeconds()
    {
        yield return new WaitForSeconds(time);
        virtualCamera.enabled = false;
        cinemachineBrain.enabled = false;
        cinemachineTargetGroup.enabled = false;
        StopCoroutine(WaitingForSeconds());
    }
}
