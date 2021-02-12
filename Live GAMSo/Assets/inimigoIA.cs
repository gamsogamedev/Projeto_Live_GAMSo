using UnityEngine;
using Pathfinding;

public class inimigoIA : MonoBehaviour
{

    [SerializeField]
    float velocidade = 10f;

    [SerializeField]
    Transform alvo;

    [SerializeField]
    float dProxPonto = 3f;

    [SerializeField]
    float freqUpdate = .5f;

    [SerializeField]
    Seeker seeker;

    [SerializeField]
    Rigidbody2D rb2d;

    Path path;
    int pontoAtual = 0;
    bool acabouCaminho = false;

    Vector2 direcao;
    float distancia;


    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();

        InvokeRepeating("AtualizarCaminho", 0f, freqUpdate);
    }

    void AtualizarCaminho()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(rb2d.position, alvo.position, OnFimCaminho);
        }
    }

    void OnFimCaminho(Path p)
    {
        if(!p.error)
        {
            path = p;
            pontoAtual = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }

        if(pontoAtual >= path.vectorPath.Count)
        {
            acabouCaminho = true;
            return;
        }
        else
        {
            acabouCaminho = false;
        }

        direcao = ((Vector2)path.vectorPath[pontoAtual] - rb2d.position).normalized;

        rb2d.velocity = direcao * velocidade;

        distancia = Vector2.Distance(rb2d.position, path.vectorPath[pontoAtual]);

        if (distancia < dProxPonto)
        {
            pontoAtual++;
        }


    }
}
