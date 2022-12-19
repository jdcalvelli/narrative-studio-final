using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchCordView : MonoBehaviour
{

    [SerializeField] private Vector3 cordStartPos;
    
    private LineRenderer _lr;
    
    private void Start()
    {
        _lr = gameObject.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _lr.SetPosition(0, cordStartPos);
        _lr.SetPosition(1, new Vector3(
            gameObject.transform.position.x, 
            gameObject.transform.position.y - 0.1f,
            gameObject.transform.position.z));
    }
}
