using System;
using UnityEngine;
using UnityEngine.Serialization;


public class HPSystemComponent : MonoBehaviour, IDamageable
{
    [field: FormerlySerializedAs("Game Object HP")] [field: SerializeField]
    public int HP { get; private set; }

    [FormerlySerializedAs("Game Object Max HP")] [SerializeField]
    public int maxHP;

    public event Action OnDeath;
    
    public event Action<float> OnDamage;
    private void Start()
    {
        HP = maxHP;
    }

    void Heal(int heal) => HP = Mathf.Min(HP + heal, maxHP);
    public void TakeDamage(float damage)
    {
        if(HP <= 0) return;
        
        HP = Mathf.Max(HP - Mathf.FloorToInt(damage), 0);

        if (HP <= 0)
        {
            OnDeath?.Invoke();
        }
        
        OnDamage?.Invoke(damage);
    }
}
