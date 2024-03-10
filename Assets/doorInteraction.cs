using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorInteraction : MonoBehaviour
{
    public GameObject player;
    public string messageToShow;
    public float messageDisplayDistance = 1f;
    private bool playerInRange = false;
    private bool showMessageFully = false;
    private Player playerMovementScript;

    private void Start()
    {
        playerMovementScript = player.GetComponent<Player>();
    }
    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= 2f)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
}

    private void OnGUI()
    {
        if (playerInRange)
        {
            playerMovementScript.enabled = false;

            GUIStyle style = GUI.skin.box;
            style.wordWrap = true;
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 100), messageToShow);

            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 30), "Entrar"))
            {
         
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

                SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
            }


        }

    }

}