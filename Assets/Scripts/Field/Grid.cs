using System.Collections.Generic;
using UnityEngine;

namespace Field
{
    public class Grid {
        private Node[,] m_Nodes;
        private int m_Width;
        private int m_Height;

        private FlowFieldPathfinding m_pathfinding;


        public int Width => m_Width;
        public int Height => m_Height;


        public Grid(int width,
                    int height,
                    Vector3 offset,
                    float nodeSize,
                    Vector2Int m_Target) {
            m_Width = width;
            m_Height = height;

            m_Nodes = new Node[m_Width, m_Height];
            for(int i = 0; i < m_Nodes.GetLength(0); i++) {
                for(int j = 0; j < m_Nodes.GetLength(1); j++) {
                    // float x = nodeSize * i + nodeSize * 05.f + offset.x;
                    // float y = nodeSize * j + nodeSize * 05.f + offset.z;
                    // Vector3 position = new Vector3(x,0,y);
                    // m_Nodes[i, j] = new Node(position);
                    m_Nodes[i, j] = new Node(new Vector3(i + 0.5f, 0, j + 0.5f) * nodeSize + offset);
                }
            }

            m_pathfinding = new FlowFieldPathfinding(this, m_Target);
            m_pathfinding.UpdateField();
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
