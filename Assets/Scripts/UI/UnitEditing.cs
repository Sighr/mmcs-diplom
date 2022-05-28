using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class UnitEditing : MonoBehaviour
    {
        public ProceduralGenerator proceduralGenerator;

        public GameObject abilityEntryUiPrefab;
        public GameObject behaviourEntryUiPrefab;
        public GameObject predicateEntryUiPrefab;
        public GameObject behaviourPredicatePairEntryPrefab;
        public GameObject scrollableUiPrefab;
        public GameObject abilitiesPanelContent;
        public GameObject behavioursPanelContent;
        public Unit selectedUnit;
        
        private GameObject _currentScrollable;
        
        private void Start()
        {
            proceduralGenerator.Generate();
        }
        
        public void GenerateUIForUnit()
        {
            GenerateBehavioursUI();
            GenerateAbilitiesUI();
        }
        
        private void GenerateBehavioursUI()
        {
            foreach (Transform child in behavioursPanelContent.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var behaviour in selectedUnit.behaviours)
            {
                var instance = Instantiate(behaviourPredicatePairEntryPrefab, behavioursPanelContent.transform);
                
                var behaviourEntry = instance.transform.GetChild(0).GetComponent<BehaviourEntry>();
                var predicateEntry = instance.transform.GetChild(1).GetComponent<PredicateEntry>();
                behaviourEntry.behaviour = behaviour;
                predicateEntry.predicate = behaviour.Predicate;
                behaviourEntry.button.onClick.AddListener(() => ExpandBehaviour(behaviourEntry, predicateEntry));
                predicateEntry.button.onClick.AddListener(() => ExpandPredicate(predicateEntry, behaviourEntry));
                
                behaviourEntry.text.text = behaviour.GetDescription();
                predicateEntry.text.text = behaviour.Predicate.GetDescription();
            }
        }
        
        private void GenerateAbilitiesUI()
        {
            foreach (Transform child in abilitiesPanelContent.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var ability in selectedUnit.abilities)
            {
                var instance = Instantiate(abilityEntryUiPrefab, abilitiesPanelContent.transform);
                var entry = instance.GetComponent<AbilityEntry>();
                entry.button.onClick.AddListener(() => ExpandAbility(entry));
                entry.text.text = ability.GetDescription();
            }
        }
        
        public void CreateEmptyAbilityEntry()
        {
            var instance = Instantiate(abilityEntryUiPrefab, abilitiesPanelContent.transform);
            var entry = instance.GetComponent<AbilityEntry>();
            entry.button.onClick.AddListener(() => ExpandAbility(entry));
        }
        
        public void CreateEmptyPairEntry()
        {
            var instance = Instantiate(behaviourPredicatePairEntryPrefab, behavioursPanelContent.transform);
            var behaviourEntry = instance.transform.GetChild(0).GetComponent<BehaviourEntry>();
            var predicateEntry = instance.transform.GetChild(1).GetComponent<PredicateEntry>();
            behaviourEntry.button.onClick.AddListener(() => ExpandBehaviour(behaviourEntry, predicateEntry));
            predicateEntry.button.onClick.AddListener(() => ExpandPredicate(predicateEntry, behaviourEntry));
        }
        
        
        // TODO: refactor Expand* into one templated function
        private void ExpandAbility(AbilityEntry entry)
        {
            if (_currentScrollable != null)
            {
                Destroy(_currentScrollable);
                _currentScrollable = null;
            }
            _currentScrollable = Instantiate(scrollableUiPrefab, entry.gameObject.transform);
            var scrollableContent = _currentScrollable.GetComponent<Scrollable>().content;
            // TODO: add filtering
            foreach (var ability in proceduralGenerator.generatedAbilities)
            {
                var instance = Instantiate(abilityEntryUiPrefab, scrollableContent.transform);
                var optionEntry = instance.GetComponent<AbilityEntry>();
                optionEntry.ability = ability;
                optionEntry.text.text = ability.GetDescription();
                optionEntry.button.onClick.AddListener(() =>
                {
                    if (entry.ability != null)
                    {
                        selectedUnit.abilities.Remove(entry.ability);
                    }
                    selectedUnit.abilities.Add(optionEntry.ability);

                    entry.ability = optionEntry.ability;
                    entry.text.text = optionEntry.text.text;
                    Destroy(_currentScrollable);
                });
            }
        }

        private void ExpandBehaviour(BehaviourEntry behaviourEntry, PredicateEntry predicateEntry)
        {
            if (_currentScrollable != null)
            {
                Destroy(_currentScrollable);
                _currentScrollable = null;
            }
            _currentScrollable = Instantiate(scrollableUiPrefab, behaviourEntry.gameObject.transform);
            var scrollableContent = _currentScrollable.GetComponent<Scrollable>().content;
            // TODO: add filtering
            foreach (var behaviour in proceduralGenerator.generatedBehaviours)
            {
                var instance = Instantiate(behaviourEntryUiPrefab, scrollableContent.transform);
                var optionEntry = instance.GetComponent<BehaviourEntry>();
                optionEntry.behaviour = behaviour;
                optionEntry.text.text = behaviour.GetDescription();
                optionEntry.button.onClick.AddListener(() =>
                {
                    // if predicate was already selected
                    if (predicateEntry.predicate != null)
                    {
                        // set up predicate
                        optionEntry.behaviour.Predicate = predicateEntry.predicate;
                        
                        // delete previous behaviour if any
                        if (behaviourEntry.behaviour != null)
                        {
                            selectedUnit.behaviours.Remove(behaviourEntry.behaviour);
                        }
                        // add new behaviour
                        selectedUnit.behaviours.Add(optionEntry.behaviour);
                    }

                    behaviourEntry.behaviour = optionEntry.behaviour;
                    behaviourEntry.text.text = optionEntry.text.text;
                    Destroy(_currentScrollable);
                });
            }
        }

        private void ExpandPredicate(PredicateEntry predicateEntry, BehaviourEntry behaviourEntry)
        {
            if (_currentScrollable != null)
            {
                Destroy(_currentScrollable);
                _currentScrollable = null;
            }
            _currentScrollable = Instantiate(scrollableUiPrefab, predicateEntry.gameObject.transform);
            var scrollableContent = _currentScrollable.GetComponent<Scrollable>().content;
            // TODO: add filtering
            foreach (var predicate in proceduralGenerator.generatedPredicates)
            {
                var instance = Instantiate(predicateEntryUiPrefab, scrollableContent.transform);
                var optionEntry = instance.GetComponent<PredicateEntry>();
                optionEntry.predicate = predicate;
                optionEntry.text.text = predicate.GetDescription();
                optionEntry.button.onClick.AddListener(() =>
                {
                    // if behaviour was already selected
                    if (behaviourEntry.behaviour != null)
                    {
                        // set up predicate
                        behaviourEntry.behaviour.Predicate = optionEntry.predicate;
                        
                        // add new behaviour if necessary
                        if (predicateEntry.predicate == null)
                        {
                            selectedUnit.behaviours.Add(behaviourEntry.behaviour);
                        }
                    }

                    predicateEntry.predicate = optionEntry.predicate;
                    predicateEntry.text.text = optionEntry.text.text;
                    Destroy(_currentScrollable);
                });
            }
        }
    }
}