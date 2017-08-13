using CardGame.Model.Engine;
using CardGame.Model.Engine.Interfaces;
using CardGame.Model.Players.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameEngineLoader : MonoBehaviour
    {
        private bool _isCreated;
        private IPlayer _currentPlayer;
        private IPlayer _currentOpponent;

        public void Awake()
        {
            if (!_isCreated)
            {
                _isCreated = true;
                DontDestroyOnLoad(this.gameObject);
               // InitializeNewGame(null, null, null);
            }
        }

        // Use this for game initialization
        public void InitializeNewGame(IPlayer player, IPlayer opponent, IGameState state)
        {
            GameEngine.Initialize(player, opponent, state);
        }

        //called by "Start New Game" button in Splash Screen Scene
        public void LoadNewGameScene()
        {
            SceneManager.LoadSceneAsync("CardGameScene1");
            InitializeNewGame(null, null, null);
        } 
    }
}