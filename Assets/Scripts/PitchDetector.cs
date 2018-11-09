using UnityEngine;
using ManagedBass;
using Pitch;
using System;
using System.Runtime.InteropServices;

public class PitchDetector : MonoBehaviour
{
    [SerializeField] private GUIStyle _gui;
    private PitchTracker _pitchTracker;
    private AudioClip _clip;
    private int _stream;
    private float[] _buffer;
    private float _pitch;
    private float _startTime;
    private bool _loggedTheLag = false;
    private float _lastPitch;

    private const int SAMPLE_RATE = 44100;

    void Start()
    {
        _pitchTracker = new PitchTracker();
        _pitchTracker.PitchDetected += HandleNewPitchDetected;
        _pitchTracker.SampleRate = SAMPLE_RATE;
        Bass.RecordInit();
        _stream = Bass.RecordStart(SAMPLE_RATE, 1, BassFlags.Float | BassFlags.RecordPause, HandleRecordingData);
        Bass.ChannelPlay(_stream);
        _startTime = Time.realtimeSinceStartup;
    }

    private void HandleNewPitchDetected(Pitch.PitchTracker sender, PitchTracker.PitchRecord pitchRecord)
    {
        _lastPitch = _pitch;
        _pitch = pitchRecord.Pitch;
    }

    private bool HandleRecordingData(int Handle, IntPtr Buffer, int Length, IntPtr User)
    {
        if (_buffer == null || _buffer.Length < Length / 4)
        {
            _buffer = new float[Length / 4];
        }

        Marshal.Copy(Buffer, _buffer, 0, Length / 4);

        _pitchTracker.ProcessBuffer(_buffer);
        return true;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 1000, 200), _pitch.ToString());
    }

    private void OnDestroy()
    {
        Bass.RecordFree();
    }
}
