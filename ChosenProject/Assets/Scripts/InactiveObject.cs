using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveObject : MonoBehaviour
{
    private float timeSinceLastActive;
    private void Update() {
        timeSinceLastActive+=Time.deltaTime;
        if (gameObject.activeInHierarchy && timeSinceLastActive > .1f){
            Disable();
        }
    }

    void Disable(){
        timeSinceLastActive=0f;
        gameObject.SetActive(false);
    }
}
