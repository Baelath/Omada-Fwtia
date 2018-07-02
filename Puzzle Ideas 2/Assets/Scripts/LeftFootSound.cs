using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftFootSound : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] shoot;
    private AudioClip shootClip;
    public float stepInterval = 0.25f;
    private float nextStep = 0f;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        int index = Random.Range(0, shoot.Length);
    //        shootClip = shoot[index];
    //        audioSource.clip = shootClip;
    //        audioSource.Play();
    //    }
    //}   // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        //int index = Random.Range(0, shoot.Length);
        //shootClip = shoot[index];
        //audioSource.clip = shootClip;
        //audioSource.Play();
        if(Time.time > nextStep)
        {
            nextStep = Time.time + stepInterval;
        }
        audioSource.PlayOneShot(shoot[Random.Range(0, shoot.Length)]);
        //Debug.Log("Puzzle 1 infocube entered!");
    }

    private void OnTriggerExit(Collider other)
    {

        
        //Debug.Log("Puzzle 1 infocube exited!");
    }
}
