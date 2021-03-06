using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding2D : MonoBehaviour
{

	Grid2D grid;
	Node2D seekerNode, targetNode;

	void Start()
	{
		//assign member variables
		grid = GameObject.Find("GridOwner").GetComponent<Grid2D>();
	}

	public List<Node2D> GetPath()
	{
		return grid.path;
	}

	public void FindPath(GameObject seeker, Vector3 targetPos)
	{

		grid.path = null;

		Vector3 seekerPos = seeker.transform.position;

		//get grid coords of seeker and target
		seekerNode = grid.NodeFromWorldPoint(seekerPos);
		targetNode = grid.NodeFromWorldPoint(targetPos);

		List<Node2D> openSet = new List<Node2D>();
		HashSet<Node2D> closedSet = new HashSet<Node2D>();
		openSet.Add(seekerNode);
		
		//calculates path for pathfinding
		while (openSet.Count > 0)
		{

			//iterates through openSet and finds lowest FCost
			Node2D node = openSet[0];
			for (int i = 1; i < openSet.Count; i++)
			{
				if (openSet[i].FCost <= node.FCost)
				{
					if (openSet[i].hCost < node.hCost)
						node = openSet[i];
				}
			}

			openSet.Remove(node);
			closedSet.Add(node);

			//If target found, retrace path
			if (node == targetNode)
			{
				RetracePath(seekerNode, targetNode);
				return;
			}
			
			//adds neighbor nodes to openSet
			foreach (Node2D neighbour in grid.GetNeighbors(node))
			{
				//if true, ignore that node
				if (neighbour.obstacle || closedSet.Contains(neighbour) ||
					(seeker.CompareTag("PantsAI") && neighbour.worldPosition == GameObject.FindGameObjectWithTag("Pants").transform.position) ||
					(seeker.CompareTag("FireAI") && neighbour.worldPosition == GameObject.FindGameObjectWithTag("Fire").transform.position) ||
					(seeker.CompareTag("AnvilAI") && neighbour.worldPosition == GameObject.FindGameObjectWithTag("Anvil").transform.position) ||
					(neighbour.worldPosition == GameObject.FindGameObjectWithTag("PantsAI").transform.position) ||
					(neighbour.worldPosition == GameObject.FindGameObjectWithTag("FireAI").transform.position) ||
					(neighbour.worldPosition == GameObject.FindGameObjectWithTag("AnvilAI").transform.position))
				{
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
				{
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = node;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
	}

	//reverses calculated path so first node is closest to seeker
	void RetracePath(Node2D startNode, Node2D endNode)
	{
		List<Node2D> path = new List<Node2D>();
		Node2D currentNode = endNode;

		while (currentNode != startNode)
		{
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		path.Reverse();

		grid.path = path;

	}

	//gets distance between 2 nodes for calculating cost
	int GetDistance(Node2D nodeA, Node2D nodeB)
	{
		int dstX = Mathf.Abs(nodeA.GridX - nodeB.GridX);
		int dstY = Mathf.Abs(nodeA.GridY - nodeB.GridY);

		if (dstX > dstY)
			return 14 * dstY + 10 * (dstX - dstY);
		return 14 * dstX + 10 * (dstY - dstX);
	}
}