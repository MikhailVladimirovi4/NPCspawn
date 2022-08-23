using System.Collections;
using UnityEngine;

public class NPCgenerator : MonoBehaviour
{
    [SerializeField] private int _numberNPC;
    [SerializeField] private Transform _respawn;
    [SerializeField] private Thief _npc;

    private Transform[] _spawnPointsTransform;
    private readonly int _delayTime = 2;
    private WaitForSeconds _spawnPause;

    private void Start()
    {
        _spawnPointsTransform = new Transform[_respawn.childCount];
        _spawnPause = new WaitForSeconds(_delayTime);

        for (int i = 0; i < _respawn.childCount; i++)
            _spawnPointsTransform[i] = _respawn.GetChild(i).transform;

        StartCoroutine(CreateNPC());
    }

    private IEnumerator CreateNPC()
    {
        for (int i = 0; i < _numberNPC; i++)
        {
            Instantiate(_npc, _spawnPointsTransform[i % _respawn.childCount].position, Quaternion.identity);

            yield return _spawnPause;
        }
    }
}
