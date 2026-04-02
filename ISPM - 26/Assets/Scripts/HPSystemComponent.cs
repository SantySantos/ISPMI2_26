using System;
using UnityEngine;
using UnityEngine.Serialization;


public class HPSystemComponent : MonoBehaviour, IDamageable
{
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
        
        HP = Mathf.Max(HP - Mathf.CeilToInt(damage), 0);
        Debug.Log(HP.ToString());

        if (HP <= 0)
        {
            OnDeath?.Invoke();
        }
        
        OnDamage?.Invoke(HP);
    }
    public void Initialize() => HP = maxHP;
}
