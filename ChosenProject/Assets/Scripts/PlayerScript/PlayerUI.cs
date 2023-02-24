using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : PlayerBehaviour
{
    public TMP_Text healthText;
    void Update()
    {
        healthText.text = player.status.health.ToString();
    }
}
