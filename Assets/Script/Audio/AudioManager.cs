using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

  [SerializeField] Sound[] soundFiles;

  [HideInInspector]
  // Start is called before the first frame update
  void Awake()
  {
    Sound[] sounds = { };
    foreach (Sound s in sounds)
    {
      s.source = gameObject.AddComponent<AudioSource>();
      s.source.clip = s.clip;
      s.source.volume = s.volume;
      s.source.pitch = s.pitch;
      s.source.loop = s.loop;
    }
  }

  // Update is called once per frame
  public void Play(string name)
  {
    Sound[] sounds = { };
    Debug.Log(sounds);
    Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
          Debug.Log("Sound not found");
          Debug.Log(name);
          return;
        }
    s.source.Play();
  }

  void Start()
    {
    //Play("themeTemp");
    }
}
