using BehaviourTree;

public class SummonerBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 15f;

    protected override Node SetupTree()
    {
        Node root = new TaskPatrol(transform, waypoints);

        return root;
    }
}
