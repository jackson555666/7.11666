using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject audioObjectPrefab;
    public List<SoundData> soundDataList = new List<SoundData>();
    public Dictionary<SoundNameEnum, SoundData> SoundDic = new Dictionary<SoundNameEnum, SoundData>();

    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        AddListToDic();
    }

    public void PlaySoundFromClip(AudioClip audioFile)
    {
        AudioSource newAudio = Instantiate(audioObjectPrefab.GetComponent<AudioSource>());
        newAudio.clip = audioFile;
        newAudio.Play();
        Destroy(newAudio.gameObject, newAudio.clip.length);
    }

    public void PlaySoundFromList(SoundNameEnum soundName)
    {
        AudioSource newAudio = Instantiate(audioObjectPrefab.GetComponent<AudioSource>());
        newAudio.clip = SoundDic[soundName].soundClip;
        newAudio.Play();
        Destroy(newAudio.gameObject, newAudio.clip.length);
    }

    void AddListToDic()
    {
        foreach(SoundData sound in soundDataList)
        {
            SoundDic.Add(sound.soundName, sound);
        }
    }
}

public enum SoundNameEnum
{
    tileClick,
    menuClick
}

[Serializable]
public class SoundData
{
    public SoundNameEnum soundName;
    public AudioClip soundClip;
}
