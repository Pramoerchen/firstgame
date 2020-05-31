using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public int LadeLevel;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(LadeLevel);
    }
}
