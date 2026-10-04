using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [TextArea(2, 5)]
    public string dialogue = "Hola, viajero.";

    public float dialogueDistance = 3f;

    private Transform player;
    private bool playerNearby;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        playerNearby = distance <= dialogueDistance;
    }

    void OnGUI()
    {
        if (!playerNearby)
            return;

        GUIStyle style = new GUIStyle(GUI.skin.box);
        style.fontSize = 24;
        style.alignment = TextAnchor.MiddleCenter;
        style.wordWrap = true;

        float width = 500;
        float height = 100;

        Rect dialogueBox = new Rect(
            (Screen.width - width) / 2,
            Screen.height - 150,
            width,
            height
        );

        GUI.Box(dialogueBox, dialogue, style);
    }
}