using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class Ending : MonoBehaviour
    {
        public void Won()
        {
            SceneManager.LoadScene(4);
        }

        public void Lose()
        {
            SceneManager.LoadScene(3);
        }
    }


