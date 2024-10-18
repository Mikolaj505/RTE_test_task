using UnityEngine;
using UnityEngine.SceneManagement;

namespace MKubiak.RTETestTask.GameStartup
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            SceneManager.LoadScene(1);
        }
    }
}