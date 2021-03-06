﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = gameSession.GetHealth().ToString();
    }
}
