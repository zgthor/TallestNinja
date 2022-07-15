using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickThisAtScreenBottom : MonoBehaviour
{
    [SerializeField] float offset;
    [SerializeField] float setItAfterSeconds;
    Vector3 idealPosition;
    void Start()
    {
        StartCoroutine(WaitingForSeconds());
    }
    void GetScreenBottom()
    {
        idealPosition = Camera.main.ViewportToWorldPoint(new Vector2(0.5f,offset));
    }
    void SetItAtScreensBottom()
    {
        transform.position = new Vector3(idealPosition.x,idealPosition.y, GameManager.Instance.GetPlayableArea());
    }
    IEnumerator WaitingForSeconds()
    {
        yield return new WaitForSeconds(setItAfterSeconds);
        GetScreenBottom();
        SetItAtScreensBottom();
        StopCoroutine(WaitingForSeconds());
    }
}
