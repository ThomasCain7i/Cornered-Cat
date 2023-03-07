using BehaviourTree;

public class SummonerBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;

    protected override Node SetupTree()
    {
        Node root = new TaskPatrol(transform, waypoints);

        return root;
    }
}