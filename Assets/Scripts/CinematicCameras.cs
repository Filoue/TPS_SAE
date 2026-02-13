using System;
using System.Collections;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.UIElements;

public class CinematicCameras : MonoBehaviour
{
    [SerializeField] private CinemachineCamera PlayerCamera;
    [SerializeField] private CinemachineCamera[] CinematicCameraList;
    [SerializeField] private UIDocument _document;

    private void Start()
    {
        _document.enabled = false;
        StartCoroutine(StartCamera());
    }

    private IEnumerator StartCamera()
    {
        CinematicCameraList[0].Priority = 2;
        yield return new WaitForSeconds(4f);
        CinematicCameraList[0].Priority = 0;
        _document.enabled = true;
    }
}
