using UnityEngine;

[RequireComponent(typeof(Detector))]
public class Generator : MonoBehaviour
{
    [SerializeField] private Detector _detector;
    [SerializeField] private GeneratorPieceManager _generatorPieceManager;
    
    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private PlayerInputs _inputs;
    [SerializeField] private Animator _animator;
    public bool BeActivated = false;


    // Update is called once per frame
    void Update()
    {
        if (_generatorPieceManager.picesCount < 1 && _inputs._interact == 1 && _detector.Detected)
        {
            Debug.Log("Generator Activated");
            BeActivated = true;
            _audioSource.Play();
        }
    }
}
