using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickThisAtAPartOfScreen : MonoBehaviour
{
    [SerializeField] float yPosition;
    [SerializeField] float xPosition;
    [SerializeField] float setItAfterSeconds;
    [SerializeField] int timesToLoop;
    [SerializeField] bool loopForever;
    Vector3 idealPosition;
    void Start()
    {
        StartCoroutine(WaitingForSeconds());
    }
    void GetScreenBottom()
    {
        idealPosition = Camera.main.ViewportToWorldPoint(new Vector2(xPosition,yPosition));
    }
    void SetItAtScreensBottom()
    {
        transform.position = new Vector3(idealPosition.x,idealPosition.y, GameManager.Instance.GetPlayableArea());
    }
    IEnumerator WaitingForSeconds()
    {
        do
        {
            GetScreenBottom();
            SetItAtScreensBottom();
            timesToLoop--;
            yield return new WaitForSeconds(setItAfterSeconds);
        }
        while(timesToLoop > 0 || loopForever);
        StopCoroutine(WaitingForSeconds());
    }
}
