using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombinationChecker : MonoBehaviour
{
    [SerializeField] private AnimalSpawner _animalSpawner;
    [SerializeField] private List<AnimalData> _animalsData;
    
    private delegate void ChoosedAction(AnimalData animalCombination);

    public void AddCombination(List<Paint> paints)
    {
        CheckCombination(paints, Spawn);
    }

    public void RemoveCombination(List<Paint> paints)
    {
        CheckCombination(paints, Despawn);
    }

    private void Spawn(AnimalData animalData)
    {
        _animalSpawner.SpawnAnimal(animalData);
    }

    private void Despawn(AnimalData animalData)
    {
        _animalSpawner.DespawnAnimal(animalData);
    }

    private void CheckCombination(List<Paint> paints, ChoosedAction action)
    {
        foreach(AnimalData animalData in _animalsData)
            if(animalData.AnimalCombination.CheckCombination(paints))
                action?.Invoke(animalData);
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
