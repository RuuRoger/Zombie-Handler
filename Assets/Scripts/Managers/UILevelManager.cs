using Player;
using System;
using UnityEngine;

public class UILevelManager : MonoBehaviour
{
    public static event Action<int> OnActivePlayerObject; // From PlayerController to PlayerObjectUI
    public static event Action OnHandlerSelectedPlayer;

    private void SetActiveObjectPlayerUI(int value) => OnActivePlayerObject?.Invoke(value);
    private void HandlerSelectedPlayer() => OnHandlerSelectedPlayer?.Invoke();

    private void OnEnable()
    {
        PlayerController.OnShowPlayerObject += SetActiveObjectPlayerUI;
        PlayerController.OnSelectedPlayer += HandlerSelectedPlayer;
    }

    private void OnDisable()
    {
        
    }
}
