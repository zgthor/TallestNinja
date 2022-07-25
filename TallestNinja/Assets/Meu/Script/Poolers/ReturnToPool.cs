using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    public void Return()
    {
        //MyRest();
        gameObject.SetActive(false);
    }
    //void MyRest()
    //{

    //}
}
