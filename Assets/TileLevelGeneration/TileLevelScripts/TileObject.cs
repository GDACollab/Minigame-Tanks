using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    private Transform _meshTransform;

    public Transform meshTransform
    {
        get { return _meshTransform; }
        private set { }
    }

    private void Awake()
    {
        _meshTransform = GetComponentInChildren<Transform>();
    }
}
