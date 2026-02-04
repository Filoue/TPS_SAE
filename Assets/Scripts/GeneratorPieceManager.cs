using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class GeneratorPieceManager : MonoBehaviour
{
    [SerializeField] private List<GeneratorPiece> _generatorPieces;
    
    public int picesCount => _generatorPieces.Count;
    public int MaxBoxes;

    void Start()
    {
        //_generatorPieces = GetComponentInChildren<GeneratorPiece>()

        foreach (GeneratorPiece piece in _generatorPieces)
        {
            piece.OnPiecePicked += RemovePiece;
        }
    }

    void RemovePiece(GeneratorPiece piece)
    {
        _generatorPieces.Remove(piece);
    }
}
