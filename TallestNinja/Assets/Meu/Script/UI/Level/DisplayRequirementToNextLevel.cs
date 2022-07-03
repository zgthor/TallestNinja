using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayRequirementToNextLevel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI requirementToNextLevelText;

    void Start()
    {
        UpdateText("0");
    }

    public void UpdateText(string newText)
    {
        requirementToNextLevelText.text = newText;
    }
}
