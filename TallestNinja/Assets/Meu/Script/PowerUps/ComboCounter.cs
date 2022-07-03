using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCounter : MonoBehaviour
{
    [SerializeField] int fruitsNeededForCombo;
    GameManager gameManager;
    int fruitsHitOnARow;
    private void Start() 
    {
        gameManager = GetComponent<GameManager>();
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
        gameManager.AskForAPowerUp();
        Debug.Log("combo");
    }
}
