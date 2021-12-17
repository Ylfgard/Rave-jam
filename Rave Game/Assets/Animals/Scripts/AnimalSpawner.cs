using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;
    [SerializeField] private Palette _palette;
    [SerializeField] private FinishDayButton _finishDayButton;
    private List<AnimaNextDayCommand> _nextDayCommands = new List<AnimaNextDayCommand>();

    private void Start() 
    {
        _finishDayButton.Clicked.AddListener(ComplitingNextDayCommands);
        _nextDayCommands.Clear();
    }

    private void SpawnAnimal(AnimalData animalData)
    {
        if(animalData.ExistingAnimals.Count == 0)
            ShowAnimal();
        Animal animal = Instantiate(animalData.AnimalPrefab, Vector3.zero, Quaternion.identity).GetComponent<Animal>();
        animal.Init(_palette, _mediator);
        _finishDayButton.Clicked.AddListener(animal.EndDay);
        animalData.AddAnimal(animal);
    }

    public void SendAnimalCommand(AnimalData animalData, bool toSpawn)
    {
        AnimaNextDayCommand command = new AnimaNextDayCommand(animalData, toSpawn);
        AddCommand(command);
    }

    private void ComplitingNextDayCommands()
    {
        foreach(AnimaNextDayCommand nextDayCommand in _nextDayCommands)
        {
            if(nextDayCommand.ToSpawn) SpawnAnimal(nextDayCommand.AnimalData);
            else DespawnAnimal(nextDayCommand.AnimalData);
        }
        _nextDayCommands.Clear();
    }

    private void AddCommand(AnimaNextDayCommand command)
    {
        foreach(AnimaNextDayCommand nextDayCommand in _nextDayCommands)
        {
            if(nextDayCommand.AnimalData == command.AnimalData && nextDayCommand.ToSpawn != command.ToSpawn)
            {
                _nextDayCommands.Remove(nextDayCommand);
                Debug.Log("Remove animal command");
                return;
            }
        }
        _nextDayCommands.Add(command);
        Debug.Log("Add animal");
    }

    private void DespawnAnimal(AnimalData animalData)
    {
        if(animalData.ExistingAnimals.Count == 0)
        {
            Debug.LogError("Try delete not existing animal!");
            return;
        }
        else
        {
            _finishDayButton.Clicked.RemoveListener(animalData.ExistingAnimals[0].EndDay);
            animalData.RemoveAnimal(animalData.ExistingAnimals[0]);
            if(animalData.ExistingAnimals.Count == 0)
                HideAnimal();
        }
    }

    private void ShowAnimal()
    {
        Debug.Log("ShowAnimal");
    }

    private void HideAnimal()
    {
        Debug.Log("HideAnimal");
    }
}

public class AnimaNextDayCommand
{
    private AnimalData _animalData;
    private bool _toSpawn;

    public AnimalData AnimalData => _animalData;

    public bool ToSpawn => _toSpawn;

    public AnimaNextDayCommand(AnimalData animalData, bool toSpawn)
    {
        _animalData = animalData;
        _toSpawn = toSpawn;
    }
}
