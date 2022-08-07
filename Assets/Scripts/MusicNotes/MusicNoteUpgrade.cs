using System;
using UnityEngine;

public class MusicNoteUpgrade : MonoBehaviour
{
    #region Variables

    public int upgradeLevel = 0;
    
    #endregion

    #region Unity Methods

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mix") || other.gameObject.CompareTag("Master"))
        {
            UpgradeNote();
        }
    }

    #endregion

    private void UpgradeNote()
    {
        if (upgradeLevel == 0) ChangeColor();
        else if (upgradeLevel == 1) AddDissolveEffect();
    }

    private void ChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        upgradeLevel += 1;
    }

    private void AddDissolveEffect()
    {
        gameObject.GetComponent<Renderer>().material.shader = GameObject.Find("DissolveEffect").GetComponent<Renderer>().material.shader;
        upgradeLevel += 1;
    }
}
