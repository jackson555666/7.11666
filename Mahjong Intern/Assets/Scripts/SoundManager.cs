using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    [SerializeField] AudioListener audioListener;
    //[SerializeField] AudioMixerGroup mainMixer;//still need for change volume level
    [SerializeField] GameObject audioObjectPrefab;
    public List<SoundData> soundDataList = new List<SoundData>();
    public Dictionary<SoundNameEnum, SoundData> SoundDic = new Dictionary<SoundNameEnum, SoundData>();

    bool isMute;

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
        PlaySound(newAudio);
    }

    public void PlaySoundFromList(SoundNameEnum soundName)
    {
        AudioSource newAudio = Instantiate(audioObjectPrefab.GetComponent<AudioSource>());
        newAudio.clip = SoundDic[soundName].soundClip;
        PlaySound(newAudio);
    }

    void PlaySound(AudioSource newAudio)
    {
        //newAudio.outputAudioMixerGroup = mainMixer;
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

    public void MuteSound()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
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
