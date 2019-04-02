using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f; // is usually influenced by some character stats
    public float attackDelay = .6f;
    const float combatCooldown = 5;
    float lastAttackTime;

    private float attackCooldown = 0f;

    public bool InCombat { get; private set; }
    public event System.Action OnAttack;
    
    CharacterStats myStats;
    CharacterStats opponentStats;

    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (Time.time - lastAttackTime > combatCooldown) {
            InCombat = false;
        }
    }

    public void Attack(CharacterStats targetStats) {

        if (attackCooldown <= 0f) {
            opponentStats = targetStats;

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 1f / attackSpeed;

            InCombat = true;
            lastAttackTime = Time.time;
        }

    }

    public void Attackhit_AnimationEvent() {
        opponentStats.TakeDamage(myStats.damage.GetValue());
        if (opponentStats.currentHealth <= 0)
        {
            InCombat = false;
        }
    }
}
