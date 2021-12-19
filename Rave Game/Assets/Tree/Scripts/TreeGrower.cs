using System;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TreeGrower : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;
    [SerializeField] private EventReference _groweSound;
    [SerializeField] private FMODUnity.StudioEventEmitter _emitter;
    [SerializeField] private Essence _essence;
    [SerializeField] private List<TreeLevelStage> _levelStages;
    private List<GameObject> _growedBranches = new List<GameObject>();
    private int _curStageIndex;
    private bool _growed;
    private TreeLevelStagesCompleteCommand _completeCommand = new TreeLevelStagesCompleteCommand();

    public Essence Essence => _essence;

    private void Start() 
    {
        _mediator.Subscribe<GetEssenceCommand>(GetEssence);
        foreach(TreeLevelStage levelStage in _levelStages)
            foreach(GameObject branch in levelStage.Branches)
                if(levelStage != _levelStages[0])
                {
                    branch.SetActive(false);
                }
                else
                {
                    branch.SetActive(true);
                    _growedBranches.Add(branch);
                }
        _curStageIndex = 0;
        _growed = false;
    }

    private void GetEssence(GetEssenceCommand callback)
    {
        if(_growed == false)
        {
            _essence.AddCount(callback.Count);
            if(_essence.Count >= _levelStages[_curStageIndex].EssenceNeed)
                ShowNextStage();
        }
    }

    private void ShowNextStage()
    {
        _curStageIndex++;
        if(_curStageIndex >= _levelStages.Count)
        {
            _mediator.Publish(_completeCommand);
            _growed = true;
        }
        else
        {
            RuntimeManager.PlayOneShot(_groweSound);
            _emitter.SetParameter("Progress", _levelStages[_curStageIndex].FMODParametr);
            foreach(GameObject branch in _levelStages[_curStageIndex].Branches)
            {
                _growedBranches.Add(branch);
                branch.SetActive(true);
            }
        }
    }
}

[Serializable]
public class TreeLevelStage 
{
    [SerializeField] private int _nextStageEssenceNeed;
    [SerializeField] private int _fmodParametr;
    [SerializeField] private List<GameObject> _branches;

    public int EssenceNeed => _nextStageEssenceNeed;

    public int FMODParametr => _fmodParametr;
    
    public List<GameObject> Branches => _branches;
}
