using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCounter : MonoBehaviour
{
    int fruitsNeededForCombo;
    int fruitsHitOnARow;
    private void Start() 
    {
        GetFruitsNeededForCombo();
        SendUIManagerMaxCombo();
    }
    void OnEnable()
    {
        EventManager.Instance.OnFruitTouched += FruitHit;
        EventManager.Instance.OnBombTouched += ResetCombo;
        EventManager.Instance.OnFruitFallen += ResetCombo;
    }
    void OnDisable()
    {
        EventManager.Instance.OnFruitTouched -= FruitHit;
        EventManager.Instance.OnBombTouched -= ResetCombo;
        EventManager.Instance.OnFruitFallen -= ResetCombo;
    }
    void GetFruitsNeededForCombo()
    {
        fruitsNeededForCombo = GameManager.Instance.GetCurrentGameMode().GetComboRequirementForBoost();
    }
    void FruitHit()
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
    void ResetCombo()
    {
        fruitsHitOnARow = 0;
        UIManager.Instance.UpdateCombo(fruitsHitOnARow);
    }
    void CallInCombo()
    {
        EventManager.Instance.FireEventOnComboThresholdReached();
    }
    void SendUIManagerMaxCombo()
    {
       UIManager.Instance.ReceiveMaxCombo(fruitsNeededForCombo);
    }
}
