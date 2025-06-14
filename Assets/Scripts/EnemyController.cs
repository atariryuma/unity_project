using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour
{
    public float Speed = 3f;
    public float DetectionRange = 20f;

    private Transform player;
    private CharacterController controller;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            if (player == null) return;
        }

        Vector3 direction = player.position - transform.position;
        if (direction.magnitude <= DetectionRange)
        {
            Vector3 move = direction.normalized * Speed;
            controller.SimpleMove(move);
            transform.LookAt(player);
        }
    }
}
