using System;
using mainGame;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    [SerializeField] public GameObject GameManager;
    private IUIGetInput _getInput;
    
    [SerializeField] public PlayerController _playerController;
    [SerializeField] private GameObject _gameOverElements;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private string _textBeforeScore;

    public UnityAction ButtonClick;

    private void Start()
    {
        _gameOverElements.SetActive(false);
        _getInput = GameManager.GetComponent<IUIGetInput>();
        if (_getInput == null) throw new Exception("GameManager doesnt have IUIGetInput");
    }

    private void OnEnable()
    {
        _playerController.GameOverUI += GameOver;
        _playerController.ShowScore += ShowScore;

    }
    private void OnDisable()
    {
        _playerController.GameOverUI -= GameOver;
        _playerController.ShowScore -= ShowScore;
    }

    private void GameOver()
    {
        _gameOverElements.SetActive(true);
    }

    void ShowScore(int scoreToShow)
    {
        _score.text = _textBeforeScore + scoreToShow.ToString();
    }

    #region Buttons
    
    public void RestartButtonClick()
    {
        ButtonClick?.Invoke();
        _getInput.Restart();
    }

    public void PauseButtonClick()
    {
        ButtonClick?.Invoke();
        _getInput.Pause();
    }

    #endregion

}
