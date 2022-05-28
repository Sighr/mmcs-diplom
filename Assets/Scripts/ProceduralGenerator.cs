using System.Collections.Generic;
using AbilitySystem;
using BehaviourSystem.BehaviourPredicates;
using BehaviourSystem.Behaviours;
using BehaviourSystem.Entities;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    // variants that can be selected for procedural generation
    private readonly List<IBehaviourPredicate> _predicateVariants = new()
    {
        Always.Instance,
        new AlliesLess(),
        new EnemiesLess(),
        new HpLow()
    };
    private readonly List<IBaseEntitiesList> _entityVariants = new()
    {
        AlliesList.Instance,
        EnemiesList.Instance,
        RocksList.Instance,
        PeaksList.Instance
    };
    private readonly List<BaseBehaviour> _behaviourVariants = new()
    {
        MoveForward.Instance,
        MoveBackward.Instance,
        new MoveToTheNearest(),
        new MoveAwayFromTheNearest(),
        new MoveInRadiusWithTheNearest()
    };
    private readonly List<IBaseAbility> _abilityVariants = new()
    {
        new ThrowProjectileAbility(),
        new ContactDamageAbility()
    };
    
    // generated variants to be used
    public readonly List<BaseBehaviour> generatedBehaviours = new();
    public readonly List<IBehaviourPredicate> generatedPredicates = new();
    public readonly List<IBaseAbility> generatedAbilities = new();
    
    // amounts to generate
    public int behaviourCount = 10;
    public int predicatesCount = 10;
    public int abilityCount = 5;

    public List<GameObject> projectilePrefabs;

    /**
     * Main function. Regenerates behaviours, predicates and abilities based on the variants.
     * Results should be accessed through generated* lists.
     */
    public void Generate()
    {
        GenerateBehaviours();
        GeneratePredicates();
        GenerateAbilities();
    }

    private void GenerateBehaviours()
    {
        generatedBehaviours.Clear();
        for (int i = 0; i < behaviourCount; i++)
        {
            var behaviour = _behaviourVariants[Random.Range(0, _behaviourVariants.Count)];
            switch (behaviour)
            {
                case MoveBackward moveBackward:
                    generatedBehaviours.Add(moveBackward);
                    break;
                case MoveAwayFromTheNearest:
                {
                    var instance = new MoveAwayFromTheNearest();
                    instance.entities = _entityVariants[Random.Range(0, _entityVariants.Count)];
                    generatedBehaviours.Add(instance);
                }
                    break;
                case MoveForward moveForward:
                    generatedBehaviours.Add(moveForward);
                    break;
                case MoveInRadiusWithTheNearest:
                {
                    var instance = new MoveInRadiusWithTheNearest();
                    instance.entities = _entityVariants[Random.Range(0, _entityVariants.Count)];
                    instance.radius = Random.Range(20, 200);
                    generatedBehaviours.Add(instance);
                }
                    break;
                case MoveToTheNearest:
                {
                    var instance = new MoveToTheNearest();
                    instance.entities = _entityVariants[Random.Range(0, _entityVariants.Count)];
                    generatedBehaviours.Add(instance);
                }
                    break;
            }
        }
    }

    private void GeneratePredicates()
    {
        generatedPredicates.Clear();
        for (int i = 0; i < predicatesCount; i++)
        {
            var predicate = _predicateVariants[Random.Range(0, _predicateVariants.Count)];
            switch (predicate)
            {
                case AlliesLess:
                {
                    var instance = new AlliesLess();
                    var threshold = Random.Range(2, 5);
                    instance.threshold = threshold;
                    generatedPredicates.Add(instance);
                }
                    break;
                case Always always:
                    generatedPredicates.Add(always);
                    break;
                case EnemiesLess:
                {
                    var instance = new EnemiesLess();
                    var threshold = Random.Range(2, 5);
                    instance.threshold = threshold;
                    generatedPredicates.Add(instance);
                }
                    break;
                case HpLow:
                {
                    var instance = new HpLow();
                    var threshold = Random.Range(10, 80);
                    instance.threshold = threshold;
                    generatedPredicates.Add(instance);
                }
                    break;
            }
        }
    }

    private void GenerateAbilities()
    {
        generatedAbilities.Clear();
        for (int i = 0; i < abilityCount; i++)
        {
            var ability = _abilityVariants[Random.Range(0, _abilityVariants.Count)];
            switch (ability)
            {
                case ContactDamageAbility:
                {
                    var instance = new ContactDamageAbility();
                    instance.currentCooldown = 0;
                    instance.baseCooldown = Random.Range(2, 10);
                    instance.damage = Random.Range(2, 11);
                    generatedAbilities.Add(instance);
                }
                    break;
                case ThrowProjectileAbility:
                {
                    var instance = new ThrowProjectileAbility();
                    instance.currentCooldown = 0;
                    instance.baseCooldown = Random.Range(2, 10);
                    instance.projectilePrefab = projectilePrefabs[Random.Range(0, projectilePrefabs.Count)];
                    generatedAbilities.Add(instance);
                }
                    break;
            }
        }
    }
}