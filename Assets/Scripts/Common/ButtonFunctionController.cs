using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace JinGroup.Base.MenuController {
    public class ButtonFunctionController : MonoBehaviour
    {
        public GameObject PanelPause;
        public GameObject PanelSetting;
        public GameObject Music;
        public GameObject Sound;
        // Start is called before the first frame update
        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {

        }
        public void PauseGame()
        {
            Time.timeScale = 0;
            PanelPause.SetActive(true);
        }
        public void OpenSetting()
        {
            PanelSetting.SetActive(true);
        }
        public void CloseSetting()
        {
            PanelSetting.SetActive(false);
        }
        public void PlayMusic()
        {
            Music.SetActive(true);
        }
        public void OffMusic()
        {
            Music.SetActive(false);
        }
        public void PlaySound()
        {
            Sound.SetActive(true);
        }
        public void OffSound()
        {
            Sound.SetActive(false);
        }
        public void RestartGame()
        {
            PanelPause.SetActive(false);
            Time.timeScale = 1;
        }
        public void ResetLevelGame()
        {
            SceneManager.LoadScene(0);
            //bao nhieu level copy paste rồi đặt lại số sence muốn restarts
        }
        public void ReturnHome()
        {
            SceneManager.LoadScene(0);
        }

    }

}
