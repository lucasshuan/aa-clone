using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public void NextLevel(string sceneName)
    {
        LevelController.Instance.LoadScene(sceneName);
    }
}