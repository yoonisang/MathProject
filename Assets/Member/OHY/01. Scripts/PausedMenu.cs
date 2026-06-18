using UnityEngine;
using UnityEngine.UI;

namespace Member.OHY._01._Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject settingsPanel;

        private bool _isOpen = false;

        private void Start()
        {
            settingsPanel.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleSettings();
            }
        }

        private void ToggleSettings()
        {
            _isOpen = !_isOpen;

            settingsPanel.SetActive(_isOpen);

            if (_isOpen)
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
    }
}