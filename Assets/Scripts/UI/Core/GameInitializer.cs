using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private void Start()
    {
        gameManager.StartNewOrLoadGame();
    }
}
