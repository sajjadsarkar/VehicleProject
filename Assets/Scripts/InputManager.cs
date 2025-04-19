using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameManager gameManager;
    public Horn hornController;
    private AudioSource hornAudio;

    private void Start()
    {
        if (hornController != null)
        {
            hornAudio = hornController.audioSource;
        }
    }

    private void Update()
    {
        // Toggle engine on/off with 'E' key
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameManager.StartStop();
        }

        // Toggle lights with 'L' key
        if (Input.GetKeyDown(KeyCode.L))
        {
            gameManager.LightOnOff();
        }

        // Horn with 'H' key
        if (Input.GetKey(KeyCode.H) && hornController != null)
        {
            hornController.horn();
        }
    }
}