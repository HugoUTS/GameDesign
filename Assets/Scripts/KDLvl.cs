using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KDButton : MonoBehaviour
{
    public void LoadScene() 
    {
        SceneManager.LoadScene("KDScene");
    }
}
