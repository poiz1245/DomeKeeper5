using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aoiti.Pathfinding; // ��� Ž�� ���̺귯���� ������

public class MovementController2D : MonoBehaviour
{
    [Header("Navigator options")]
    [SerializeField] float gridSize = 0.5f; // �׸��� ũ�� ����, ū ���� ���� Patience�� gridSize�� �ø� �� ����
    [SerializeField] float speed = 0.05f; // ������ �ӵ� ����, �� ���� �̵��� ���� ���� ������ų �� ����

    Pathfinder<Vector2> pathfinder; // ��� Ž�� �޼���� Patience�� �����ϴ� Pathfinder ��ü
    [Tooltip("Navigator�� ����� �� ���� ���̾��")]
    [SerializeField] LayerMask obstacles;
    [Tooltip("������ ������ ������ ������ �׺�����Ͱ� �׸��� �������� �����̵��� ��Ȱ��ȭ. ��δ� ª�������� �߰����� Physics2D.LineCast�� �ʿ���")]
    [SerializeField] bool searchShortcut = false;
    [Tooltip("���� ����� �׸��� ���� ������ ���ߵ��� �׺�����͸� �����մϴ�.")]
    [SerializeField] bool snapToGrid = false;
    Vector2 targetNode; // 2D ���������� ��ǥ
    List<Vector2> path;
    List<Vector2> pathLeftToGo = new List<Vector2>();
    [SerializeField] bool drawDebugLines;

    // ù ��° ������ ���� ȣ��Ǵ� �Լ�
    void Start()
    {
        pathfinder = new Pathfinder<Vector2>(GetDistance, GetNeighbourNodes, 1000); // ū ���� ���� Patience�� gridSize�� �ø� �� ����
    }

    // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) // ���ο� ��ǥ�� Ȯ���ϴ� �κ�
        {
            GetMoveCommand(new Vector2 (-0.5f, -11.0f));
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            CircleCollider2D circleColl = GetComponent<CircleCollider2D>();
            circleColl.enabled = false;
            
        }

        if (pathLeftToGo.Count > 0) // ��ǥ�� �������� �ʾ��� ��
        {
            Vector3 dir = (Vector3)pathLeftToGo[0] - transform.position;
            transform.position += dir.normalized * speed;
            if (((Vector2)transform.position - pathLeftToGo[0]).sqrMagnitude < speed * speed)
            {
                transform.position = pathLeftToGo[0];
                pathLeftToGo.RemoveAt(0);

                if (pathLeftToGo.Count == 0)
                {
                    Rigidbody2D rb = GetComponent<Rigidbody2D>();
                    rb.gravityScale = 2;
                    CircleCollider2D circleColl = GetComponent<CircleCollider2D>();
                    circleColl.enabled = true;
                }

            }
        }

        if (drawDebugLines)
        {
            for (int i = 0; i < pathLeftToGo.Count - 1; i++) // �ð�ȭ�� ���� ��θ� ȭ�鿡 ǥ��
            {
                Debug.DrawLine(pathLeftToGo[i], pathLeftToGo[i + 1]);
            }
        }
    }

    // ��ǥ�� �޾ƿͼ� ������ ����� �����ϴ� �Լ�
    void GetMoveCommand(Vector2 target)
    {
        Vector2 closestNode = GetClosestNode(transform.position);
        if (pathfinder.GenerateAstarPath(closestNode, GetClosestNode(target), out path)) // ���� ��ġ�� ��ǥ ��ġ �ֺ��� �׸��� ������ ��θ� ����
        {
            if (searchShortcut && path.Count > 0)
                pathLeftToGo = ShortenPath(path);
            else
            {
                pathLeftToGo = new List<Vector2>(path);
                if (!snapToGrid) pathLeftToGo.Add(target);
            }
        }
    }

    // ���� ����� �׸��� ���� ã�� �Լ�
    Vector2 GetClosestNode(Vector2 target)
    {
        return new Vector2(Mathf.Round(target.x / gridSize) * gridSize, Mathf.Round(target.y / gridSize) * gridSize);
    }

    // �Ÿ��� �ٻ�ȭ�ϴ� �Լ�
    float GetDistance(Vector2 A, Vector2 B)
    {
        return (A - B).sqrMagnitude; // CPU �ð��� �����ϱ� ���� ���� �Ÿ��� ���
    }

    // ������ ����� �� �Ÿ��� �׸��忡�� ã�� �Լ�
    Dictionary<Vector2, float> GetNeighbourNodes(Vector2 pos)
    {
        Dictionary<Vector2, float> neighbours = new Dictionary<Vector2, float>();
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (i == 0 && j == 0) continue;

                Vector2 dir = new Vector2(i, j) * gridSize;
                if (!Physics2D.Linecast(pos, pos + dir, obstacles))
                {
                    neighbours.Add(GetClosestNode(pos + dir), dir.magnitude);
                }
            }
        }
        return neighbours;
    }

    // ��θ� ª�� ����� �Լ�
    List<Vector2> ShortenPath(List<Vector2> path)
    {
        List<Vector2> newPath = new List<Vector2>();

        for (int i = 0; i < path.Count; i++)
        {
            newPath.Add(path[i]);
            for (int j = path.Count - 1; j > i; j--)
            {
                if (!Physics2D.Linecast(path[i], path[j], obstacles))
                {
                    i = j;
                    break;
                }
            }
            newPath.Add(path[i]);
        }
        newPath.Add(path[path.Count - 1]);
        return newPath;
    }
}