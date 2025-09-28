using UnityEngine;

public class TeleportOnTouch : MonoBehaviour
{
    public Transform teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && teleportTarget != null)
        {
            // Disable player movement script if it exists
            PlayerMovement movement = other.GetComponent<PlayerMovement>();
            if (movement != null) movement.enabled = false;

            // Handle CharacterController safely
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;

            // Teleport
            other.transform.position = teleportTarget.position;
            other.transform.rotation = teleportTarget.rotation;

            if (cc != null) cc.enabled = true;
            if (movement != null) movement.enabled = true;

            Debug.Log("Teleported player to " + teleportTarget.position);
        }
    }
}