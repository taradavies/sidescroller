using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Lives { get; private set; }
    [SerializeField] int _lives;
    public event Action<int> OnLivesChanged;

    void Awake()
    {
        Lives = _lives;
        if (Instance != null) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void KillPlayer() {
        Lives--;
        OnLivesChanged?.Invoke(Lives);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
