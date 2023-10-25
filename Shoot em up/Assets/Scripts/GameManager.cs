using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameState
{
    Playing,
    Paused
}
public class GameManager : MonoBehaviour
{
    public EGameState GameState;

    private void Start()
    {
        GameState = EGameState.Playing;
    }
}
