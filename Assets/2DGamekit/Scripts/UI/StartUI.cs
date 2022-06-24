using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

//using UnityEditor.Events;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


namespace hgcxt
{
    public class StartUI : MonoBehaviour {
        public Button StartButton;
        public GameObject TransitionStart;

        private void Start()
        {
 
            print(StartButton.name);
            StartButton.onClick.AddListener(delegate () { SceneController.TransitionToScene(TransitionStart.GetComponent<TransitionPoint>()); });
            print(StartButton.onClick.GetPersistentEventCount());
            //StartButton.onClick.AddListener(SceneController.TransitionToScene(TransitionStart.GetComponent<TransitionPoint>()));
//            UnityEventTools.AddObjectPersistentListener<TransitionPoint>(StartButton.onClick, SceneController.TransitionToScene, TransitionStart.GetComponent< TransitionPoint>());

        }
        public void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
		Application.Quit();
    #endif
        }
    }
}
