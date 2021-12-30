using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    private Transform _meshTransform;

    private MeshRenderer _meshRenderer;

    public Transform meshTransform
    {
        get { return _meshTransform; }
        private set { }
    }

    private void Awake()
    {
        _meshTransform = GetComponent<Transform>();

        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
}
