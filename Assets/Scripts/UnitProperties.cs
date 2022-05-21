using System.Collections.Generic;
using AbilitySystem;
using BehaviourSystem.BehaviourPredicates;
using BehaviourSystem.Behaviours;
using BehaviourSystem.Entities;
using ColliderSystem;
using SO;
using UnityEngine;

[RequireComponent(typeof(CollisionsList))]
public class UnitProperties : MonoBehaviour
{
    public float hp = 100;
    public float speed = 400;
    
    public List<BaseBehaviour> behaviours;
    public List<IBaseAbility> abilities;
    public CollisionsList collisionsList;
    
    public PlayerTag owner;
    
    public UnitsList allUnits;
    public PlayersUnitsLists playersUnits;
    public UnitsList alliedUnits => playersUnits.value[owner];

    public void Start()
    {
        collisionsList = GetComponent<CollisionsList>();
        allUnits.Register(this);
        alliedUnits.Register(this);
        behaviours = new();
    }
    
    public void OnDisable()
    {
        allUnits.Unregister(this);
        alliedUnits.Unregister(this);
    }
    
    // TODO: remove (debug util)
    #region debugUitls
    [ContextMenu("SetPushBehaviours")]
    public void SetPushBehaviour()
    {
        var behaviour = new MoveToTheNearest();
        behaviour.Predicate = Always.Instance;
        behaviour.Entities = new EnemiesList();
        behaviours.Add(behaviour);
    }
    
    [ContextMenu("SetRadiusBehaviours")]
    public void SetRadiusBehaviour()
    {
        var behaviour = new MoveInRadiusWithTheNearest();
        behaviour.Predicate = Always.Instance;
        behaviour.Radius = 100;
        behaviour.Entities = new AlliesList();
        behaviours.Add(behaviour);
    }
    
    [ContextMenu("SetFleeBehaviours")]
    public void SetFleeBehaviour()
    {
        var behaviour = new MoveAwayFromTheNearest();
        behaviour.Predicate = new Always();
        behaviour.Entities = new EnemiesList();
        behaviours.Add(behaviour);
    }
    #endregion
}
