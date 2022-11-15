using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // enum for state management
    public enum GameStates
    {
        InitialCalls,
        DeterminePatching,
        ListenIn,
        DeterminePostConvo,
        PostConvo,
    }

    // tracking current state
    public GameStates currentState;
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = GameStates.InitialCalls;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
