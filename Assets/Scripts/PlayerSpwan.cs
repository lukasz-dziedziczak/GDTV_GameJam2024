using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpwan : MonoBehaviour
{
    public static PlayerSpwan Instance;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Player player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);

        if (player == null) player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        //ResetToGroundPosition();
    }


    private void ResetToGroundPosition()
    {
        Vector3 rayCastOrigin = new Vector3(transform.position.x, 500, transform.position.z);
        Vector3 rayCastDirection = new Vector3(0, -1, 0);
        float rayCastLenght = 1000f;
        Debug.DrawRay(rayCastOrigin, rayCastDirection * rayCastLenght, Color.yellow, 10f);
        if (Physics.Raycast(rayCastOrigin, rayCastDirection, out RaycastHit hit, rayCastLenght, groundLayer))
        {
            transform.position = hit.point;
        }
        else Debug.LogError("SpawnPoint raycast miss");
    }

    public static void ResetPlayerPosition()
    {
        Instance.player.transform.position = Instance.transform.position;
        Instance.player.transform.rotation = Instance.transform.rotation;
    }
}
