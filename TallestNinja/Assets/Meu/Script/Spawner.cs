using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] fruitsToSpawn = new GameObject[]{};    
    [SerializeField] GameObject[] bombsToSpawn = new GameObject[] { };
    [SerializeField] GameObject[] powerUpsToSpawn = new GameObject[]{};
    float chanceOfBomb;    
    [HideInInspector] public float timeToSpawn;
    protected float timer;
    [SerializeField] float force;
    [SerializeField] float forceRange;
    GameObject instantiated;
    List <int> fruitKeys = new List<int>();
    List<int> bombKeys = new List<int>();
    List<int> powerUpKeys = new List<int>();
    [SerializeField] Vector3 spawnPosition;
    Rigidbody instantiatedRigidBody;
    public bool spawnConditionMet;
    GameModeSettingsSO currentGameMode;

    void Start()
    {
        CreatePoolAndGetPoolKey();
        GetGameModeConfig();
        ApplyConfig();
        ResetTimer(); 
    }
    void CreatePoolAndGetPoolKey()
    {
        for (int i = 0; i < fruitsToSpawn.Length; i++)
        {
            fruitKeys.Add(ObjectPoolSpawner.Instance.GetKey(fruitsToSpawn[i]));
        }
        for (int i = 0; i < bombsToSpawn.Length; i++)
        {
            bombKeys.Add(ObjectPoolSpawner.Instance.GetKey(bombsToSpawn[i]));
        }
        for (int i = 0; i < powerUpsToSpawn.Length; i++)
        {
            powerUpKeys.Add(ObjectPoolSpawner.Instance.GetKey(powerUpsToSpawn[i]));
        }
    }
    void GetGameModeConfig()
    {
        currentGameMode = GameManager.Instance.GetCurrentGameMode();
    }
    void ApplyConfig()
    {
        chanceOfBomb = currentGameMode.GetChanceOfBomb();
        timeToSpawn = currentGameMode.GetSpawnFrequency();
    }
    void ResetTimer()
    {
        timer = timeToSpawn;
    }
    void Update()
    {   // this will spawn stuff after a timer
        TimerCountDown();
        if(isTimerCompleted() && spawnConditionMet) // remove timer CountDown reset timer and this, make it so you call in the spawn trough endless per time or per fruit
        {
            ResetTimer();
            if (isFruitChanceHigherThanBombChance())
            {
                PoolInFruitFromPoolFromKey();
                SetInstantiatedPosition();
                ReportThePoolingOfFruit();
            }
            else
            {
                PoolInBombFromPoolFromKey();
                SetInstantiatedPosition();
            }
            ActivateInstantiatedGameObject();
            GetInstantiatedGameObjectRigidbody();
            ApplyRandomRotationAndForceToTheInstantiatedGameObject();            
        }
    }
    bool isTimerCompleted()
    {
        return timer <= 0;
    }
    bool isFruitChanceHigherThanBombChance()
    {
        return Random.Range(1, 101) > chanceOfBomb;
    }
    void PoolInFruitFromPoolFromKey()
    {
        instantiated = ObjectPoolSpawner.Instance.GetObjectFromPool(fruitKeys[Random.Range(0, fruitKeys.Count - 1)]);
    }
    void SetInstantiatedPosition()
    {
        instantiated.transform.position = new Vector3(Random.Range(-spawnPosition.x, spawnPosition.x), spawnPosition.y, spawnPosition.z);
    }
    void ReportThePoolingOfFruit()
    {
        GameManager.Instance.FruitSpawned();
    }
    void PoolInBombFromPoolFromKey()
    {
        instantiated = ObjectPoolSpawner.Instance.GetObjectFromPool(bombKeys[Random.Range(0, fruitKeys.Count - 1)]);
    }
    void TimerCountDown()
    {
        timer -= Time.deltaTime;
    }
    void ActivateInstantiatedGameObject()
    {
        instantiated.SetActive(true);
    }
    void GetInstantiatedGameObjectRigidbody()
    {
        instantiatedRigidBody = instantiated.GetComponent<Rigidbody>();
    }
    void ApplyRandomRotationAndForceToTheInstantiatedGameObject()
    {
        instantiatedRigidBody.rotation = Random.rotation;
        instantiatedRigidBody.AddExplosionForce(Random.Range(force, force * forceRange), transform.position, 5f);
    }
    public void SpawnAPowerUp()
    {
        PoolInPowerUpFromPoolFromKey();
        SetInstantiatedPosition();
        ActivateInstantiatedGameObject();
        GetInstantiatedGameObjectRigidbody();
        ApplyRandomRotationAndForceToTheInstantiatedGameObject();  
    }
    void PoolInPowerUpFromPoolFromKey()
    {
        instantiated = ObjectPoolSpawner.Instance.GetObjectFromPool(powerUpKeys[Random.Range(0, powerUpKeys.Count - 1)]);
    }
    public void DecreaseTimeToSpawnBy(float by)
    {
        timeToSpawn -= by;
    }
}
