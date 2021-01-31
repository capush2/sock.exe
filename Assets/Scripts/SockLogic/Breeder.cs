using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Breeder : MonoBehaviour
{
    private Sock _male;
    private Sock _female;
    private List<Sock> _kids = new List<Sock>();
    private bool isBreeding = false;
    private bool isIncubating = false;
    private int timeToNextBreed = 0;
    private int timeToBirth = 0;
    private SockInventory inventory; //aller chercher le inventory et le mettre ici
    public Sock Male
    {
        get => _male;
        set
        {
            if (value.isMale && value.isOfAge)
            { //TODO mettre la verif dans le manager
                _male = value;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public Sock Female
    {
        get => _female;
        set
        {
            if (!value.isMale && value.isOfAge)
            {
                _female = value;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    void Start()
    {
        StartCoroutine(UpdateBreeding());
    }

    IEnumerator UpdateBreeding()
    {
        while(true)
        {
            if (isBreeding == false && isIncubating == false)
                checkBreeding();
            else
                tickDown();
            yield return new WaitForSecondsRealtime(1);
        }
    }

    void Update()
    {
        
    }

    private void checkBreeding()
    {
        if (_male != null && _female != null)
        {
            timeToNextBreed = Random.Range(MIN_BREED_TIME, MAX_BREED_TIME); //TODO ajouter promiscuité/sex appeal peut etre et definir les trucs
            isBreeding = true;
        }
    }
    private void breed()
    {
        isBreeding = false;
        int numberOfChilds = Mathf.Max(Mathf.RoundToInt((_male.fertility + _female.fertility) / 2 + Random.Range(-1.25f, 1.25f)),1); //TODO verifier le random et sortir le chiffre
        for (int i = 0; i < numberOfChilds; i++)
        {
            _kids.Add(new Sock(_male, _female));
        }
        timeToBirth = INCUBATION_TIME; //TODO definir le truc et peut etre randomize un peu
        isIncubating = true;
    }

    private void birth()
    {
        isIncubating = false;
        foreach (Sock sock in _kids)
        {
            inventory.add(sock);
        }
        _kids.Clear();
    }

    private void tickDown()
    {
        if (isBreeding)
        {
            timeToNextBreed--;
            if (timeToNextBreed == 0)
            {
                breed();
                return;
            }
        }
        else if (isIncubating)
        {
            timeToBirth--;
            if (timeToBirth == 0)
            {
                birth();
                return;
            }
        }
    }
}