using System;
using UnityEngine;
using UnityEngine.Serialization;


public class HPSystem : MonoBehaviour
{
    [field: FormerlySerializedAs("Game Object HP")] [field: SerializeField]
    public int HP { get; private set; }

    [FormerlySerializedAs("Game Object Max HP")] [SerializeField]
    public int maxHP;

    public event Action OnDeath;
    private void Start()
    {
        HP = maxHP;
    }

    void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    void Heal(int heal) => HP = Mathf.Min(HP + heal, maxHP);
}
