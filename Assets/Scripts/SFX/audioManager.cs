using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour{


    public Sound[] sounds;

    public static audioManager instance;

    // Start is called before the first frame update
    void Awake() {

        if (instance == null) instance = this;

        else
        {
            Destroy(gameObject);
            return;
        } 
            
        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    public void Start()
    {
        Play("MainMusic");
    }

    public void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Stop("MainMusic");
        }
    }


    public void Play (string name) {

        Sound s =  Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");

            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");

            return;
        }

        s.source.Stop();
    }

}
