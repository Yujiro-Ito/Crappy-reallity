using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAudio : MonoBehaviour
{
    private GameObject camera;
    private AudioSource audio;
    public AudioClip clap;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        camera = GameObject.FindWithTag("MainCamera");
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    float dist = (camera.transform.position - gameObject.transform.position).magnitude;
    //    if (dist < 0.3)
    //    {
    //        audio.PlayOneShot(clap, 0.1f);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(audio != null)audio.PlayOneShot(clap, 0.1f);
    }
}
