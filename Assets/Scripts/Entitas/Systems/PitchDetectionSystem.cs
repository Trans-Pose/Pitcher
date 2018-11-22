using Entitas;
using ManagedBass;
using Pitch;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PitchDetectionSystem : IExecuteSystem, IInitializeSystem, ITearDownSystem
{
    private const int SAMPLE_RATE = 44100;

    private GameContext _gameContext;
    private PitchTracker _pitchTracker;
    private int _streamId;
    private float[] _buffer;
    private List<float> _pitchesThisUpdate = new List<float>();
    private DropOutStack<float> _detectedPitches = new DropOutStack<float>(10);
    public DropOutStack<float> DetectedPitches { get { return new DropOutStack<float>(_detectedPitches); } }
    private bool _isRecording = false;


    public PitchDetectionSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
    }

    #region Entitas messages

    public void Initialize()
    {
        _pitchTracker = new PitchTracker();
        _pitchTracker.PitchDetected += HandleNewPitchDetected;
        _pitchTracker.SampleRate = SAMPLE_RATE;
        Bass.RecordInit();
        _streamId = Bass.RecordStart(SAMPLE_RATE, 1, BassFlags.Float | BassFlags.RecordPause, HandleRecordingData);
    }

    public void Execute()
    {
        UpdateDetection();
        TryUpdateCurrentPitch();
    }

    public void TearDown()
    {
        Bass.RecordFree();
    }

    #endregion

    private void UpdateDetection()
    {
        if (_gameContext.shouldDetectPitch)
        {
            if (!_isRecording)
            {
                StartDetection();
            }
        }
        else if (_isRecording)
        {
            StopDetection();
        }
    }

    private void TryUpdateCurrentPitch()
    {
        if (_isRecording)
        {
            var pitch = AverageOfNonZeroPitches();

            Debug.Log("Pitch is " + pitch + " time " + Time.time);
            _detectedPitches.Push(pitch);
            _pitchesThisUpdate.Clear();
            _gameContext.ReplaceCurrentPitch(pitch);
        }
    }

    private void StartDetection()
    {
        Bass.ChannelPlay(_streamId);
        _isRecording = true;
    }

    private void StopDetection()
    {
        Bass.ChannelPause(_streamId);
        _isRecording = false;
        _pitchesThisUpdate.Clear();
        _detectedPitches.Clear();
    }

    // TODO: Average over time ???
    private float AverageOfNonZeroPitches()
    {
        var sum = 0f;
        int validPitches = 0;
        for (int i = 0; i < _pitchesThisUpdate.Count; i++)
        {
            if (_pitchesThisUpdate[i] > 1)
            {
                sum += _pitchesThisUpdate[i];
                validPitches++;
            }
        }
        if (validPitches > 0 && validPitches >= _pitchesThisUpdate.Count * 1f / 3f)
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
}
