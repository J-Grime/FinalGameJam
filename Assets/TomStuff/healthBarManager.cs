using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarManager : MonoBehaviour {

    public RectTransform healthBar;
    GameObject attachedTo;
    health objHealth;

    private void Start()
    {
        attachedTo = gameObject;
        objHealth = attachedTo.GetComponent<health>();
    }

    // Update is called once per frame
    void Update () {
        healthBar.localScale = new Vector3(healthPercentage(objHealth.hitPoints, objHealth.maxHealth), 1.0f, 1.0f);
    }

    float healthPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

}
