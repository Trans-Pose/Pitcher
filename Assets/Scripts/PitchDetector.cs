using UnityEngine;
using ManagedBass;
using Pitch;
using System;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using System.Collections.Generic;

public class PitchDetector : MonoBehaviour
{
    [SerializeField] private Image _pitchFill;

    private PitchTracker _pitchTracker;
    private int _stream;
    private float[] _buffer;
    private float _lastRealPitch;
    private List<float> _pitchesThisUpdate = new List<float>();

    private const float MIN_FREQ = 100f;
    private const float MAX_FREQ = 1000f;

    private const int SAMPLE_RATE = 44100;

    void Start()
    {
        _pitchTracker = new PitchTracker();
        _pitchTracker.PitchDetected += HandleNewPitchDetected;
        _pitchTracker.SampleRate = SAMPLE_RATE;
        Bass.RecordInit();
        _stream = Bass.RecordStart(SAMPLE_RATE, 1, BassFlags.Float | BassFlags.RecordPause, HandleRecordingData);
        Bass.ChannelPlay(_stream);
    }

    private void Update()
    {
        var pitch = AverageOfNonZeroPitches();
        if (pitch > 0)
        {
            _pitchFill.fillAmount = (pitch - MIN_FREQ) / (MAX_FREQ - MIN_FREQ);
        }
        _pitchesThisUpdate.Clear();
    }

    // TODO: Average over time
    private float AverageOfNonZeroPitches()
    {
        var sum = 0f;
        int validPitches = 0;
        for (int i = 0; i < _pitchesThisUpdate.Count; i++)
        {
            if(_pitchesThisUpdate[i] > 1)
            {
                sum += _pitchesThisUpdate[i];
                validPitches++;
            }
        }
        if(validPitches >= _pitchesThisUpdate.Count * 1f/3f)
        {
            return sum / validPitches;
        }
        return 0;
    }

    private void HandleNewPitchDetected(Pitch.PitchTracker sender, PitchTracker.PitchRecord pitchRecord)
    {
        _pitchesThisUpdate.Add(pitchRecord.Pitch);
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

    private void OnDestroy()
    {
        Bass.RecordFree();
    }
}
