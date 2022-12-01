using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchCordController : MonoBehaviour
{

    private GameManager _gameManagerReference;
    
    private Camera _mainCam;
    private Vector3 _initialPosition;
    
    private bool _isColliding;
    private Collider2D _collidedHole;

    [SerializeField] private string cordValue;

    private void Start()
    {
        _gameManagerReference = FindObjectOfType<GameManager>();
        
        _mainCam = Camera.main;
        _initialPosition = gameObject.transform.position;
    }

    private void OnMouseDrag()
    {
        if (_gameManagerReference.currentState == GameManager.GameStates.DeterminePatching)
        {
            gameObject.transform.position = 
                _mainCam.ScreenToWorldPoint(
                    new Vector3(
                        Input.mousePosition.x, 
                        Input.mousePosition.y, 
                        _mainCam.WorldToScreenPoint(gameObject.transform.position).z));
        }
    }

    private void OnMouseUp()
    {
        if (_gameManagerReference.currentState == GameManager.GameStates.DeterminePatching)
        {
            if (_isColliding)
            {
                // snap into place
                gameObject.transform.position = new Vector3(
                    _collidedHole.transform.position.x,
                    _collidedHole.transform.position.y,
                    gameObject.transform.position.z);
            
                // pass info to game manager
                switch (cordValue)
                {
                    case "person":
                        _gameManagerReference.PatchResult["personPatched"] 
                            = _collidedHole.GetComponent<PatchHoleController>().patchHoleValue;
                        break;
                    
                    case "location":
                        _gameManagerReference.PatchResult["locationPatched"] 
                            = _collidedHole.GetComponent<PatchHoleController>().patchHoleValue;
                        break;
                }
            }
            else
            {
                gameObject.transform.position = _initialPosition;
            }
        }
    }

    // pass to gm
    private void OnTriggerEnter2D(Collider2D col)
    {
        _isColliding = true;
        _collidedHole = col;
        Debug.Log(_isColliding);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        _isColliding = false;
        _collidedHole = null;
        Debug.Log(_isColliding);
    }
}
