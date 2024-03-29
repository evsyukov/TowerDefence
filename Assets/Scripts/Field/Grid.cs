using System.Collections.Generic;
using UnityEngine;

namespace Field
{
    public class Grid {
        private Node[,] m_Nodes;
        private int m_Width;
        private int m_Height;

        private Vector2Int m_StartCoordinate;
        private Vector2Int m_TargetCoordinate;

        private Node m_SelectedNode = null;

        private FlowFieldPathfinding m_pathfinding;

        public int Width => m_Width;
        public int Height => m_Height;


        public Grid(int width,
                    int height,
                    Vector3 offset,
                    float nodeSize,
                    Vector2Int start,
                    Vector2Int target) {
            m_Width = width;
            m_Height = height;

            m_StartCoordinate = start;
            m_TargetCoordinate = target;

            m_Nodes = new Node[m_Width, m_Height];
            for(int i = 0; i < m_Nodes.GetLength(0); i++) {
                for(int j = 0; j < m_Nodes.GetLength(1); j++) {
                    m_Nodes[i, j] = new Node(new Vector3(i + 0.5f, 0, j + 0.5f) * nodeSize + offset);
                }
            }

            m_pathfinding = new FlowFieldPathfinding(this, target);
            m_pathfinding.UpdateField();
        }

        public Node GetStartNode() {
            return GetNode(m_StartCoordinate);
        }

        public Node GetTargetNode() {
            return GetNode(m_TargetCoordinate);
        }

        public void SelectCoordinate(Vector2Int coordinate) {
            m_SelectedNode = GetNode(coordinate);
        }

        public void UnselectNode() {
            m_SelectedNode = null;
        }

        public bool HasSelectedNode() {
            return m_SelectedNode != null;
        }

        public Node GetSelectedNode() {
            return m_SelectedNode;
        }

        public Node GetNode(Vector2Int coordinate) {
            return GetNode(coordinate.x, coordinate.y);
        }

        public Node GetNode(int i, int j) {
            if(i < 0 || i >= m_Width || j < 0 || j >= m_Height) {
                return null;
            }

            return m_Nodes[i, j];
        }

        public IEnumerable<Node> EnumerateAllnodes() {
            for(int i = 0; i < m_Width; i++) {
                for(int j = 0; j < m_Height; j++) {
                    yield return GetNode(i, j);
                }
            }
        }

        public void UpdatePathfinding() {
            m_pathfinding.UpdateField();
        }

        
    }
}
