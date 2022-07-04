using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] AudioSource musicSource, effectsSource;

    private void Start() 
    {
        if(ThereIsNoGameManagerSingleton())
        {
            InstantiateGameManagerSingleton();
            DontDestroyOnLoad(gameObject);
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
    
    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }
}
