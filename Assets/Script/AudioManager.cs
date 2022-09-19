using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public sound[] _sound;
    AudioSource _source;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        for (int i = 0; i < _sound.Length  ; i++)
        {
            _source=this.gameObject.AddComponent<AudioSource>();
            _source.clip = _sound[i]._clip;
            _source.volume  = _sound[i]._volume ;
            _source.loop   = _sound[i]._loop  ;
            _source.playOnAwake    = _sound[i]._playOnAwake   ;
        }
    }

    void Update()
    {
     //if(Input.GetKeyDown (KeyCode.M ))
     //   {
     //       PlaySound("coin");
     //   }
    }
    public void PlaySound(string name)
    {
        foreach (sound s in _sound)
        {
            if (name == s._name )
            {
                _source.PlayOneShot (s._clip,s._volume );
            }
        }

    }
}
