using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationChecker : MonoBehaviour
{
    [SerializeField] private Palette _palette;
    [SerializeField] private List<AnimalCombination> _animalCombinations;

    private delegate void ChoosedAction(AnimalCombination animalCombination);

    public void AddCombination(List<Paint> paints)
    {
        CheckCombination(paints, Spawn);
    }

    public void RemoveCombination(List<Paint> paints)
    {
        CheckCombination(paints, Despawn);
    }

    private void Spawn(AnimalCombination animalCombination)
    {
        animalCombination.SpawnAnimal(_palette);
    }

    private void Despawn(AnimalCombination animalCombination)
    {
        animalCombination.DespawnAnimal();
    }

    private void CheckCombination(List<Paint> paints, ChoosedAction action)
    {
        foreach(AnimalCombination animalCombination in _animalCombinations)
            if(animalCombination.CheckCombination(paints))
                action?.Invoke(animalCombination);
    }
}
