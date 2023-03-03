using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : PlayerBehaviour
{
    public TMP_Text healthText;
    public GameObject interact;
    void Update()
    {
        healthText.text = player.status.health.ToString();
    }

    public void ShowIinteract()
    {
        interact.SetActive(true);
    }
    public void Stop_ShowInteract()
    {
        interact.SetActive(false);
    }
}
