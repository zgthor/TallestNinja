using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endless : Spawner
{
    [SerializeField] float spawnTimer;
    void Start()
    {
        spawnConditionMet = true;
    }
}
