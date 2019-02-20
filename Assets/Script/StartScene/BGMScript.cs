﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    private AudioSource startBGM, gameBGM, clickedSound, introBGM;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        startBGM = gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        gameBGM = gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        clickedSound = gameObject.transform.GetChild(2).gameObject.GetComponent<AudioSource>();
        introBGM = gameObject.transform.GetChild(3).gameObject.GetComponent<AudioSource>();
    }

    public void StartBGMPlay()
    {
        if (gameBGM.isPlaying) gameBGM.Pause();
        if (introBGM.isPlaying) introBGM.Pause();
        if (!startBGM.isPlaying) startBGM.Play();
    }

    public void GameBGMPlay()
    {
        if (startBGM.isPlaying) startBGM.Pause();
        if (introBGM.isPlaying) introBGM.Pause();
        if (!gameBGM.isPlaying) gameBGM.Play();
    }

    public void PauseGameBGM()
    {
        if (startBGM.isPlaying) startBGM.Pause();
        else if (gameBGM.isPlaying) gameBGM.Pause();
    }

    public void ButtonClickedSoundPlay()
    {
        clickedSound.Play();
    }

    public void IntroBGMPlay()
    {
        if (gameBGM.isPlaying) gameBGM.Pause();
        if (startBGM.isPlaying) startBGM.Pause();
        if (!introBGM.isPlaying) introBGM.Play();
    }
}
