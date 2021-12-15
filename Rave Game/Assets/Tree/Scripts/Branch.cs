using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;
    [SerializeField] private List<Leaf> _leafs;

    private void Start() 
    {
        _mediator.Subscribe<LeafColorizedCommand>(CheckForCombination);
    }
    
    private void CheckForCombination(LeafColorizedCommand callback)
    {
        CombinationIsAssembledCommand command = new CombinationIsAssembledCommand();
        if(_leafs.Contains(callback.Leaf))
        {
            foreach(Leaf leaf in _leafs)
                if(leaf.Colorized)
                    command.Paints.Add(leaf.Paint);
            if(command.Paints.Count == _leafs.Count)
            {
                command.AddCombination = true;
                _mediator.Publish(command);
            } 
        }
    }

    public void UncolorizeLeafs()
    {
        foreach(Leaf leaf in _leafs)
            leaf.Uncolorize();
    }
}
