using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombinationChecker : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;
    [SerializeField] private AnimalSpawner _animalSpawner;
    [SerializeField] private List<AnimalData> _animalsData;

    private void Start()
    {
        _mediator.Subscribe<CombinationIsAssembledCommand>(CheckCombination);
    }

    private void CheckCombination(CombinationIsAssembledCommand callback)
    {
        foreach(AnimalData animalData in _animalsData)
            if(animalData.AnimalCombination.CheckCombination(callback.Paints))
                _animalSpawner.SendAnimalCommand(animalData, callback.AddCombination);
    }
}

[Serializable]
public class AnimalData
{
    [SerializeField] private string _name;
    [SerializeField] private AnimalCombination _animalCombination;
    [SerializeField] private GameObject _animalPrefab;
    [SerializeField] private Animator _animator;
    private List<Animal> _existingAnimals = new List<Animal>();

    public string Name => _name;

    public AnimalCombination AnimalCombination => _animalCombination;

    public GameObject AnimalPrefab => _animalPrefab;

    public Animator Animator => _animator;

    public List<Animal> ExistingAnimals => _existingAnimals;

    public void AddAnimal(Animal animal) 
    {
        _existingAnimals.Add(animal);
    }

    public void RemoveAnimal(Animal animal)
    {
        _existingAnimals.Remove(animal);
        animal.Despawn();
    }
}
