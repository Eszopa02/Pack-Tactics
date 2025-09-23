using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    public Camera mainCameraInScene1;
    public Camera mainCameraInScene2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

        void DisableCameraInScene(string sceneName)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                Camera targetCamera = Camera.main;

                if (targetCamera != null)
                {
                    targetCamera.enabled = false;
                }
            }
            else
            {

            }
        }
    }

    public void EnableCameraInScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            Camera targetCamera = Camera.main;

            if (targetCamera != null)
            {
                targetCamera.enabled = true;
            }
        }
    }
}
