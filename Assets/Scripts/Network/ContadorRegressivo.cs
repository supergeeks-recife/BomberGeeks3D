using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContadorRegressivo : MonoBehaviour
{
    public float countdownDuration = 10f;
    private float countdownTimer;

    public UnityEvent onCountdownFinished;

    private void Start()
    {
        StartCountdown();
    }

    private void Update()
    {
        countdownTimer -= Time.deltaTime;

        if (countdownTimer <= 0f)
        {
            // O tempo acabou
            Debug.Log("Contagem regressiva concluída!");

            // Dispara o UnityEvent quando o tempo terminar
            onCountdownFinished.Invoke();

            // Reinicie a contagem regressiva ou interrompa o processo, se necessário
            // StartCountdown();
            // StopCountdown();
        }
    }

    public void StartCountdown()
    {
        countdownTimer = countdownDuration;
    }

    public void StopCountdown()
    {
        countdownTimer = 0f;
    }
}
