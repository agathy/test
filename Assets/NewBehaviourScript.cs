using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace hgcxt
{
    public class NewBehaviourScript : MonoBehaviour
    {
        public CinemachineVirtualCamera cam;
        public GameObject cameraFollowGameObjectName;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void text()
        {
            SceneController.async.allowSceneActivation = true;
            print("a");
        }

        public void StartSpeaking()
        {
         
            EllenDialogue. IsAutomaticSpeaking = true;
            DialogueCanvasController.Instance.ActivateCanvasWithText("Ö÷½Ç");
            this.gameObject.SetActive(false);

        }

        public void ChangeCameraFollow()
        {
            cam.Follow = cameraFollowGameObjectName.transform;
        }
    }
}
