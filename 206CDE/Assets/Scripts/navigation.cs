using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class navigation : MonoBehaviour
{
    public void gotomainmenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void gotocamera()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

   /* public void resetcamera()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/
}


