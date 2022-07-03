using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] List <AudioClip> clip = new List<AudioClip>();
    public void PlaySoundFromList()
    {
        PlaySpecifiedSound(clip[Random.Range(0,clip.Count-1)]);
    }
        public void PlaySpecifiedSound(AudioClip audioClip)
    {
        Debug.Log(audioClip.name);
        SoundManager.Instance.PlaySound(audioClip);
    }
}
