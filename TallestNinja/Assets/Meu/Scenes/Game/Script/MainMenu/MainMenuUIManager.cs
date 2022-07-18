using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    GameObject[] stepsTaken;
    [SerializeField]
    GameObject MainMenu;

    [Header("Games")]
    [SerializeField]
    GameObject GamesPanel;
    [SerializeField]
    GameObject TwoD2DPanel;
    [SerializeField]
    GameObject TwoPointFiveD25DPanel;
    [SerializeField]
    GameObject ThreeD3DPanel;

    List<GameObject> gameObjectList = new List<GameObject>();
    public void Return()
    {
        UIToDisable();
        // remove last GO from list
        // Activate the next GO from the list
    }
    public void Clicked()
    {
        GameObject clickedUI = EventSystem.current.currentSelectedGameObject;
        string name = clickedUI.name;
        Debug.Log(name);
        //stepsTaken.Push(name);
        //if needed put an if

        Main();
    }   
    private void Main()
    {
        UIToDisable(); // a ternary could be used here but the performance cost and the readability would both suffer
        UIToEnable();
        CreateNewCanvas();
        AnimateCamera();
    }
    private void CreateNewCanvas()
    {
        
    }
    private void AnimateCamera()
    {

    }
    private void UIToDisable()
    {
        //Debug.Log(stepsTaken.Peek());
    }
    private void UIToEnable()
    {

    }
    public void loadNextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
