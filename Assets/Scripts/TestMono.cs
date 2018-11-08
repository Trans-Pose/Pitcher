using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSCore.SoundIn;
using CSCore;
using CSCore.Streams;
using System.Text;

//[RequireComponent(typeof(CsoundUnity))]
public class TestMono : MonoBehaviour
{

    [SerializeField] private CsoundUnity _cSound;
    [SerializeField] private AudioSource _source;

    // Use this for initialization
    void Start()
    {
        _source.clip = Microphone.Start(null, true, 1, 44100);
        _source.loop = true;
        while (!(Microphone.GetPosition(null) > 0))
        { }
        _source.Play();
        //_cSound.processClipAudio = true;
    }

    private void OnDestroy()
    {
    }
}
