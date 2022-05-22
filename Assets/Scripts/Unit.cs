using System.Collections.Generic;
using AbilitySystem;
using BehaviourSystem.BehaviourPredicates;
using BehaviourSystem.Behaviours;
using BehaviourSystem.Entities;
using SO;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviour
{
    public float hp = 100;
    public float speed = 400;
    
    public readonly List<BaseBehaviour> behaviours = new();
    public readonly List<IBaseAbility> abilities = new();
    public readonly Components.ComponentsContainer components = new();
    
    public PlayerTag owner;
    
    public UnitsList allUnits;
    public PlayersUnitsLists playersUnits;
    public UnitsList alliedUnits => playersUnits.value[owner];

    public Rigidbody rb;
    
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        allUnits.Register(this);
        alliedUnits.Register(this);
    }
    
    public void OnDisable()
    {
        allUnits.Unregister(this);
        alliedUnits.Unregister(this);
    }
    
    // TODO: remove (debug util)
    #region debugUitls
    [ContextMenu("SetPushBehaviour")]
    public void SetPushBehaviour()
    {
        var behaviour = new MoveToTheNearest
        {
            Predicate = Always.Instance,
            Entities = EnemiesList.Instance
        };
        behaviours.Add(behaviour);
    }
    
    [ContextMenu("SetRadiusBehaviour")]
    public void SetRadiusBehaviour()
    {
        var behaviour = new MoveInRadiusWithTheNearest();
        var behaviourPredicate = new AlliesLess();
        behaviourPredicate.threshold = 1;
        behaviour.Predicate = behaviourPredicate;
        behaviour.Radius = 50;
        behaviour.Entities = AlliesList.Instance;
        behaviours.Add(behaviour);
    }
    
    [ContextMenu("SetFleeBehaviour")]
    public void SetFleeBehaviour()
    {
        var behaviour = new MoveAwayFromTheNearest
        {
            Predicate = Always.Instance,
            Entities = EnemiesList.Instance
        };
        behaviours.Add(behaviour);
    }
    
    public GameObject debugProjectile;
    [ContextMenu("SetThrowAbility")]
    public void SetThrowAbility()
    {
        var ability = new ThrowProjectileAbility
        {
            baseCooldown = 5,
            currentCooldown = 0,
            projectilePrefab = debugProjectile
        };
        abilities.Add(ability);
    }
    
    [ContextMenu("SetContactDamageAbility")]
    public void SetContactDamageAbility()
    {
        var ability = new ContactDamageAbility
        {
            baseCooldown = 5,
            currentCooldown = 0,
            damage = 10
        };
        abilities.Add(ability);
    }
    
    
    #endregion
}
