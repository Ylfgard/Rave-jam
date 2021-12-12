using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimalBehavior", menuName = "Animal/Behavior", order = 0)]
public class AnimalBehavior : ScriptableObject
{
    [SerializeField] private Paint _paint;
    [SerializeField] private bool _bringEssence;
    [SerializeField] private int _income;
    [SerializeField] private int _period;

    public Paint Paint => _paint;

    public bool BringEssence => _bringEssence;

    public int Income => _income;

    public int Period => _period;
}
