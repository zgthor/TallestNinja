using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCounter : MonoBehaviour
{
    int fruitsNeededForCombo;
    int fruitsHitOnARow;
    public static ComboCounter Instance;
    private void Start() 
    {
        if(ThereIsNoComboCounterSingleton())
        {
            InstantiateComboCounterSingleton();
        }
        else
        {
            Destroy(this);
        }    
        GetFruitsNeededForCombo();
        SendUIManagerMaxCombo();
    }
    bool ThereIsNoComboCounterSingleton()
    {
        return Instance == null;
    }
    void InstantiateComboCounterSingleton()
    {
        Instance = this;
    }
    void GetFruitsNeededForCombo()
    {
        fruitsNeededForCombo = GameManager.Instance.gameMode.GetComboRequirementForBoost();
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
        UIManager.Instance.UpdateCombo(fruitsHitOnARow);
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
        UIManager.Instance.UpdateCombo(fruitsHitOnARow);
    }
    void CallInCombo()
    {
        GameManager.Instance.AskForAPowerUp();
        Debug.Log("combo");
    }
    void SendUIManagerMaxCombo()
    {
       UIManager.Instance.ReceiveMaxCombo(fruitsNeededForCombo);
    }
}
