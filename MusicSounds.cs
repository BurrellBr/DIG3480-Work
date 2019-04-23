using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSounds : MonoBehaviour
{
    public AudioSource levelMusic;
    public AudioSource deathSound;
    public AudioSource winSound;

    public bool levelSong = true;
    public bool deathSong = false;
    public bool winSong = false;

    public void LevelMusic()
    {
        levelSong = true;
        deathSong = false;
        winSong = false;
        levelMusic.Play();
    }

    public void DeathSound()
    {
        if (levelMusic.isPlaying)
            levelSong = false;
        {
            levelMusic.Stop();
        }
        if(!deathSound.isPlaying && deathSong == false)
        {
            deathSound.Play();
            deathSong = true;
        }
    }

    public void WinSound()
    {
        if (levelMusic.isPlaying)
            levelSong = false;
        {
            levelMusic.Stop();
        }
        if (!winSound.isPlaying && winSong == false)
        {
            winSound.Play();
            winSong = true;
        }
    }


}
