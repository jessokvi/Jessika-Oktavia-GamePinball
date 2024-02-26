using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{
    public Collider bola;
    public GameObject GameOverCanvas;

    private void OnTriggerEnter(Collider other) 
    {
        if (other == bola)
        {
            GameOverCanvas.SetActive(true);
        }
    }
}
