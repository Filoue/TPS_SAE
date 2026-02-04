using UnityEngine;
using System;

public class GeneratorPiece : MonoBehaviour
{
    public Action<GeneratorPiece> OnPiecePicked;

    [SerializeField] private PlayerInputs _inputs;
    [SerializeField] private Detector detector;
    [SerializeField] private GameObject _generatorPieces;
    
    void Start()
    {
        _generatorPieces = this.gameObject;
    }

    void Update()
    {
        if (detector.Detected && _inputs._interact == 1)
        {
            Debug.Log("GeneratorPiece");
            
            Destroy(gameObject);
        }
    }
}
