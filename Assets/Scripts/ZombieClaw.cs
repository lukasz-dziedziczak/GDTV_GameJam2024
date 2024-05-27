using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieClaw : MonoBehaviour
{
    [SerializeField] float damge = 10f;
    [SerializeField] List<Health> damged = new List<Health>();
    [SerializeField] Collider _collider;

    private void Start()
    {
        Active(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player) && !damged.Contains(player.Health))
        {
            player.Health.ApplyDamage(damge);
            damged.Add(player.Health);
        }
    }

    public void Active(bool isActive)
    {
        _collider.enabled = isActive;
        if (!isActive) damged.Clear();
    }

}
