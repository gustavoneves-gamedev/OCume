using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header(" Cowboy Level")]
    [SerializeField] private GameObject[] cowboyLevelPrefabsA;
    [SerializeField] private GameObject[] cowboyLevelPrefabsB;
    [SerializeField] private GameObject[] cowboyLevelPrefabsC;
    [SerializeField] private GameObject[] cowboyLevelPrefabsD;

    //OS TESTES SERÃO FEITOS NO LEVEL DO COWBOY E POSTERIORMENTE IREI APLICAR AOS DEMAIS (CASO DEEM CERTO NÉ)
    [Header(" Samurai Level")]
    [SerializeField] private GameObject[] samuraiLevelPrefabs;

    [Header(" Alpinista Level")]
    [SerializeField] private GameObject[] alpinistaLevelPrefabs;

    [Header("Config")]
    [SerializeField] private Transform startSpawn;
    [SerializeField] private GameObject[] currentLevelPrefabs; //Tornar private após testes
    [SerializeField] private levelID currentLevelID;
    [SerializeField] private GameObject checkpointPrefab; //Prefab dos checkpoints
    private GameObject activeCheckpoint;
    private bool hasChangedCheckpoint;//Essa bool detecta se houve troca de zona ou não
    private GameObject currentPrefab;
    private GameObject lastPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.gameController.levelManager = this;
                
        //InitializeLevel(GameController.gameController.currentLevelID);

        InitializeLevel(levelID.CowboyLevel, 100f);
    }

    public void InitializeLevel(levelID levelID, float checkpointDistance)
    {
        
        Destroy(currentPrefab);
        Destroy(lastPrefab);
        Destroy(activeCheckpoint);

        currentLevelID = levelID;

        if (currentLevelID == levelID.CowboyLevel)
        {
            currentLevelPrefabs = cowboyLevelPrefabsA;
        }
        else if (currentLevelID == levelID.SamuraiLevel)
        {
            currentLevelPrefabs = samuraiLevelPrefabs;
        }
        else if (currentLevelID == levelID.AlpinistaLevel)
        {
            currentLevelPrefabs = alpinistaLevelPrefabs;
        }


        currentPrefab = Instantiate(currentLevelPrefabs[0], startSpawn.position, startSpawn.rotation);

        //activeCheckpoint = Instantiate(checkpointPrefab, 
        //    startSpawn.position + Vector3.forward * checkpointDistance, startSpawn.rotation);

    }

    public void SpawnLevelPrefab()
    {
        //Os Ifs abaixo servem para verificar se deve spawnar o primeiro prefab de cada segmento ou não!!
        if (hasChangedCheckpoint)
        {
            GameObject newLevelPrefab = Instantiate(currentLevelPrefabs[0],
            currentPrefab.GetComponent<LevelRoot>().levelPrefabSpawnPoint.position, startSpawn.rotation);

            lastPrefab = currentPrefab;
            currentPrefab = newLevelPrefab;

            hasChangedCheckpoint = false;
        }
        else
        {
            GameObject newLevelPrefab = Instantiate(currentLevelPrefabs[Random.Range(1, currentLevelPrefabs.Length)],
            currentPrefab.GetComponent<LevelRoot>().levelPrefabSpawnPoint.position, startSpawn.rotation);

            lastPrefab = currentPrefab;
            currentPrefab = newLevelPrefab;
        }
    }

    public void UpdateLevelPrefabCheckpoint(int checkpoint)
    {
        //Essa bool detecta se houve troca de zona ou não para determinar qual será o próximo prefab        
        hasChangedCheckpoint = true;

        if (currentLevelID == levelID.CowboyLevel)
        {
            //currentLevelPrefabs = cowboyLevelPrefabsA;
            CowboyCheckpointUpdate(checkpoint);
        }
        else if (currentLevelID == levelID.SamuraiLevel)
        {
            currentLevelPrefabs = samuraiLevelPrefabs;
        }
        else if (currentLevelID == levelID.AlpinistaLevel)
        {
            currentLevelPrefabs = alpinistaLevelPrefabs;
        }
    }

    #region Checkpoint Update

    //HÁ UM PROBLEMA USANDO ISTO!! Ao cruzar o checkpoint, apenas os prefabs subsequentes serãp atualizados
    //No caso, no meio da run, o jogador trocará de área, mas apenas 1 prefab depois irá mostrar isso visualmente
    //Não vou mexer nisso agora porque basta calcular bonitinho (ex.: colocar o checkpoint no meio do prefab atual) que
    //aí isso vai impactar pouco no jogador visualmente, fora que posso colocar um trecho seguro para ele recuperar o fôlego
    //antes de mudar de zona
    private void CowboyCheckpointUpdate(int checkpoint)
    {
        if (checkpoint == 1)
        {
            currentLevelPrefabs = cowboyLevelPrefabsB;
        }
        else if (checkpoint == 2)
        {
            currentLevelPrefabs = cowboyLevelPrefabsC;
        }
        else if (checkpoint == 3)
        {
            currentLevelPrefabs = cowboyLevelPrefabsD;
        }
    }

    #endregion

    public void DestroyLevelPrefab()
    {
        Destroy(lastPrefab);
    }

}
