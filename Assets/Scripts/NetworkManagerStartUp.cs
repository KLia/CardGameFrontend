using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Cards;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManagerStartUp : MonoBehaviour
{
    public GameEngineLoader GameManager;
    public CardCreator CardCreator;

    private static GameEngineLoader _gameManager;

	// Initialization
    public void Awake ()
    {
        _gameManager = Instantiate(GameManager);
    }

    public void StartNewGame()
    {
        _gameManager.LoadNewGameScene();
    }
}
