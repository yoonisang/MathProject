using UnityEngine;

namespace Member.OHY._01._Scripts
{
    public class SettingManager : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject pausedPanel;

        private bool isPaused = false;

        private void Start()
        {
            pausedPanel.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        public void TogglePause()
        {
            isPaused = !isPaused;

            pausedPanel.SetActive(isPaused);

            if (isPaused)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        public void ResumeGame()
        {
            isPaused = false;

            pausedPanel.SetActive(false);
            Time.timeScale = 1f;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}