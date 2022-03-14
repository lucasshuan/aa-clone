using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgainButton : MonoBehaviour
{
    public void TryAgain()
    {
        LevelController.Instance.ReloadScene();
    }
}