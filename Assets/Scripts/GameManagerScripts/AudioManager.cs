using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    private AudioSource source;

    public float volume;
    public bool loop;

    public void SetAudioSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
    }

    public void Play()
    {
        if(!source.isPlaying)
            source.Play();
    }

}
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public Sound[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            GameObject soundObject = new GameObject("사운드 파일 이름 : " + sounds[i].name);
            sounds[i].SetAudioSource(soundObject.AddComponent<AudioSource>());
            soundObject.transform.SetParent(this.transform);
        }
    }
    public int Find(string _name)
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
                return i;
        }
        return 0;
    }

}
