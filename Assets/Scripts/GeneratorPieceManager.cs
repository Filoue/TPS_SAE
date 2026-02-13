using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Animations.Rigging;

public class GeneratorPieceManager : MonoBehaviour
{
    [SerializeField] private List<GeneratorPiece> _generatorPieces;
    
    public int picesCount => _generatorPieces.Count;
    public Items items;
    
    void Start()
    {
        //_generatorPieces = GetComponentInChildren<GeneratorPiece>().ToList();
        items.item = 0;
        foreach (GeneratorPiece piece in _generatorPieces)
        {
            piece.OnPiecePicked+= RemovePiece;
        }
    }


    void RemovePiece(GeneratorPiece piece)
    {
        _generatorPieces.Remove(piece);
        items.item++;
    }
}
