using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour, IUIGetInput
{
    private bool _pause = false;
    [SerializeField] private float _defaultTimeScale;
    private void Start()
    {
        Time.timeScale = _defaultTimeScale;
    }

    public void Pause()
    {
        if (_pause == false)
        {
            _pause = true;
            Time.timeScale = 0;
            return; 
        }
        if (_pause == true)
        {
            Time.timeScale = 1;
            _pause = false;
            return;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name,  LoadSceneMode.Single);
    }
}
