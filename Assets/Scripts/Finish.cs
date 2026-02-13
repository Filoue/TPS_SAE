using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Finish : MonoBehaviour
{
    [SerializeField] private Detector _detector;
    [SerializeField] private PlayerInputs _inputs;
    [SerializeField] private Generator _generator;
    [SerializeField] private PlayableDirector _director;

    private void Update()
    {
        if (_detector.Detected && _inputs._interact == 1 && _generator.BeActivated)
        {
            
        }
    }
}
