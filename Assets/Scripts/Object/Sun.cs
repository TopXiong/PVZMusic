using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.Audio;

public class Sun : MonoBehaviour ,BaseClickObject
{
    public float[] pitchFrequency  =
    new float[]{
        261.5f,293.5f,329.5f,349,392,440,494
    };

    public int tone;

    private static Dictionary<float,AudioClip> clips = new Dictionary<float, AudioClip>();

    public float rotateSpeed = 1;
    private float Speed = 3.5f;
    private float acceleration = -8.5f;
    private bool isAlive = false;
    public Vector2Int point;

    public void OnClick()
    {
        if (isAlive)
        {
            GetComponent<AudioSource>().Play();
            isAlive = false;
            StartCoroutine(CollectSun());
        }
    }

    public IEnumerator CollectSun()
    {
        //阳光被点击之后要去的地方
        GameObject SunPoint = GameObject.Find("SunPoint");
        while (Mathf.Abs(SunPoint.transform.position.x - transform.position.x) > 0.3)
        {
            transform.position = Vector3.Lerp(transform.position, SunPoint.transform.position, Time.deltaTime * 4);
            yield return null;
        }
        Destroy(this.gameObject);
    }


    /// <summary>
    /// 出现
    /// </summary>
    private IEnumerator Appear()
    {
        float t = 0;
        float y = transform.position.y;
        while (transform.position.y >= y)
        {
            t += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y+ Speed * t + 0.5f * acceleration * t * t, 0);
            yield return null;
        }
        //t = 0.824
        isAlive = true;
        OnClick();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Appear());
        AudioSource audio = GetComponent<AudioSource>();
        audio.pitch = GetPitch(tone);

        #region SoundTouch暂时会导致Unity崩溃
        //float pitch = GetPitch();
        //Debug.Log(pitch);
        //if (clips.ContainsKey(pitch))
        //{
        //    audio.clip = clips[pitch];
        //}
        //else
        //{
        //    //变调
        //    float[] saveClip_befor = new float[audio.clip.samples];
        //    audio.clip.GetData(saveClip_befor, 0);

        //    SoundTouch soundTouch = new SoundTouch();
        //    soundTouch.SampleRate = 44100;
        //    soundTouch.Channels = 2;
        //    //soundTouch.Rate = 1f;
        //    soundTouch.Pitch = pitch;
        //    soundTouch.PutSamples(saveClip_befor, (uint)saveClip_befor.Length);
        //    float[] saveClip_after = new float[saveClip_befor.Length];
        //    soundTouch.ReceiveSamples(saveClip_after, (uint)saveClip_after.Length);
        //    soundTouch.Flush();
        //    audio.clip = AudioClip.Create("changedClip", saveClip_after.Length, 2, 44100, false);
        //    audio.clip.SetData(saveClip_after, 0);
        //    clips[pitch] = audio.clip;
        //}
        //audio.Play();
        #endregion

        //var test = Resources.Load("Mixers/MasterMixer", typeof(AudioMixer)) as AudioMixer;
        //try
        //{
        //    audio.outputAudioMixerGroup = test.FindMatchingGroups(tone[point.y - 1])[0];
        //}
        //catch (Exception e)
        //{
        //    Debug.Log(e);
        //}

    }

    private float GetPitch(int tone)
    {
        Debug.Log(tone);
        if (tone > 0)
        {
            return (1+ tone / 8) * pitchFrequency[(tone - 1) % 7 ] / pitchFrequency[0];            
        }
        if(tone < 0)
        {
            tone = -tone;
            return pitchFrequency[(tone-1) % 7] / (2 + tone / 8) / pitchFrequency[0];
        }
        
        return 0;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -1) * rotateSpeed);
    }
}
