using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Lives { get; private set; }
    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinCollected;
    [SerializeField] int _lives;
    int _coinsCollected;

    public void AddCoin()
    {
        _coinsCollected++;
        OnCoinCollected?.Invoke(_coinsCollected);
    }

    void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            RestartGame();
        }
    }

    public void KillPlayer() {
        Lives--;
        OnLivesChanged?.Invoke(Lives);

        if (Lives <= 0) {
            RestartGame();
        }
    }
    private void RestartGame()
    {
        Lives = _lives;
        _coinsCollected = 0;
        OnCoinCollected?.Invoke(_coinsCollected);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
