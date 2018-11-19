using UnityEngine;
using ManagedBass;
using Pitch;
using System;
using System.Runtime.InteropServices;
using EnumerableDropOutStack;
using System.Collections.Generic;

public class PitchDetector : MonoBehaviour
{
    private const int SAMPLE_RATE = 44100;

    private PitchTracker _pitchTracker;
    private int _streamId;
    private float[] _buffer;
    private List<float> _pitchesThisUpdate = new List<float>();
    private DropOutStack<float> _detectedPitches = new DropOutStack<float>(10);
    public DropOutStack<float> DetectedPitches { get { return new DropOutStack<float>(_detectedPitches); } }
    private bool _isRecording;

    private void Awake()
    {
        _pitchTracker = new PitchTracker();
        _pitchTracker.PitchDetected += HandleNewPitchDetected;
        _pitchTracker.SampleRate = SAMPLE_RATE;
        Bass.RecordInit();
        _streamId = Bass.RecordStart(SAMPLE_RATE, 1, BassFlags.Float | BassFlags.RecordPause, HandleRecordingData);
    }

    public void StartDetection()
    {
        Bass.ChannelPlay(_streamId);
        _isRecording = true;
    }

    public void StopDetection()
    {
        Bass.ChannelPause(_streamId);
        _isRecording = false;
        _pitchesThisUpdate.Clear();
        _detectedPitches.Clear();
    }

    private void Update()
    {
        if (_isRecording)
        {
            var pitch = AverageOfNonZeroPitches();
            _detectedPitches.Push(pitch);
            _pitchesThisUpdate.Clear();
        }
    }

    // TODO: Average over time ???
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

    private void HandleNewPitchDetected(PitchTracker sender, PitchTracker.PitchRecord pitchRecord)
    {
        _pitchesThisUpdate.Add(pitchRecord.Pitch);
    }

    private void OnDestroy()
    {
        Bass.RecordFree();
    }
}
