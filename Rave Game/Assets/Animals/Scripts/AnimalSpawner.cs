using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private Palette _palette;
    [SerializeField] private FinishDayButton _finishDayButton;
    public void SpawnAnimal(AnimalData animalData)
    {
        if(animalData.ExistingAnimals.Count == 0)
            ShowAnimal();
        Animal animal = Instantiate(animalData.AnimalPrefab, Vector3.zero, Quaternion.identity).GetComponent<Animal>();
        animal.Init(_palette);
        _finishDayButton.Clicked.AddListener(animal.EndDay);
        animalData.AddAnimal(animal);
    }

    public void DespawnAnimal(AnimalData animalData)
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
