using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] int _lives;
    public int Lives { get; private set; }
    public static GameManager Instance { get; private set; }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
