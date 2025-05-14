using UnityEngine;

public class MakeLevel : MonoBehaviour
{

    [SerializeField] private GameObject[] _prefabGrass;
    [SerializeField] private GameObject _player;

    [SerializeField] private float _firstRowPosition;
    [SerializeField] private float _firstColumnPosition;
    [SerializeField] private float _lastRowPosition;
    [SerializeField] private float _lastColumnPosition;

    private int _randomColumnPlayer;

    //Put the player in the firt column in random mode and create all the level
    //Also, is not possible make a cell with diferrent tag (Accesible)
    private void MakeGrassLevel()
    {
        _player.transform.position = new Vector3(-4.5f, _randomColumnPlayer + 0.5f, 0f);
        Vector3 playerPosition = _player.transform.position;

        for (float i = _firstRowPosition; i < _lastRowPosition; i++)
        {
            for (float j = _firstColumnPosition; j > _lastColumnPosition; j--)
            {
                int randomObject = Random.Range(0, _prefabGrass.Length);
                Vector3 _newPlace = new Vector3(i, j, 0f);
                bool isAccesibleForPlayer =
                    _newPlace == playerPosition ||
                    _newPlace == playerPosition + Vector3.up ||
                    _newPlace == playerPosition + Vector3.right ||
                    _newPlace == playerPosition + Vector3.down;

                // Si el objeto coincide con la posición del jugador
                if (isAccesibleForPlayer)
                {
                    Debug.Log($"El objeto {_prefabGrass[randomObject].name} en la posición x:{i}, y:{j}, coincide con el jugador");
                    //for (int objectAccessible = 0; objectAccessible < _prefabGrass.Length; objectAccessible++)
                    //{
                        //if (_prefabGrass[randomObject].tag == "Accesible")
                        //    break;
                        while (_prefabGrass[randomObject].tag != "Accessible")
                        {
                            randomObject = Random.Range(0, _prefabGrass.Length);
                        }
                    //}
                }
                else
                    randomObject = Random.Range(0, _prefabGrass.Length);

                Instantiate(_prefabGrass[randomObject], _newPlace, Quaternion.identity);
            }
        }
    }

    private void Awake()
    {
        _randomColumnPlayer = Random.Range(-5, 5);
    }

    private void Start() => MakeGrassLevel();

}
