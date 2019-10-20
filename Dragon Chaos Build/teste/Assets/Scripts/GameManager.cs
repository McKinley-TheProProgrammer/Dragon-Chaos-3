﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public GameObject player,spawn;
    public GameObject camera;
    
    
    private void Awake()
    {
        instance = this;
    }

    public void Coroutine()
    {
        StartCoroutine(Destroyed());

    }
    public void SfxPlayer(AudioClip sfx)
    {
        AudioSource audio = GetComponent<AudioSource>();
        sfx.frequency.Equals(Random.value);
        audio.PlayOneShot(sfx);
    }
    public void CineEnabled()
    {
        camera.SetActive(true);
    }
    public void CineDisabled()
    {
        camera.SetActive(false);
    }
    IEnumerator Destroyed()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //player.SetActive(true);
        //Instantiate(player, spawn.transform.position, Quaternion.identity);
    }
    





}
