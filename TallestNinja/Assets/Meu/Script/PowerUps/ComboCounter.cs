using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCounter : MonoBehaviour
{
    [SerializeField] int fruitsNeededForCombo;
    int fruitsHitOnARow;
    public static ComboCounter Instance;
    private void Start() 
    {
        if(ThereIsNoGameManagerSingleton())
        {
            InstantiateGameManagerSingleton();
        }
        else
        {
            Destroy(this);
        }    
    }
    bool ThereIsNoGameManagerSingleton()
    {
        return Instance == null;
    }
    void InstantiateGameManagerSingleton()
    {
        Instance = this;
    }
    public void FruitHit()
    {
        IncreaseComboCounter();

        if(ComboRequirementReached())
        {
            CallInCombo();
            ResetCombo();
        }
    }
    void IncreaseComboCounter()
    {
        fruitsHitOnARow++;
    }
    bool ComboRequirementReached()
    {
        return fruitsNeededForCombo <= fruitsHitOnARow;
    }
    public void ComboLost()
    {
        ResetCombo();
    }
    void ResetCombo()
    {
        fruitsHitOnARow = 0;
    }
    void CallInCombo()
    {
        GameManager.Instance.AskForAPowerUp();
        Debug.Log("combo");
    }
}
