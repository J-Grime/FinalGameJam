using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthManager : health {

    // Update is called once per frame
    void Update () {
        if (hitPoints <= 0)
        {
            Debug.Log("Your ded");
        }
	}
    public void damage(float damage)
    {
        hitPoints -= damage;
    }


}
