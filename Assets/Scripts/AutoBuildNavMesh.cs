using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace TopDownShooter
{
public class AutoBuildNavMesh : MonoBehaviour
{
   [SerializeField] private NavMeshSurface m_surface;

private void Start()
{
    m_surface.BuildNavMesh();
}
}
}