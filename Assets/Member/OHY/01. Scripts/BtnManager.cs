using UnityEngine;

namespace Member.OHY._01._Scripts
{
    public class BtnManager : MonoBehaviour
    {
        [SerializeField] private SettingManager settingManager;

        public void ContinueGame()
        {
            settingManager.ResumeGame();
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